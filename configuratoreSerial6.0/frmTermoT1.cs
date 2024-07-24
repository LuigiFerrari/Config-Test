using configuratore.costStatoT1;
using configuratore.stato;
using configuratore.statoCassette;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static configuratore.frmCassette;
using static configuratore.statoCassette.frmStatoCassette;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace configuratore
{
    public partial class frmTermoT1 : Form
    {
        gbOxConfig[] LayOutT1Grp;
        clsRxBuffer rxBuffer;

        gbOx[] statoGrp;
        gbInfo cfgGbox;
        List<classGroupBoxT1> gBox;
        int progressivo;

        int parametroDaRichiedere;
        int statoDaRichiedere;
        int rchiedi;


        frmStartUp parent;
        int richiestoDa;

        const String STR_MASTER = "0";

        public int getRichiestoDa() { return richiestoDa; }
        public frmTermoT1(String Type, String Info, frmStartUp lparent, Boolean DefaultData, int lrichiestoDa)
        {
            parent = lparent;
            richiestoDa = lrichiestoDa;
            InitializeComponent();
            initData();
            constStatoT1.init();
            initStato();
            global.glbfrmT1 = this;
            gBox = new List<classGroupBoxT1>();
            progressivo = 0;
            for (int i = 0; i < LayOutT1Grp.Length; i++)
            {

                classGroupBoxT1 gbTest = new classGroupBoxT1(LayOutT1Grp[i], this);
                progressivo = gbTest.getProgresivo();
                this.Controls.Add(gbTest.getGroupBox());
                gBox.Add(gbTest);
            }
            setColorDefault();
            this.Text = Type + Info;

            clsArbitrator.setEsecuzione();
            utility.setAllVisibleInvisibile(utility.SET_INVISIBLE_START, LayOutT1Grp);
            utility.visibileInvisibile(LayOutT1Grp);
            if (DefaultData == false)
            {
                labelPleaseWait.Width = labelFondo.Width;
                labelIndice.Height = labelFondo.Height;
                labelFondo.Left = (this.Width - labelFondo.Width) / 2;
                labelIndice.Left = labelFondo.Left;
                labelFondo.Top = (this.Height - labelFondo.Height) / 2;
                labelIndice.Top = labelFondo.Top;
                labelPleaseWait.Text = loca.getStr(loca.indice.STR_CARICA_PARAMETRI);
                labelPleaseWait.Left = labelFondo.Left;
                labelPleaseWait.Top = labelFondo.Top - labelFondo.Height;
                labelPleaseWait.Visible = true;
                richiestaParametri();
                timerRxDati.Enabled = true;
                labelFondo.Visible = true;
                labelIndice.Visible = true;
                tabControl.Visible = false;

            }
            else
            {
                labelFondo.Visible = false;
                labelIndice.Visible = false;
                labelPleaseWait.Visible = false;
                utility.setAllVisibleInvisibile(0, LayOutT1Grp);
                utility.visibileInvisibile(LayOutT1Grp);
                timerRxDati.Enabled = false;
            }
            costStatoT2.init();
            initStato();
            rxBuffer = new clsRxBuffer();
        }

        public byte[] getRxBuffr() { return rxBuffer.getRxBuffer(); }
        public clsRxBuffer getRxBufferClass() { return rxBuffer; }
        private void richiestaParametri()
        {
            clsArbitrator.setDoNotLoop();
            parametroDaRichiedere = 0;
            rchiedi = 1;
            richiedi();
        }

        void richiedi()
        {
            switch (rchiedi)
            {
                case 1: // richiesta parametri
                    Debug.Write("Parametro da richiedere "); Debug.WriteLine(parametroDaRichiedere);

                    txMsg.requireParameter(parametroDaRichiedere, Costanti.BITS_DEVICE_TERMOT1 | Costanti.BITS_VIDEATA_PARAMETRI, richiestoDa);
                    labelIndice.Width = (int)((double)parametroDaRichiedere * ((double)labelFondo.Width / parametriT2.NUMERO_PARAMETRI_KT2));
                    rchiedi = 0;
                    break;
                case 2: // richiesta stati
                    txMsg.requireParameter(statoDaRichiedere, Costanti.BITS_DEVICE_TERMOT1 | Costanti.BITS_VIDEATA_STATO, richiestoDa);
                    // Debug.Write("Stato da richiedere "); Debug.WriteLine(statoDaRichiedere);
                    rchiedi = 0;
                    break;

            }

        }

        void continuaRichiesta()
        {
            if (parametroDaRichiedere >= 0)
            {
                rchiedi = 1;
                parametroDaRichiedere++;
                if (parametroDaRichiedere < parametriT2.NUMERO_PARAMETRI_KT2)
                {
                    richiedi();
                }
                else
                {
                    // PASSA ALLA RICHIESTA STATO
                    rchiedi = 2;
                    parametroDaRichiedere = -1;
                    statoDaRichiedere = 0;
                    // timerRxDati.Enabled = false;
                    labelFondo.Visible = false;
                    labelIndice.Visible = false;
                    labelPleaseWait.Visible = false;
                    clsArbitrator.clrEsecuzione();
                    clsArbitrator.clrDoNotLoop();
                    utility.setAllVisibleInvisibile(0, LayOutT1Grp);
                    utility.visibileInvisibile(LayOutT1Grp);
                    tabControl.Visible = true;
                    richiedi();
                }
            }

        }


        void continuaRichiestaStato(int skip)
        {
            rchiedi = 2;
            parametroDaRichiedere = -1;
            statoDaRichiedere = statoDaRichiedere + skip;

            if (statoDaRichiedere >= costStatoT2.T2S_NUMERO_STATI)
            {
                rchiedi = 0;
                statoDaRichiedere = -1;
                timerRefresh.Enabled = true;
            }
            else
            {
                // timerRxDati.Enabled = false;
                //labelFondo.Visible = false;
                //labelIndice.Visible = false;
                //labelPleaseWait.Visible = false;
                clsArbitrator.clrEsecuzione();
                clsArbitrator.clrDoNotLoop();
                //utility.setAllVisibleInvisibile(0, LayOutT1Grp);
                //utility.visibileInvisibile(LayOutT1Grp);
                // tabControl.Visible = true;
                richiedi();
            }
        }

        private void setColorDefault()
        {
            coloreLEDcmd.BackColor = coloreLEDcmd.BackColor = Color.FromArgb(255, (int)nud_0_00.Value, (int)nud_0_01.Value, (int)nud_0_02.Value);
        }

        public void aggiornaStato(int p, byte[] buffer, int pos)
        // p = numero stato
        // buffer = buffer ricezione (F0 ... F7
        // pos = posizione del segno
        {
            int g;
            int j;
            int v;
            int trovato = -1;
            string s = "";

            int skipNum = 1;

            //for (g = 0; buffer[g] != 0xf7; g++)
            //{
            //    Debug.Write(buffer[g].ToString("X2"));
            //    Debug.Write(" ");
            //}

            //Debug.WriteLine("F7");
            // ricava la lunghezza dei dati
            int nbyte = costStatoT2.getSizeStato(p);
            //Debug.Write("Stato ");
            //Debug.Write(p);
            //Debug.Write(" nbyte ");
            //Debug.Write(nbyte);
            //Debug.Write("  ");

            for (g = 0; g < statoGrp.Length && trovato < 0; g++)
            {
                if (statoGrp[g].vvParametro != null)
                {
                    for (j = 0; j < statoGrp[g].vvParametro.Length && trovato < 0; j++)
                    {
                        if (statoGrp[g].vvParametro[j] == p)
                        {
                            // trovato
                            trovato = j;
                            switch (costStatoT2.getTipoParametro(p))
                            {
                                case 'B':
                                    v = utility.conv728(buffer, pos + 1, nbyte);

                                    setAlarm(statoGrp[g].valLabel[j], v);

                                    // Debug.WriteLine(v);
                                    break;
                                case 'S':
                                    s = "";
                                    for (int i = 0; i < costAl.MAX_SIZE_STRING; i++)
                                        s = s + (char)buffer[pos + i + 1];
                                    statoGrp[g].valLabel[j].Text = s;
                                    skipNum = costAl.MAX_SIZE_STRING / 2;
                                    // Debug.WriteLine(s);
                                    break;
                                case 'N':
                                    v = utility.conv728(buffer, pos + 1, nbyte);
                                    int d = costStatoT2.getdecimali(p);
                                    s = utility.convertToString(v, d);

                                    if (p == costStatoT2.T2S_MASTERSLAVE)
                                    {
                                        if (s == STR_MASTER)
                                        {
                                            s = "M";
                                        }
                                        else
                                            s = "S";
                                    }

                                    if (p == costStatoT2.T2S_ON_OFF)
                                    {
                                        if (v == 0)
                                            s = "OFF";
                                        else
                                            s = "ON";
                                    }
                                    if (gestioneErrori(p, g, j) == 0)
                                    {
                                        // se deve aggiornare va a vedere se il campo va a vedere se
                                        // il campo è T2S_REAL_SETPOINT_TEMP
                                        // In tal caso il campo non deve essere aggiornato
                                        if (p == costStatoT2.T2S_DEVIAZIONE_SETPOINT)
                                            deviazioneMaxMinSetPoint = utility.fromStringToFolat(s);
                                        if (p == costStatoT2.T2S_DEFAULT_SETPOINT)
                                            defaultSetPoint = utility.fromStringToFolat(s);
                                        if (p == costStatoT2.T2S_TEMP_SETPOINT)
                                            discreteSetPoint = (int)utility.fromStringToFolat(s);
                                        if (p == costStatoT2.T2S_REAL_SETPOINT_TEMP)
                                        {
                                            updateSetpointReale(g, j, p);
                                        }
                                        else
                                            statoGrp[g].valLabel[j].Text = s;
                                    }



                                    if (p == costStatoT2.T2S_TEMP_SETPOINT)
                                        discreteSetPoint = (int)utility.fromStringToFolat(s);
                                    // Debug.WriteLine(s);
                                    break;
                            }

                        }

                    }

                }
            }
            if (trovato < 0)
            {
                Debug.WriteLine("Stato " + p.ToString() + " non in videata");

            }


            writeLogFile();
            if (trovato >= 0)
            {
                //Debug.Write("Aggiorno ");
                // Debug.WriteLine(p);
            }
            continuaRichiestaStato(skipNum);
            //Debug.Write("Richiedo ");
            //Debug.Write(statoDaRichiedere);
            //Debug.Write(" ");

        }

        int gestioneErrori(int p, int g, int j)
        {
            _sgp ret = new _sgp();
            ret.gruppo = -1;
            ret.posizione = -1;
            int err = 0;
            switch (p)
            {
                case costStatoT2.T2S_TEMP_NTCEXT:
                    ret = cercaGruppoeOisizione(costStatoT2.T2S_ERR_NTCEXT);
                    break;
                case costStatoT2.T2S_TEMP_NTC1:
                    ret = cercaGruppoeOisizione(costStatoT2.T2S_ERR_NTC1);
                    break;
                case costStatoT2.T2S_ERR_NTCBOARD:
                    ret = cercaGruppoeOisizione(costStatoT2.T2S_ERR_NTCBOARD);
                    break;
            }
            if (ret.gruppo >= 0 && ret.posizione >= 0)
            {
                if (statoGrp[ret.gruppo].valLabel[ret.posizione].BackColor == errColor)
                {
                    statoGrp[g].valLabel[j].Text = "--";
                    err = -1;
                }
            }
            return err;
        }

        void updateSetpointReale(int gruppo, int posizione, int p)
        {
            {
                // ricalcola setpoint reale
                // legge le variabili grafiche
                _sgp ret = new _sgp();
                ret.gruppo = -1;
                ret.posizione = -1;

                ret = cercaGruppoeOisizione(costStatoT2.T2S_REAL_SETPOINT_TEMP);
                if (ret.gruppo >= 0 && ret.posizione >= 0)
                {
                    // ricalcola tutto
                    int v = 0;
                    float nuovoSetPoint = defaultSetPoint + adjustSetpoint();
                    int d = costStatoT2.getdecimali(costStatoT2.T2S_REAL_SETPOINT_TEMP);
                    nuovoSetPoint = nuovoSetPoint * utility.potDieci(d);
                    statoGrp[ret.gruppo].valLabel[ret.posizione].Text = utility.convertToString((int)nuovoSetPoint, d);
                }
            }
        }

        Color errColor = Color.Red;

        void setAlarm(Label l, int v)
        {
            if (v != 0)
            {
                l.BackColor = errColor;
            }
            else
            {
                l.BackColor = Color.Gray;
            }
        }

        const int MASTER = 0;
        const int SLAVE = 1;



        private void t1_rb_1_00_TipDisp_MASTER_CheckedChanged(object sender, EventArgs e)
        {
            abilitaDisabilitaParRete(MASTER);
        }

        private void t1_rb_1_00_TipDisp_SLAVE_CheckedChanged(object sender, EventArgs e)
        {
            abilitaDisabilitaParRete(SLAVE);

        }


        void abilitaDisabilitaParRete(int a)
        {
            t1_lbl_1_01_Indirizzo.Enabled = (a == MASTER);
            t1_lbl_1_02_Baudrate.Enabled = (a == MASTER);
            t1_lbl_1_03_Parita.Enabled = (a == MASTER);
            t1_lbl_1_04_StopBit.Enabled = (a == MASTER);

            t1_nud_1_01_Indirizzo.Enabled = (a == MASTER);
            t1_cb_1_02_Baudrate.Enabled = (a == MASTER);
            t1_cb_1_03_Parita.Enabled = (a == MASTER);
            t1_cb_1_04_StopBit.Enabled = (a == MASTER);
        }
        public void aggiornaParametro(int p, byte[] buffer, int pos)
        // p = numero parametro
        // buffer = buffer ricezione (F0 ... F7
        // pos = posizione del segno
        {
            int g;
            int j;
            int v;
            int trovato = -1;
            int nbyte = parametriT2.calcolaSizeParametro(p);

            for (g = 0; g < LayOutT1Grp.Length && trovato < 0; g++)
            {
                if (LayOutT1Grp[g].cfgCombo != null)
                {
                    for (j = 0; j < LayOutT1Grp[g].cfgCombo.Length && trovato < 0; j++)
                    {
                        if (LayOutT1Grp[g].cfgCombo[j].numParametro == p)
                        {
                            // trovato
                            trovato = j;
                            v = utility.conv728(buffer, pos + 1, nbyte);
                            LayOutT1Grp[g].cfgCombo[j].combo.SelectedIndex = v;
                            // campoDinamico(p, g, j, v);
                        }

                    }

                }
                // ----------------------------------
                if (LayOutT1Grp[g].cfgUpDown != null)
                {
                    for (j = 0; j < LayOutT1Grp[g].cfgUpDown.Length && trovato < 0; j++)
                    {
                        if (LayOutT1Grp[g].cfgUpDown[j].numParametro == p)
                        {
                            // trovato
                            trovato = j;
                            // trasformare decimali
                            v = utility.conv728(buffer, pos + 1, nbyte);
                            decimal d = utility.convert2Decimal(v, LayOutT1Grp[g].cfgUpDown[j].nDec);
                            LayOutT1Grp[g].cfgUpDown[j].numUpDown.Value = d;
                            // calcoli(p);
                            // campoDinamico(p, g, j, v);
                        }

                    }
                }
                // ----------------------------------
                if (LayOutT1Grp[g].cfgRadioButton != null)
                {
                    for (j = 0; j < LayOutT1Grp[g].cfgRadioButton.Length && trovato < 0; j++)
                    {
                        if (LayOutT1Grp[g].cfgRadioButton[j].numParametro == p)
                        {
                            // trovato
                            trovato = j;
                            v = utility.conv728(buffer, pos + 1, nbyte);
                            for (int k = 0; k < LayOutT1Grp[g].cfgRadioButton[trovato].rButton.Length; k++)
                            {
                                LayOutT1Grp[g].cfgRadioButton[trovato].rButton[k].Checked = (k == v);
                            }
                            // ampoDinamico(p, g, j, v);
                        }

                    }
                }
            }
            // ----------------------------------
            if (trovato >= 0)
                continuaRichiesta();
            else
            {
                Debug.WriteLine("Parametro Non trovato " + p.ToString());
                continuaRichiesta();
            }


        }

        void initData()
        {
            LayOutT1Grp = new gbOxConfig[] {
                new gbOxConfig()
                {
                    cfgGbox = new gbInfo()
                    {
                        gpBox = t1_gb_0,
                        testo = loca.indice.T1_GB_0,
                    },
                     cfgLabel = new lblInfo[] {
                         new lblInfo() {
                             lbl = t1_lbl_0_00,
                             testo = loca.indice.T1_LBL_0_00
                         },
                         new lblInfo() {
                             lbl = t1_lbl_0_01,
                             testo = loca.indice.T1_LBL_0_01
                         },
                         new lblInfo() {
                             lbl = t1_lbl_0_02,
                             testo = loca.indice.T1_LBL_0_02
                         },
                         new lblInfo() {
                             lbl = t1_lbl_0_03,
                             testo = loca.indice.T1_LBL_0_03
                         },
                         new lblInfo() {
                             lbl = t1_lbl_0_04,
                             testo = loca.indice.T1_LBL_0_04
                         },

                           new lblInfo()    {
                            lbl = t2_lbl_0_10,
                            testo = loca.indice.T2_LBL_0_06
                        },
                          new lblInfo()    {
                            lbl = t2_lbl_0_11,
                            testo = loca.indice.T2_LBL_0_07
                        },
                          new lblInfo()    {
                            lbl = t2_lbl_0_12,
                            testo = loca.indice.T2_LBL_0_08
                        },
                         new lblInfo()
                        {
                            lbl=t1_lbl_s0_14,
                            testo= loca.indice.T2_LBL_1_01,
                        }
                     },

                     cfgUpDown = new upDownInfo[]
                    {
                        new upDownInfo
                        {
                            numUpDown = nud_0_00, // 0
                            numParametro = parametriT1.KT2_R_COMMAND,
                            vDefault =(decimal)255,vMin =(decimal) 0,vMax =(decimal) 255,vInc =(decimal) 1,nDec =(int) 0
                        },
                          new upDownInfo
                        {
                            numUpDown = nud_0_01, // 1
                            numParametro = parametriT1.KT2_G_COMMAND,
                            vDefault =(decimal)255,vMin =(decimal) 0,vMax =(decimal) 255,vInc =(decimal) 1,nDec =(int) 0
                        },
                            new upDownInfo
                        {
                            numUpDown = nud_0_02, // 2
                            numParametro = parametriT1.KT2_B_COMMAND,
                            vDefault =(decimal)255,vMin =(decimal) 0,vMax =(decimal) 255,vInc =(decimal) 1,nDec =(int) 0
                        },
                        new upDownInfo
                        {
                            numUpDown = nud_0_03, // 3
                            numParametro = parametriT1.KT2_FULL,
                            vDefault =(decimal)100,vMin =(decimal) 1,vMax =(decimal) 100,vInc =(decimal) 1,nDec =(int) 0
                        },
                        new upDownInfo
                        {
                            numUpDown = nud_0_04, // 3
                            numParametro = parametriT1.KT2_TEMP_ON,
                            vDefault =(decimal)5,vMin =(decimal) 1,vMax =(decimal) 60,vInc =(decimal) 1,nDec =(int) 0
                        },
                          new upDownInfo
                        {
                            numUpDown = nud_0_05, // 4
                            numParametro = parametriT1.KT2_DIMMER,
                            vDefault =(decimal)50,vMin =(decimal) 1,vMax =(decimal) 100,vInc =(decimal) 1,nDec =(int) 0
                        },
                            new upDownInfo
                        {
                            numUpDown = nud_0_06, // 5
                            numParametro = parametriT1.KT2_TEMP_OFF,
                            vDefault =(decimal)5,vMin =(decimal) 0,vMax =(decimal) 60,vInc =(decimal) 1,nDec =(int) 0
                        },
                            new upDownInfo
                        {
                            numUpDown = nud_0_07, // 5
                            numParametro = parametriT1.KT2_COMP_P1,
                            vDefault =(decimal)0,vMin =(decimal) 0,vMax =(decimal) 10,vInc =(decimal) 0.1,nDec =(int) 1
                        },
                            new upDownInfo
                        {
                            numUpDown = nud_0_08, // 5
                            numParametro = parametriT1.KT2_COMP_P2,
                            vDefault =(decimal)0,vMin =(decimal) 0,vMax =(decimal) 2,vInc =(decimal) 0.01,nDec =(int) 2
                        },
                    },
                     cfgRadioButton = new radioButtonInfo[]
                    {
                            new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { t1_rb_s0_1_0, t1_rb_s0_1_1 },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.VUOTO, loca.indice.VUOTO },
                                numParametro = parametriT1.KT2_NTC_ENABLE,
                                vDefault = new int[] { 1, 0 },
                            },
                            new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_0_1_00_ON, rb_0_1_01_OFF },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.OFF, loca.indice.ON },
                                numParametro = parametriT1.KT2_BUZZER_ON_OFF,
                                vDefault = new int[] { 0, 1},
                            }

                        },
                }, // GB 0
                new gbOxConfig() // --- GB 1 -> impostazioni rete
                {
                    cfgGbox = new gbInfo()
                    {
                        gpBox = t1_gb_1,
                        testo = loca.indice.T1_GB_1,
                    },
                     cfgLabel = new lblInfo[] {
                         new lblInfo() {
                             lbl = t1_lbl_1_00_TipDisp,
                             testo = loca.indice.T1_LBL_1_00
                         },
                         new lblInfo() {
                             lbl = t1_lbl_1_01_Indirizzo,
                             testo = loca.indice.FC_LBL_13_01
                         },
                         new lblInfo() {
                             lbl = t1_lbl_1_02_Baudrate,
                             testo = loca.indice.FC_LBL_13_02
                         },
                         new lblInfo() {
                             lbl = t1_lbl_1_03_Parita,
                             testo = loca.indice.FC_LBL_13_03
                         },
                        new lblInfo() {
                             lbl = t1_lbl_1_04_StopBit,
                             testo = loca.indice.FC_LBL_13_04
                         }
                     },
                      cfgRadioButton = new radioButtonInfo[]
                    {
                            new radioButtonInfo()
                            {
                                rButton = new RadioButton[] {  t1_rb_1_00_TipDisp_MASTER, t1_rb_1_00_TipDisp_SLAVE},
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.FC_RB_LBL_13_00, loca.indice.FC_RB_LBL_13_01 },
                                vDefault = new int[] { 1, 0 },
                                numParametro = parametriT1.KT2_TIPO_DISPOSITIVO_MS,
                            }
                    },

                     cfgCombo = new comboInfo[]
                     {

                            new comboInfo() {
                             combo = t1_cb_1_02_Baudrate,
                             lista = new loca.indice[] { loca.indice.FC_CB_13_00_2400, loca.indice.FC_CB_13_00_4800, loca.indice.FC_CB_13_00_9600, loca.indice.FC_CB_13_00_19200, loca.indice.FC_CB_13_00_19200,loca.indice.FC_CB_13_00_57600,loca.indice.FC_CB_13_00_115200, },
                             vDefault = 2,
                             numParametro = parametriT1.KT2_BAUDRATE,
                        },
                           new comboInfo() {
                             combo = t1_cb_1_03_Parita,
                             lista = new loca.indice[] { loca.indice.FC_CB_13_01_00_NESSUNA, loca.indice.FC_CB_13_01_00_PARI, loca.indice.FC_CB_13_01_00_DISPARI, },
                             vDefault = 0,
                             numParametro = parametriT1.KT2_PARITA,
                        },
                             new comboInfo() {
                             combo = t1_cb_1_04_StopBit,
                             lista = new loca.indice[] { loca.indice.FC_CB_13_02_BITSTOP_1, loca.indice.FC_BC_13_02_BITSTOP_2 },
                             vDefault = 0,
                             numParametro = parametriT1.KT2_BITSTOP,
                        },
                     }

                }, // GB 1
            };
        }


        void initStato()
        {
            statoGrp = new gbOx[]
         {
                new gbOx()    // ---------- 0
                {
                    SgpBox = new box()
                        {
                            gpBox = t1_gb_0_stato,
                            text = lStat.Indice.T1_GB_S0
                        },
                    infoLabel = new sLabel[]
                    {
                        new sLabel()
                        {
                            mlabel = t1_lbl_s0_00,
                             text=lStat.Indice.T1_LBL_S0_00,   // Temp NTC1
                        },
                        new sLabel()
                        {
                            mlabel = t1_lbl_s0_01,
                            text=lStat.Indice.T1_LBL_S0_02, // Temp NTC EXT
                        },

                        new sLabel()
                        {
                            mlabel = t1_lbl_s0_02,
                            text=lStat.Indice.T1_LBL_S0_03, // // Temp NTC BOARD
                        },

                        new sLabel()
                        {
                            mlabel = t1_lbl_s0_03,
                            text = lStat.Indice.T1_LBL_S0_04,
                        },
                         new sLabel()
                        {
                            mlabel = t1_lbl_s0_04,
                            text = lStat.Indice.T1_LBL_S0_05,
                        },
                        new sLabel()
                        {
                            mlabel = t1_lbl_s0_14,
                            text =lStat.Indice.T2_LBL_S2_00,
                        },
                         new sLabel()
                        {
                            mlabel = t1_lbl_s0_15,
                            text = lStat.Indice.T2_LBL_S2_01,
                        },
                    },
                    valLabel = new Label[] { val_s0_00,val_s0_01, val_s0_02,val_s0_03, val_s0_04,val_s0_05,val_s0_07,val_s0_08,val_s0_09,val_s0_15,val_s0_16 },
                    vvParametro = new int[] {
                        constStatoT1.T2S_TEMP_NTC1,
                        constStatoT1.T2S_TEMP_NTCEXT,
                        constStatoT1.T2S_TEMP_NTCBOARD,
                        constStatoT1.T2S_REAL_SETPOINT_TEMP,
                        constStatoT1.T2S_ALIM_VOLT,
                        constStatoT1.T2S_TEMP_SETPOINT,
                        constStatoT1.T2S_ERR_NTC1,
                        constStatoT1.T2S_ERR_NTCEXT,
                        constStatoT1.T2S_ERR_NTCBOARD,
                        constStatoT1.T2S_DEFAULT_SETPOINT,
                        constStatoT1.T2S_DEVIAZIONE_SETPOINT },
                },   // ---------- 0
                new gbOx()    // ---------- 0
                 {
                    SgpBox = new box()
                        {
                            gpBox = t1_gb_s1_forzature,
                            text = lStat.Indice.TXT_gbForzature,
                        }
                  },
                new gbOx() {
                        SgpBox = new box()
                        {
                            gpBox = t1_gb_s2_matricola,
                            text = lStat.Indice.T1_GB_S2,
                        },
                        infoLabel = new sLabel[]
                    {
                        new sLabel()
                        {
                            mlabel = t1_lbl_s2_00,
                            text = lStat.Indice.T1_LBL_S2_00
                        },
                        new sLabel()
                        {
                            mlabel = t2_lbl_s2_01,
                            text = lStat.Indice.T1_LBL_S2_01
                        },

                        new sLabel()
                        {
                            mlabel = t2_lbl_s2_02,
                            text = lStat.Indice.T1_LBL_S2_02,
                        },
                    },
                        valLabel = new Label[] { t1_val_s2_00, t1_val_s2_01, t1_val_s2_02 },
                        vvParametro = new int[] { constStatoT1.T2S_MATRICOLA_00,  constStatoT1.T2S_MASTERSLAVE, constStatoT1.T2S_INDIRIZZO_SLAVE }
                   },   // ---------- 0
          };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            coloreLEDcmd.BackColor = colorDialog1.Color;
            nud_0_00.Value = coloreLEDcmd.BackColor.R;
            nud_0_01.Value = coloreLEDcmd.BackColor.G;
            nud_0_02.Value = coloreLEDcmd.BackColor.B;
        }

        public void campoDinamico(int parametro, int valore)
        {
            switch (parametro)
            {
                case parametriT1.KT2_R_COMMAND:
                    coloreLEDcmd.BackColor = Color.FromArgb(255, valore, coloreLEDcmd.BackColor.G, coloreLEDcmd.BackColor.B);
                    break;
                case parametriT1.KT2_G_COMMAND:
                    coloreLEDcmd.BackColor = Color.FromArgb(255, coloreLEDcmd.BackColor.R, valore, coloreLEDcmd.BackColor.B);
                    break;
                case parametriT1.KT2_B_COMMAND:
                    coloreLEDcmd.BackColor = Color.FromArgb(255, coloreLEDcmd.BackColor.R, coloreLEDcmd.BackColor.G, valore);
                    break;
            }
        }

        private void frmTermoT1_Load(object sender, EventArgs e)
        {
            setLangage();
            // costAl.
            updateAllLAbel();
        }

        float deviazioneMaxMinSetPoint = -1;
        int discreteSetPoint = -1;
        float defaultSetPoint = -1;

        public void setLangage()
        {
            int i;
            int j;
            for (i = 0; i < statoGrp.Length; i++)
            {
                statoGrp[i].SgpBox.gpBox.Text = lStat.getStr(statoGrp[i].SgpBox.text);
                if (statoGrp[i].infoLabel != null)
                {
                    for (j = 0; j < statoGrp[i].infoLabel.Length; j++)
                        statoGrp[i].infoLabel[j].mlabel.Text = lStat.getStr(statoGrp[i].infoLabel[j].text);
                }
            }

            for (i = 0; i < LayOutT1Grp.Length; i++)
            {
                LayOutT1Grp[i].cfgGbox.gpBox.Text = loca.getStr(LayOutT1Grp[i].cfgGbox.testo);
                if (LayOutT1Grp[i].cfgLabel != null)
                {
                    for (j = 0; j < LayOutT1Grp[i].cfgLabel.Length; j++)
                        LayOutT1Grp[i].cfgLabel[j].lbl.Text = loca.getStr(LayOutT1Grp[i].cfgLabel[j].testo);
                }
            }

        }

        void updateAllLAbel()
        {
            int g;
            int l;
            constStatoT1.lbl r;
            for (g = 0; g < statoGrp.Length; g++)
            {
                if (statoGrp[g].valLabel != null)
                {
                    for (l = 0; l < statoGrp[g].valLabel.Length; l++)
                    {
                        int p = statoGrp[g].vvParametro[l];

                        r = constStatoT1.getFormatStato(p);
                        statoGrp[g].valLabel[l].Text = r.Text;
                        if (r.NochangeColor == true)
                        {
                            statoGrp[g].valLabel[l].BackColor = r.bckColor;
                        }

                    }
                }
            }
        }

        private void timerRxDati_Tick(object sender, EventArgs e)
        {
            int d;
            if (parametroDaRichiedere >= 0)
                d = clsSerial.pop(Costanti.BITS_DEVICE_TERMOT1 | Costanti.BITS_VIDEATA_PARAMETRI);
            else
                d = clsSerial.pop(Costanti.BITS_DEVICE_TERMOT1 | Costanti.BITS_VIDEATA_STATO);
            // Debug.WriteLine("----------------------");
            while (d >= 0)
            {
                byte b = (byte)(d & 0xff);
                clsHandler.decode(b, this);
                // handelrData
                if (parametroDaRichiedere >= 0)
                    d = clsSerial.pop(Costanti.BITS_DEVICE_TERMOT1 | Costanti.BITS_VIDEATA_PARAMETRI);
                else
                    d = clsSerial.pop(Costanti.BITS_DEVICE_TERMOT1 | Costanti.BITS_VIDEATA_STATO);

            }
        }




        struct _sgp
        {
            public int gruppo;
            public int posizione;
        };
        _sgp cercaGruppoeOisizione(int p)
        {
            int g;
            int j;
            _sgp ret = new _sgp();
            ret.gruppo = -1;
            ret.posizione = -1;

            int trovato = -1;
            for (g = 0; g < statoGrp.Length && trovato < 0; g++)
            {
                if (statoGrp[g].vvParametro != null)
                {
                    for (j = 0; j < statoGrp[g].vvParametro.Length && trovato < 0; j++)
                    {
                        if (statoGrp[g].vvParametro[j] == p)
                        {
                            // trovato
                            trovato = j;
                            ret.gruppo = g;
                            ret.posizione = j;
                        }

                    }
                }
            }
            if (trovato < 0)
            {
                Debug.WriteLine("Stato " + p.ToString() + " non in videata");
            }
            return ret;
        }
        float adjustSetpoint()
        {
            float ret = 0;
            float maxStep = (deviazioneMaxMinSetPoint / 10) * 2;
            ret = (float)(discreteSetPoint - 5) * maxStep;
            return ret;
        }

        StreamWriter writer;
        String oldTempo = "";
        void writeLogFile()
        {
            // val_s0_00, val_s0_01, val_s0_02
            if (button2.Text != "Selezione file di Log")
            {
                DateTime localDate = DateTime.Now;
                String tempo = localDate.ToString("HH:mm");
                if (tempo != oldTempo)
                {
                    oldTempo = tempo;
                    writer.WriteLine(tempo + "\t" + val_s0_00.Text + "\t" + val_s0_01.Text + "\t" + val_s0_03.Text);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Selezione file di Log")
            {


                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Text file|*.txt";
                saveFileDialog1.Title = "Seleziona un file di testo per salvare i dati";
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {
                    writer = File.CreateText(saveFileDialog1.FileName);
                    button2.Text = "Chiudi file di Log";
                    writer.WriteLine("TIME\tNTC1\tNTC EXT.\tNTC BOARD");

                }

            }
            else
            {
                writer.Close();
                button2.Text = "Selezione file di Log";
            }
        }

        private void btn_s1__00_LED_ROSSO_Click(object sender, EventArgs e)
        {
            int l = 0;
            OffAll(l);
            toggleStato(l);
            if (isStatoInON(l))
            {
                btn_s1__00_LED_ROSSO.Image = global::configuratoreSerial6._0.Resource1.LedRossoON;
            }
            else
            {
                btn_s1__00_LED_ROSSO.Image = global::configuratoreSerial6._0.Resource1.LedRossoOFF;
            }
            txMsg.txMsgOne(parametriT2.KT2_V_ROSSO, getStato(l), richiestoDa);
        }




        int[] statoLED = new int[3];

        private void toggleStato(int s)
        {
            if (statoLED[s] == 0)
                statoLED[s] = 1;
            else
                statoLED[s] = 0;
        }
        private Boolean isStatoInON(int s) { return statoLED[s] == 1; }
        int getStato(int l) { return statoLED[l]; }
        private void OffAll(int l)
        {
            switch (l)
            {
                case 0:
                    statoLED[1] = 0;
                    statoLED[2] = 0;
                    btn_s1__01_LED_VERDE.Image = global::configuratoreSerial6._0.Resource1.LedVerdeOFF;
                    btn_s1__02_LED_BLU.Image = global::configuratoreSerial6._0.Resource1.LedBluOFF;
                    break;
                case 1:
                    statoLED[0] = 0;
                    statoLED[2] = 0;
                    btn_s1__02_LED_BLU.Image = global::configuratoreSerial6._0.Resource1.LedBluOFF;
                    btn_s1__00_LED_ROSSO.Image = global::configuratoreSerial6._0.Resource1.LedRossoOFF;
                    break;
                case 2:
                    statoLED[0] = 0;
                    statoLED[1] = 0;
                    btn_s1__00_LED_ROSSO.Image = global::configuratoreSerial6._0.Resource1.LedRossoOFF;
                    btn_s1__01_LED_VERDE.Image = global::configuratoreSerial6._0.Resource1.LedVerdeOFF;
                    break;


            }
        }

        private void btn_s1__01_LED_VERDE_Click(object sender, EventArgs e)
        {
            int l = 1;
            OffAll(l);
            toggleStato(l);
            if (isStatoInON(l))
            {
                btn_s1__01_LED_VERDE.Image = global::configuratoreSerial6._0.Resource1.LedVerdeON;
            }
            else
            {
                btn_s1__01_LED_VERDE.Image = global::configuratoreSerial6._0.Resource1.LedVerdeOFF;
            }
            txMsg.txMsgOne(parametriT2.KT2_V_VERDE, getStato(l), richiestoDa);
        }

        void offForzature()
        {
            txMsg.txMsgOne(parametriT2.KT2_V_ROSSO, 0, richiestoDa);
            txMsg.txMsgOne(parametriT2.KT2_V_VERDE, 0, richiestoDa);
            txMsg.txMsgOne(parametriT2.KT2_V_BLU, 0, richiestoDa);
            txMsg.txMsgOne(parametriT2.KT2_V_FORZ_SETPOINT_ONOFF, 0, richiestoDa);
        }

        private void btn_s1__02_LED_BLU_Click(object sender, EventArgs e)
        {
            int l = 2;
            OffAll(l);
            toggleStato(l);
            if (isStatoInON(l))
            {
                btn_s1__02_LED_BLU.Image = global::configuratoreSerial6._0.Resource1.LedBluON;
            }
            else
            {
                btn_s1__02_LED_BLU.Image = global::configuratoreSerial6._0.Resource1.LedBluOFF;
            }
            txMsg.txMsgOne(parametriT2.KT2_V_BLU, getStato(l), richiestoDa);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void frmTermoT1_FormClosing(object sender, FormClosingEventArgs e)
        {
            clsArbitrator.clrEsecuzione();
            //clsArbitrator.clrLoadingParameter();
            if (richiestoDa == 0)
                parent.abilitaMenu();
            else
                clsArbitrator.setriabilitaBottoni();
            // blocca eventuali forzature
            offForzature();
        }


        struct retStat
        {
            public Image img;
            public String txt;
        }

        const String V_OFF = "  ";
        const String V_ON = " ";
        retStat toggleStatus(Button b)
        {
            retStat x;
            if (b.Text == V_OFF)
            {
                x.txt = V_ON;
                x.img = global::configuratoreSerial6._0.Resource1.FrecciaDestraON;
            }
            else
            {
                x.txt = V_OFF;
                x.img = global::configuratoreSerial6._0.Resource1.FrecciaDestraOFF;
            }
            return x;
        }
        int getStato(Button b)
        {
            int x;
            if (b.Text == V_OFF)
            {
                x = 0;
            }
            else
            {
                x = 1;
            }
            return x;
        }

        private void t2_s1_btn_00_Click(object sender, EventArgs e)
        {
            retStat y;
            y = toggleStatus(t2_s1_btn_00);
            t2_s1_btn_00.Image = y.img;
            t2_s1_btn_00.Text = y.txt;
            txMsg.txMsgOne(parametriT2.KT2_V_FORZ_SETPOINT_ONOFF, getStato(t2_s1_btn_00), richiestoDa);
        }



        private void t2_s1_nud_00_ValueChanged(object sender, EventArgs e)
        {
            txMsg.txMsg2(parametriT2.KT2_V_FORZ_SETPOINT_VALORE, (int)t2_s1_nud_00.Value * 10, richiestoDa);
        }

        void abilitaTimerRichiesta()
        {
            statoDaRichiedere = 0;
            rchiedi = 2;
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {

            abilitaTimerRichiesta();
            richiedi();
            timerRefresh.Enabled = false;

        }



        private void nud_0_06_ValueChanged_1(object sender, EventArgs e)
        {
            if (nud_0_06.Value == 0)
            {
                nud_0_06.BackColor = Color.Black;
            }
            else
            {
                nud_0_06.BackColor = Color.White;

            }
        }

        private void timerUnSecondo_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < gBox.Count; i++)
                gBox[i].Tick(LayOutT1Grp[i]);


        }
    }
}





