using configuratore.statoCassette;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static configuratore.datiCassette;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace configuratore
{
    public partial class frmMasterNetwork : Form
    {
        int parametroDaRichiedere;
        frmStartUp parent;
        int erroreRete;
        Label dragLabel;
        int dragRow;
        DataTable tblMirror;
        Boolean masterRunning;

        clsRxBuffer rxBuffer;
        int resetRete = 0;
        // la prima volta che si apre la videata resetRete==0
        // i dati vengono letti dalla lista NetList del Master che contiene già chi è principale e chi non
        // questa viene mesa a 1 non appena si fa ResetRete o Aggiorna Rete

        static sCampiTabella[] campiTabellaMirror =
       {
            new sCampiTabella() {NameField="MATRICOLA",TypeField="System.String" ,primaryKey=1 },
            new sCampiTabella() {NameField="DISPOSITIVO",TypeField="System.String" ,primaryKey=1 },
            new sCampiTabella() {NameField="CODICE",TypeField="System.Int32" ,primaryKey=1 },
            new sCampiTabella() {NameField="INDIRIZZO",TypeField="System.String" ,primaryKey=1 },
            new sCampiTabella() {NameField="PRINCIPALE",TypeField="System.Int32" ,primaryKey=1 },

        };
        public frmMasterNetwork(String Type, String Info, frmStartUp lparent, Boolean DefaultData)
        {
            InitializeComponent();
            setLangage();
            InitData();
            parametroDaRichiedere = 0;
            this.Text = Type + Info;
            parent = lparent;
            initDataTable();
            picPleaseWait.Visible = true;
            rxBuffer = new clsRxBuffer();
            timerTick.Enabled = true;
            masterRunning = true;
        }

        public byte[] getRxBuffr() { return rxBuffer.getRxBuffer(); }
        public clsRxBuffer getRxBufferClass() { return rxBuffer; }
        void add2Mirror(DataGridView dgv)
        {
            tblMirror.Rows.Clear();
            for (int r = 0; r < dgv.RowCount; r++)
            {
                tblMirror.Rows.Add();
                tblMirror.Rows[r]["MATRICOLA"] = dgv.Rows[r].Cells["MATRICOLA"].Value;
                tblMirror.Rows[r]["DISPOSITIVO"] = dgv.Rows[r].Cells["DISPOSITIVO"].Value;
                tblMirror.Rows[r]["INDIRIZZO"] = dgv.Rows[r].Cells["INDIRIZZO"].Value;
                tblMirror.Rows[r]["CODICE"] = Convert.ToInt32(dgv.Rows[r].Cells["CODICE"].Value);
                tblMirror.Rows[r]["PRINCIPALE"] = Convert.ToInt32(dgv.Rows[r].Cells["FLAGPRINCIPALE"].Value);
            }
        }

        Boolean isChanged(DataGridView dgv)
        {
            Boolean flg = false;
            if (dgv.RowCount != tblMirror.Rows.Count)
                flg = true;
            else
            {
                for (int r = 0; r < dgv.RowCount; r++)
                {

                    if (tblMirror.Rows[r]["MATRICOLA"] != dgv.Rows[r].Cells["MATRICOLA"].Value) flg = true;
                    if (tblMirror.Rows[r]["DISPOSITIVO"] != dgv.Rows[r].Cells["DISPOSITIVO"].Value) flg = true;
                    if (tblMirror.Rows[r]["INDIRIZZO"] != dgv.Rows[r].Cells["INDIRIZZO"].Value.ToString()) flg = true;
                    if (Convert.ToInt32(tblMirror.Rows[r]["CODICE"]) != Convert.ToInt32(dgv.Rows[r].Cells["CODICE"].Value)) flg = true;
                    if (Convert.ToInt32(tblMirror.Rows[r]["PRINCIPALE"]) != Convert.ToInt32(dgv.Rows[r].Cells["FLAGPRINCIPALE"].Value)) flg = true;

                }
            }
            return flg;
        }

        void initDataTable()
        {
            tblMirror = new DataTable();
            int c;
            for (c = 0; c < campiTabellaMirror.Count(); c++)
            {
                DataColumn column;
                column = new DataColumn();
                column.DataType = System.Type.GetType(campiTabellaMirror[c].TypeField);
                column.ColumnName = campiTabellaMirror[c].NameField;
                tblMirror.Columns.Add(column);
            }
        }

        void InitData()
        {
            dataGridDevices.Rows.Clear();
            btnExit.Enabled = true;
            btnResetRete.Enabled = true;
            btnSalvaRete.Enabled = false;
            btnAggiornaRete.Enabled = false;
        }
        public void setLangage()
        {
            DISPOSITIVO.HeaderText = loca.getStr(loca.indice.MNET_H_DISPOSITIVO);
            INDIRIZZO.HeaderText = loca.getStr(loca.indice.MNET_H_INDIRIZZO);
            MATRICOLA.HeaderText = loca.getStr(loca.indice.MNET_H_MATRICOLA);
            STATO.HeaderText = loca.getStr(loca.indice.MNET_H_STATO);
            VERSIONE.HeaderText = loca.getStr(loca.indice.MNET_H_SW_RELEASE);

            btnResetRete.Text = loca.getStr(loca.indice.MNET_B_RESET);
            btnAggiornaRete.Text = loca.getStr(loca.indice.MNET_B_UPDATE);
            btnSalvaRete.Text = loca.getStr(loca.indice.MNET_B_FIX);
            btnExit.Text = loca.getStr(loca.indice.MNET_B_ESCI);

            btnRestartMaster.Text = loca.getStr(loca.indice.MNET_MSG_RESTART);
        }

        void getNetworkInfo()
        {
            // richiede informazioni sulla rete da 
            // txMsg.requireParameter(parametroDaRichiedere, Costanti.BITS_DEVICE_MASTER | Costanti.BITS_VIDEATA_NETWORK);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (isChanged(dataGridDevices))
            {
                var resp = MessageBox.Show(loca.getStr(loca.indice.MNET_MSG_DNOTSAVED), loca.getStr(loca.indice.MNET_MSG_WARNING), MessageBoxButtons.YesNo);
                if (resp == DialogResult.Yes)
                {
                    txMsg.restartMaster();
                    System.Threading.Thread.Sleep(500);
                    parent.abilitaMenu();
                    masterRunning = true;
                    this.Close();
                }

            }
            else
            {
                txMsg.restartMaster();
                System.Threading.Thread.Sleep(500);
                parent.abilitaMenu();
                masterRunning = true;
                this.Close();
            }
        }

        private void frmMasterNetwork_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            dataGridDevices.Rows.Clear();
            for (int i = 0; i < 10; i++)
                Application.DoEvents();
            txMsg.requireNetworkInfo();
            timerRicezione.Enabled = true;
            btnRestartMaster.Enabled = false;
            btnResetRete.Enabled = false;
            picPleaseWait.Top = dataGridDevices.Top;
            picPleaseWait.Left = dataGridDevices.Left;
        }

        private void btnRescan_Click(object sender, EventArgs e)
        {
            // spedisce il comando per resettare la rete e far partire lo scanning
            //   String j = "{ \"netList\": [ { \"m\": \"00001\", \"t\" : 0, \"s\" : 0 }  ] }";
            setIconsToStop();
            timerRicezione.Enabled = true;
            txMsg.rescanNetork();
            btnResetRete.Enabled = false;
            btnAggiornaRete.Enabled = false;
            btnSalvaRete.Enabled = false;
            btnRestartMaster.Enabled = false;
            erroreRete = 0;
            dataGridDevices.Rows.Clear();
            picPleaseWait.Visible = true;
            masterRunning = false;
            resetRete = 1;

        }

        void setIconsToStop()
        {
            int r;
            for (r = 0; r < dataGridDevices.Rows.Count; r++)
                dataGridDevices.Rows[r].Cells["CONNECT"].Value = global::configuratoreSerial6._0.Resource1.stop;
        }

        void setIconsToConnect()
        {
            int r;
            for (r = 0; r < dataGridDevices.Rows.Count; r++)
                dataGridDevices.Rows[r].Cells["CONNECT"].Value = global::configuratoreSerial6._0.Resource1.Connetti;
        }

        private void btnAggiornaRete_Click(object sender, EventArgs e)
        {
            timerRicezione.Enabled = true;
            txMsg.aggiornaRete();
            btnResetRete.Enabled = false;
            btnAggiornaRete.Enabled = false;
            btnSalvaRete.Enabled = false;
            erroreRete = 0;
            picPleaseWait.Visible = true;
            masterRunning = false;
            resetRete = 1;
        }

        private void timerRicezione_Tick(object sender, EventArgs e)
        {
            int d;

            if (clsArbitrator.isriabilitaBottoni())
            {
                clsArbitrator.clrriabilitaBottoni();
                riabilitaBottoni();
            }
            d = clsSerial.pop(Costanti.BIT_IM_MASTER);
            if (d >= 0)
            {
                byte b = (byte)(d & 0xff);
                // qui decodifica la stringa
                int x = clsHandler.decodifica(b, this.getRxBufferClass());
                if (x >= 0)
                {
                    // controlla messaggistica
                    picPleaseWait.Visible = false;
                    btnResetRete.Enabled = true;

                    // stringa terminata
                    String Json = convert2Json(getRxBuffr());
                    JsonNetlist miaRete = new JsonNetlist();
                    switch (miaRete.decodeNET(Json))
                    {
                        case Costanti.NETLIST:
                            dataGridDevices.Rows.Clear();
                            for (int i = 0; i < miaRete.getNumOfNodi(); i++)
                            {
                                dataGridDevices.Rows.Add();
                                dataGridDevices.Rows[i].Cells["MATRICOLA"].Value = miaRete.getMatricola(i);
                                dataGridDevices.Rows[i].Cells["DISPOSITIVO"].Value = Costanti.getNomeDispositivo(miaRete.getTipo(i), miaRete.getSubType(i));
                                dataGridDevices.Rows[i].Cells["STATO"].Value = miaRete.getStato(i);
                                if (masterRunning)
                                    dataGridDevices.Rows[i].Cells["CONNECT"].Value = global::configuratoreSerial6._0.Resource1.Connetti;
                                else
                                    dataGridDevices.Rows[i].Cells["CONNECT"].Value = global::configuratoreSerial6._0.Resource1.stop;
                                dataGridDevices.Rows[i].Cells["CODICE"].Value = miaRete.getTipo(i);
                                dataGridDevices.Rows[i].Cells["SUBTYPE"].Value = miaRete.getSubType(i);
                                dataGridDevices.Rows[i].Cells["VERSIONE"].Value = miaRete.getSwVersione(i);

                                if (miaRete.getStato(i) != 0 || miaRete.getErrore() != 0)
                                    erroreRete = -1;
                                if (miaRete.getIndirizzo(i) <= 0)
                                {
                                    // indirizzo non assegnato
                                    if (i == 0)
                                        dataGridDevices.Rows[i].Cells["INDIRIZZO"].Value = "MASTER";
                                    else
                                        dataGridDevices.Rows[i].Cells["INDIRIZZO"].Value = i;
                                }
                                else
                                {
                                    int xy = miaRete.getIndirizzo(i);
                                    if (xy == 0)
                                        dataGridDevices.Rows[i].Cells["INDIRIZZO"].Value = "MASTER";
                                    else
                                        dataGridDevices.Rows[i].Cells["INDIRIZZO"].Value = xy;
                                }
                                if (resetRete == 1)
                                {
                                    // è stato eseguito un RESET
                                    // nel caso di RESET tutti i fancoil/cassette non sono principali
                                    if (Costanti.isCassetteOrFancoil(miaRete.getTipo(i)))
                                    {
                                        dataGridDevices.Rows[i].Cells["PRINCIPALE"].Value = global::configuratoreSerial6._0.Resource1.PrincipaleOFF;
                                        dataGridDevices.Rows[i].Cells["FLAGPRINCIPALE"].Value = 0;
                                    }
                                    else
                                    {
                                        dataGridDevices.Rows[i].Cells["PRINCIPALE"].Value = global::configuratoreSerial6._0.Resource1.PrincipaleNEUTRO;
                                        dataGridDevices.Rows[i].Cells["FLAGPRINCIPALE"].Value = -1;
                                    }
                                }
                                else
                                {
                                    // la rete viene letta da quella slavata in flash
                                    if (Costanti.isCassetteOrFancoil(miaRete.getTipo(i)))
                                    {
                                        // cassetta o fancoil
                                        if (miaRete.getPrincipale(i) == 0)
                                        {
                                            dataGridDevices.Rows[i].Cells["PRINCIPALE"].Value = global::configuratoreSerial6._0.Resource1.PrincipaleOFF;
                                            dataGridDevices.Rows[i].Cells["FLAGPRINCIPALE"].Value = 0;
                                        }
                                        else
                                        {
                                            dataGridDevices.Rows[i].Cells["PRINCIPALE"].Value = global::configuratoreSerial6._0.Resource1.PrincipaleON;
                                            dataGridDevices.Rows[i].Cells["FLAGPRINCIPALE"].Value = 1;
                                        }
                                    }
                                    else
                                    {
                                        dataGridDevices.Rows[i].Cells["PRINCIPALE"].Value = global::configuratoreSerial6._0.Resource1.PrincipaleNEUTRO;
                                        dataGridDevices.Rows[i].Cells["FLAGPRINCIPALE"].Value = -1;
                                    }

                                }
                            }

                            if (resetRete == 1 || tblMirror.Rows.Count == 0)
                            {
                                add2Mirror(dataGridDevices);
                                btnSalvaRete.Enabled = false;
                            }
                            else
                            {
                                if (erroreRete != 0)
                                    btnAggiornaRete.Enabled = true;
                                else
                                    btnSalvaRete.Enabled = true;
                            }
                            btnResetRete.Enabled = true;

                            if (erroreRete != 0)
                            {
                                string message = loca.getStr(loca.indice.MNET_MSG_ERROR_2);
                                string title = loca.getStr(loca.indice.MNET_MSG_ERROR);
                                MessageBox.Show(message, title);
                            }
                            else
                                btnRestartMaster.Enabled = true;
                            break;
                        case Costanti.NETSTATUS:

                            {
                                for (int r = 0; r < dataGridDevices.Rows.Count; r++)
                                {
                                    int xs = miaRete.getNetStatus(r);
                                    if (xs >= 0)
                                    {
                                        dataGridDevices.Rows[r].Cells["STATO"].Value = xs;
                                    }
                                }
                            }
                            break;
                    }

                }

            }
            // handelrData
        }

        private String convert2Json(byte[] buffer)
        {
            String xx = "";
            int i;
            int j;
            for (j = 0; buffer[j] != 0xf7; j++) ;
            j = j - 2;
            for (i = 3; i < j; i++)
            {
                xx = xx + (char)buffer[i];
            }
            return xx;
        }

        private void dataGridDevices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String name = dataGridDevices.Columns[e.ColumnIndex].Name;
            int riga = e.RowIndex;
            if (riga >= 0) {
                switch (name)
                {
                    case "CONNECT":
                        // disabilita tutti i controlli della scheda
                        // dataGridDevices.Enabled = false;
                        if (!masterRunning)  // master NON in RUN
                        {
                            string message = loca.getStr(loca.indice.MNET_MSG_RESATART);
                            string title = loca.getStr(loca.indice.MNET_MSG_ERROR);
                            MessageBox.Show(message, title);
                        }
                        else
                        {
                            int device = Convert.ToInt32(dataGridDevices.Rows[riga].Cells["CODICE"].Value) & 0x07;
                            // inserisce nel parametro RICHIESTA_DA_MASTER l'indirizzo del dispositivo
                            int richiestoDa;
                            String matricola = dataGridDevices.Rows[riga].Cells["MATRICOLA"].Value?.ToString();
                            if (dataGridDevices.Rows[riga].Cells["INDIRIZZO"].Value.ToString() == "MASTER")
                                richiestoDa = Costanti.RICHIESTA_DA_MASTER;
                            else
                                richiestoDa = Costanti.RICHIESTA_DA_MASTER | Convert.ToInt32(dataGridDevices.Rows[riga].Cells["INDIRIZZO"].Value);
                            disabilitaBottoni();
                            String relese = dataGridDevices.Rows[riga].Cells["VERSIONE"].Value.ToString();
                            parent.openFromRemote(device, true, richiestoDa, matricola, relese);
                            // frmCassette fcassette = new frmCassette("CASSETTE: ", clsMsg.getInfoMsg(), this, false); // String Type, String Info, frmStartUp lparent, Boolean DefaultData
                        }
                        break;
                    case "PRINCIPALE":
                        if (Convert.ToInt32(dataGridDevices.Rows[riga].Cells["FLAGPRINCIPALE"].Value) == 0)
                        {
                            // mette tutti gli altri a zero
                            for (int i = 0; i < dataGridDevices.RowCount; i++)
                            {
                                if (Costanti.isCassetteOrFancoil(Convert.ToInt32(dataGridDevices.Rows[i].Cells["CODICE"].Value)))
                                {
                                    if (i != riga)
                                    {
                                        dataGridDevices.Rows[i].Cells["PRINCIPALE"].Value = global::configuratoreSerial6._0.Resource1.PrincipaleOFF;
                                        dataGridDevices.Rows[i].Cells["FLAGPRINCIPALE"].Value = 0;
                                    }
                                    else
                                    {
                                        dataGridDevices.Rows[riga].Cells["FLAGPRINCIPALE"].Value = 1;
                                        dataGridDevices.Rows[riga].Cells["PRINCIPALE"].Value = global::configuratoreSerial6._0.Resource1.PrincipaleON;
                                    }
                                }
                                else
                                {
                                    dataGridDevices.Rows[i].Cells["PRINCIPALE"].Value = global::configuratoreSerial6._0.Resource1.PrincipaleNEUTRO;
                                    dataGridDevices.Rows[i].Cells["FLAGPRINCIPALE"].Value = -1;
                                }
                            }
                        }
                        break;
                        // apre la videata in base al dispositivo selezionato
                }

            }
        }

        Boolean[] btnStatus = new Boolean[5];
        public void disabilitaBottoni()
        {
            btnStatus[0] = btnResetRete.Enabled;
            btnStatus[1] = btnAggiornaRete.Enabled;
            btnStatus[2] = btnSalvaRete.Enabled;
            btnStatus[3] = btnRestartMaster.Enabled;
            btnStatus[4] = btnExit.Enabled;

            btnResetRete.Enabled = false;
            btnAggiornaRete.Enabled = false;

            btnSalvaRete.Enabled = false;
            btnRestartMaster.Enabled = false;
            btnExit.Enabled = false;
            dataGridDevices.Enabled = false;
            for (int i = 0; i < dataGridDevices.Rows.Count; i++)
            {
                dataGridDevices.Rows[i].Cells["CONNECT"].Value = global::configuratoreSerial6._0.Resource1.stop;
            }
        }

        public void riabilitaBottoni()
        {
            btnResetRete.Enabled = btnStatus[0];
            btnAggiornaRete.Enabled = btnStatus[1];
            btnSalvaRete.Enabled = btnStatus[2];
            btnRestartMaster.Enabled = btnStatus[3];
            btnExit.Enabled = btnStatus[4];
            dataGridDevices.Enabled = true;
            for (int i = 0; i < dataGridDevices.Rows.Count; i++)
            {
                dataGridDevices.Rows[i].Cells["CONNECT"].Value = global::configuratoreSerial6._0.Resource1.Connetti;
            }
        }

        // ----------- GESTIONE DRAG and DROP

        int currRiga = 0;
        void selezDeselezRiga(int r, int selDesel)
        {
            if (r >= 0)
            {

                for (int c = 0; c < dataGridDevices.ColumnCount; c++)
                {
                    if (selDesel == 1)
                    {
                        dataGridDevices[c, r].Style.BackColor = Color.Yellow;
                        currRiga = r;
                    }
                    else
                    {
                        dataGridDevices[c, r].Style.BackColor = Color.White;
                    }
                }
            }
        }

        void deselectAll()
        {
            for (int r = 0; r < dataGridDevices.RowCount; r++)
                selezDeselezRiga(r, 0);
        }

        private void dataGridDevices_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && dragLabel != null)
            {
                //dragLabel.Parent = dataGridDevices;
                //dragLabel.Location = e.Location;
                dataGridDevices.ClearSelection();
                int r = e.RowIndex;
                int c = e.ColumnIndex;


                var cellRectangle = dataGridDevices.GetCellDisplayRectangle(c, r, true);
                // Can create Points using the Rectangle if you want.
                Point lblp = new Point(cellRectangle.Left + e.Location.X + 10, cellRectangle.Top + e.Location.Y - 10);

                dragLabel.Location = lblp;

                if (r != currRiga)
                {
                    selezDeselezRiga(currRiga, 0);
                    selezDeselezRiga(r, 1);
                }

            }
        }

        private void dataGridDevices_MouseUp(object sender, MouseEventArgs e)
        {
            if (dragLabel != null)
            {
                var hit = dataGridDevices.HitTest(e.X, e.Y);
                int dropRow = -1;
                if (hit.Type != DataGridViewHitTestType.None)
                {
                    dropRow = hit.RowIndex;
                    if (dragRow >= 0)
                    {
                        int tgtRow = dropRow + (dragRow > dropRow ? 1 : 0);
                        if (tgtRow != dragRow)
                        {
                            DataGridViewRow row = dataGridDevices.Rows[dragRow];
                            dataGridDevices.Rows.Remove(row);
                            dataGridDevices.Rows.Insert(tgtRow, row);

                            dataGridDevices.ClearSelection();
                            row.Selected = true;
                        }
                    }
                }
                else { dataGridDevices.Rows[dragRow].Selected = true; }
                if (dragLabel != null)
                {
                    dragLabel.Dispose();
                    dragLabel = null;
                }
                // rigenera indirizzi rete
                for (int i = 0; i < dataGridDevices.Rows.Count; i++)
                {
                    if (i == 0)
                        dataGridDevices.Rows[i].Cells["INDIRIZZO"].Value = "MASTER";
                    else
                        dataGridDevices.Rows[i].Cells["INDIRIZZO"].Value = i;
                }
            }
            deselectAll();
            currRiga = -1;
            enableSalva();
        }

        private void dataGridDevices_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (e.ColumnIndex == 0)
            {
                dragRow = e.RowIndex;
                if (dragRow != 0)
                {
                    if (dragLabel == null)
                    {
                        dragLabel = new Label();
                        dragLabel.Width = 100;
                        dragLabel.Height = 50;
                    }

                    dragLabel.Text = loca.getStr(loca.indice.MNET_H_MATRICOLA) + ": " + dataGridDevices["MATRICOLA", e.RowIndex].Value.ToString() + "\n\r" + loca.getStr(loca.indice.MNET_H_INDIRIZZO) + ": " + dataGridDevices["INDIRIZZO", e.RowIndex].Value.ToString();
                    dragLabel.Parent = dataGridDevices;
                    dragLabel.Location = e.Location;
                    selezDeselezRiga(e.RowIndex, 1);

                }
                else
                {
                    MessageBox.Show(loca.getStr(loca.indice.MNET_MSG_ERROR_1), loca.getStr(loca.indice.MNET_MSG_ERROR), MessageBoxButtons.OK);
                }
            }
        }

        private void btnSalvaRete_Click(object sender, EventArgs e)
        {
            // controlla che ci sia almeno un MASTER
            int p = -1;
            // vede se c'è un solo dispositivo
            if (dataGridDevices.RowCount == 1)
            {
                p = 1;
            }
            else
            {

                for (int i = 0; i < dataGridDevices.RowCount && p < 0; i++)
                {
                    if (Convert.ToInt32(dataGridDevices.Rows[i].Cells["FLAGPRINCIPALE"].Value) == 1)
                    {
                        p = 1;
                    }
                }
            }
            if (p <= 0)
            {
                var resp = MessageBox.Show(loca.getStr(loca.indice.MNET_MSG_NO_PRINCIPALE), loca.getStr(loca.indice.MNET_MSG_ERROR), MessageBoxButtons.OK);

            }
            else
            {
                // crea un stringa JSON con i dati e la spedisce al MASTER
                picPleaseWait.Visible = true;
                JsonNetlist miaRete = new JsonNetlist();
                String jsonSTR = miaRete.encodeNET(dataGridDevices);
                txMsg.storeNetork(jsonSTR);

                add2Mirror(dataGridDevices);
                Fintosave.Interval = 1500 * dataGridDevices.RowCount;
                Fintosave.Enabled = true;
            }
        }


        void fintaFineSalvataggio()
        {
            picPleaseWait.Visible = false;
            MessageBox.Show(loca.getStr(loca.indice.MNET_MSG_SAVED), loca.getStr(loca.indice.MNET_MSG_INFO), MessageBoxButtons.OK);
            btnSalvaRete.Enabled = false;
        }

        private void btnRestartMaster_Click(object sender, EventArgs e)
        {
            // txMsg.restartMaster();
            timerDelay.Enabled = true;
            masterRunning = true;
            setIconsToConnect();
        }

        void enableSalva()
        {
            if (isChanged(dataGridDevices))
                btnSalvaRete.Enabled = true;
            else
                btnSalvaRete.Enabled = false;
        }

        private void Fintosave_Tick(object sender, EventArgs e)
        {
            Fintosave.Enabled = false;
            fintaFineSalvataggio();
        }

        private void timerTick_Tick(object sender, EventArgs e)
        {
            if (!clsSerial.serialPortIsOpen())
            {
                timerTick.Enabled = false;
                this.Close();
                clsSerial.USBerrorRestart();
            }
           
        }

        private void timerDelay_Tick(object sender, EventArgs e)
        {
            txMsg.restartMaster();
            timerDelay.Enabled = false;
        }
    }
}
