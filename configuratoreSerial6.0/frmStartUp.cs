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
using configuratore.statoCassette;
using System.IO.Ports;
using System.IO;
using configuratore.stato;
using static configuratore.Costanti;
using configuratoreSerial6._0;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using UniqueID;
using configuratoreSerial6._0.uniqueID;


namespace configuratore
{
    public partial class frmStartUp : Form
    {
        int oldConnected;
        int connectedStatus;
        frmCassette myForm;
        frmFanCoil FanCoilmyForm;
        frmCassette devForm;
        frmStatoCassette statoCassetteForm;
        frmStatoFanCoil statoFanCoil;
        frmTermoT1 termoT1Form;
        frmTermoT2 termoT2Form;
        frmMasterNetwork devFormNetwork;
        uniqueID testCodice;

        String FileName = "";
        public clsRxBuffer rxBuffer;
        int vTimerDisconnetti = -1;
        int TimerConnessioneTimeout = -1;
        public frmStartUp()
        {
            InitializeComponent();
            dir.init();
            txMsg.initDati();
            datiConfig.Initdati();
            datiFancoil.Initdati("");  // inizializza le tabelle
            datiTermostato.Initdati("");  // inizializza le tabelle
            datiCassette.Initdati("");  // inizializza le tabelle
            clsHandler.initData();
            statusWinddows.initData();
            oldConnected = -1;
            aggiornaLingua(datiConfig.getLinguaggio());

            addSubMenuVersioni();
            startupData.setgfrmStartUp(this);
            rxBuffer = new clsRxBuffer();
            TimerConnessioneTimeout = -1;
#if DEBUG
            deviceToolStripMenuItem.Visible=true;
#else
            deviceToolStripMenuItem.Visible = false;
#endif

        }

        public byte[] getRxBuffr() { return rxBuffer.getRxBuffer(); }

        public clsRxBuffer getRxBufferClass() { return rxBuffer; }
        void addSubMenuVersioni()
        {
            int i;
            for (i = 0; i < clsDeviceVersion.getNumOfVersioniCassette(); i++)
            {
                ToolStripMenuItem subMenu = new ToolStripMenuItem();
                subMenu.Text = clsDeviceVersion.getCassetteVersion(i);
                subMenu.Click += new System.EventHandler(this.Cassette_Click);
                cASSETTEToolStripMenuItem.DropDownItems.Add(subMenu);

            }
            for (i = 0; i < clsDeviceVersion.getNumOfVersioniFamcoil(); i++)
            {
                ToolStripMenuItem subMenu = new ToolStripMenuItem();
                subMenu.Text = clsDeviceVersion.getFancoilVersion(i);
                subMenu.Click += new System.EventHandler(this.Fancoil_Click);
                fANCOILToolStripMenuItem.DropDownItems.Add(subMenu);
            }

            for (i = 0; i < clsDeviceVersion.getNumOfVersioniTermoT1(); i++)
            {
                ToolStripMenuItem subMenu = new ToolStripMenuItem();
                subMenu.Text = clsDeviceVersion.getTermoT1Version(i);
                subMenu.Click += new System.EventHandler(this.TermoT1_Click);
                tERMOSTATOANALOGICOToolStripMenuItem.DropDownItems.Add(subMenu);
            }

            for (i = 0; i < clsDeviceVersion.getNumOfVersioniTermoT2(); i++)
            {
                ToolStripMenuItem subMenu = new ToolStripMenuItem();
                subMenu.Text = clsDeviceVersion.getTermoT2Version(i);
                subMenu.Click += new System.EventHandler(this.TermoT2_Click);
                tERMOSTATOTOUCHCONTROLToolStripMenuItem.DropDownItems.Add(subMenu);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = global::configuratoreSerial6._0.Resource1.AppIcona;
            this.Text = "STARTUP " + Versione.versioneStrForm(); ;

            this.MaximizeBox = false;
            testCodice = new uniqueID();
            if (testCodice.getConfigurazione() < 0)
            {
                this.Close();
                Application.Exit();
            }


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
                timerConnessione.Enabled = true;
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
            if (myForm != null)
                myForm.setLangage();
            if (statoCassetteForm != null)
                statoCassetteForm.setLangage();
            if (FanCoilmyForm != null)
                FanCoilmyForm.setLangage();
            if (termoT1Form != null)
                termoT1Form.setLangage();
            if (termoT2Form != null)
                termoT2Form.setLangage();

        }

        void aggiornaMenu()
        {
            this.fileToolStripMenuItem.Text = loca.getStr(loca.indice.MENU_FILE);
            // 
            // apriToolStripMenuItem
            // 
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
            this.deviceToolStripMenuItem.Text = loca.getStr(loca.indice.MENU_DEVICE);
            // 
            // cASSETTEToolStripMenuItem
            // 
            this.cASSETTEToolStripMenuItem.Text = loca.getStr(loca.indice.MENU_CASSETTE);
            // 
            // fANCOILToolStripMenuItem
            // 
            this.fANCOILToolStripMenuItem.Text = loca.getStr(loca.indice.MENU_FANCOIL);
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

            this.cOMToolStripMenuItem.Text = loca.getStr(loca.indice.MENU_COM);
            this.spedisciTCPToolStripMenuItem.Text= loca.getStr(loca.indice.MENU_CONNETTI);

        }

        void aggiornaLabelConnected()
        {
            switch(connectedStatus)
            {
                case Costanti.CONNECTING:
                    labelConnected.Text = loca.getStr(loca.indice.STR_CONNECTING);
                    pictureBoxConnected.Image = global::configuratoreSerial6._0.Resource1.arancioON;
                    TimerConnessioneTimeout = 5;
                    break;
                case Costanti.UNCONNECTED:
                    labelConnected.Text = loca.getStr(loca.indice.LBL_UNCONNECTED);
                    pictureBoxConnected.Image = global::configuratoreSerial6._0.Resource1.verdeOFF;
                    TimerConnessioneTimeout = -1;
                    break;
                case Costanti.CONNECTED:
                    labelConnected.Text = loca.getStr(loca.indice.LBL_CONNECTED);
                    pictureBoxConnected.Image = global::configuratoreSerial6._0.Resource1.verdeON;
                    TimerConnessioneTimeout = -1;
                    break;
                case Costanti.DISCONNECTING:
                    labelConnected.Text = loca.getStr(loca.indice.STARTUP_DISCONNSSIONE_INCORSO);
                    pictureBoxConnected.Image = global::configuratoreSerial6._0.Resource1.arancioON;
                    TimerConnessioneTimeout = -1;
                    break;


            }
         
        }


        void aggiornaLabelDisconnect()
        {
            connectedStatus=Costanti.DISCONNECTING;
            aggiornaLabelConnected();
            clsSerial.Disconnect();
            timerDisconnetti.Enabled = true;
        }

        private void timerConnessione_Tick(object sender, EventArgs e)
        {
            if(TimerConnessioneTimeout>=0)
            {
                TimerConnessioneTimeout--;
                if(TimerConnessioneTimeout<0)
                {
                    connectedStatus = Costanti.UNCONNECTED;
                    aggiornaLabelConnected();
                    String caption = "error";
                    String message = "Time out!";

                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Error);
                }
            }


        }



        private void timerRicezione_Tick(object sender, EventArgs e)
        {
            

            if (connectedStatus == Costanti.CONNECTING)
            {
                int d;
                d = clsSerial.pop(Costanti.BITS_DEVICE_CASSETTE | Costanti.BITS_VIDEATA_MASTER);
                if (d >= 0)
                {
                    byte b = (byte)(d & 0xff);
                    clsHandler.decode(b, this);
                    // handelrData
                }
                d = clsSerial.pop(Costanti.BITS_DEVICE_FANCOIL | Costanti.BITS_VIDEATA_MASTER);
                if (d >= 0)
                {
                    byte b = (byte)(d & 0xff);
                    clsHandler.decode(b, this);
                    // handelrData

                }
                d = clsSerial.pop(Costanti.BITS_DEVICE_TERMOT2 | Costanti.BITS_VIDEATA_MASTER);
                if (d >= 0)
                {
                    byte b = (byte)(d & 0xff);
                    clsHandler.decode(b, this);
                    // handelrData
                }
                d = clsSerial.pop(Costanti.BITS_DEVICE_TERMOT1 | Costanti.BITS_VIDEATA_MASTER);
                while (d >= 0)
                {
                    byte b = (byte)(d & 0xff);
                    clsHandler.decode(b, this);
                    d = clsSerial.pop(Costanti.BITS_DEVICE_TERMOT1 | Costanti.BITS_VIDEATA_MASTER);
                    // handelrData
                }



                d = clsSerial.pop(Costanti.BIT_IM_MASTER | Costanti.BITS_DEVICE_TERMOT2 | Costanti.BITS_VIDEATA_MASTER);
                if (d >= 0)
                {
                    byte b = (byte)(d & 0xff);
                    clsHandler.decode(b, this);
                    // handelrData
                }
                d = clsSerial.pop(Costanti.BIT_IM_MASTER | Costanti.BITS_DEVICE_CASSETTE | Costanti.BITS_VIDEATA_MASTER);
                if (d >= 0)
                {
                    byte b = (byte)(d & 0xff);
                    clsHandler.decode(b, this);
                    // handelrData
                }
                d = clsSerial.pop(Costanti.BIT_IM_MASTER | Costanti.BITS_DEVICE_FANCOIL | Costanti.BITS_VIDEATA_MASTER);
                while (d >= 0)
                {
                    byte b = (byte)(d & 0xff);
                    clsHandler.decode(b, this);
                    d = clsSerial.pop(Costanti.BIT_IM_MASTER | Costanti.BITS_DEVICE_FANCOIL | Costanti.BITS_VIDEATA_MASTER);
                    // handelrData
                }
                d = clsSerial.pop(Costanti.BIT_IM_MASTER | Costanti.BITS_DEVICE_TERMOT1 | Costanti.BITS_VIDEATA_MASTER);
                while (d >= 0)
                {
                    byte b = (byte)(d & 0xff);
                    clsHandler.decode(b, this);
                    d = clsSerial.pop(Costanti.BIT_IM_MASTER | Costanti.BITS_DEVICE_TERMOT1 | Costanti.BITS_VIDEATA_MASTER);
                    // handelrData
                }

            }


        }

        private void disaAbiilitaMenu(Boolean flg)
        {
            deviceToolStripMenuItem.Enabled = flg;
            cOMToolStripMenuItem.Enabled = flg;
        }

        private void Cassette_Click(object sender, EventArgs e)
        {
            if (deviceToolStripMenuItem.Enabled == true)
            {
                disaAbiilitaMenu(false);
                sVerdins v = clsDeviceVersion.getLastCassetteVersion();
                statusWinddows.setVersion(clsDeviceVersion.getLastCassetteVersion());
                myForm = new frmCassette("CASSETTE: ", "", this, true, Costanti.RICHIESTA_DA_LOCALE);
                statusWinddows.setFinestraAperta(Costanti.CASSETTE);
                myForm.Show();
                statoCassetteForm = new frmStatoCassette("","",-1);
                statoCassetteForm.Show();
            }
            else
            {
                // finestra cassette già aperta
                // 
                tryToOpen(Costanti.CASSETTE);

            }
        }

        private void Fancoil_Click(object sender, EventArgs e)
        {
            if (deviceToolStripMenuItem.Enabled == true)
            {
                disaAbiilitaMenu(false);
                sVerdins v = clsDeviceVersion.getLastCassetteVersion();
                statusWinddows.setVersion(clsDeviceVersion.getLastCassetteVersion());
                FanCoilmyForm = new frmFanCoil("FANCOIL: ", "", this, true, Costanti.RICHIESTA_DA_LOCALE);
                statusWinddows.setFinestraAperta(Costanti.FANCOIL);
                FanCoilmyForm.Show();

                statoFanCoil = new frmStatoFanCoil("", "", -1);
                statoFanCoil.Show();

                //statoCassetteForm = new frmStatoCassette();
                //statoCassetteForm.Show();
            }
        }

        private void TermoT1_Click(object sender, EventArgs e)
        {
            if (deviceToolStripMenuItem.Enabled == true)
            {
                disaAbiilitaMenu(false);
                sVerdins v = clsDeviceVersion.getLastCassetteVersion();
                statusWinddows.setVersion(clsDeviceVersion.getLastCassetteVersion());
                termoT1Form = new frmTermoT1("ANALOG TERM.: ", "", this, true, Costanti.RICHIESTA_DA_LOCALE);
                statusWinddows.setFinestraAperta(Costanti.CASSETTE);
                termoT1Form.Show();

                //statoCassetteForm = new frmStatoCassette();
                //statoCassetteForm.Show();
            }
        }

        private void TermoT2_Click(object sender, EventArgs e)
        {
            if (deviceToolStripMenuItem.Enabled == true)
            {
                disaAbiilitaMenu(false);
                sVerdins v = clsDeviceVersion.getLastCassetteVersion();
                statusWinddows.setVersion(clsDeviceVersion.getLastCassetteVersion());
                termoT2Form = new frmTermoT2("CASSETTE: ", "", this, true, Costanti.RICHIESTA_DA_LOCALE);
                statusWinddows.setFinestraAperta(Costanti.CASSETTE);
                termoT2Form.Show();

                //statoCassetteForm = new frmStatoCassette();
                //statoCassetteForm.Show();
            }
        }

        private void disabilitaMenu()
        {
            abilitadisabilitamenu(false);
        }

        public void abilitaMenu()
        {
            abilitadisabilitamenu(true);
            disconnetti();
        }

        private void abilitadisabilitamenu(Boolean x)
        {
            deviceToolStripMenuItem.Enabled = x;
            cOMToolStripMenuItem.Enabled = x;
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

        public void openFromRemote(int fancas, Boolean SaltaTestDisabilitato, int richiestoDa, String Matricola,String release="")
        {

            if (deviceToolStripMenuItem.Enabled == true || SaltaTestDisabilitato == true)
            {
                if (clsDeviceVersion.checkVersionFromRemote(fancas, clsMsg.getDataVersionStr()) >= 0)
                {
                    connectedStatus = Costanti.CONNECTED;
                    aggiornaLabelConnected();
                    disabilitaMenu();
                    switch (fancas)
                    {
                        case Costanti.FANCOIL | Costanti.BIT_IM_MASTER:
                        case Costanti.CASSETTE | Costanti.BIT_IM_MASTER:
                        case Costanti.T2 | Costanti.BIT_IM_MASTER:
                        case Costanti.T1 | Costanti.BIT_IM_MASTER:
                            // apre la videata di config RETE
                            devFormNetwork = new frmMasterNetwork(getNomeDispositivo(fancas), clsMsg.getInfoMsg() + " " + clsSerial.getSelectedPortName(), this, false) ; ; // frmMasterNetwork("NETWORK ", clsMsg.getInfoMsg(), this, false);
                            statusWinddows.setFinestraAperta(fancas & (~Costanti.BIT_IM_MASTER));
                            devFormNetwork.Show();
                            while (clsArbitrator.isInEsecuzione() == true)
                            {
                                Application.DoEvents();
                            }
                            break;

                        // case Costanti.
                        case Costanti.CASSETTE:
                            if (Costanti.getCurrVersionH(tblIndice.TBLCASSETTE) == clsMsg.getDataVersionH())
                            {
                                if ((richiestoDa & Costanti.RICHIESTA_DA_MASTER) != 0)
                                {
                                    // si vuole accedere ad uno SLAVE. I dati sono sul MASTER
                                    // devForm = new frmCassette("CASSETTE: ", clsMsg.getInfoMsg(Matricola, "S", release) + " " + clsSerial.getSelectedPortName(), this, false, richiestoDa);
                                    devForm = new frmCassette("CASSETTE: ", clsMsg.getInfoMsg() + " " + clsSerial.getSelectedPortName(), this, false, richiestoDa);

                                }
                                else
                                {
                                    devForm = new frmCassette("CASSETTE: ", clsMsg.getInfoMsg(Matricola, "S", release) + " " + clsSerial.getSelectedPortName(), this, false, richiestoDa);

                                    // devForm = new frmCassette("CASSETTE: ", clsMsg.getInfoMsg() + " " + clsSerial.getSelectedPortName(), this, false, richiestoDa);
                                }
                                statusWinddows.setFinestraAperta(Costanti.CASSETTE);
                                devForm.Show();
                                clsArbitrator.setLoadingParameter();
                                while (clsArbitrator.isInEsecuzione() == true)
                                {
                                    Application.DoEvents();
                                }
                                if (clsArbitrator.isLoadingParameter() == false)
                                {
                                    if ((richiestoDa & Costanti.RICHIESTA_DA_MASTER) != 0)
                                        statoCassetteForm = new frmStatoCassette("CASSETTE: ", clsMsg.getInfoMsg() + " " + clsSerial.getSelectedPortName(), richiestoDa);
                                    else
                                        statoCassetteForm = new frmStatoCassette("CASSETTE: ", clsMsg.getInfoMsg(Matricola, "S", release) + " " + clsSerial.getSelectedPortName(), richiestoDa);

                                    statoCassetteForm.Show();
                                }
                            }
                            break;
                        case Costanti.FANCOIL:
                            if (Costanti.getCurrVersionH(tblIndice.TBLCASSETTE) == clsMsg.getDataVersionH())
                            {
                                if ((richiestoDa & Costanti.RICHIESTA_DA_MASTER) != 0)
                                {
                                    // si vuole accedere ad uno SLAVE. I dati sono sul MASTER
                                    // devForm = new frmCassette("CASSETTE: ", clsMsg.getInfoMsg(Matricola, "S", release) + " " + clsSerial.getSelectedPortName(), this, false, richiestoDa);
                                    FanCoilmyForm = new frmFanCoil("FANCOIL: ", clsMsg.getInfoMsg() + " " + clsSerial.getSelectedPortName(), this, false, richiestoDa);

                                }
                                else
                                {
                                    FanCoilmyForm = new frmFanCoil("FANCOIL: ", clsMsg.getInfoMsg(Matricola, "S", release) + " " + clsSerial.getSelectedPortName(), this, false, richiestoDa);

                                    // devForm = new frmCassette("CASSETTE: ", clsMsg.getInfoMsg() + " " + clsSerial.getSelectedPortName(), this, false, richiestoDa);
                                }
                                statusWinddows.setFinestraAperta(Costanti.FANCOIL);
                                FanCoilmyForm.Show();
                                clsArbitrator.setLoadingParameter();
                                while (clsArbitrator.isInEsecuzione() == true)
                                {
                                    Application.DoEvents();
                                }
                                if (clsArbitrator.isLoadingParameter() == false)
                                {
                                    if ((richiestoDa & Costanti.RICHIESTA_DA_MASTER) != 0)
                                        statoFanCoil = new frmStatoFanCoil("FANCOIL: ", clsMsg.getInfoMsg() + " " + clsSerial.getSelectedPortName(), richiestoDa);
                                    else
                                        statoFanCoil = new frmStatoFanCoil("FANCOIL: ", clsMsg.getInfoMsg(Matricola, "S", release) + " " + clsSerial.getSelectedPortName(), richiestoDa);

                                    statoFanCoil.Show();
                                }
                            }
                            break;

                        case Costanti.T2:
                            termoT2Form = new frmTermoT2("THERMOSTAT TOUCH TYPE: ", clsMsg.getInfoMsg(), this, false, richiestoDa);
                            statusWinddows.setFinestraAperta(Costanti.T2);
                            termoT2Form.Show();
                            while (clsArbitrator.isInEsecuzione() == true)
                            {
                                Application.DoEvents();
                            }
                            break;
                        case Costanti.T1:
                            termoT1Form = new frmTermoT1("THERMOSTAT ANALOG TYPE: ", clsMsg.getInfoMsg(), this, false, richiestoDa);
                            statusWinddows.setFinestraAperta(Costanti.T1);
                            termoT1Form.Show();
                            //while (clsArbitrator.isInEsecuzione() == true)
                            //{
                            //    Application.DoEvents();
                            //}
                            break;
                    }
                    //if (fancas == Costanti.CASSETTE)
                    //{                 
                    //    devForm = new frmCassette(version,bld,Matricola,this,false);
                    //    statusWinddows.setFinestraAperta(Costanti.CASSETTE);
                    //    devForm.Show();
                    //    while(clsArbitrator.isInEsecuzione()==true)
                    //    {
                    //        Application.DoEvents();
                    //    }
                    //    statoCassetteForm = new frmStatoCassette();
                    //    statoCassetteForm.Show();

                    //}  
                }
                else
                {
                    MessageBox.Show(loca.getStr(loca.indice.ERR_NON_COMPATIBILE), loca.getStr(loca.indice.MSG_ERRORE), MessageBoxButtons.OK);
                    abilitaMenu();
                }
            }
            else
            {
                tryToOpen(fancas);
            }
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

        public void enableDevice()
        {
            if (devForm == null && statoCassetteForm == null)
                disaAbiilitaMenu(true);
        }
        private void cASSETTEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a;
            if (devForm != null)
            {
                if (FileName == "")
                {
                    // SaveAs();
                    a = 1;
                }
                else
                {
                    String fullFileName = dir.getConfigDir() + FileName;
                    if (File.Exists(fullFileName))
                    {
                        string message = loca.getStr(loca.indice.MSG_FILE_EXIEST);
                        string caption = loca.getStr(loca.indice.MSG_WORNING);

                        var result = MessageBox.Show(message, caption,
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                        // If the no button was pressed ...
                        if (result == DialogResult.No)
                        {
                            // cancel the closure of the form.

                        }
                    }
                }
            }
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
            frmInfo f = new frmInfo(testCodice.getConfigurazione());
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
            }
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
