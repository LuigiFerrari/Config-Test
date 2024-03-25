using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Net.Sockets;
using System.Threading;
using System.Configuration;
using System.IO.Ports;
using System.IO;
using static configuratore.Costanti;

namespace configuratore
{
    public partial class frmStartUp : Form
    {
        int oldConnected;
        int connectedStatus;

        int TimerConnessioneTimeout;

        String FileName = "";
        public clsRxBuffer rxBuffer;
        int vTimerDisconnetti = -1;

        public String Matricola;
        public int MasterSlave;
        public int IndirizzoMaster;
        public int rp = 0;
        public int rmb = 0;
        public int rn = 0;
        public int rma = 0;
        public int flgVerify;
        public frmStartUp()
        {
            InitializeComponent();
            dir.init();
            txMsg.initDati();
            datiConfig.Initdati();
            aggiornaLingua(datiConfig.getLinguaggio());

            startupData.setgfrmStartUp(this);
            rxBuffer = new clsRxBuffer();
            TimerConnessioneTimeout = -1;
        }

        public byte[] getRxBuffr() { return rxBuffer.getRxBuffer(); }

        public clsRxBuffer getRxBufferClass() { return rxBuffer; }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = global::configuratoreSerial6._0.Resource1.AppIcona;
            this.Text = "PARAMETER SETTING " + Versione.versioneStrForm(); ;

            this.MaximizeBox = false;


        }



        private void spedisciTCPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsSerial.initSerial();
            frmSerialPortSelect frmPort = new frmSerialPortSelect();
            frmPort.ShowDialog();

            if (frmPort.isSelectedOk())
            {

                connectedStatus = Costanti.CONNECTING;
                //gfrmPortselect.ShowDialog();
                //if (gfrmPortselect.getIndex() < 0)
                //    this.Close();
                //else
                //{
                //    serialPort = new SerialPort(comPorts[gfrmPortselect.getIndex()], 9600, Parity.None, 8, StopBits.One);;
                //    serialPort.DtrEnable = true;
                //    serialPort.DataReceived += SerialPortDataReceived;
                //    serialPort.Open();
                // timerConnessione.Enabled = true;



                TimerConnessioneTimeout = 100;


                //if (SocketClient.isConnected())
                //{
                //    disconnetti();
                //}
                //else
                //{
                //    backgroundThread = new Thread(new ThreadStart(SocketClient.StartClient));
                //    // Start thread  
                //    backgroundThread.Start();
                //    timerConnessione.Enabled = true;

                //}
                aggiornaLabelConnected();
                txMsg.requireInfo();
                flgVerify = 0;
            }
        }

        private void italianoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aggiornaLingua(loca.ITALIANO);
        }

        private void engllishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aggiornaLingua(loca.INGLESE);
        }

        void aggiornaLingua(int l)
        {
            datiConfig.setLinguaggio(l);
            loca.setLinguaggio(l);
            if (l == loca.INGLESE)
            {
                pictureBox1.Image = global::configuratoreSerial6._0.Resource1.uk;
            }
            if (l == loca.ITALIANO)
            {
                pictureBox1.Image = global::configuratoreSerial6._0.Resource1.italia;
            }



            aggiornaMenu();
            // oldConnected = -1;
            aggiornaLabelConnected();
        }

        void aggiornaMenu()
        {
            this.fileToolStripMenuItem.Text = loca.getStr(loca.indice.MENU_FILE);
            // 
            // apriToolStripMenuItem
            // 
            this.apriToolStripMenuItem.Text = loca.getStr(loca.indice.MENU__APRI);
            // 
            // nuovoToolStripMenuItem
            // 
            this.nuovoToolStripMenuItem.Text = loca.getStr(loca.indice.MENU_NUOVO);
            // 
            // salvaToolStripMenuItem
            // 
            this.salvaToolStripMenuItem.Text = loca.getStr(loca.indice.MENU_SALVA);
            // 
            // salvaComeToolStripMenuItem
            // 
            this.salvaComeToolStripMenuItem.Text = loca.getStr(loca.indice.MENU_SALVA_COME);
            // 
            // esciToolStripMenuItem
            // 
            this.esciToolStripMenuItem.Text = loca.getStr(loca.indice.MENU_ESCI);
            // 
            // cOMToolStripMenuItem
            // 
            this.cOMToolStripMenuItem.Text = loca.getStr(loca.indice.MENU_COM);
            // 
            // spedisciTCPToolStripMenuItem
            // 

            // deviceToolStripMenuItem
            // 

            // 
            // lingiaToolStripMenuItem
            // 
            this.lingiaToolStripMenuItem.Text = loca.getStr(loca.indice.MENU_LINGUA);
            // 
            // italianoToolStripMenuItem
            // 
            this.italianoToolStripMenuItem.Text = loca.getStr(loca.indice.MENU_ITALIANO);
            // 
            // engllishToolStripMenuItem
            // 
            this.engllishToolStripMenuItem.Text = loca.getStr(loca.indice.MENU_INGLESE);
            // 
        }

        void aggiornaLabelConnected()
        {
            switch (connectedStatus)
            {
                case Costanti.CONNECTING:
                    labelConnected.Text = loca.getStr(loca.indice.STR_CONNECTING);
                    pictureBoxConnected.Image = global::configuratoreSerial6._0.Resource1.arancioON;
                    break;
                case Costanti.UNCONNECTED:
                    labelConnected.Text = loca.getStr(loca.indice.LBL_UNCONNECTED);
                    pictureBoxConnected.Image = global::configuratoreSerial6._0.Resource1.verdeOFF;
                    break;
                case Costanti.CONNECTED:
                    labelConnected.Text = loca.getStr(loca.indice.LBL_CONNECTED);
                    pictureBoxConnected.Image = global::configuratoreSerial6._0.Resource1.verdeON;
                    break;
                case Costanti.DISCONNECTING:
                    labelConnected.Text = loca.getStr(loca.indice.STARTUP_DISCONNSSIONE_INCORSO);
                    pictureBoxConnected.Image = global::configuratoreSerial6._0.Resource1.arancioON;
                    break;


            }

        }


        void aggiornaLabelDisconnect()
        {
            connectedStatus = Costanti.DISCONNECTING;
            aggiornaLabelConnected();
            clsSerial.Disconnect();
            timerDisconnetti.Enabled = true;
        }

        private void timerConnessione_Tick(object sender, EventArgs e)
        {
            oldConnected = connectedStatus;
            if (connectedStatus == Costanti.CONNECTING)
            {
                aggiornaLabelConnected();
                labelConnected.Text = loca.getStr(loca.indice.STR_CONNECTING);
                pictureBoxConnected.Image = global::configuratoreSerial6._0.Resource1.arancioON;
                txMsg.requireInfo();
                connectedStatus = Costanti.IDLE;
            }
        }



        private void timerRicezione_Tick(object sender, EventArgs e)
        {

            int d;
            if (connectedStatus == Costanti.CONNECTING || connectedStatus == Costanti.IDLE || connectedStatus == Costanti.CONNECTED)
            {

                d = clsSerial.pop(0);
                if (d >= 0)
                {
                    byte b = (byte)(d & 0xff);
                    if (clsHandler.decode(b, this) >= 0)
                    {
                        connectedStatus = Costanti.CONNECTED;
                        aggiornaLabelConnected();
                    }
                }
            }
        }


        String getNomeDispositivo(int fancas)
        {
            String ret;
            ret = "";
            fancas = fancas & (~Costanti.BIT_IM_MASTER);
            switch (fancas)
            {
                case Costanti.CASSETTE:
                    ret = "CASSETTE";
                    break;
                case Costanti.T1:
                    ret = "ANALOG THERMOSTAT";
                    break;
                case Costanti.T2:
                    ret = "THERMOSTAT TOUCH TYPE";
                    break;
            }
            ret = ret + ": ";
            return ret;
        }

        public void openFromRemote(int fancas, Boolean SaltaTestDisabilitato, int richiestoDa, String Matricola, String release = "")
        {

            //if (deviceToolStripMenuItem.Enabled == true || SaltaTestDisabilitato == true)
            //{
            //    if (clsDeviceVersion.checkVersionFromRemote(fancas, clsMsg.getDataVersionStr()) >= 0)
            //    {
            //        connectedStatus = Costanti.CONNECTED;
            //        aggiornaLabelConnected();
            //        disabilitaMenu();
            //        switch (fancas)
            //        {
            //            case Costanti.CASSETTE | Costanti.BIT_IM_MASTER:
            //            case Costanti.T2 | Costanti.BIT_IM_MASTER:
            //            case Costanti.T1 | Costanti.BIT_IM_MASTER:
            //                // apre la videata di config RETE
            //                devFormNetwork = new frmMasterNetwork(getNomeDispositivo(fancas), clsMsg.getInfoMsg() + " " + clsSerial.getSelectedPortName(), this, false); ; // frmMasterNetwork("NETWORK ", clsMsg.getInfoMsg(), this, false);
            //                statusWinddows.setFinestraAperta(fancas & (~Costanti.BIT_IM_MASTER));
            //                devFormNetwork.Show();
            //                while (clsArbitrator.isInEsecuzione() == true)
            //                {
            //                    Application.DoEvents();
            //                }
            //                break;

            //            // case Costanti.
            //            case Costanti.CASSETTE:
            //                if (Costanti.getCurrVersionH(tblIndice.TBLCASSETTE) == clsMsg.getDataVersionH())
            //                {
            //                    if ((richiestoDa & Costanti.RICHIESTA_DA_MASTER) != 0)
            //                    {
            //                        // si vuole accedere ad uno SLAVE. I dati sono sul MASTER
            //                        // devForm = new frmCassette("CASSETTE: ", clsMsg.getInfoMsg(Matricola, "S", release) + " " + clsSerial.getSelectedPortName(), this, false, richiestoDa);
            //                        devForm = new frmCassette("CASSETTE: ", clsMsg.getInfoMsg() + " " + clsSerial.getSelectedPortName(), this, false, richiestoDa);

            //                    }
            //                    else
            //                    {
            //                        devForm = new frmCassette("CASSETTE: ", clsMsg.getInfoMsg(Matricola, "S", release) + " " + clsSerial.getSelectedPortName(), this, false, richiestoDa);

            //                        // devForm = new frmCassette("CASSETTE: ", clsMsg.getInfoMsg() + " " + clsSerial.getSelectedPortName(), this, false, richiestoDa);
            //                    }
            //                    statusWinddows.setFinestraAperta(Costanti.CASSETTE);
            //                    devForm.Show();
            //                    clsArbitrator.setLoadingParameter();
            //                    while (clsArbitrator.isInEsecuzione() == true)
            //                    {
            //                        Application.DoEvents();
            //                    }
            //                    if (clsArbitrator.isLoadingParameter() == false)
            //                    {
            //                        if ((richiestoDa & Costanti.RICHIESTA_DA_MASTER) != 0)
            //                            statoCassetteForm = new frmStatoCassette("CASSETTE: ", clsMsg.getInfoMsg() + " " + clsSerial.getSelectedPortName(), richiestoDa);
            //                        else
            //                            statoCassetteForm = new frmStatoCassette("CASSETTE: ", clsMsg.getInfoMsg(Matricola, "S", release) + " " + clsSerial.getSelectedPortName(), richiestoDa);

            //                        statoCassetteForm.Show();
            //                    }
            //                }
            //                break;

            //            case Costanti.T2:
            //                termoT2Form = new frmTermoT2("THERMOSTAT TOUCH TYPE: ", clsMsg.getInfoMsg(), this, false, richiestoDa);
            //                statusWinddows.setFinestraAperta(Costanti.T2);
            //                termoT2Form.Show();
            //                while (clsArbitrator.isInEsecuzione() == true)
            //                {
            //                    Application.DoEvents();
            //                }
            //                break;
            //        }
            //        //if (fancas == Costanti.CASSETTE)
            //        //{                 
            //        //    devForm = new frmCassette(version,bld,Matricola,this,false);
            //        //    statusWinddows.setFinestraAperta(Costanti.CASSETTE);
            //        //    devForm.Show();
            //        //    while(clsArbitrator.isInEsecuzione()==true)
            //        //    {
            //        //        Application.DoEvents();
            //        //    }
            //        //    statoCassetteForm = new frmStatoCassette();
            //        //    statoCassetteForm.Show();

            //        //}  
            //    }
            //    else
            //    {
            //        MessageBox.Show(loca.getStr(loca.indice.ERR_NON_COMPATIBILE), loca.getStr(loca.indice.MSG_ERRORE), MessageBoxButtons.OK);
            //        abilitaMenu();
            //    }
            //}
            //else
            //{
            //    tryToOpen(fancas);
            //}
        }

        public void tryToOpen(int fancas)
        {
            string msg;
            string caption;
            msg = loca.getStr(loca.indice.MSG_WORNING);
            caption = loca.getStr(loca.indice.MSG_FINAPERTA);
            var result = MessageBox.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.No)
            {
                // testa se ci sono modifiche sui dati
            }
        }

        private void frmStartUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            disconnetti();

        }

        public void disconnetti()
        {
            aggiornaLabelDisconnect();
            // aggiornaLabelConnected();
        }


        private void cASSETTEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void fANCOILToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tERMOSTATOANALOGICOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInfo f = new frmInfo();
            f.ShowDialog();
        }

        private void cOMToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timerDisconnetti_Tick(object sender, EventArgs e)
        {
            if (!clsSerial.isConnected())
            {
                timerConnessione.Enabled = false;
                connectedStatus = Costanti.UNCONNECTED;
                aggiornaLabelConnected();
                flgVerify = 0;
            }
        }

        private void pictureBoxConnected_Click(object sender, EventArgs e)
        {

        }

        private void labelConnected_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        public String getMatricola() { return textBoxMatricola.Text; }
        public int getIndirizzoMaster() { return (int)numericUpDownIndirizzoMaster.Value; }
        public int getMasterSlave() { return radioButtonMaster.Checked ? 0 : 1; }


        public void setMatricola(String m)
        {
            textBoxMatricola.Text = m;
        }



        public void setVersone(String m)
        {
            lblVersione.Text = m;
        }

        public void setMasterSlave(int m)
        {
            if (m == 0)
            {
                radioButtonMaster.Checked = true;
                radioButtonSlave.Checked = false;
                numericUpDownIndirizzoMaster.Enabled = true;
            }
            else
            {
                radioButtonMaster.Checked = false;
                radioButtonSlave.Checked = true;
                numericUpDownIndirizzoMaster.Enabled = false;

            }
        }

        String[] dispositivo =
        {
            "CASSETTE","FANCOIL","TERMOSTATO ANALOGICO","TERMOSTATO TOUCH","TERMOSTATO TFT"
        };

        public void setDispositivo(int d)
        {
            lblDispositivo.Text = dispositivo[d];
        }

        public void setIndirizzoMaster(int m)
        {
            if (m > 0 && m < 255)
                numericUpDownIndirizzoMaster.Value = (decimal)m;
        }

        private void lblDispositivo_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonMaster_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMaster.Checked)
            {
                radioButtonSlave.Checked = false;
                numericUpDownIndirizzoMaster.Enabled = true;
            }
        }

        private void radioButtonSlave_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSlave.Checked)
            {
                radioButtonMaster.Checked = false;
                numericUpDownIndirizzoMaster.Enabled = false;
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            // crea string JSON
            // Master/Slave
            // Indirizzo
            // Matricola
            if (textBoxMatricola.Text.Length > 15)
            {
                string message = "Il numero di matricola non può essere più lungo di 15 caratteri";
                string title = "Errore";
                MessageBox.Show(message, title);
            }
            else
            {
                JsonNetlist jsonMsg = new JsonNetlist();
                String hMsg = jsonMsg.encodeNET(this);
                // add F0 F7
                byte[] TxMsg = clsHandler.convertForTx(hMsg);
                txMsg.txMessageGeneric(TxMsg);
                // fa partire un timer che rilegge i parametri per verifica
                flgVerify = 1;
                timerVerifica.Enabled = true;
            }

        }

        public int getResetParametri() { return chkParametri.Checked ? 1 : 0; }
        public int getResetNetlist() { return chkNetlist.Checked ? 1 : 0; }
        public int getResetModbus() { return chkModbus.Checked ? 1 : 0; }
        public int getResetMatricola() { return chkMatricola.Checked ? 1 : 0; }
        private void timerVerifica_Tick(object sender, EventArgs e)
        {
            timerVerifica.Enabled = false;
            txMsg.requireInfo();
        }

        public void setErrorVerify(int x)
        {
            string message;
            string title;
            switch (x)
            {
                case 0:
                    message = "Verifica dati OK";
                    title = "OK";
                    MessageBox.Show(message, title);
                    break;
                case 1:
                    message = "Errore Scrittura/Lettura dati";
                    title = "Errore";
                    MessageBox.Show(message, title);
                    break;
            }

        }
        void enableBtnReset()
        {
            if (chkParametri.Checked || chkNetlist.Checked || chkModbus.Checked || chkMatricola.Checked)
                btnReset.Enabled = true;
            else
                btnReset.Enabled = false;

        }
        private void chkParametri_CheckedChanged(object sender, EventArgs e)
        {
            enableBtnReset();
        }

        private void chkModbus_CheckedChanged(object sender, EventArgs e)
        {
            enableBtnReset();
        }

        private void chkNetlist_CheckedChanged(object sender, EventArgs e)
        {
            enableBtnReset();
        }

        private void chkMatricola_CheckedChanged(object sender, EventArgs e)
        {
            enableBtnReset();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            JsonNetlist js = new JsonNetlist();
            String hMsg = js.encodeJSONresetCommand(this);
            byte[] TxMsg = clsHandler.convertForTx(hMsg);
            txMsg.txMessageGeneric(TxMsg);
            // fa partire un timer che rilegge i parametri per verifica
            flgVerify = 0;
            timerVerifica.Enabled = true;
        }
    }

    public partial class startupData
    {
        static private frmStartUp gfrmStartUp;

        static public void setgfrmStartUp(frmStartUp f)
        {
            gfrmStartUp = f;
        }

        static public frmStartUp getgfrmStartUp()
        {
            return gfrmStartUp;
        }
    }
}
