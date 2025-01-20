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
using configuratoreSerial6._0;
using System.Diagnostics;
using System.Media;
using Windows.ApplicationModel.Resources.Core;
using Windows.ApplicationModel.Chat;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;

namespace configuratore
{
    public partial class frmStartUp : Form
    {
        int oldConnected;
        public int connectedStatus;

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
        int tDisp;
        int beep;

        int cdispositivo;

        struct btnLED
        {
            public int stato;
            public Button btn;
            public PictureBox pic;
            public Image imgLEDoff;
            public Image imgLEDon;
        }

        struct lblADCs
        {
            public Label lblBkg;
            public Label lblFrg;

        }

        struct sDigitalInput
        {
            public int stato;
            public int vecchiostato;

            public int sommatoria;
            public PictureBox ledDI;
        }

        struct sRS_485
        {
            public int stato;
            public PictureBox ledRS_485;
        }

        struct sNTC
        {
            public int stato;
            public int MIN;
            public int MAX;
            public PictureBox ledNTC;
            public Label lblNTCval;
        }

        btnLED[] onOffLED = new btnLED[6];
        lblADCs[] lblADC = new lblADCs[2];
        sDigitalInput[] DigitalInput = new sDigitalInput[5];
        sRS_485[] RS_485 = new sRS_485[3];
        sNTC[] NTC = new sNTC[2];

        RadioButton[] RadioButtonsLEDAnal = new RadioButton[9];
        PictureBox[] ledPowerAnal = new PictureBox[3];

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
            initBtn();
            initAnal();
            chkParametri.CheckedChanged += chkParametri_CheckedChanged;
            chkModbus.CheckedChanged += chkParametri_CheckedChanged;
            chkNetlist.CheckedChanged += chkParametri_CheckedChanged;
            chkMatricola.CheckedChanged += chkParametri_CheckedChanged;
        }

        void initAnal()
        {
            RadioButtonsLEDAnal[0] = rbR100;
            RadioButtonsLEDAnal[1] = rbR50;
            RadioButtonsLEDAnal[2] = rbR0;
            RadioButtonsLEDAnal[3] = rbG100;
            RadioButtonsLEDAnal[4] = rbG50;
            RadioButtonsLEDAnal[5] = rbG0;
            RadioButtonsLEDAnal[6] = rbB100;
            RadioButtonsLEDAnal[7] = rbB50;
            RadioButtonsLEDAnal[8] = rbB0;

            for (int i = 0; i < RadioButtonsLEDAnal.Length; i++)
            {
                RadioButtonsLEDAnal[i].MouseDown += rbLEDAnal_Click;
            }
            ledPowerAnal[0] = LEDRossoPower;
            ledPowerAnal[1] = LEDVerdePower;
            ledPowerAnal[2] = LEDBluPower;


        }

        void initBtn()
        {
            onOffLED[0].btn = btnLED0;
            onOffLED[0].pic = pbLED0;

            onOffLED[1].btn = btnLED1;
            onOffLED[1].pic = pbLED1;

            onOffLED[2].btn = btnLED2;
            onOffLED[2].pic = pbLED2;

            onOffLED[3].btn = btnLED3;
            onOffLED[3].pic = pbLED3;

            onOffLED[4].btn = btnLED4;
            onOffLED[4].pic = pbLED4;

            onOffLED[5].btn = btnLED5;
            onOffLED[5].pic = pbLED5;
            for (int i = 0; i < onOffLED.Length; i++)
            {
                onOffLED[i].stato = 0;
                onOffLED[i].imgLEDoff = configuratoreSerial6._0.Resource1.LedVerdeOFF;
                onOffLED[i].imgLEDon = configuratoreSerial6._0.Resource1.LedVerdeON;
                onOffLED[i].btn.Click += btnLED_Click;
            }



            onOffLED[0].imgLEDoff = configuratoreSerial6._0.Resource1.LedRossoOFF;
            onOffLED[0].imgLEDon = configuratoreSerial6._0.Resource1.LedRossoON;

            onOffLED[1].imgLEDoff = configuratoreSerial6._0.Resource1.LedRossoOFF;
            onOffLED[1].imgLEDon = configuratoreSerial6._0.Resource1.LedRossoON;

            lblADC[0].lblBkg = lblADC1bkg;
            lblADC[1].lblBkg = lblADC2bkg;

            lblADC[0].lblFrg = lblADC1;
            lblADC[1].lblFrg = lblADC2;

            DigitalInput[0].stato = 0;
            DigitalInput[0].sommatoria = 0;
            DigitalInput[0].ledDI = pbLEDDI1;

            DigitalInput[1].stato = 0;
            DigitalInput[1].sommatoria = 0;
            DigitalInput[1].ledDI = pbLEDDI2;

            DigitalInput[2].stato = 0;
            DigitalInput[2].sommatoria = 0;
            DigitalInput[2].ledDI = pbLEDDI3;

            DigitalInput[3].stato = 0;
            DigitalInput[3].sommatoria = 0;
            DigitalInput[3].ledDI = pbLEDDI4;

            DigitalInput[4].stato = 0;
            DigitalInput[4].sommatoria = 0;
            DigitalInput[4].ledDI = pbLEDDI5;

            RS_485[0].stato = 0;
            RS_485[0].ledRS_485 = pbLED_RS4851PLC;

            RS_485[1].stato = 0;
            RS_485[1].ledRS_485 = pbLED_RS4852PLC;


            NTC[0].stato = 0;
            NTC[1].stato = 0;
            NTC[0].ledNTC = pbLEDNTC1;
            NTC[1].ledNTC = pbLEDNTC2;
            NTC[0].lblNTCval = lblNTC1;
            NTC[1].lblNTCval = lblNTC2;
            NTC[0].MIN = 550;
            NTC[0].MAX = 750;
            NTC[1].MIN = 550;
            NTC[1].MAX = 750;


            resetPanelTest();

        }

        void resetPanelTest()
        {
            for (int i = 0; i < onOffLED.Length; i++)
            {
                onOffLED[i].stato = 0;
                onOffLED[i].btn.Image = new Bitmap(configuratoreSerial6._0.Resource1.OFF, new Size(71, 43));
                onOffLED[i].pic.Image = onOffLED[i].imgLEDoff;

            }
            DAC1.Value = 512;
            DAC2.Value = 512;
            resetLblADC();

            for (int i = 0; i < DigitalInput.Length; i++)
            {
                DigitalInput[i].stato = 0;
                DigitalInput[i].ledDI.Image = configuratoreSerial6._0.Resource1.LedBluOFF;
            }

            resetRS485LED(0);
            resetRS485LED(1);

            setNTC(0, 0);
            setNTC(0, 1);
        }

        void resetLblADC()
        {
            setLblADC(0, 0);
            setLblADC(0, 1);
        }

        void setOnOffDigitalInput(int i, bool onOff)
        {
            if (onOff)
            {
                DigitalInput[i].stato = 1;
                DigitalInput[i].ledDI.Image = configuratoreSerial6._0.Resource1.LedBluON;
            }
            else
            {
                DigitalInput[i].stato = 0;
                DigitalInput[i].ledDI.Image = configuratoreSerial6._0.Resource1.LedBluOFF;
            }
            if (flagPrimoGiro == 0)
            {
                DigitalInput[i].sommatoria = DigitalInput[i].stato;
            }
            if (flagPrimoGiro != 0)
            {
                if (DigitalInput[i].stato != DigitalInput[i].vecchiostato)
                {
                    DigitalInput[i].vecchiostato = DigitalInput[i].stato;
                    DigitalInput[i].sommatoria++;
                }
            }
            int miaSomma = 0;
            for (int k = 0; k < DigitalInput.Length; k++)
            {
                if (DigitalInput[k].sommatoria >= 2)
                    miaSomma++;
            }
            //Debug.Write("-> ");
            //Debug.WriteLine(DigitalInput[0].sommatoria);
            //Debug.WriteLine(miaSomma);
            if (miaSomma >= 5)
            {
                pbLEDDIOK.Image = configuratoreSerial6._0.Resource1.LedVerdeON;
                reportList.setPass(reportList.FCDI);
            }
        }


        void setRS485LED(int value, int rs485)
        {

            RS_485[rs485].stato = value;
            if (RS_485[rs485].stato == 1)
            {
                RS_485[rs485].ledRS_485.Image = configuratoreSerial6._0.Resource1.LedVerdeON;
                if (rs485 == 0)
                {
                    reportList.setPass(reportList.FCRS4851);
                }
                else
                {
                    reportList.setPass(reportList.FCRS4852);
                }
            }
            else
                RS_485[rs485].ledRS_485.Image = configuratoreSerial6._0.Resource1.LedRossoON;

        }

        void resetRS485LED(int rs485)
        {
            RS_485[rs485].stato = 0;
            RS_485[rs485].ledRS_485.Image = configuratoreSerial6._0.Resource1.LedRossoON;
        }

        public void setLblADC(int value, int adc)
        {
            int TOLLERANZA = 100;
            String repStr = "";
            PictureBox ledTest;
            int l = lblADC[adc].lblBkg.Width;   // 1023:l = adc: w    w=(adc x l)/1023
            int size = l * value;
            lblADC[adc].lblFrg.Width = size / 1023;

            // controlla se il valore ADC ugual al valore DAC
            // entro una certa toleranza
            int DACv;
            if (adc == 0)
            {
                DACv = DAC1.Value;
                ledTest = pbLEDADCDAC1OK;
                repStr = reportList.FCAD2;
            }
            else
            {
                DACv = DAC2.Value;
                ledTest = pbLEDADCDAC2OK;
                repStr = reportList.FCAD1;

            }
            if ((value < (DACv + TOLLERANZA)) && (value > (DACv - TOLLERANZA)))
            {
                ledTest.Image = configuratoreSerial6._0.Resource1.LedVerdeON;
                reportList.setPass(repStr);
            }
            else
            {
                ledTest.Image = configuratoreSerial6._0.Resource1.LedVerdeOFF;
            }
        }


        int pressSens = 0;
        public void setPressSens(int value)
        {


            int size = (int)utility.dmap((double)value, (double)-32768, (double)32767, (double)0, (double)lblPressSensBck.Height);
            lblPressSensFrg.Height = size;
            if (size < 10)
                pressSens = pressSens | 1;
            if (size > (lblPressSensBck.Height - 10))
                pressSens = pressSens | 2;
            if (pressSens == 3)
            {
                pbLEDPRESSOK.Image = configuratoreSerial6._0.Resource1.LedVerdeON;
                reportList.setPass(reportList.FCPRESS);
            }

        }

        public void setRS485(int value)
        {
            int xx;
            xx = ((value & 0x01) != 0) ? 1 : 0;
            setRS485LED(xx, 0);
            xx = ((value & 0x02) != 0) ? 1 : 0;
            setRS485LED(xx, 1);
        }

        public void setNTC(int val, int num)
        {
            NTC[num].stato = val;
            NTC[num].lblNTCval.Text = val.ToString();
            if (val >= NTC[num].MIN && val <= NTC[num].MAX)
            {
                NTC[num].ledNTC.Image = configuratoreSerial6._0.Resource1.LedVerdeON;
                if (num == 0)
                    reportList.setPass(reportList.FCNTC1);
                else
                    reportList.setPass(reportList.FCNTC2);
            }
            else
            {
                NTC[num].ledNTC.Image = configuratoreSerial6._0.Resource1.LedRossoON;
            }
        }

        int[,] onOffLed = new int[2, 6];
        private void btnLED_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int indice = -1;
            for (int i = 0; i < this.onOffLED.Length && indice < 0; i++)
            {
                if (btn == this.onOffLED[i].btn)
                    indice = i;
            }
            if (indice >= 0)
            {
                subOnOff(indice);
            }
        }

        void subOnOff(int indice)
        {
            if (onOffLED[indice].stato == 0)
            {
                onOffLed[0, indice] = 1;
                onOffLED[indice].stato = 1;
                onOffLED[indice].btn.Image = new Bitmap(configuratoreSerial6._0.Resource1.ON, new Size(71, 43));
                onOffLED[indice].pic.Image = onOffLED[indice].imgLEDon;
            }
            else
            {
                onOffLed[1, indice] = 1;
                onOffLED[indice].stato = 0;
                onOffLED[indice].btn.Image = new Bitmap(configuratoreSerial6._0.Resource1.OFF, new Size(71, 43));
                onOffLED[indice].pic.Image = onOffLED[indice].imgLEDoff;
            }

            int sum = 0;
            for (int i = 0; i < onOffLED.Length; i++)
            {
                sum = sum + onOffLed[1, i] + onOffLed[0, i];
            }
            if (sum == onOffLED.Length * 2)
            {
                btLEDSOK.Image = configuratoreSerial6._0.Resource1.LedVerdeON;
                reportList.setPass(reportList.FCLEDS);
            }
        }

        public int getLED(int l) { return onOffLED[l].stato; }

        public int getDAC(int l)
        {
            int x = 0;
            if (l == 0)
                x = DAC1.Value;
            if (l == 1)
                x = DAC2.Value;

            return x;
        }

        int flagPrimoGiro = 0;
        public void setDI(int v)
        {
            for (int i = 0; i < 5; i++)
            {
                setOnOffDigitalInput(i, (v & 0x01) != 0);
                v = v >> 1;
            }
            flagPrimoGiro++;
        }




        public byte[] getRxBuffr() { return rxBuffer.getRxBuffer(); }

        public clsRxBuffer getRxBufferClass() { return rxBuffer; }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = global::configuratoreSerial6._0.Resource1.AppIcona;
            this.Text = "PARAMETER SETTING " + Versione.versioneStrForm(); ;

            this.MaximizeBox = false;

            tabPage2.Enabled = false;
            timerPowerOn.Enabled = true;


        }
        private void DisableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                DisableControls(c);
            }

        }

        void openSerialWindowConnection()
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
            textBoxMatricola.Select();

            // Select all text in the text box.


            
        }


        private void spedisciTCPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openSerialWindowConnection();
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

        int timerTimeOut = -1;

        private void timerRicezione_Tick(object sender, EventArgs e)
        {

            int d;
            if (connectedStatus == Costanti.CONNECTING || connectedStatus == Costanti.IDLE || connectedStatus == Costanti.CONNECTED)
            {

                d = clsSerial.pop(0);
                while (d >= 0)
                {
                    byte b = (byte)(d & 0xff);
                    if (clsHandler.decode(b, this) >= 0)
                    {
                        connectedStatus = Costanti.CONNECTED;
                        aggiornaLabelConnected();
                        if(lblVersione.Text!="---")
                            tabPage2.Enabled = true;
                        if (tabControl1.SelectedIndex == 1)
                            timerTimeOut = 250;
                        else
                            timerTimeOut = -1;
                    }
                    d = clsSerial.pop(0);
                }
                if (timerTimeOut >= 0)
                {
                    timerTimeOut--;
                    if (timerTimeOut == 0)
                    {
                        timerTimeOut = 250;
                        reportCls.SaveTestReportFile();
                        Application.Restart();
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
            textBoxMatricola.SelectAll();
            textBoxMatricola.Focus();
            reportCls.setMatricola(m);
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
            tDisp = d;
            reportCls.setDevice(d);
            reportList.setDevice(d);
            reportList.initreportList(d);
            if (d == 0 || d == 1)
            {
                // cassette o fancoil
                sysTimer.Enabled = true;
            }
            else
            {
                sysTimer.Enabled = false;
            }
            cdispositivo = d;
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

        private void msgNonConnesso()
        {
            string message = "Seriale non connessa";
            string title = "Errore";
            MessageBox.Show(message, title);
        }


        private void msgSpegniERiacendi()
        {
            string message = "Spegni e riaccendi il dispositivo";
            string title = "Errore";
            MessageBox.Show(message, title);
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            // crea string JSON
            // Master/Slave
            // Indirizzo
            // Matricola
            if (Costanti.CONNECTED != connectedStatus)
            {
                msgNonConnesso();

            }
            else
            {
                if ("00001" == textBoxMatricola.Text || "000001" == textBoxMatricola.Text || "2436019999" == textBoxMatricola.Text)
                {
                    string message = "Il numero di matricola non è stato inserito";
                    string title = "Errore";
                    MessageBox.Show(message, title);
                }
                else
                {
                    if (textBoxMatricola.Text.Length != 10)
                    {
                        string message = "Il numero di matricola deve essere di 10 caratteri";
                        string title = "Errore";
                        MessageBox.Show(message, title);
                    }
                    else
                    {

                        byte[] mm = Encoding.ASCII.GetBytes(textBoxMatricola.Text);
                        // che è formata AASSMm
                        // AA anno
                        // SS settimana
                        // Mm Modello
                        // m = 0 -> cassette
                        // m = 1 -> Fancoil
                        // m = 2 -> termostato analogico
                        // m = 3 -> tremostato Touch
                        // m = 4 -> termostato TFT
                        // per il termostato analogico M vale
                        // M = 0 manopola, Touch + LED
                        // M = 1 manopola
                        // M = 2 Slider On/Off meccanico
                        // M = 3 Slider
                        byte charValue = (byte)(cdispositivo + '0');
                        if (mm.Length > 5)
                        {
                            if (mm[5] != charValue)
                            {
                                MessageBox.Show(loca.getStr(loca.indice.INVALID_SERIAL_NUMBER), loca.getStr(loca.indice.MNET_MSG_WARNING));
                            }

                            else
                            {
                                JsonNetlist jsonMsg = new JsonNetlist();
                                String hMsg = jsonMsg.encodeNET(this);
                                reportCls.setMatricola(this.textBoxMatricola.Text);
                                // add F0 F7
                                byte[] TxMsg = clsHandler.convertForTx(hMsg);
                                txMsg.txMessageGeneric(TxMsg);
                                // fa partire un timer che rilegge i parametri per verifica
                                flgVerify = 1;
                                timerVerifica.Enabled = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show(loca.getStr(loca.indice.INVALID_SERIAL_NUMBER), loca.getStr(loca.indice.MNET_MSG_WARNING));
                        }
                    }
                }
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (Costanti.CONNECTED != connectedStatus)
            {
                msgNonConnesso();

            }
            else
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

        String currTab;
        private void timerTest_Tick(object sender, EventArgs e)
        {
            if (currTab != tabControl1.SelectedTab.Text)
            {
                currTab = tabControl1.SelectedTab.Text;
                if (Costanti.CONNECTED == connectedStatus)
                {
                    if (currTab == "TEST")
                    {

                        enterTest();
                        txMsgTest = 1;


                    }
                    else
                    {
                        txMsgTest = -1;
                        exitTest();
                    }
                }
            }
            else
            {
                requireTersData();
            }
        }

        int txMsgTest = -1;

        void exitTest()
        {
            String hMsg = "Test mode OFF";
            // add F0 F7
            byte[] TxMsg = clsHandler.convertForTx(hMsg);
            txMsg.txMessageGeneric(TxMsg);
        }

        void requireTersData()
        {
            JsonNetlist jsonReq;
            string jMSG;
            byte[] TxMsg;
            if (txMsgTest >= 0)
            {
                txMsgTest--;
                if (txMsgTest == 0)
                {
                    switch (tDisp)
                    {
                        case 0:
                        case 1:
                            jsonReq = new JsonNetlist();
                            jMSG = jsonReq.encodeTestParameter(this);
                            txMsgTest = 10;
                            TxMsg = clsHandler.convertForTx(jMSG);
                            txMsg.txMessageGeneric(TxMsg);
                            break;
                        case 2:
                            jsonReq = new JsonNetlist();
                            jMSG = jsonReq.encodeTestParameterTermoAnal(this);
                            txMsgTest = 10;
                            TxMsg = clsHandler.convertForTx(jMSG);
                            txMsg.txMessageGeneric(TxMsg);
                            break;

                    }

                }
            }
        }

        void enterTest()
        {
            resetPanelTest(); String hMsg = "Test mode ON";
            // add F0 F7
            byte[] TxMsg = clsHandler.convertForTx(hMsg);
            txMsg.txMessageGeneric(TxMsg);
            txMsgTest = 10;
        }

        private void cOMToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        int triac1;
        int triac2;

        public int getTriac1() { return triac1; }
        public int getTriac2() { return triac2; }

        void testLedTriacON()
        {
            if (triacOnOffCnt[0] >= 1 && triacOnOffCnt[1] >= 1)
            {
                pbLEDTRIACOK.Image = configuratoreSerial6._0.Resource1.LedVerdeON;
                reportList.setPass(reportList.FCTRIAC);
            }
        }

        int[] triacOnOffCnt = new int[2];
        private void btnTriac1_MouseDown(object sender, MouseEventArgs e)
        {
            btnTriac1.Image = configuratoreSerial6._0.Resource1.triac_1_on;
            triac1 = 1;
            triacOnOffCnt[0]++;
        }

        private void btnTriac1_MouseLeave(object sender, EventArgs e)
        {
            btnTriac1.Image = configuratoreSerial6._0.Resource1.triac_1_off;
            triac1 = 0;
            testLedTriacON();
        }

        private void btnTriac1_MouseUp(object sender, MouseEventArgs e)
        {
            btnTriac1.Image = configuratoreSerial6._0.Resource1.triac_1_off;
            triac1 = 0;
            testLedTriacON();
        }

        private void btnTriac2_MouseDown(object sender, MouseEventArgs e)
        {
            btnTriac2.Image = configuratoreSerial6._0.Resource1.triac_2_on;
            triac2 = 1;
            triacOnOffCnt[1]++;
            testLedTriacON();
        }

        private void btnTriac2_MouseUp(object sender, MouseEventArgs e)
        {
            btnTriac2.Image = configuratoreSerial6._0.Resource1.triac_2_off;
            triac2 = 0;
            testLedTriacON();

        }

        private void btnTriac2_MouseLeave(object sender, EventArgs e)
        {
            btnTriac2.Image = configuratoreSerial6._0.Resource1.triac_2_off;
            triac2 = 0;
            testLedTriacON();

        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!e.TabPage.Enabled)
            {
                e.Cancel = true;
                if (lblVersione.Text == "---")
                    msgSpegniERiacendi();
                else
                    msgNonConnesso();
            }
            else
            {
                switch (tDisp)
                {
                    case 0:
                    case 1:
                        CassetteFancoilGrp.Visible = true;
                        TermostatoAnalogicoGrp.Visible = false;
                        break;
                    case 2:
                        CassetteFancoilGrp.Visible = false;
                        TermostatoAnalogicoGrp.Visible = true;
                        // controlla che tipo do termostato analogico è collegato in base alla matricola
                        // il modello viene ricavato dalla matricola
                        // che è formata AASSMm
                        // AA anno
                        // SS settimana
                        // Mm Modello
                        // m = 0 -> cassette
                        // m = 1 -> Fancoil
                        // m = 2 -> termostato analogico
                        // m = 3 -> tremostato Touch
                        // m = 4 -> termostato TFT
                        // per il termostato analogico M vale
                        // M = 0 manopola, Touch + LED
                        // M = 1 manopola
                        // M = 2 Slider On/Off meccanico
                        // M = 3 Slider
                        String st = textBoxMatricola.Text.Trim();
                        if (st[4] != '0')
                        {
                            groupBoxLEDS.Visible = false;
                            groupBoxBEEP.Visible = false;
                            switch (st[4])
                            {
                                case '3':
                                case '4':
                                    groupBoxSWT.Visible = false;
                                    break;
                                case '2':
                                    pictureBoxOnOff.Image = configuratoreSerial6._0.Resource1.SliderOFF;
                                    break;

                            }
                            if (st[4] == 3 || st[4] == '1')
                            {

                            }
                        }

                        break;
                }
            }
        }



        public int getLEDR()
        {
            int l = 0;
            if (rbR100.Checked)
            {
                l = 255;
            }
            else
            {
                if (rbR50.Checked)
                {
                    l = 128;
                }
                else
                {
                    if (rbR50.Checked)
                        l = 0;
                }
            }
            return l;
        }

        public int getLEDG()
        {
            int l = 0;
            if (rbG100.Checked)
            {
                l = 255;
            }
            else
            {
                if (rbG50.Checked)
                    l = 128;
                else
                {
                    if (rbG50.Checked)
                        l = 0;
                }
            }

            return l;
        }
        public int getLEDB()
        {
            int l = 0;
            if (rbB100.Checked)
                l = 255;
            else
            {
                if (rbB50.Checked)
                {
                    l = 128;
                }
                else
                {
                    if (rbB50.Checked)
                        l = 0;
                }
            }
            return l;
        }

        public int getBeep() { return beep; }

        private void pictureBox8_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox8.Image = configuratoreSerial6._0.Resource1.SpeakerON;
            beep = 1;
            reportList.setPass(reportList.T1BEEP);
            pbLEDBEEPOK.Image = configuratoreSerial6._0.Resource1.LedVerdeON;
        }

        private void pictureBox8_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox8.Image = configuratoreSerial6._0.Resource1.SpeakerOFF;
            beep = 0;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.Image = configuratoreSerial6._0.Resource1.SpeakerOFF;
            beep = 0;
        }

        int pots;
        public void setPotAnal(int v)
        {
            int lx = sliderBck.Width;
            forgroundKnob.Width = (int)((float)(lx * v) / 65536);
            if (forgroundKnob.Width < 10)
            {
                pots = pots | 1;

            }
            if (forgroundKnob.Width > lx - 10)
            {
                pots = pots | 2;

            }
            if (pots == 3)
            {
                reportList.setPass(reportList.T1POT);
                pbLEDPOTOK.Image = configuratoreSerial6._0.Resource1.LedVerdeON;
            }

        }

        public void setOnOffAnal(int v)
        {
            if (v == 1)
            {  // Off
                LEDOnOff.Image = configuratoreSerial6._0.Resource1.LedRossoOFF;
            }
            else
            {
                LEDOnOff.Image = configuratoreSerial6._0.Resource1.LedRossoON;
                reportList.setPass(reportList.T1TOUCH);
                pbLEDTOUCHOK.Image = configuratoreSerial6._0.Resource1.LedVerdeON;

            }
        }

        public void SetRS48513Anal(int x)
        {
            int l = 0;
            while (x != 0)
            {
                if ((x & 1) != 0)
                {
                    switch (l)
                    {
                        case 0:
                            pbLED_RS48512T.Image = configuratoreSerial6._0.Resource1.LedVerdeON;
                            reportList.setPass("RS4851-2");
                            break;
                        case 1:
                            pbLED_RS4852T.Image = configuratoreSerial6._0.Resource1.LedVerdeON;
                            reportList.setPass("RS4852");
                            break;
                        case 2:
                            pbLED_RS48513T.Image = configuratoreSerial6._0.Resource1.LedVerdeON;
                            reportList.setPass("RS4851-3");
                            break;
                        case 3:
                            pbLED_RS4853T.Image = configuratoreSerial6._0.Resource1.LedVerdeON;
                            reportList.setPass("RS4853");
                            break;
                    }
                }
                x = x >> 1;
                l++;
            }
        }

        public void setNTC2Anal(int v, int err)
        {
            if (err == 1)
            {
                lblNTC2val.Text = "ERRORE";
                ledNTC2Anal.Image = configuratoreSerial6._0.Resource1.LedRossoON;
            }
            else
            {
                lblNTC2val.Text = (((float)v) / 10).ToString();
                ledNTC2Anal.Image = configuratoreSerial6._0.Resource1.LedVerdeON;
                reportList.setPass(reportList.T1NTC2);
            }
        }


        public void setNTC1Anal(int v, int err)
        {
            if (err == 1)
            {
                lblNTC1val.Text = "ERRORE";
                ledNTC1Anal.Image = configuratoreSerial6._0.Resource1.LedRossoON;
            }
            else
            {
                lblNTC1val.Text = (((float)v) / 10).ToString();
                ledNTC1Anal.Image = configuratoreSerial6._0.Resource1.LedVerdeON;
                reportList.setPass(reportList.T1NTC1);

            }
        }



        private void timerPowerOn_Tick(object sender, EventArgs e)
        {
            timerPowerOn.Enabled = false;
            openSerialWindowConnection();
        }

        int refLed = 0;
        void LEDOff50On(int l)
        {
            switch (l)
            {
                case 0:
                    LEDRossoPower.Image = configuratoreSerial6._0.Resource1.LedRossoON;
                    refLed = refLed | 1;
                    break;
                case 1:
                    LEDRossoPower.Image = configuratoreSerial6._0.Resource1.LedRossoON50;
                    refLed = refLed | 2;
                    break;
                case 2:
                    LEDRossoPower.Image = configuratoreSerial6._0.Resource1.LedRossoOFF;
                    refLed = refLed | 4;
                    break;
                case 3:
                    LEDVerdePower.Image = configuratoreSerial6._0.Resource1.LedVerdeON;
                    refLed = refLed | 8;
                    break;
                case 4:
                    LEDVerdePower.Image = configuratoreSerial6._0.Resource1.LedVerdeON50;
                    refLed = refLed | 16;
                    break;
                case 5:
                    LEDVerdePower.Image = configuratoreSerial6._0.Resource1.LedVerdeOFF;
                    refLed = refLed | 32;
                    break;

                case 6:
                    LEDBluPower.Image = configuratoreSerial6._0.Resource1.LedBluON;
                    refLed = refLed | 64;
                    break;
                case 7:
                    LEDBluPower.Image = configuratoreSerial6._0.Resource1.LedBluON50;
                    refLed = refLed | 128;
                    break;
                case 8:
                    LEDBluPower.Image = configuratoreSerial6._0.Resource1.LedBluOFF;
                    refLed = refLed | 256;
                    break;
            }
            reportList.setPass(l);
            if ((refLed & 0x07) == (1 | 2 | 4))
            {
                pbLEDROSSOOK.Image = configuratoreSerial6._0.Resource1.LedVerdeON;
            }
            if ((refLed & (8 | 16 | 32)) == (8 | 16 | 32))
            {
                PBLEDVERDEOK.Image = configuratoreSerial6._0.Resource1.LedVerdeON;
            }
            if ((refLed & (64 | 128 | 256)) == (64 | 128 | 256))
            {
                PBLEDBLUOK.Image = configuratoreSerial6._0.Resource1.LedVerdeON;
            }



        }

        private void rbLEDAnal_Click(object sender, EventArgs e)
        {
            RadioButton x = (RadioButton)sender;

            int indice = -1;
            for (int i = 0; i < RadioButtonsLEDAnal.Length && indice < 0; i++)
            {
                if (x == RadioButtonsLEDAnal[i])
                {
                    indice = i;
                    LEDOff50On(indice);
                    Debug.WriteLine(indice);
                }
            }

        }

        private void sysTimer_Tick(object sender, EventArgs e)
        {
            // correzione matricola
            if (cdispositivo == 0 || cdispositivo == 1)
            {
                // corregge matricola dispositivo
                cercaPosXX();
            }
        }

        void cercaPosXX()
        {
            // cerca la posizione della doppia xx nella matricola del dispositivo
            String zz = textBoxMatricola.Text.ToUpper();
            bool b = zz.Contains("XX");
            if (b == true)
            {
                // la metricola contiene XX
                int index = zz.IndexOf("XX");
                // yywwXXssss
                // index deve essere 4
                if (index != 4)
                {
                    msgErr.Text = "la posizione di XX è errata";
                }
                else
                {
                    msgErr.Text = "";
                    string dv = "";
                    if (cdispositivo == 0)
                        dv = "00";
                    if (cdispositivo == 1)
                        dv = "01";
                    String av = textBoxMatricola.Text.Substring(0, index);
                    av = av + dv;
                    av = av + textBoxMatricola.Text.Substring(index + 2);
                    textBoxMatricola.Text = av;
                    textBoxMatricola.SelectionStart = textBoxMatricola.Text.Length;
                    textBoxMatricola.SelectionLength = 0;

                }
            }

        }

        private void radioButtonSlave_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButtonSlave.Checked == true)
            {
                numericUpDownIndirizzoMaster.Enabled = false;
                labelIndirizzo.Enabled = false;
            }
            else
            {
                numericUpDownIndirizzoMaster.Enabled = true;
                labelIndirizzo.Enabled = true;
            }
        }


        int indice = 0;

        int[] sequenza = { 1, 1, 0, 0, 3, 3, 2, 2, 5, 5, 4, 4 };
        private void timerAutoClick_Tick(object sender, EventArgs e)
        {
            subOnOff(sequenza[indice]);
            indice++;
            if (indice == sequenza.Length)
                indice = 0;
        }

        private void btnAutotest_Click(object sender, EventArgs e)
        {
            if(timerAutoClick.Enabled == false)
            {
                timerAutoClick.Enabled = true;
                btnAutotest.Image = configuratoreSerial6._0.Resource1.autotestON;
            } else
            {
                timerAutoClick.Enabled = false;
                btnAutotest.Image = configuratoreSerial6._0.Resource1.autotestOFF;
            }
        }












        //private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int z = tabControl1.SelectedIndex;
        //    if (z == 1)
        //        initBtn();
        //}
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
