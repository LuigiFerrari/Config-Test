using configuratoreSerial6._0;
using configuratoreSerial6._0.uniqueID;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static configuratore.frmCassette;
using static configuratore.statoCassette.frmStatoCassette;


namespace configuratore
{
    public partial class frmFanCoil : Form
    {
        gbOxConfig[] LayOutFanCoilGrp;
        int parametroDaRichiedere;
        int rchiedi;
        String FileName;
        int progressivo;
        int richiestoDa;
        int indirizzo;
        List<ClassGroupBoxFanCoil> gBox;
        frmStartUp parent;
        clsRxBuffer rxBuffer;
        int oldPrimaryValue;

        String CurrentFileName = "";

        public int getRichiestoDa() { return richiestoDa; }
        public int getIndirizzo() { return indirizzo; }
        public frmFanCoil(String Type, String Info, frmStartUp lparent, Boolean DefaultData, int lrichiestoDa)
        {
            InitializeComponent();
            initListDamper();
            initDatiLayout();
            initDisabilitazioni();
            comTask.InitcomTask();

            global.glbfrmFanCoil = this;
            parent = lparent;
            FileName = "";
            String sRichiestoDa = "";
            gBox = new List<ClassGroupBoxFanCoil>();
            progressivo = 0;
            progressivo = 0;
            richiestoDa = lrichiestoDa & Costanti.RICHIESTA_DA_MASTER;
            if (richiestoDa != 0)
                sRichiestoDa = " (MASTER)";  // inica se sono collegato alla pagina dal MASTER oppure sono connesso direttamente allo slave
            indirizzo = lrichiestoDa & (~Costanti.RICHIESTA_DA_MASTER);

            for (int i = 0; i < LayOutFanCoilGrp.Length; i++)
            {

                ClassGroupBoxFanCoil gbTest = new ClassGroupBoxFanCoil(LayOutFanCoilGrp[i], this);
                progressivo = gbTest.getProgresivo();
                this.Controls.Add(gbTest.getGroupBox());
                gBox.Add(gbTest);
            }
            // aggiorna tabs
            tabPage1.Text = loca.getStr(loca.indice.FC_TAB_INGRESSO_USCITE);
            tabPage2.Text = loca.getStr(loca.indice.FC_TAB_REGOLAZIONI);
            tabPage3.Text = loca.getStr(loca.indice.FC_TAB_IMPOSTAZIONI);
            tabPage4.Text = loca.getStr(loca.indice.FC_TAB_MODBUS);
            this.Text = Type + Info + sRichiestoDa; //  + " Cassette Ver. " + version + " (Build" + bld + ") Matricola: " + Matricola;
            labelIndice.Width = 0;
            clsArbitrator.setEsecuzione();
            setAllVisibleInvisibile(utility.SET_INVISIBLE_START);
            visibileInvisibile();
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
                timerTick.Enabled = true;
                clsArbitrator.setDoNotLoop();
            }
            else
            {
                labelFondo.Visible = false;
                labelIndice.Visible = false;
                labelPleaseWait.Visible = false;
                setAllVisibleInvisibile(0);
                visibileInvisibile();
                timerRxDati.Enabled = false;
            }
            // Debug.WriteLine("MASTER/SLAVE PaR=" + parametriCassetta.KK_TIPO_DISPOSITIVO_MS.ToString());
            rxBuffer = new clsRxBuffer();
            systemTimer.Enabled = true;

        }
        public clsRxBuffer getRxBufferClass() { return rxBuffer; }
        public byte[] getRxBuffr() { return rxBuffer.getRxBuffer(); }
        private void richiestaParametri()
        {
            // clsArbitrator.setDoNotLoop();
            parametroDaRichiedere = 0;
            rchiedi = 1;
            richiedi();
        }

        void richiedi()
        {

            if (rchiedi == 1)
            {

                // txMsg.requireParameter(parametroDaRichiedere, Costanti.BITS_DEVICE_CASSETTE | Costanti.BITS_VIDEATA_PARAMETRI, richiestoDa | indirizzo);
                txMsg.requireParameter(parametroDaRichiedere, Costanti.BITS_DEVICE_FANCOIL | Costanti.BITS_VIDEATA_PARAMETRI, richiestoDa | indirizzo);
                Debug.Write("Parametro da richiedere "); Debug.WriteLine(parametroDaRichiedere);
                labelIndice.Width = (int)((double)parametroDaRichiedere * ((double)labelFondo.Width / parametriFanCoil.NUMERO_PARAMETRI_KF));
                labelPleaseWait.Text = loca.getStr(loca.indice.STR_CARICA_PARAMETRI) + "(" + (parametroDaRichiedere + 1).ToString() + "/" + parametriFanCoil.NUMERO_PARAMETRI_KF.ToString() + ")";
                rchiedi = 0;
            }
        }
        public void setLangage()
        {
            for (int i = 0; i < gBox.Count; i++)
            {
                ClassGroupBoxFanCoil gbTest = gBox[i];
                gbTest.UpdateDeviceLanguage();
            }
            // aggiorna tabs
            tabPage1.Text = loca.getStr(loca.indice.FC_TAB_INGRESSO_USCITE);
            tabPage2.Text = loca.getStr(loca.indice.FC_TAB_REGOLAZIONI);
            tabPage3.Text = loca.getStr(loca.indice.FC_TAB_IMPOSTAZIONI);
            tabPage4.Text = loca.getStr(loca.indice.FC_TAB_MODBUS);
        }
        #region LAYOUT

        int CalcolanumByte(byte[] buffer, int p)
        {
            int j = 0;
            int isize = buffer.Length;
            while (buffer[p] != 0xf7 && isize >= 0)
            {
                j++;
                p++;
            }
            if (isize < 0)
                j = -1;
            return j;
        }
        public void aggiornaParametro(int p, byte[] buffer, int pos)
        // p = numero parametro
        // buffer = buffer ricezione (F0 ... F7
        // pos = posizione del segno

        {
            Debug.WriteLine("Par: " + p.ToString());
            int g;
            int j;
            int v;
            int trovato = -1;

            clsArbitrator.setDoNotLoop2();
            int nbyte = CalcolanumByte(buffer, pos + 1);

            for (g = 0; g < LayOutFanCoilGrp.Length && trovato < 0; g++)
            {
                if (LayOutFanCoilGrp[g].cfgCombo != null)
                {
                    for (j = 0; j < LayOutFanCoilGrp[g].cfgCombo.Length && trovato < 0; j++)
                    {
                        if (LayOutFanCoilGrp[g].cfgCombo[j].numParametro == p)
                        {
                            // trovato
                            trovato = j;
                            v = utility.conv728(buffer, pos + 1, nbyte);
                            if (LayOutFanCoilGrp[g].cfgCombo[j].combo.SelectedIndex != v)
                                LayOutFanCoilGrp[g].cfgCombo[j].combo.SelectedIndex = v;
                            // campoDinamico(p, g, j, v);
                        }

                    }

                }
                // ----------------------------------
                if (LayOutFanCoilGrp[g].cfgUpDown != null)
                {
                    for (j = 0; j < LayOutFanCoilGrp[g].cfgUpDown.Length && trovato < 0; j++)
                    {
                        if (LayOutFanCoilGrp[g].cfgUpDown[j].numParametro == p)
                        {
                            // trovato
                            trovato = j;
                            // trasformare decimali
                            v = utility.conv728(buffer, pos + 1, nbyte);
                            decimal d = utility.convert2Decimal(v, LayOutFanCoilGrp[g].cfgUpDown[j].nDec);
                            if (LayOutFanCoilGrp[g].cfgUpDown[j].numUpDown.Value != d)
                                LayOutFanCoilGrp[g].cfgUpDown[j].numUpDown.Value = d;
                            // calcoli(p);
                            // campoDinamico(p, g, j, v);
                        }

                    }
                }
                // ----------------------------------
                if (LayOutFanCoilGrp[g].cfgRadioButton != null)
                {
                    for (j = 0; j < LayOutFanCoilGrp[g].cfgRadioButton.Length && trovato < 0; j++)
                    {
                        if (LayOutFanCoilGrp[g].cfgRadioButton[j].numParametro == p)
                        {
                            // trovato
                            trovato = j;
                            v = utility.conv728(buffer, pos + 1, nbyte);
                            int qualeBottone = -1;
                            int k;
                            for (k = 0; k < LayOutFanCoilGrp[g].cfgRadioButton[trovato].rButton.Length && qualeBottone < 0; k++)
                            {
                                if (LayOutFanCoilGrp[g].cfgRadioButton[trovato].rButton[k].Checked == true)
                                    qualeBottone = k;  // qualeBottone = bottone che sta a true
                            }
                            if (v != qualeBottone) // bisogna mettere a true un altro bottone
                            {
                                for (k = 0; k < LayOutFanCoilGrp[g].cfgRadioButton[trovato].rButton.Length; k++)
                                {
                                    LayOutFanCoilGrp[g].cfgRadioButton[trovato].rButton[k].Checked = (k == v);
                                }
                            }
                            // campoDinamico(p, g, j, v);
                        }

                    }
                }
                // ----------------------------------

            }
            if (trovato < 0)
            {
                Debug.WriteLine("Parametro non trovato" + p.ToString());
                clsArbitrator.clrDoNotLoop2();
                switch (p)
                {
                    // parametri non visualizzabili
                    case parametriFanCoil.KF_MBUS_FORZATURA_VENTILATORE:
                    case parametriFanCoil.KF_MBUS_FORZATURA_RISCALDAMENTO:
                    case parametriFanCoil.KF_MBUS_FORZATURA_RAFFREDDAMENTO:
                    case parametriFanCoil.KF_MBUS_FORZATURA_SERRANDA:
                        v = utility.conv728(buffer, pos + 1, nbyte);
                        int np = p - parametriFanCoil.KF_MBUS_FORZATURA_VENTILATORE; // 0  - 3
                        if (v < 0)
                        {
                            comTask.setValoreDaModbus(np, 0xffff);
                        }
                        else
                        {
                            comTask.setValoreDaModbus(np, v);
                        }
                        break;
                }
            }
            continuaRichiesta();
            // clsArbitrator.clrDoNotLoop2();

        }

        void continuaRichiesta()
        {
            if (parametroDaRichiedere >= 0)
            {
                rchiedi = 1;
                parametroDaRichiedere++;
                if (parametroDaRichiedere < parametriFanCoil.NUMERO_PARAMETRI_KF)
                {
                    richiedi();
                }
                else
                {
                    rchiedi = 0;
                    parametroDaRichiedere = -1;
                    // timerRxDati.Enabled = false;
                    labelFondo.Visible = false;
                    labelIndice.Visible = false;
                    labelPleaseWait.Visible = false;
                    clsArbitrator.clrEsecuzione();
                    clsArbitrator.clrDoNotLoop();
                    clsArbitrator.clrLoadingParameter();
                    setAllVisibleInvisibile(0);
                    visibileInvisibile();
                    tabControl.Visible = true;
                    forzaDisabilitazioni(); // cancella primario così da forzare la disabilitazione di parametri primari

                }
            }
        }
        void initDatiLayout()
        {
            LayOutFanCoilGrp = new gbOxConfig[]
            {
                new gbOxConfig() { // ------------------------------  INGRESSI 0                    
                    cfgGbox = new gbInfo()
                    {
                        gpBox = gb0_Ingressi,
                        testo = loca.indice.FC_GB_0_STR_INGRESSI,
                    },
                     cfgLabel = new lblInfo[] {
                         new lblInfo() {
                             lbl = lbl_0_00_DL1,
                             testo = loca.indice.FC_LBL_0_00
                         },
                          new lblInfo() {
                             lbl = lbl_0_01_DI2,
                             testo = loca.indice.FC_LBL_0_01,
                         }, new lblInfo() {
                             lbl = lbl_0_02_DI3,
                             testo = loca.indice.FC_LBL_0_02,
                         }, new lblInfo() {
                             lbl = lbl_0_03_DI4,
                             testo = loca.indice.FC_LBL_0_03,
                         }, new lblInfo() {
                             lbl = lbl_0_04_DI5,
                             testo = loca.indice.FC_LBL_0_04
                         }, new lblInfo() {
                             lbl = lbl_0_05_NTC1,
                             testo = loca.indice.FC_LBL_0_05,
                         }, new lblInfo() {
                             lbl = lbl_0_06_NTC2,
                             testo = loca.indice.FC_LBL_0_06,
                         }, new lblInfo() {
                             lbl = lbl_0_07_AI1,
                             testo = loca.indice.FC_LBL_0_07
                         }, new lblInfo() {
                             lbl = lbl_0_08_AI2,
                             testo = loca.indice.FC_LBL_0_08
                         }, new lblInfo() {
                             lbl = lbl_0_09_DI1logic,
                             testo = loca.indice.FC_LBL_0_09
                         }, new lblInfo() {
                             lbl = lbl_0_10_DI2logic,
                             testo = loca.indice.FC_LBL_0_10
                         }, new lblInfo() {
                             lbl = lbl_0_11_DI3logic,
                             testo = loca.indice.FC_LBL_0_11
                         }, new lblInfo() {
                             lbl = lbl_0_12_DI5logic,
                             testo = loca.indice.FC_LBL_0_12
                         }, new lblInfo() {
                             lbl = lbl_0_13_DI2descr,
                             testo = loca.indice.FC_LBL_0_13
                         }, new lblInfo() {
                             lbl = lbl_0_14_DI3descr,
                             testo = loca.indice.FC_LBL_0_14
                         }, new lblInfo() {
                             lbl = lbl_0_15_DI4descr,
                             testo = loca.indice.FC_LBL_0_15
                         }, new lblInfo() {
                             lbl = lbl_0_16_DI5descr,
                             testo = loca.indice.FC_LBL_0_16
                         },new lblInfo() {
                             lbl = lbl_0_17_NTC1descr,
                             testo = loca.indice.FC_LBL_0_17
                         },new lblInfo() {
                             lbl = lbl_0_19_OFF,
                             testo = loca.indice.OFF
                         },new lblInfo() {
                             lbl = lbl_0_20_ON,
                             testo = loca.indice.ON
                         },new lblInfo() {
                             lbl = lbl_0_21_NA,
                             testo = loca.indice.NORM_AP
                         },new lblInfo() {
                             lbl = lbl_0_22_NC,
                             testo = loca.indice.NORM_CH
                         },
                         new lblInfo() {
                             lbl = lbl_0_23_NTC2descr,
                             testo = loca.indice.FC_LBL_0_19
                         },
                     },
                     cfgCombo = new comboInfo[]
                     {
                         new comboInfo() {
                             combo = cb_0_00_DI1,
                             lista = new loca.indice[] { loca.indice.FC_CB_0_00_0, loca.indice.FC_CB_0_00_1,loca.indice.FC_CB_0_00_2,loca.indice.FC_CB_0_00_3 },
                             vDefault = 1,
                             numParametro = parametriFanCoil.KF_DI1_TYPE,

                        },
                           new comboInfo() {
                             combo = cb_0_02_AI2,
                             lista = new loca.indice[] { loca.indice.FC_CB_0_02_0, loca.indice.FC_CB_0_02_1 },
                             vDefault = 1,
                             numParametro = parametriFanCoil.KF_AI2_TYPE,

                        },
                        new comboInfo() {
                             combo = cb_0_01_AI1,
                             lista = new loca.indice[] { loca.indice.FC_CB_0_01_0, loca.indice.FC_CB_0_01_1, loca.indice.FC_CB_0_01_2 },
                             vDefault = 1,
                             numParametro = parametriFanCoil.KF_AI1_TYPE,
                        }

                     },
                     cfgRadioButton = new radioButtonInfo[]
                    {
                        new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_0_00_OFF, rb_0_00_ON },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.VUOTO, loca.indice.VUOTO },
                                numParametro = parametriFanCoil.KF_DI1_ONOFF,
                                vDefault = new int[] { 0,1},
                            },  // 1
                        new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_0_01_OFF, rb_0_01_ON },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.VUOTO, loca.indice.VUOTO },
                                numParametro = parametriFanCoil.KF_DI2_ONOFF,
                                vDefault = new int[] { 0,1},
                            },  // 2
                        new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_0_02_OFF, rb_0_02_ON },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.VUOTO, loca.indice.VUOTO },
                                numParametro = parametriFanCoil.KF_DI3_ONOFF,
                                vDefault = new int[] { 0,1},
                            },  // 3
                        new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_0_03_OFF, rb_0_03_ON },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.VUOTO, loca.indice.VUOTO },
                                numParametro = parametriFanCoil.KF_DI4_ONOFF,
                                vDefault = new int[] { 0,1},
                            },  // 4
                        new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_0_04_OFF, rb_0_04_ON },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.VUOTO, loca.indice.VUOTO },
                                numParametro = parametriFanCoil.KF_DI5_ONOFF,
                                vDefault = new int[] { 0,1},
                            },  // 5
                        new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_0_05_OFF, rb_0_05_ON },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.VUOTO, loca.indice.VUOTO },
                                numParametro = parametriFanCoil.KF_NTC1_ONOFF,
                                vDefault = new int[] { 0,1},
                            },  // 6
                        new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_0_06_OFF, rb_0_06_ON },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.VUOTO, loca.indice.VUOTO },
                                numParametro = parametriFanCoil.KF_NTC2_ONOFF,
                                vDefault = new int[] { 0,1},
                            },  // 7
                        new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_0_07_OFF, rb_0_07_ON },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.VUOTO, loca.indice.VUOTO },
                                numParametro = parametriFanCoil.KF_AI2_ONOFF,
                                vDefault = new int[] { 0,1},
                            },  // 8
                        // fine RB array On/Off
                         new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_0_08_na, rb_0_08_nc },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.VUOTO, loca.indice.VUOTO },
                                numParametro = parametriFanCoil.KF_LOGIC_DI1_NANC,
                                vDefault = new int[] { 0,1},
                            },  // 1
                          new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_0_09_na, rb_0_09_nc  },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.VUOTO, loca.indice.VUOTO },
                                numParametro = parametriFanCoil.KF_LOGIC_DI2_NANC,
                                vDefault = new int[] { 0,1},
                            },  // 2
                           new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_0_10_na, rb_0_10_nc  },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.VUOTO, loca.indice.VUOTO },
                                numParametro = parametriFanCoil.KF_LOGIC_DI3_NANC,
                                vDefault = new int[] { 0,1},
                            },  // 3
                            new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_0_11_na, rb_0_11_nc  },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.VUOTO, loca.indice.VUOTO },
                                numParametro = parametriFanCoil.KF_LOGIC_DI5_NANC,
                                vDefault = new int[] { 0,1},
                            },  // 4
                             new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_0_12_OFF, rb_0_12_ON  },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.VUOTO, loca.indice.VUOTO },
                                numParametro = parametriFanCoil.KF_AI1_ONOFF,
                                vDefault = new int[] { 1,0},
                            },  // 4

                    }, // fine RB arrray
                }, // END ------------------------------  INGRESSI 0
                 new gbOxConfig() { // ------------------------------  TEMPI RITARDO 1
                    cfgGbox = new gbInfo()
                    {
                        gpBox = gb1_Ritardo,
                        testo = loca.indice.FC_GB_1_STR_TRITARDO,
                    },
                     cfgLabel = new lblInfo[] {
                         new lblInfo() {
                             lbl = lbl_1_00_D1A,
                             testo = loca.indice.FC_LBL_1_00
                         },
                             new lblInfo() {
                             lbl = lbl_1_01_D1D,
                             testo = loca.indice.FC_LBL_1_01
                         },
                                 new lblInfo() {
                             lbl = lbl_1_02_D2A,
                             testo = loca.indice.FC_LBL_1_02
                         },
                                     new lblInfo() {
                             lbl = lbl_1_03_D2D,
                             testo = loca.indice.FC_LBL_1_03
                         },
                                         new lblInfo() {
                             lbl = lbl_1_04_D3A,
                             testo = loca.indice.FC_LBL_1_04
                         },
                                             new lblInfo() {
                             lbl = lbl_1_05_D3D,
                             testo = loca.indice.FC_LBL_1_05
                         },
                    },  // fine array label
                     // array Num UPd DOWN
                     cfgUpDown = new upDownInfo[]
                    {
                        new upDownInfo
                        {
                            numUpDown = nud_1_00_DI1A, // 1
                            numParametro = parametriFanCoil.KF_ATTIVAZIONE_DI1,
                            vDefault =(decimal)5,vMin =(decimal) 0,vMax =(decimal) 120,vInc =(decimal) 1,nDec =(int) 0
                        },
                         new upDownInfo
                        {
                            numUpDown = nud_1_01_DI1D, // 1
                            numParametro = parametriFanCoil.KF_DISATTIVAZIONE_DI1,
                            vDefault =(decimal)5,vMin =(decimal) 0,vMax =(decimal) 120,vInc =(decimal) 1,nDec =(int) 0
                        },
                          new upDownInfo
                        {
                            numUpDown = nud_1_02_DI2A, // 1
                            numParametro = parametriFanCoil.KF_ATTIVAZIONE_DI2,
                            vDefault =(decimal)5,vMin =(decimal) 0,vMax =(decimal) 120,vInc =(decimal) 1,nDec =(int) 0
                        },
                           new upDownInfo
                        {
                            numUpDown = nud_1_03_DI2D, // 1
                            numParametro = parametriFanCoil.KF_DISATTIVAZIONE_DI2,
                            vDefault =(decimal)5,vMin =(decimal) 0,vMax =(decimal) 120,vInc =(decimal) 1,nDec =(int) 0
                        },
                            new upDownInfo
                        {
                            numUpDown = nud_1_04_DI3A, // 1
                            numParametro = parametriFanCoil.KF_ATTIVAZIONE_DI3,
                            vDefault =(decimal)5,vMin =(decimal) 0,vMax =(decimal) 120,vInc =(decimal) 1,nDec =(int) 0
                        },
                             new upDownInfo
                        {
                            numUpDown = nud_1_05_DI3D, // 1
                            numParametro = parametriFanCoil.KF_DISATTIVAZIONE_DI3,
                            vDefault =(decimal)5,vMin =(decimal) 0,vMax =(decimal) 120,vInc =(decimal) 1,nDec =(int) 0
                        },
                    }

                 }, // ------------------------------  TEMPI RITARDO 1
                 new gbOxConfig() { // ------------------------------  USCITE 2
                    cfgGbox = new gbInfo()
                    {
                        gpBox = gb2_uscite,
                        testo = loca.indice.FC_GB_2_STR_USCITE
                    },
                     cfgLabel = new lblInfo[] {
                         new lblInfo() {
                             lbl = lbl_2_00_CONFIG,
                             testo = loca.indice.FC_LBL_2_00, //  loca.indice.FC_LBL_2_03,
                         },
                         new lblInfo() {
                             lbl = lbl_2_00_AO2,
                             testo = loca.indice.FC_LBL_2_00,
                         },
                             new lblInfo() {
                             lbl = lbl_2_01_TR1,
                             testo = loca.indice.FC_LBL_2_01
                         },
                                 new lblInfo() {
                             lbl = lbl_2_02_TR2,
                             testo = loca.indice.FC_LBL_2_02
                         }
                     }, // fine array label
                      cfgRadioButton = new radioButtonInfo[]
                    {
                        new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_2_00_OFF, rb_2_00_ON },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.OFF, loca.indice.ON },
                                numParametro = parametriFanCoil.KF_AO2_ON_OFF,
                                vDefault = new int[] { 0,1,},
                            },  // 1
                        new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_2_01_OFF, rb_2_01_ON },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.OFF, loca.indice.ON},
                                numParametro = parametriFanCoil.KF_TR1_ON_OFF,
                                vDefault = new int[] { 0,1},
                            },  // 2
                        new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_2_02_OFF, rb_2_02_ON },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.OFF, loca.indice.ON },
                                numParametro = parametriFanCoil.KF_TR2_ON_OFF,
                                vDefault = new int[] { 0,1},
                            },  // 3
                    },
                    cfgCombo = new comboInfo[]
                    {new comboInfo() {
                         combo = cb_2_00_OutputConfig,
                             lista = new loca.indice[] { loca.indice.FC_CMB_2_00, loca.indice.FC_CMB_2_01, loca.indice.FC_CMB_2_02, loca.indice.FC_CMB_2_03,
                                                         loca.indice.FC_CMB_2_04, loca.indice.FC_CMB_2_05, loca.indice.FC_CMB_2_06, loca.indice.FC_CMB_2_07,
                                                         loca.indice.FC_CMB_2_08, loca.indice.FC_CMB_2_09,

                             },
                             vDefault = 1,
                             numParametro = parametriFanCoil.KF_CFG_USCITE,
                    }
                    }
                 },// ------------------------------  USCITE 2
#if SALTA
                new gbOxConfig() { // ------------------------------  USCITE 2
                    cfgGbox = new gbInfo()
                    {
                        gpBox = gb2_uscite,
                        testo = loca.indice.FC_GB_2_STR_USCITE
                    },
                     cfgLabel = new lblInfo[] {
                         new lblInfo() {
                             lbl = lbl_2_00_AO2,
                             testo = loca.indice.FC_LBL_2_00,
                         },
                             new lblInfo() {
                             lbl = lbl_2_01_VALVE,
                             testo = loca.indice.FC_LBL_2_01
                         },
                                 new lblInfo() {
                             lbl = lbl_2_02_HEAT,
                             testo = loca.indice.FC_LBL_2_02
                         }
                     }, // fine array label
                      cfgRadioButton = new radioButtonInfo[]
                    {
                        new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_2_00_OFF, rb_2_00_SERRANDA, rb_2_00_VALVOLA  },
                                Enabled = new int[] { 0,0,0 },
                                testo = new loca.indice[] { loca.indice.FC_RB_2_00_0 , loca.indice.FC_RB_2_00_1, loca.indice.FC_RB_2_00_2 },
                                numParametro = parametriFanCoil.KF_AO2_TYPE,
                                vDefault = new int[] { 0,1,0},
                            },  // 1
                        new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_2_01_OFF, rb_2_01_ON_OFF, rb_2_01_PWM },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.FC_RB_2_00_0,loca.indice.FC_RB_2_01_0, loca.indice.FC_RB_2_01_1},
                                numParametro = parametriFanCoil.KF_VALVE_TYPE,
                                vDefault = new int[] { 1,0,0},
                            },  // 2
                        new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_2_02_OFF, rb_2_02_ON },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.OFF, loca.indice.ON },
                                numParametro = parametriFanCoil.KF_HEAT_ONOFF,
                                vDefault = new int[] { 0,1},
                            },  // 3
                    }
                 },// ------------------------------  USCITE 2
#endif
                   new gbOxConfig() { // ------------------------------  FILTRO SPORCO 3
                    cfgGbox = new gbInfo()
                    {
                        gpBox = gb3_filtroSporco,
                        testo = loca.indice.FC_GB_3_SEGN_FILTRO_SPORCO
                    },
                    cfgLabel = new lblInfo[] {      // LABELS
                         new lblInfo() {
                             lbl = lbl_3_00_Abilitazione,          // 1
                             testo = loca.indice.FC_LBL_3_00,
                         },
                          new lblInfo() {
                             lbl = lbl_3_01_TempoSegn,          // 2
                             testo = loca.indice.FC_LBL_3_01
                         },
                           new lblInfo() {
                             lbl = lbl_3_02_ResetContatore,          // 3
                             testo = loca.indice.FC_LBL_3_02
                         },
                             new lblInfo() {
                             lbl = lbl_3_03_OFF,          // 4
                             testo = loca.indice.OFF
                         },
                           new lblInfo() {
                             lbl = lbl_3_04_ON,          // 5
                             testo = loca.indice.ON
                         },
                    }, // LABELS
                      cfgRadioButton = new radioButtonInfo[]
                    {
                      new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_3_00_OFF, rb_3_00_ON },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.VUOTO, loca.indice.VUOTO },
                                numParametro = parametriFanCoil.KF_ABILITAZIONE_SEG_FILTRO,
                                vDefault = new int[] { 0,1},
                            },  // 1
                    },
                      cfgUpDown = new upDownInfo[]
                    {
                        new upDownInfo
                        {
                            numUpDown = nud_3_00_TempoSegn, // 1
                            numParametro = parametriFanCoil.KF_TEMPO_SEG_FILTRO,
                            vDefault =(decimal)180,vMin =(decimal) 0,vMax =(decimal) 180,vInc =(decimal) 1,nDec =(int) 0
                        },
                    },
                      cfgButton = new btnInfo[]
                      {
                          new btnInfo
                          {
                              btn=btn_3_00_Reset,
                              testo=loca.indice.FC_BTN_3_00,
                          }
                      }
                   }, // ------------------------------  FILTRO SPORCO 3
                   // --------- TAB 1
                    new gbOxConfig() { // ------------------------------  REGOLAZIONI 4
                    cfgGbox = new gbInfo()
                    {
                        gpBox = gb4_RegolazioneRiacaldamento,
                        testo = loca.indice.FC_GB_4_REGOLAZIONE_RISC
                    },
                    cfgLabel = new lblInfo[] {      // LABELS
                         new lblInfo() {
                             lbl = lbl_4_00_ZMGDZ,          // 1
                             testo = loca.indice.FC_LBL_4_00,
                         },
                          new lblInfo() {
                             lbl = lbl_4_01_BandRegEHB,          // 2
                             testo = loca.indice.FC_LBL_4_01
                         },
                           new lblInfo() {
                             lbl = lbl_4_02_KI_RegRisc,          // 3
                             testo = loca.indice.FC_LBL_4_02
                         },
                             new lblInfo() {
                             lbl = lbl_4_03_PeriodoModPWM,          // 4
                             testo = loca.indice.FC_LBL_4_03
                         },
                           new lblInfo() {
                             lbl = lbl_4_04_MinDCres,          // 5
                             testo = loca.indice.FC_LBL_4_04
                         },
                           new lblInfo() {
                             lbl = lbl_4_05_MaxDCres,          // 6
                             testo = loca.indice.FC_LBL_4_05
                         },
                           new lblInfo() {
                             lbl = lbl_4_06_AbilAlarmRE,          // 6
                             testo = loca.indice.FC_LBL_4_06
                         },
                           
                    }, // LABELS
                    
                      cfgUpDown = new upDownInfo[]
                    {
                        new upDownInfo
                        {
                            numUpDown = nud_4_00_ZMGDZ, // 1
                            numParametro = parametriFanCoil.KF_ZM_RISCALDAMENTO_HDZ,
                            vDefault =(decimal)0.5,vMin =(decimal) 0,vMax =(decimal) 10,vInc =(decimal) 0.1,nDec =(int) 1
                        },
                         new upDownInfo
                        {
                            numUpDown = nud_4_01_BandRegEHB, // 2
                            numParametro = parametriFanCoil.KF_BR_RISCALDAMENTO_HB,
                            vDefault =(decimal)1,vMin =(decimal) 0,vMax =(decimal) 10,vInc =(decimal) 0.1,nDec =(int) 1 ,
                        },
                          new upDownInfo
                        {
                            numUpDown = nud_4_02_KI_RegRisc, // 1
                            numParametro = parametriFanCoil.KF_KI_RISCALDAMENTO,
                            vDefault =(decimal)0,vMin =(decimal) 0,vMax =(decimal) 100,vInc =(decimal) 1,nDec =(int) 0,
                        },
                           new upDownInfo
                        {
                            numUpDown = nud_4_03_PeriodoModPWM, // 1
                            numParametro = parametriFanCoil.KF_PERIODO_MODULAZIONE,
                            vDefault =(decimal)3,vMin =(decimal) 1,vMax =(decimal) 30,vInc =(decimal) 0.1,nDec =(int) 1,
                        },
                            new upDownInfo
                        {
                            numUpDown = nud_4_04_MinDCres, // 1
                            numParametro = parametriFanCoil.KF_MINIMO_DCYCLE,
                            vDefault =(decimal)0,vMin =(decimal) 0,vMax =(decimal) 100,vInc =(decimal) 1,nDec =(int) 0 ,
                        },
                             new upDownInfo
                        {
                            numUpDown = nud_4_05_MaxDCres, // 1
                            numParametro = parametriFanCoil.KF_MASSIMO_DCYCLE,
                           vDefault =(decimal)100,vMin =(decimal) 0,vMax =(decimal) 100,vInc =(decimal) 1,nDec =(int) 0
                        },
                    },
                        cfgRadioButton = new radioButtonInfo[]
                    {
                      new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_4_00_OFF, rb_4_01_ON },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.OFF, loca.indice.ON },
                                numParametro = parametriFanCoil.KF_ALLARME_RESISTENZA,
                                vDefault = new int[] { 0,1},
                            },  // 1
                    },

                   }, // ------------------------------  REGOLAZIONI 4
                    
                      new gbOxConfig() { // ------------------------------ // REGOLAZIONI RAFFREDDAMENTO 5
                    cfgGbox = new gbInfo()
                    {
                        gpBox = gb5_RegolazioneRaffreddamento,
                        testo = loca.indice.FC_GB_5_REGOLAZIONE_FREDDO
                    },
                    cfgLabel = new lblInfo[] {      // LABELS
                         new lblInfo() {
                             lbl = lbl_5_00_ZMraffCDZ,          // 1
                             testo = loca.indice.FC_LBL_5_00
                         },
                          new lblInfo() {
                             lbl = lbl_5_01_BandaRegVCB,          // 2
                             testo = loca.indice.FC_LBL_5_01
                         },
                           new lblInfo() {
                             lbl = lbl_5_02_KIraff,          // 3
                             testo = loca.indice.FC_LBL_5_02
                         },
                             new lblInfo() {
                             lbl = lbl_5_03_Isteresi,          // 4
                             testo = loca.indice.FC_LBL_5_03
                         },
                           new lblInfo() {
                             lbl = lbl_5_04_PWMValv,          // 5
                             testo = loca.indice.FC_LBL_5_04
                         },
                           new lblInfo() {
                             lbl = lbl_5_05_MinDC,          // 6
                             testo = loca.indice.FC_LBL_5_05
                         },
                             new lblInfo() {
                             lbl = lbl_5_06_MaxDC,          // 7
                             testo = loca.indice.FC_LBL_5_05
                         },
                           new lblInfo() {
                             lbl = lbl_5_07_DurRaff,          // 8
                             testo = loca.indice.FC_LBL_5_07
                         },
                           new lblInfo() {
                             lbl = lbl_5_08_PotRaff,          // 9
                             testo = loca.indice.FC_LBL_5_08
                         },
                    }, // LABELS
                    
                      cfgUpDown = new upDownInfo[]
                    {
                        new upDownInfo
                        {
                            numUpDown = nud_5_00_ZMraffCDZ, // 1
                            numParametro = parametriFanCoil.KF_ZM_RAFFREDDAMENTO_CDZ,
                            vDefault =(decimal)0.5,vMin =(decimal) 0,vMax =(decimal) 10,vInc =(decimal) 0.1,nDec =(int) 1
                        },
                         new upDownInfo
                        {
                            numUpDown = nud_5_01_BandRegVCB, // 2
                            numParametro = parametriFanCoil.KF_BR_VALV_RAFFREDDAMENTO_CB,
                            vDefault =(decimal)0.5,vMin =(decimal) 0,vMax =(decimal) 10,vInc =(decimal) 0.1,nDec =(int) 1                      },
                          new upDownInfo
                        {
                            numUpDown = nud_5_02_KIraff, // 3
                            numParametro = parametriFanCoil.KF_KI_VALVOLA,
                            vDefault =(decimal)0,vMin =(decimal) 0,vMax =(decimal) 100,vInc =(decimal) 1,nDec =(int) 0
                        },
                           new upDownInfo
                        {
                            numUpDown = nud_5_03_Isteresi, // 4
                            numParametro = parametriFanCoil.KF_ISTERESI_VALVOLA,
                            vDefault =(decimal)0.5,vMin =(decimal) 0,vMax =(decimal) 10,vInc =(decimal) 0.1,nDec =(int) 1,
                        },
                            new upDownInfo
                        {
                            numUpDown = nud_5_04_PWMValv, // 5
                            numParametro = parametriFanCoil.KF_PERIODO_MOD_VALVOLA,
                            vDefault =(decimal)3,vMin =(decimal) 1,vMax =(decimal) 30,vInc =(decimal) 0.1,nDec =(int) 1 ,
                        },
                             new upDownInfo
                        {
                            numUpDown = nud_5_05_MinDC, // 6
                            numParametro = parametriFanCoil.KF_MINIMO_DC_VALVOLA,
                           vDefault =(decimal)0,vMin =(decimal) 0,vMax =(decimal) 100,vInc =(decimal) 1,nDec =(int) 0
                        },
                                new upDownInfo
                        {
                            numUpDown = nud_5_06_MaxDC, // 7
                            numParametro = parametriFanCoil.KF_MASSIMO_DC_VALVOLA,
                            vDefault =(decimal)100,vMin =(decimal) 0,vMax =(decimal) 100,vInc =(decimal) 1,nDec =(int) 0,
                        },
                            new upDownInfo
                        {
                            numUpDown = nud_5_07_DurRaff, // 8
                            numParametro = parametriFanCoil.KF_DURATA_RAFF_RAPIDO,
                            vDefault =(decimal)30,vMin =(decimal) 0,vMax =(decimal) 120,vInc =(decimal) 1,nDec =(int) 0 ,
                        },
                             new upDownInfo
                        {
                            numUpDown = nud_5_08_PotRaff, // 9
                            numParametro = parametriFanCoil.KF_POT_RAFF_RAPIDO,
                           vDefault =(decimal)100,vMin =(decimal) 0,vMax =(decimal) 100,vInc =(decimal) 1,nDec =(int) 0
                        },
                    },

                   }, // REGOLAZIONI RAFFREDDAMENTO 5


                        new gbOxConfig() { // ------------------------------ // REGOLAZIONI VENTILATORE 6
                    cfgGbox = new gbInfo()
                    {
                        gpBox = gb6_RegolazioneVentilatore,
                        testo = loca.indice.FC_GB_6_REGOLAZIONE_VENTILATORE
                    },
                    cfgLabel = new lblInfo[] {      // LABELS
                         new lblInfo() {
                             lbl = lbl_6_00_ModVentZM,          // 1
                             testo = loca.indice.FC_LBL_6_00
                         },
                          new lblInfo() {
                             lbl = lbl_6_01_AbVentMan,          // 2
                             testo = loca.indice.FC_LBL_6_01
                         },
                           new lblInfo() {
                             lbl = lbl_6_02_TempoPostV,          // 3
                             testo = loca.indice.FC_LBL_6_02
                         },
                             new lblInfo() {
                             lbl = lbl_6_03_TensVent0,          // 4
                             testo = loca.indice.FC_LBL_6_03
                         },
                           new lblInfo() {
                             lbl = lbl_6_04_TensVent100,          // 5
                             testo = loca.indice.FC_LBL_6_04
                         },
                           new lblInfo() {
                             lbl = lbl_6_05_TensMinAttiv,          // 6
                             testo = loca.indice.FC_LBL_6_05
                         },
                             new lblInfo() {
                             lbl = lbl_6_06_GiriMin,          // 7
                             testo = loca.indice.FC_LBL_6_06
                         },
                           new lblInfo() {
                             lbl = lbl_6_07_BandRegFHB,          // 8
                             testo = loca.indice.FC_LBL_6_07
                         },
                           new lblInfo() {
                             lbl = lbl_6_08_BandRegFCB,          // 9
                             testo = loca.indice.FC_LBL_6_08
                         },
                              new lblInfo() {
                             lbl = lbl_6_09_KIregRaffRisc,          // 10
                             testo = loca.indice.FC_LBL_6_09
                         },
                                                            new lblInfo() {
                             lbl = lbl_6_10_AzioneOff,          // 10
                             testo = loca.indice.FC_LBL_6_10
                         },
                              // 

                                 new lblInfo() {
                             lbl = lbl_6_10_OFF,          // 9
                             testo = loca.indice.OFF
                         },
                              new lblInfo() {
                             lbl = lbl_6_11_ON,          // 10
                             testo = loca.indice.ON
                         },
                    }, // LABELS
                    // RADIO BUTTON
                      cfgRadioButton = new radioButtonInfo[]
                    {
                        new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_6_00_ModVentZM_OFF, rb_6_00_ModVentZM_ON },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.VUOTO, loca.indice.VUOTO },
                                numParametro = parametriFanCoil.KF_MOD_VEN_MINIMA_ZM_ONOFF,
                                vDefault = new int[] { 0,1},
                            },  // 1
                          new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_6_01_AbVentMan_OFF, rb_6_01_AbVentMan_ON },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.VUOTO, loca.indice.VUOTO },
                                numParametro = parametriFanCoil.KF_ABILITAZ_VENT_MANUALE_ONOFF,
                                vDefault = new int[] { 0,1},
                            },  // 2
                    },
                      cfgCombo= new comboInfo[]
                      {
                          new comboInfo()
                          {
                             combo = cb_6_00_AzioneOff,
                             lista = new loca.indice[] { loca.indice.FC_CB_6_00, loca.indice.FC_CB_6_01},
                             vDefault = 1,
                             numParametro = parametriFanCoil.KF_AZIONE_OFF,
                          }
                      },


                      cfgUpDown = new upDownInfo[]
                    {
                        new upDownInfo
                        {
                            numUpDown = nud_6_02_TempoPostV, // 1
                            numParametro = parametriFanCoil.KF_TEMPO_POST_VENTILAZIONE,
                            vDefault =(decimal)180,vMin =(decimal) 0,vMax =(decimal) 500,vInc =(decimal) 1,nDec =(int) 0
                        },
                         new upDownInfo
                        {
                            numUpDown = nud_6_03_TensVent0, // 2
                            numParametro = parametriFanCoil.KF_TENSIONE_VENT_AT_ZERO,
                           vDefault =(decimal)2,vMin =(decimal) 0,vMax =(decimal) 10,vInc =(decimal) 0.1,nDec =(int) 1                    },
                          new upDownInfo
                        {
                            numUpDown = nud_6_04_TensVent100, // 3
                            numParametro = parametriFanCoil.KF_TENSIONE_VENT_AT_CENTO,
                            vDefault =(decimal)10,vMin =(decimal) 0,vMax =(decimal) 10,vInc =(decimal) 0.1,nDec =(int) 1
                        },
                           new upDownInfo
                        {
                            numUpDown = nud_6_05_TensMinAttiv, // 4
                            numParametro = parametriFanCoil.KF_TENSIONE_MINIMA_ATTIVAZ,
                            vDefault =(decimal)1,vMin =(decimal) 0,vMax =(decimal) 2,vInc =(decimal) 0.1,nDec =(int) 1
                        },
                            new upDownInfo
                        {
                            numUpDown = nud_6_06_GiriMin, // 5
                            numParametro = parametriFanCoil.KF_GIRI_MINIMI_VENTOLA,
                            vDefault =(decimal)300,vMin =(decimal) 0,vMax =(decimal) 5000,vInc =(decimal) 1,nDec =(int) 0
                        },
                             new upDownInfo
                        {
                            numUpDown = nud_6_07_BandRegFHB, // 6
                            numParametro = parametriFanCoil.KF_BANDA_REG_VENT_RISC_FHB,
                            vDefault =(decimal)1,vMin =(decimal) 0.5,vMax =(decimal) 10,vInc =(decimal) 0.1,nDec =(int) 1
                        },
                                new upDownInfo
                        {
                            numUpDown = nud_6_08_BandRegFCB, // 7
                            numParametro = parametriFanCoil.KF_BANDA_REG_VENT_RAFF_FCB,
                            vDefault =(decimal)1,vMin =(decimal) 0.5,vMax =(decimal) 10,vInc =(decimal) 0.1,nDec =(int) 1
                        },
                            new upDownInfo
                        {
                            numUpDown = nud_6_09_KIregRaffRisc, // 8
                            numParametro = parametriFanCoil.KF_KI_REGOLAZ_VENT,
                            vDefault =(decimal)0,vMin =(decimal) 0,vMax =(decimal) 100,vInc =(decimal) 1,nDec =(int) 0
                        },

                    },

                   }, //  REGOLAZIONI VENTILATORE 6
                    new gbOxConfig() { // ------------------------------ // REGOLAZIONI SERRANDA 7
                        cfgGbox = new gbInfo()
                        {
                            gpBox = gb7_RegolazioneSerrandaFAir,
                            testo = loca.indice.FC_GB_7_REGOLAZIONE_SERRANDA_FA
                        },
                         cfgLabel = new lblInfo[] {      // LABELS
                         new lblInfo() {
                             lbl = lbl_7_00_ModGestione,          // 1
                             testo = loca.indice.FC_LBL_7_00
                         },
                          new lblInfo() {
                             lbl = lbl_7_01_SetPointCO2,          // 2
                             testo = loca.indice.FC_LBL_7_01
                         },
                           new lblInfo() {
                             lbl = lbl_7_02_BandaRegolazCO2,          // 3
                             testo = loca.indice.FC_LBL_7_02
                         },
                             new lblInfo() {
                             lbl = lbl_7_03_SetpointVOC,          // 4
                             testo = loca.indice.FC_LBL_7_03
                         },
                           new lblInfo() {
                             lbl = lbl_7_04_BandaRegVOC,          // 5
                             testo = loca.indice.FC_LBL_7_04
                         },
                           new lblInfo() {
                             lbl = lbl_7_05_ApMinSerr,          // 6
                             testo = loca.indice.FC_LBL_7_05
                         },
                                 new lblInfo() {
                             lbl = lbl_7_06_ApMaxSerr,          // 7
                             testo = loca.indice.FC_LBL_7_06
                         },
                             new lblInfo() {
                             lbl = lbl_7_07_TensPortMin,          // 7
                             testo = loca.indice.FC_LBL_7_07
                         },
                           new lblInfo() {
                             lbl = lbl_7_08_TensPortMax,          // 8
                             testo = loca.indice.FC_LBL_7_08
                         },
                           new lblInfo() {
                             lbl = lbl_7_09_PortMin,          // 9
                             testo = loca.indice.FC_LBL_7_09
                         },
                              new lblInfo() {
                             lbl = lbl_7_10_PortMax,          // 10
                             testo = loca.indice.FC_LBL_7_10
                         },
                                 new lblInfo() {
                             lbl = lbl_7_11_SpPortConf,          // 11
                             testo = loca.indice.FC_LBL_7_11
                         },
                              new lblInfo() {
                             lbl = lbl_7_12_SpPortEcom,          // 12
                             testo = loca.indice.FC_LBL_7_12
                         },
                    }, // LABELS
                         // COMBO
                     cfgCombo = new comboInfo[]
                     {
                         new comboInfo() {
                             combo = cb_7_00_ModGestione,
                             lista = new loca.indice[] { loca.indice.FC_CB_7_00, loca.indice.FC_CB_0_02_1,loca.indice.FC_CB_7_01, loca.indice.FC_CB_7_02 },
                             vDefault = 1,
                             numParametro = parametriFanCoil.KF_MODALITA_GESTIONE_SERRANDA,
                        },
                     },
                     // UP DOWN
                      cfgUpDown = new upDownInfo[]
                    {
                        new upDownInfo
                        {
                            numUpDown = nud_7_01_SetPointCO2, // 1
                            numParametro = parametriFanCoil.KF_SETPOINT_CO2,
                            vDefault =(decimal)800,vMin =(decimal) 0,vMax =(decimal) 2000,vInc =(decimal) 1,nDec =(int) 0
                        },
                         new upDownInfo
                        {
                            numUpDown = nud_7_02_BandaRegolazCO2, // 1
                            numParametro = parametriFanCoil.KF_BANDA_REG_CO2,
                           vDefault =(decimal)800,vMin =(decimal) 10,vMax =(decimal) 1500,vInc =(decimal) 1,nDec =(int) 0
                        },
                          new upDownInfo
                        {
                            numUpDown = nud_7_03_SetpointVOC, // 1
                            numParametro = parametriFanCoil.KF_SETPOINT_VOC,
                            vDefault =(decimal)50,vMin =(decimal) 0,vMax =(decimal) 100,vInc =(decimal) 1,nDec =(int) 0
                        },
                           new upDownInfo
                        {
                            numUpDown = nud_7_04_BandaRegVOC, // 1
                            numParametro = parametriFanCoil.KF_BANDA_REGOLAZIONE_VOC,
                            vDefault =(decimal)50,vMin =(decimal) 0,vMax =(decimal) 100,vInc =(decimal) 1,nDec =(int) 0
                        },
                            new upDownInfo
                        {
                            numUpDown = nud_7_05_ApMinSerr, // 1
                            numParametro = parametriFanCoil.KF_APERTURA_MINIMA_SERRANDA,
                            vDefault =(decimal)0,vMin =(decimal) 0,vMax =(decimal) 100,vInc =(decimal) 1,nDec =(int) 0
                        },
                             new upDownInfo
                        {
                            numUpDown = nud_7_06_ApMaxSerr, // 1
                            numParametro = parametriFanCoil.KF_APERTURA_MASSIMA_SERRANDA,
                            vDefault =(decimal)100,vMin =(decimal) 0,vMax =(decimal) 100,vInc =(decimal) 1,nDec =(int) 0
                        },
                              new upDownInfo
                        {
                            numUpDown = nud_7_07_TensPortMin, // 1
                            numParametro = parametriFanCoil.KF_TENSIONE_ALLA_PORTATA_MINIMA,
                            vDefault =(decimal)0,vMin =(decimal) 0,vMax =(decimal) 10,vInc =(decimal) 0.1,nDec =(int) 1
                        },
                               new upDownInfo
                        {
                            numUpDown = nud_7_08_TensPortMax, // 1
                            numParametro = parametriFanCoil.KF_TENSIONE_ALLA_PORTATA_MASSIMA,
                            vDefault =(decimal)10,vMin =(decimal) 0,vMax =(decimal) 10,vInc =(decimal) 0.1,nDec =(int) 1
                        },
                                new upDownInfo
                        {
                            numUpDown = nud_7_09_PortMin, // 1
                            numParametro = parametriFanCoil.KF_PORTATA_MINIMA,
                            vDefault =(decimal)100,vMin =(decimal) 0,vMax =(decimal) 500,vInc =(decimal) 1,nDec =(int) 0
                        },
                                 new upDownInfo
                        {
                            numUpDown = nud_7_10_PortMax, // 1
                            numParametro = parametriFanCoil.KF_PORTATA_MASSIMA,
                            vDefault =(decimal)500,vMin =(decimal) 0,vMax =(decimal) 500,vInc =(decimal) 1,nDec =(int) 0
                        },
                                  new upDownInfo
                        {
                            numUpDown = nud_7_11_SpPortConf, // 1
                            numParametro = parametriFanCoil.KF_SETPOINT_PORTATA_CONFORT,
                            vDefault =(decimal)200,vMin =(decimal) 0,vMax =(decimal) 500,vInc =(decimal) 1,nDec =(int) 0
                        },
                                   new upDownInfo
                        {
                            numUpDown = nud_7_12_SpPortEcom, // 1
                            numParametro = parametriFanCoil.KF_SETPOINT_PORTATA_ECONOMY,
                            vDefault =(decimal)100,vMin =(decimal) 0,vMax =(decimal) 500,vInc =(decimal) 1,nDec =(int) 0
                        },
                    },
               },// ------------------------------ // REGOLAZIONI SERRANDA 7
               // ------- tab 2 ---------
                new gbOxConfig() { // ------------------------------ // impostazione setpoint temperatura 8
                        cfgGbox = new gbInfo()
                        {
                            gpBox = gb8_impostSondaReg,
                            testo = loca.indice.FC_GB_8_IMPOSTAZIONE_SONDA
                        },
                          cfgLabel = new lblInfo[] {      // LABELS
                         new lblInfo() {
                             lbl = lbl_8_00_TipoSonda,          // 1
                             testo = loca.indice.FC_LBL_8_00
                         },
                          new lblInfo() {
                             lbl = lbl_8_01_SetpointTemp,          // 2
                             testo = loca.indice.FC_LBL_8_01
                         },
                           new lblInfo() {
                             lbl = lbl_8_02_DeviazSP,          // 3
                             testo = loca.indice.FC_LBL_8_02
                         },
                     },  // fine array label
                            cfgCombo = new comboInfo[]
                     {
                         new comboInfo() {
                             combo = cb_8_00_TipoSonda,
                             lista = new loca.indice[] {  loca.indice.FC_CB_8_00_01, loca.indice.FC_CB_8_00_02, loca.indice.FC_CB_8_00_03, loca.indice.FC_CB_8_00_04},
                             vDefault = 0,
                             numParametro = parametriFanCoil.KF_TIPO_SONDA_REGOLAZ,
                        },
                     },
                             cfgUpDown = new upDownInfo[]
                    {
                        new upDownInfo
                        {
                            numUpDown = nud_8_01_SetpointTemp, // 1
                            numParametro = parametriFanCoil.KF_SETPOINT_TEMP_DEFAULT,
                            vDefault =(decimal)23,vMin =(decimal) 20,vMax =(decimal) 28,vInc =(decimal) 0.1,nDec =(int) 1
                        },
                          new upDownInfo
                        {
                            numUpDown = nud_8_02_DeviazSP, // 2
                            numParametro = parametriFanCoil.KF_DEVIAZ_MAX_SETPOINT,
                            vDefault =(decimal)3,vMin =(decimal) 0,vMax =(decimal) 20,vInc =(decimal) 0.1,nDec =(int) 1
                        },

                    }
                },// ------------------------------ // impostazione setpoint temperatura 8
                new gbOxConfig() { // ------------------------------ // SENSORE DI PRESSIONE 9
                        cfgGbox = new gbInfo()
                        {
                            gpBox = gb9_SensPress,
                            testo = loca.indice.FC_GB_9_SENSORE_PRESSIONE
                        },
                          cfgLabel = new lblInfo[] {      // LABELS
                         new lblInfo() {
                             lbl = lbl_9_00_SogliaIntasFiltro,          // 1
                             testo = loca.indice.FC_LBL_9_00
                         },
                          new lblInfo() {
                             lbl = lbl_9_01_IsteresiIntasFiltro,          // 2
                             testo = loca.indice.FC_LBL_9_01
                         },
                            new lblInfo() {
                             lbl = lbl_9_02_SogliaAltraPress,          // 3
                             testo = loca.indice.FC_LBL_9_02
                         },
                                new lblInfo() {
                             lbl = lbl_9_03_IstSogliaAltraPress,          // 4
                             testo = loca.indice.FC_LBL_9_03
                         },
                                    new lblInfo() {
                             lbl = lbl_9_04_SogliaBassaPress,          // 5
                             testo = loca.indice.FC_LBL_9_04
                         },
                                        new lblInfo() {
                             lbl = lbl_9_05_IstSogliaBassaPress,          // 6
                             testo = loca.indice.FC_LBL_9_05
                         },
                                            new lblInfo() {
                             lbl = lbl_9_06_RitAllarmeBassaPressione,          // 7
                             testo = loca.indice.FC_LBL_9_06
                         },
                     },  // fine array FC_LBL_9_06
                        
                             cfgUpDown = new upDownInfo[]
                    {
                        new upDownInfo
                        {
                            numUpDown = nud_9_00_SogliaIntasFiltro, // 1
                            numParametro = parametriFanCoil.KF_SOGLIA_INTASAMENTO_FILTRO,
                           vDefault =(decimal)70,vMin =(decimal) 0,vMax =(decimal) 500,vInc =(decimal) 1,nDec =(int) 0
                        },
                          new upDownInfo
                        {
                            numUpDown = nud_9_01_IsteresiIntasFiltro, // 2
                            numParametro = parametriFanCoil.KF_ISTERESI_SOGLIA_INTASAMENTO,
                            vDefault =(decimal)10,vMin =(decimal) 0,vMax =(decimal) 30,vInc =(decimal) 1,nDec =(int) 0
                        },
                           new upDownInfo
                        {
                            numUpDown = nud_9_02_SogliaAltraPress, // 2
                            numParametro = parametriFanCoil.KF_SOGLIA_ALTA_PRESSIONE,
                            vDefault =(decimal)200,vMin =(decimal) 0,vMax =(decimal) 500,vInc =(decimal) 1,nDec =(int) 0
                        },
                             new upDownInfo
                        {
                            numUpDown = nud_9_03_IstSogliaAltraPress, // 2
                            numParametro = parametriFanCoil.KF_ISTERESI_SOGLIA_ALTA_PRESSIONE,
                            vDefault =(decimal)20,vMin =(decimal) 0,vMax =(decimal) 100,vInc =(decimal) 1,nDec =(int) 0
                        },
                               new upDownInfo
                        {
                            numUpDown = nud_9_04_SogliaBassaPress, // 2
                            numParametro = parametriFanCoil.KF_SOGLIA_BASSA_PRESSIONE,
                            vDefault =(decimal)50,vMin =(decimal) 0,vMax =(decimal) 100,vInc =(decimal) 1,nDec =(int) 0
                        },
                                 new upDownInfo
                        {
                            numUpDown = nud_9_05_IstSogliaBassaPress, // 2
                            numParametro = parametriFanCoil.KF_ISTERESI_SOGLIA_BASSA_PRESSIONE,
                            vDefault =(decimal)5,vMin =(decimal) 0,vMax =(decimal) 20,vInc =(decimal) 1,nDec =(int) 0
                        },
                                   new upDownInfo
                        {
                            numUpDown = nud_9_06_RitAllarmeBassaPressione, // 2
                            numParametro = parametriFanCoil.KF_RITARDO_ALLARME_BASSA_PRESSIONE,
                            vDefault =(decimal)30,vMin =(decimal) 0,vMax =(decimal) 120,vInc =(decimal) 1,nDec =(int) 0
                        },
                    }
                },// ------------------------------ //  SENSORE DI PRESSIONE 9
                new gbOxConfig() { // ------------------------------ // SENSORE DI PRESSIONE 9
                        cfgGbox = new gbInfo()
                        {
                            gpBox = gb10_gestTempInt,
                            testo = loca.indice.FC_GB_10_TEMP_INTERNA
                        },
                          cfgLabel = new lblInfo[] {      // LABELS
                         new lblInfo() {
                             lbl = lbl_10_00_tempSicur,          // 1
                             testo = loca.indice.FC_LBL_10_00
                         },
                          new lblInfo() {
                             lbl = lbl_10_01_istTempSicur,          // 2
                             testo = loca.indice.FC_LBL_10_01
                         },

                     },  // fine array FC_LBL_9_06
                        
                             cfgUpDown = new upDownInfo[]
                    {
                        new upDownInfo
                        {
                            numUpDown = nud_10_00_tempSicur, // 1
                            numParametro = parametriFanCoil.KF_SOGLIA_TEMP_SICUREZZA,
                           vDefault =(decimal)55,vMin =(decimal) 40,vMax =(decimal) 90,vInc =(decimal) 1,nDec =(int) 0
                        },
                          new upDownInfo
                        {
                            numUpDown = nud_10_01_istTempSicur, // 2
                            numParametro = parametriFanCoil.KF_ISTERESI_TEMP_SICUREZZA,
                            vDefault =(decimal)5,vMin =(decimal) 0,vMax =(decimal) 10,vInc =(decimal) 0.1,nDec =(int) 1
                        },
                    }
                },// ------------------------------ // gestione temperatura interna 10
                new gbOxConfig() { // ------------------------------ // limiti temperatura mandata 11
                        cfgGbox = new gbInfo()
                        {
                            gpBox = gb11_limTempMand,
                            testo = loca.indice.FC_GB_11_TEMP_MADATA
                        },
                          cfgLabel = new lblInfo[] {      // LABELS
                         new lblInfo() {
                             lbl = lbl_11_00_SetpointLimMinimo,          // 1
                             testo = loca.indice.FC_LBL_11_00
                         },
                          new lblInfo() {
                             lbl = lbl_11_01_IsteresiLimMinimo,          // 2
                             testo = loca.indice.FC_LBL_11_01
                         },
                         new lblInfo() {
                             lbl = lbl_11_02_SetPointLimMassimo,          // 3
                             testo = loca.indice.FC_LBL_11_02
                         },
                          new lblInfo() {
                             lbl = lbl_11_03_BamdaRegolazioneLimiti,          // 4
                             testo = loca.indice.FC_LBL_11_03
                         },

                     },  // fine array FC_LBL_9_06
                        
                             cfgUpDown = new upDownInfo[]
                    {
                        new upDownInfo
                        {
                            numUpDown = nud_11_00_SetpointLimMinimo, // 1
                            numParametro = parametriFanCoil.KF_SETPOINT_LIMITE_MINIMO_LLSP,
                           vDefault =(decimal)15,vMin =(decimal) 5,vMax =(decimal) 30,vInc =(decimal) 1,nDec =(int) 0
                        },
                          new upDownInfo
                        {
                            numUpDown = nud_11_01_IsteresiLimMinimo, // 2
                            numParametro = parametriFanCoil.KF_ISTERESI_LIMITE_MINIMO_CLHY,
                            vDefault =(decimal)0.5,vMin =(decimal) 0,vMax =(decimal) 5,vInc =(decimal) 0.1,nDec =(int) 1
                        },
                            new upDownInfo
                        {
                            numUpDown = nud_11_02_SetPointLimMassimo, // 3
                            numParametro = parametriFanCoil.KF_SETPOINT_LIMITE_MASSIMO_HLSP,
                           vDefault =(decimal)40,vMin =(decimal) 30,vMax =(decimal) 70,vInc =(decimal) 1,nDec =(int) 0
                        },
                          new upDownInfo
                        {
                            numUpDown = nud_11_03_BamdaRegolazioneLimiti, // 4
                            numParametro = parametriFanCoil.KF_BANDA_DI_REGOLAZIONE_LB,
                            vDefault =(decimal)5,vMin =(decimal) 0.5,vMax =(decimal) 10,vInc =(decimal) 0.1,nDec =(int) 1
                        },
                    }
                },// ------------------------------ // limiti temperatura mandata 11
                new gbOxConfig() { // ------------------------------ // FUNZIONE RAMPA VENTILATORE 12
                        cfgGbox = new gbInfo()
                        {
                            gpBox = gb12_FunzRampa,
                            testo = loca.indice.FC_GB_12_RAMPA_VENTIL
                        },
                          cfgLabel = new lblInfo[] {      // LABELS
                         new lblInfo() {
                             lbl = lbl_12_00_Abilitazione,          // 1
                             testo = loca.indice.FC_LBL_12_00
                         },
                          new lblInfo() {
                             lbl = lbl_12_01_tempo,          // 2
                             testo = loca.indice.FC_LBL_12_01
                         },
                           new lblInfo() {
                             lbl = lbl_12_2_OFF,          // 1
                             testo = loca.indice.OFF
                         },
                          new lblInfo() {
                             lbl = lbl_12_3_ON,          // 2
                             testo = loca.indice.ON
                         },
                     },  // fine array FC_LBL_9_06

                          cfgRadioButton = new radioButtonInfo[]
                          {
                               new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_12_00_Abilitazione_OFF, rb_12_00_Abilitazione_ON },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.VUOTO, loca.indice.VUOTO },
                                numParametro = parametriFanCoil.KF_ABILITAZIONE_RAMPA_ONOFF,
                                vDefault = new int[] { 0,1},
                            },  // 1
                          },

                             cfgUpDown = new upDownInfo[]
                    {

                        new upDownInfo
                        {
                           numUpDown = nud_12_01_tempo, // 1
                           numParametro = parametriFanCoil.KF_TEMPO_RAMPA,
                           vDefault =(decimal)60,vMin =(decimal) 5,vMax =(decimal) 120,vInc =(decimal) 1,nDec =(int) 0
                        },

                    }
                },// ------------------------------ // FUNZIONE RAMPA VENTILATORE 12
                // TAB 3
               new gbOxConfig() { // ------------------------------ // PARAMETRI RETE 13
                        cfgGbox = new gbInfo()
                        {
                            gpBox = gb_13_impMODBUS,
                            testo = loca.indice.FC_GB_13_IMPOSTAZIONI_RETE
                        },
                          cfgLabel = new lblInfo[] {      // LABELS
                         new lblInfo() {
                             lbl = lbl_13_00_TipDisp,          // 1
                             testo = loca.indice.FC_LBL_13_00
                         },
                          new lblInfo() {
                             lbl = lbl_13_01_Indirizzo,          // 2
                             testo = loca.indice.FC_LBL_13_01
                         },
                           new lblInfo() {
                             lbl = lbl_13_02_Baudrate,          // 3
                             testo = loca.indice.FC_LBL_13_02
                         },
                          new lblInfo() {
                             lbl = lbl_13_03_Parita,          // 4
                             testo = loca.indice.FC_LBL_13_03
                         },
                              new lblInfo() {
                             lbl = lbl_13_04_StopBit,          // 5
                             testo = loca.indice.FC_LBL_13_04
                         },
                     },

                          cfgRadioButton = new radioButtonInfo[]
                          {
                               new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_13_00_TipDisp_MASTER, rb_13_00_TipDisp_SLAVE },
                                Enabled = new int[] { 0,1 },
                                testo = new loca.indice[] { loca.indice.FC_RB_LBL_13_00, loca.indice.FC_RB_LBL_13_01 },
                                numParametro = parametriFanCoil.KF_TIPO_DISPOSITIVO_MS,
                                vDefault = new int[] { 0,1},
                            },  // 1
                          },

                    cfgUpDown = new upDownInfo[]
                    {

                        new upDownInfo
                        {
                           numUpDown = nud_13_01_Indirizzo, // 1
                           numParametro = parametriFanCoil.KF_INDIRIZZO,
                           vDefault =(decimal)0,vMin =(decimal) 0,vMax =(decimal) 255,vInc =(decimal) 1,nDec =(int) 0
                        },
                    },
                     cfgCombo = new comboInfo[]
                     {
                         new comboInfo() {
                             combo = cb_13_02_Baudrate,
                             lista = new loca.indice[] { loca.indice.FC_CB_13_00_2400, loca.indice.FC_CB_13_00_4800, loca.indice.FC_CB_13_00_9600, loca.indice.FC_CB_13_00_19200, loca.indice.FC_CB_13_00_38400,loca.indice.FC_CB_13_00_57600,loca.indice.FC_CB_13_00_115200, },
                             vDefault = 2,
                             numParametro = parametriFanCoil.KF_BAUDRATE,
                        },
                           new comboInfo() {
                             combo = cb_13_03_Parita,
                             lista = new loca.indice[] { loca.indice.FC_CB_13_01_00_NESSUNA, loca.indice.FC_CB_13_01_00_PARI, loca.indice.FC_CB_13_01_00_DISPARI, },
                             vDefault = 0,
                             numParametro = parametriFanCoil.KF_PARITA,
                        },
                             new comboInfo() {
                             combo = cb_13_04_StopBit,
                             lista = new loca.indice[] { loca.indice.FC_CB_13_02_BITSTOP_1, loca.indice.FC_BC_13_02_BITSTOP_2 },
                             vDefault = 0,
                             numParametro = parametriFanCoil.KF_BITSTOP,
                        },
                     },
                },// ------------------------------ // PARAMETRI RETE 13
                  new gbOxConfig() { // ------------------------------ // PARAMETRI CHANGE OVER 15
                        cfgGbox = new gbInfo()
                        {
                            gpBox = gb15_RegolazioneChangeOver,
                            testo = loca.indice.FC_GB15_RegolazioneChangeOver,
                        },
                          cfgLabel = new lblInfo[] {      // LABELS
                         new lblInfo() {
                             lbl = lbl_15_00,          // 1
                             testo = loca.indice.FC_LBL_15_00
                         },
                         new lblInfo() {
                             lbl = lbl_15_01,          // 1
                             testo = loca.indice.FC_LBL_15_01
                         },
                         new lblInfo() {
                             lbl = lbl_15_02,          // 1
                             testo = loca.indice.FC_LBL_15_02
                         },
                      },

                      cfgUpDown = new upDownInfo[]
                    {

                        new upDownInfo
                        {
                           numUpDown = nud_15_00, // 1
                           numParametro = parametriFanCoil.KF_ISTERESI_VALV_CHOV,
                           vDefault =(decimal)1,vMin =(decimal) 0,vMax =(decimal) 10,vInc =(decimal) 0.1,nDec =(int) 1
                        },
                          new upDownInfo
                        {
                           numUpDown = nud_15_01, // 1
                           numParametro = parametriFanCoil.KF_TEMPO_RITARDO_ATTIV_USCITE,
                           vDefault =(decimal)1,vMin =(decimal) 0,vMax =(decimal) 600,vInc =(decimal) 1,nDec =(int) 0
                        },


                    },
                     cfgCombo = new comboInfo[]
                     {
                         new comboInfo() {
                             combo = CB_15_00_Logica,
                             lista = new loca.indice[] { loca.indice.FC_CB_15_00, loca.indice.FC_CB_15_01,},
                             vDefault = 0,
                             numParametro = parametriFanCoil.KF_LOGICA_VALVOLA,
                        },

                     },
                },  // ------------------------------ // PARAMETRI CHANGE OVER 15
                           new gbOxConfig() { // ------------------------------ // PARAMETRI SENSORE PRESSIONE ESTERNO 16
                        cfgGbox = new gbInfo()
                        {
                            gpBox = gb16_senspresest,
                            testo = loca.indice.FC_GB16_ExtPressSens,
                        },
                        // --- 3 labels
                          cfgLabel = new lblInfo[] {      // LABELS
                         new lblInfo() {
                             lbl = LBL_16_00_VoltageRange,      // 1
                             testo = loca.indice.FC_LBL_16_00_VoltageRange
                         },
                         new lblInfo() {
                             lbl = LBL_16_01_PressRange,          // 2
                             testo = loca.indice.FC_LBL_16_01_PressRange
                         },
                         new lblInfo() {
                             lbl = lbl_16_02_AlarmTreshold,       // 1
                             testo = loca.indice.FC_LBL_16_02_AlarmTreshold
                         },
                      },
                          // COMBO 
                          cfgCombo = new comboInfo[]
                     {
                         new comboInfo() {
                             combo = CB_16_00_RangeTensione,
                             lista = new loca.indice[] { loca.indice.FC_CB_16_00_RANGETENSIONE_00, loca.indice.FC_CB_16_00_RANGETENSIONE_01 },
                             vDefault = 0,
                             numParametro = parametriFanCoil.KF_RANGE_TENSIONE,
                        },
                         new comboInfo() {
                             combo = CB_16_01_RangePressione,
                             lista = new loca.indice[] { loca.indice.FC_CB_16_01_RANGEPRESSIONE_00,loca.indice.FC_CB_16_01_RANGEPRESSIONE_01,
                                                         loca.indice.FC_CB_16_01_RANGEPRESSIONE_02,loca.indice.FC_CB_16_01_RANGEPRESSIONE_03,
                                                         loca.indice.FC_CB_16_01_RANGEPRESSIONE_04,loca.indice.FC_CB_16_01_RANGEPRESSIONE_05 },
                             vDefault = 0,
                             numParametro = parametriFanCoil.KF_RANGE_PRESSIONE,
                        }
                     },
                          // UP DOWN
                    cfgUpDown = new upDownInfo[]
                    {
                        new upDownInfo
                        {
                           numUpDown = nud_16_00_AlarmTreshold, // 1
                           numParametro = parametriFanCoil.KF_SOGLIA_ALLARME,
                           vDefault =(decimal)0,vMin =(decimal) 0,vMax =(decimal) 2,vInc =(decimal) 0.1,nDec =(int) 1
                        },
                    },
                },  // ------------------------------ // PARAMETRI SENSORE PRESSIONE ESTERNO 16
                                  new gbOxConfig() { // ------------------------------ // PARAMETRI TIPO ECONOMY 17
                        cfgGbox = new gbInfo()
                        {
                            gpBox = gb17_EconomyMode,
                            testo = loca.indice.FC_GB17_ECONOMYMODE,
                        },
                        // 8 label
                    cfgLabel = new lblInfo[] {      // LABELS
                         new lblInfo() {
                             lbl = lbl_17_00_tedi1,      // 1
                             testo = loca.indice.FC_LBL_17_00_TED1
                         },
                           new lblInfo() {
                             lbl = lbl_17_01_tedi2,      // 2
                             testo = loca.indice.FC_LBL_17_01_TED2,
                         },
                             new lblInfo() {
                             lbl = lbl_17_02_tedi3,      // 3
                             testo = loca.indice.FC_LBL_17_02_TED3,
                         },
                             new lblInfo() {
                             lbl = lbl_17_03_priorita,      // 4
                             testo = loca.indice.FC_LBL_17_03_PRIORITA,
                         },
                             new lblInfo() {
                             lbl = lbl_17_04_HDZI1,     // 5
                             testo = loca.indice.FC_LBL_17_04_HDZI1,
                         },
                             new lblInfo() {
                             lbl = lbl_17_05_CDZI1,      // 6
                             testo = loca.indice.FC_LBL_17_05_CDZI1,
                         },
                             new lblInfo() {
                             lbl = lbl_17_06_HDZI2,      // 7
                             testo = loca.indice.FC_LBL_17_06_HDZI2,
                         },
                             new lblInfo() {
                             lbl = lbl_17_07_CDZI2,      // 8
                             testo = loca.indice.FC_LBL_17_07_CDZI2,
                         }
                     }, // label array END
                     // 4 combo
                 cfgCombo = new comboInfo[]
                     {
                         new comboInfo() {  // TIPO ECONOMY DI1
                             combo = CB_17_00_tedi1,
                             lista = new loca.indice[] { loca.indice.FC_CB_17_00_TIPO_ECONOMY_00, loca.indice.FC_CB_17_00_TIPO_ECONOMY_01, loca.indice.FC_CB_17_00_TIPO_ECONOMY_02, loca.indice.FC_CB_17_00_TIPO_ECONOMY_03 },
                             vDefault = 0,
                             numParametro = parametriFanCoil.KF_TIPO_ECONOMY_DI1,
                        },
                         new comboInfo() { // TIPO ECONOMY DI2
                             combo = CB_17_01_tedi2,
                             lista = new loca.indice[] { loca.indice.FC_CB_17_00_TIPO_ECONOMY_00, loca.indice.FC_CB_17_00_TIPO_ECONOMY_01, loca.indice.FC_CB_17_00_TIPO_ECONOMY_02, loca.indice.FC_CB_17_00_TIPO_ECONOMY_03 },
                             vDefault = 0,
                             numParametro = parametriFanCoil.KF_TIPO_ECONOMY_DI2,
                        },
                          new comboInfo() { // TIPO ECONOMY DI3
                             combo = CB_17_02_tedi3,
                             lista = new loca.indice[] { loca.indice.FC_CB_17_00_TIPO_ECONOMY_00, loca.indice.FC_CB_17_00_TIPO_ECONOMY_01, loca.indice.FC_CB_17_00_TIPO_ECONOMY_02, loca.indice.FC_CB_17_00_TIPO_ECONOMY_03 },
                             vDefault = 0,
                             numParametro = parametriFanCoil.KF_TIPO_ECONOMY_DI3,
                        },
                        new comboInfo() { // PRIORITA'
                             combo = CB_17_03_Priorita,
                             lista = new loca.indice[] { loca.indice.FC_CB_17_01_PRIOROTA_00,loca.indice.FC_CB_17_01_PRIOROTA_01,loca.indice.FC_CB_17_01_PRIOROTA_02,loca.indice.FC_CB_17_01_PRIOROTA_03,loca.indice.FC_CB_17_01_PRIOROTA_04,loca.indice.FC_CB_17_01_PRIOROTA_05 },
                             vDefault = 0,
                             numParametro = parametriFanCoil.KF_PRIORITA_ECONOMY,
                        },
                     },
                          // UP DOWN
                    cfgUpDown = new upDownInfo[]
                    {
                        new upDownInfo
                        {
                           numUpDown = nud_17_00_HDZI1, // 1
                           numParametro = parametriFanCoil.KF_INCR_ZM_RISC_TIPO1,
                           vDefault =(decimal)1,vMin =(decimal) 0,vMax =(decimal) 20,vInc =(decimal) 0.1,nDec =(int) 1
                        },
                         new upDownInfo
                        {
                           numUpDown = nud_17_01_CDZI1, // 1
                           numParametro = parametriFanCoil.KF_INCR_ZM_RAFF_TIPO1,
                           vDefault =(decimal)1,vMin =(decimal) 0,vMax =(decimal) 20,vInc =(decimal) 0.1,nDec =(int) 1
                        },
                        new upDownInfo
                        {
                           numUpDown = nud_17_02_HDZI2, // 1
                           numParametro = parametriFanCoil.KF_INCR_ZM_RISC_TIPO2,
                           vDefault =(decimal)1,vMin =(decimal) 0,vMax =(decimal) 20,vInc =(decimal) 0.1,nDec =(int) 1
                        },
                        new upDownInfo
                        {
                           numUpDown = nud_17_03_CDZI2, // 1
                           numParametro = parametriFanCoil.KF_INCR_ZM_RAFF_TIPO2,
                           vDefault =(decimal)1,vMin =(decimal) 0,vMax =(decimal) 20,vInc =(decimal) 0.1,nDec =(int) 1
                        },
                    },
                 }, // ------------------------------ // PARAMETRI TIPO ECONOMY 17
            };
        }
        #endregion



        private void rb_13_00_TipDisp_SLAVE_CheckedChanged(object sender, EventArgs e)
        {
            disabEnableModBus(Costanti.SLAVE);
        }

        private void rb_13_00_TipDisp_MASTER_CheckedChanged(object sender, EventArgs e)
        {
            disabEnableModBus(Costanti.MASTER);
        }

        void disabEnableModBus(int ft)
        {
            nud_13_01_Indirizzo.Enabled = (ft == Costanti.MASTER);
            cb_13_02_Baudrate.Enabled = (ft == Costanti.MASTER);
            cb_13_03_Parita.Enabled = (ft == Costanti.MASTER);
            cb_13_04_StopBit.Enabled = (ft == Costanti.MASTER);

            lbl_13_01_Indirizzo.Enabled = (ft == Costanti.MASTER);
            lbl_13_02_Baudrate.Enabled = (ft == Costanti.MASTER);
            lbl_13_03_Parita.Enabled = (ft == Costanti.MASTER);
            lbl_13_04_StopBit.Enabled = (ft == Costanti.MASTER);
        }
        void setAllVisibleInvisibile(int visInvis)
        {
            int i;
            int j;
            for (int g = 0; g < LayOutFanCoilGrp.Length; g++)
            {
                gbOxConfig GroupBpox = LayOutFanCoilGrp[g];
                LayOutFanCoilGrp[g].cfgGbox.Visible = visInvis;


                if (GroupBpox.cfgLabel != null)
                {
                    for (i = 0; i < GroupBpox.cfgLabel.Length; i++)
                    {
                        GroupBpox.cfgLabel[i].Visible = visInvis;
                    }
                }
                if (GroupBpox.cfgCombo != null)
                {
                    // cancella lista precedente

                    for (i = 0; i < GroupBpox.cfgCombo.Length; i++)
                    {
                        GroupBpox.cfgCombo[i].Visible = visInvis;
                    }
                }
                if (GroupBpox.cfgRadioButton != null)
                {
                    for (i = 0; i < GroupBpox.cfgRadioButton.Length; i++)
                    {
                        for (j = 0; j < GroupBpox.cfgRadioButton[i].rButton.Length; j++)
                        {
                            GroupBpox.cfgRadioButton[i].Visible = visInvis;
                        }
                        // selezione item di  default
                    }
                }
                if (GroupBpox.cfgUpDown != null)
                {
                    for (i = 0; i < GroupBpox.cfgUpDown.Length; i++)
                    {

                        GroupBpox.cfgUpDown[i].Visible = visInvis;

                        // selezione item di  default
                    }
                }
            }
        }



        void visibileInvisibile()
        {

            int i;
            int j;
            for (int g = 0; g < LayOutFanCoilGrp.Length; g++)
            {
                gbOxConfig GroupBpox = LayOutFanCoilGrp[g];

                GroupBpox.cfgGbox.gpBox.Visible = GroupBpox.cfgGbox.Visible == 0;

                if (GroupBpox.cfgLabel != null)
                {
                    for (i = 0; i < GroupBpox.cfgLabel.Length; i++)
                    {
                        GroupBpox.cfgLabel[i].lbl.Visible = (GroupBpox.cfgLabel[i].Visible == 0);
                    }
                }
                if (GroupBpox.cfgCombo != null)
                {
                    // cancella lista precedente

                    for (i = 0; i < GroupBpox.cfgCombo.Length; i++)
                    {
                        GroupBpox.cfgCombo[i].combo.Visible = (GroupBpox.cfgCombo[i].Visible == 0);
                    }
                }
                if (GroupBpox.cfgRadioButton != null)
                {
                    for (i = 0; i < GroupBpox.cfgRadioButton.Length; i++)
                    {
                        for (j = 0; j < GroupBpox.cfgRadioButton[i].rButton.Length; j++)
                        {
                            GroupBpox.cfgRadioButton[i].rButton[j].Visible = (GroupBpox.cfgRadioButton[i].Visible == 0);
                        }
                        // selezione item di  default
                    }
                }
                if (GroupBpox.cfgUpDown != null)
                {
                    for (i = 0; i < GroupBpox.cfgUpDown.Length; i++)
                    {

                        GroupBpox.cfgUpDown[i].numUpDown.Visible = (GroupBpox.cfgUpDown[i].Visible == 0);

                        // selezione item di  default
                    }
                }
                // gb_14_impPrinc.Visible = false; // elimina selezione Principale/Secondario
            }
        }

        private void timerRxDati_Tick(object sender, EventArgs e)
        {

            int d;
            d = clsSerial.pop(Costanti.BITS_DEVICE_FANCOIL | Costanti.BITS_VIDEATA_PARAMETRI);
            while (d >= 0)
            {
                byte b = (byte)(d & 0xff);
                clsHandler.decode(b, this);
                // handelrData
                if (labelPleaseWait.Visible == true)
                    Application.DoEvents();
                d = clsSerial.pop(Costanti.BITS_DEVICE_FANCOIL | Costanti.BITS_VIDEATA_PARAMETRI);
            }
        }

        private void timerTick_Tick(object sender, EventArgs e)
        {
            if (!clsSerial.serialPortIsOpen())
            {
                this.Close();
                clsSerial.USBerrorRestart();
            }
            // aggiustamento abilitazione disabilitazione partametri

        }








        void forzaDisabilitazioni()
        {
            oldPrimaryValue = -1;
            clsArbitrator.clrPrimario();
        }
        void initDisabilitazioni()
        {
            //DisabPrimaryLblArray = new Label[] {
            //    lbl_ZomaMortaRiscaldamento,
            //    lbl_BandaDiregolazione,
            //    lbl_KIRegolazioneRiscaldamento ,
            //    lbl_PeriodoModulazionePWM,
            //    lbl_SetPointDefault,
            //    lbl_deviazMaxSetpoint,
            //    lbl_IncZMEconomy,
            //    lbl_SetpointLimiteMassimoHLSP,
            //    lbl_BandaRegolazioneLimiti,
            //    lbl_TipoEconomy,
            //    lbl_TastoEconomyRiduzione,
            //     };
            //DisabPrimaryNudArray = new NumericUpDown[]
            //{
            //    nud_ZonaMortaRiscaldamento,
            //    nud_BandaDiregolazione,
            //    nud_KIRegolazioneRiscaldamento,
            //    nud_PeriofoModulazionePWM,
            //    nud_SetPointDefault,
            //    nud_deviazMaxSetpoint,
            //    nud_IncZMEconomy,
            //    nud_SetpointLimiteMassimoHLSP,
            //    nud_BandaRegolazioneLimiti,
            //    nud_TastoEconomyRiduzione,
            //};
            //DisabPrimaryCBArray = new ComboBox[] { comboTipoEcomomy };

            oldPrimaryValue = -1;
        }

        private void frmFanCoil_Load(object sender, EventArgs e)
        {
            this.Icon = global::configuratoreSerial6._0.Resource1.AppIcona;
            this.MaximizeBox = false;
            switch (global.getLivello())
            {
                case 0: // Manufacturer
                    break;
                case 1: // Commissioning
                    initListCommissioning();
                    setCommissioningLevel();
                    break;
                case 2: // User
                    initListUser();
                    setUserLevel();
                    break;

            }


        }

        private void frmFanCoil_FormClosing(object sender, FormClosingEventArgs e)
        {
            chiudi();
        }

        private void systemTimer_Tick(object sender, EventArgs e)
        {
            aggiustaAbilitazioneComboDI1();
            int v = comTask.variazioneParametro();
            int numForzatura = 0;
            while (v != 0)
            {
                // è stato mosso un parametro
                // da schermata
                if ((v & 0x01) != 0)
                {
                    // 
                    // spedisco il parametro via USB
                    int z = comTask.getParametro(numForzatura);
                    int np = numForzatura + parametriFanCoil.KF_MBUS_FORZATURA_VENTILATORE;
                    txMsg.txMsgOne(np, z, comTask.getRichiestoDa());
                }
                v = v >> 1;
                numForzatura++;
            }
        }

        int oldcb_0_00_DI1Index = -1;
        void aggiustaAbilitazioneComboDI1()
        {
            int x = 0;

            if (LayOutFanCoilGrp[0].cfgCombo[0].combo.SelectedIndex != oldcb_0_00_DI1Index)
            {
                oldcb_0_00_DI1Index = LayOutFanCoilGrp[0].cfgCombo[0].combo.SelectedIndex;
                x = oldcb_0_00_DI1Index;
                // trova combo
                int xx = trovagp(parametriFanCoil.KF_TIPO_ECONOMY_DI1);
                if ((xx & 0xffff) != 0xffff)
                {
                    int p = xx & 0xffff;
                    int g = xx >> 16;
                    if (x == 0)
                    {
                        // cointatto presenza
                        LayOutFanCoilGrp[g].cfgCombo[p].Enabled = LayOutFanCoilGrp[g].cfgCombo[p].Enabled | 1;
                    }
                    else
                    {
                        LayOutFanCoilGrp[g].cfgCombo[p].Enabled = LayOutFanCoilGrp[g].cfgCombo[p].Enabled & (~1);
                    }
                    LayOutFanCoilGrp[g].cfgCombo[p].combo.Enabled = LayOutFanCoilGrp[g].cfgCombo[p].Enabled != 0 ? true : false;
                }
            }
        }


        int trovagp(int p)
        {
            int g;
            int j;
            int trovato = -1;
            int xx;



            xx = -1;
            for (g = 0; g < LayOutFanCoilGrp.Length && trovato < 0; g++)
            {
                if (LayOutFanCoilGrp[g].cfgCombo != null)
                {
                    for (j = 0; j < LayOutFanCoilGrp[g].cfgCombo.Length && trovato < 0; j++)
                    {
                        if (LayOutFanCoilGrp[g].cfgCombo[j].numParametro == p)
                        {
                            // trovato
                            trovato = j;
                            xx = g << 16 + j;
                            // campoDinamico(p, g, j, v);
                        }

                    }

                }
            }
            return xx;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String Filename = datiConfig.getDefaultDirFancoil();
            String directoryName = Path.GetDirectoryName(Filename);
            String myFile = Path.GetFileName(Filename);

            openFileDialog1.FileName = myFile;
            openFileDialog1.InitialDirectory = directoryName;
            openFileDialog1.Filter = "FanCoil parameter (*.prm)|*.prm|All files (*.*)|*.*";
            openFileDialog1.DefaultExt = "s19";

            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                Filename = openFileDialog1.FileName;
                datiConfig.setDefaultDirFancoil(Filename);
                datiConfig.saveFile();
                datiFancoil.Initdati(Filename);
                AggiornaCampi();
                CurrentFileName = Filename;
            }
        }


        void saveAs()
        {
            String Filename = datiConfig.getDefaultDirFancoil();
            String directoryName = Path.GetDirectoryName(Filename);
            saveFileDialog1.InitialDirectory = directoryName;
            saveFileDialog1.DefaultExt = "prm";
            saveFileDialog1.Filter = "FanCoil parameter (*.prm)|*.prm";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Filename = saveFileDialog1.FileName;
                preparaTabellaDatiParametri();
                datiConfig.setDefaultDirFancoil(Filename);
                datiConfig.saveFile();
                datiFancoil.saveFile(Filename);
                // datiFancoil.Initdati(Filename);
                CurrentFileName = Filename;

            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {     
                saveAs();
        }

        void AggiornaCampi()
        {
            for (int r = 0; r < datiFancoil.getNumeroTtaleParametri(); r++)
            {
                String Nome = datiFancoil.getNomefromTabella(r);
                int p = datiFancoil.getIDParametro(Nome);
                if (p >= 0)
                {
                    int v = datiFancoil.getValorefromTabella(r);
                    aggiornaParametroDaFile(p, v);
                }
            }
        }
        void preparaTabellaDatiParametri()
        {
            // legge tutti i dati dei parametri e li salva nella relativa tabella
            int g;
            int j;
            int v;
            datiFancoil.cancellaTabella();
            int numeroTotaleParametri = datiFancoil.getNumeroTtaleParametri();
            for (g = 0; g < LayOutFanCoilGrp.Length; g++)
            {
                if (LayOutFanCoilGrp[g].cfgCombo != null)
                {
                    for (j = 0; j < LayOutFanCoilGrp[g].cfgCombo.Length; j++)
                    {
                        int ID = LayOutFanCoilGrp[g].cfgCombo[j].numParametro;
                        String nomeParametro = datiFancoil.getNomeParametro(ID);
                        v = LayOutFanCoilGrp[g].cfgCombo[j].combo.SelectedIndex;
                        datiFancoil.salvaParametro(ID, nomeParametro, v);



                    }

                }
                // ----------------------------------
                if (LayOutFanCoilGrp[g].cfgUpDown != null)
                {
                    for (j = 0; j < LayOutFanCoilGrp[g].cfgUpDown.Length; j++)
                    {

                        int ID = LayOutFanCoilGrp[g].cfgUpDown[j].numParametro;
                        String nomeParametro = datiFancoil.getNomeParametro(ID);
                        decimal x = LayOutFanCoilGrp[g].cfgUpDown[j].numUpDown.Value;
                        v = (int)(x * (decimal)utility.potDieci(LayOutFanCoilGrp[g].cfgUpDown[j].nDec));

                        datiFancoil.salvaParametro(ID, nomeParametro, v);
                    }
                }
                // ----------------------------------
                if (LayOutFanCoilGrp[g].cfgRadioButton != null)
                {
                    for (j = 0; j < LayOutFanCoilGrp[g].cfgRadioButton.Length; j++)
                    {

                        int ID = LayOutFanCoilGrp[g].cfgRadioButton[j].numParametro;
                        String nomeParametro = datiFancoil.getNomeParametro(ID);
                        for (int k = 0; k < LayOutFanCoilGrp[g].cfgRadioButton[j].rButton.Length; k++)
                        {

                            if (LayOutFanCoilGrp[g].cfgRadioButton[j].rButton[k].Checked)
                            {
                                v = k;
                                datiFancoil.salvaParametro(ID, nomeParametro, v);
                            }
                        }
                        // campoDinamico(p, g, j, v);
                    }

                }
            }
            //// ----------------------------------

        }

        public void aggiornaParametroDaFile(int p, int v)
        // p = numero parametro
        // v = valore parametro

        {
            Debug.WriteLine("Par: " + p.ToString());
            int g;
            int j;
            int trovato = -1;

            for (g = 0; g < LayOutFanCoilGrp.Length && trovato < 0; g++)
            {
                if (LayOutFanCoilGrp[g].cfgCombo != null)
                {
                    for (j = 0; j < LayOutFanCoilGrp[g].cfgCombo.Length && trovato < 0; j++)
                    {
                        if (LayOutFanCoilGrp[g].cfgCombo[j].numParametro == p)
                        {
                            // trovato
                            trovato = j;
                            LayOutFanCoilGrp[g].cfgCombo[j].combo.SelectedIndex = v;
                            // campoDinamico(p, g, j, v);
                        }

                    }

                }
                // ----------------------------------
                if (LayOutFanCoilGrp[g].cfgUpDown != null)
                {
                    for (j = 0; j < LayOutFanCoilGrp[g].cfgUpDown.Length && trovato < 0; j++)
                    {
                        if (LayOutFanCoilGrp[g].cfgUpDown[j].numParametro == p)
                        {
                            // trovato
                            trovato = j;
                            // trasformare decimali
                            decimal d = utility.convert2Decimal(v, LayOutFanCoilGrp[g].cfgUpDown[j].nDec);
                            LayOutFanCoilGrp[g].cfgUpDown[j].numUpDown.Value = d;
                            // calcoli(p);
                            // campoDinamico(p, g, j, v);
                        }

                    }
                }
                // ----------------------------------
                if (LayOutFanCoilGrp[g].cfgRadioButton != null)
                {
                    for (j = 0; j < LayOutFanCoilGrp[g].cfgRadioButton.Length && trovato < 0; j++)
                    {
                        if (LayOutFanCoilGrp[g].cfgRadioButton[j].numParametro == p)
                        {
                            // trovato
                            trovato = j;
                            for (int k = 0; k < LayOutFanCoilGrp[g].cfgRadioButton[trovato].rButton.Length; k++)
                            {
                                LayOutFanCoilGrp[g].cfgRadioButton[trovato].rButton[k].Checked = (k == v);
                            }
                            // campoDinamico(p, g, j, v);
                        }

                    }
                }
                // ----------------------------------

            }
            if (trovato < 0)
            {
                Debug.WriteLine("Parametro non trovato" + p.ToString());
            }
        }

        private void btn_3_00_Reset_Click(object sender, EventArgs e)
        {
            txMsg.txMsgOne(parametriFanCoil.KF_BTN_RESET, 1, richiestoDa);

        }

        // ---------- ABILITAZIONE/DISABILITAZIONE PARAMETRI SERRANDA ------

        List<int> enCO2;
        List<int> enVOC;
        List<int> enEconomy;
        List<int> enPortata;
        List<int> tutto;

        void initListDamper()
        {
            enCO2 = new List<int> { 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 };
            enVOC = new List<int> { 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 };
            enEconomy = new List<int> { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 };
            enPortata = new List<int> { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1 };
            tutto = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }

        void disabilitaSerranda()
        {
            gbOxConfig GroupBpox = LayOutFanCoilGrp[7];
            abilitaDisabilitaSerranda(tutto);
            GroupBpox.cfgCombo[0].Enabled = GroupBpox.cfgCombo[0].Enabled | Costanti.ABILITA_SERRANDA;
            GroupBpox.cfgLabel[0].Enabled = GroupBpox.cfgLabel[0].Enabled | Costanti.ABILITA_SERRANDA;
            GroupBpox.cfgLabel[0].lbl.Enabled = (GroupBpox.cfgLabel[0].Enabled == 0);
            GroupBpox.cfgCombo[0].combo.Enabled = (GroupBpox.cfgCombo[0].Enabled == 0);

        }

        void abilitaSerranda()
        {
            gbOxConfig GroupBpox = LayOutFanCoilGrp[7];
            GroupBpox.cfgCombo[0].Enabled = GroupBpox.cfgCombo[0].Enabled & (~Costanti.ABILITA_SERRANDA);
            GroupBpox.cfgLabel[0].Enabled = GroupBpox.cfgLabel[0].Enabled & (~Costanti.ABILITA_SERRANDA);

            selezionaAbilitazione(cb_7_00_ModGestione.SelectedIndex);
            GroupBpox.cfgLabel[0].lbl.Enabled = (GroupBpox.cfgLabel[0].Enabled == 0);
            GroupBpox.cfgCombo[0].combo.Enabled = (GroupBpox.cfgCombo[0].Enabled == 0);
        }



        void abilitaDisabilitaSerranda(List<int> en)
        {
            gbOxConfig GroupBpox = LayOutFanCoilGrp[7];
            for (int i = 0; i < en.Count; i++)
            {

                if (en[i] == 0)
                {
                    GroupBpox.cfgLabel[i + 1].Enabled = GroupBpox.cfgLabel[i].Enabled | Costanti.ABILITA_SERRANDA;
                    GroupBpox.cfgUpDown[i].Enabled = GroupBpox.cfgUpDown[i].Enabled | Costanti.ABILITA_SERRANDA;

                }
                else
                {
                    GroupBpox.cfgLabel[i + 1].Enabled = GroupBpox.cfgLabel[i].Enabled & (~Costanti.ABILITA_SERRANDA);
                    GroupBpox.cfgUpDown[i].Enabled = GroupBpox.cfgUpDown[i].Enabled & (~Costanti.ABILITA_SERRANDA);
                }
            }
            for (int i = 0; i < en.Count; i++)
            {
                GroupBpox.cfgLabel[i + 1].lbl.Enabled = (GroupBpox.cfgLabel[i + 1].Enabled == 0);
                GroupBpox.cfgUpDown[i].numUpDown.Enabled = (GroupBpox.cfgUpDown[i].Enabled == 0);
            }
        }

        void selezionaAbilitazione(int k)
        {
            switch (k)
            {
                case 0:
                    abilitaDisabilitaSerranda(enCO2);
                    break;
                case 1:
                    abilitaDisabilitaSerranda(enVOC);
                    break;
                case 2:
                    abilitaDisabilitaSerranda(enEconomy);
                    break;
                case 3:
                    abilitaDisabilitaSerranda(enPortata);
                    break;
            }
        }

        private void cb_7_00_ModGestione_SelectedIndexChanged(object sender, EventArgs e)
        {
            selezionaAbilitazione(cb_7_00_ModGestione.SelectedIndex);
        }
        void subAbilitaSerranda()
        {
            if (cb_2_00_OutputConfig.SelectedIndex > 6 && rb_2_00_ON.Checked == true)
            {
                abilitaSerranda();
            }
            else
            {
                disabilitaSerranda();
            }
        }
        private void cb_2_00_OutputConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            subAbilitaSerranda();

        }

        private void rb_2_00_ON_CheckedChanged(object sender, EventArgs e)
        {
            subAbilitaSerranda();
        }

        private void rb_2_00_OFF_CheckedChanged(object sender, EventArgs e)
        {
            subAbilitaSerranda();
        }

        private void CB_16_00_RangeTensione_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_16_00_RangeTensione.SelectedIndex == 1)
            {
                if (nud_16_00_AlarmTreshold.Value < 2)
                    nud_16_00_AlarmTreshold.Value = 2;
            }
        }

        private void timerUnSecondo_Tick(object sender, EventArgs e)
        {

            for (int i = 0; i < gBox.Count; i++)
                gBox[i].Tick(LayOutFanCoilGrp[i]);



        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentFileName != "")
            {
                preparaTabellaDatiParametri();
                datiConfig.setDefaultDirFancoil(CurrentFileName);
                datiConfig.saveFile();
                datiFancoil.saveFile(CurrentFileName);
            }
            else
            {
                saveAs();
            }
        }


        public Boolean isNTC1On() { return rb_0_05_ON.Checked == true; }
        public Boolean isNTC2On() { return rb_0_06_ON.Checked == true; }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chiudi();
            this.Close();

        }

        void chiudi()
        {
            clsArbitrator.clrEsecuzione();
            //clsArbitrator.clrLoadingParameter();
            if (richiestoDa == 0)
                parent.abilitaMenu();
            else
                clsArbitrator.setriabilitaBottoni();
            global.abilitaChiusuraStatoFanCoil();
            global.frmStatoFanCoil.Close();
            clsArbitrator.clsFinestraAperta();
        }

        // ---------- ABILITAZIONE/DISABILITAZIONE PARAMETRI SERRANDA ------
        List<ComboBox> ListCommisioningCombo = new List<ComboBox>();
        List<Label> ListCommisioningLabel = new List<Label>();
        List<NumericUpDown> ListCommisioningNumericUpDown = new List<NumericUpDown>();
        List<Panel> ListCommisioningPanel = new List<Panel>();
        List<GroupBox> ListCommisioningGroupBox = new List<GroupBox>();



        void setCommissioningLevel()
        {
            for (int i = 0; i < ListCommisioningCombo.Count; i++)
            {
                ListCommisioningCombo[i].Enabled = false;
            }
            for (int i = 0; i < ListCommisioningLabel.Count; i++)
            {
                ListCommisioningLabel[i].Enabled = false;
            }

            for (int i = 0; i < ListCommisioningNumericUpDown.Count; i++)
            {
                ListCommisioningNumericUpDown[i].Enabled = false;
            }

            for (int i = 0; i < ListCommisioningPanel.Count; i++)
            {
                ListCommisioningPanel[i].Enabled = false;
            }
            for (int i = 0; i < ListCommisioningGroupBox.Count; i++)
            {
                ListCommisioningGroupBox[i].Enabled = false;
            }
        }


        void initListCommissioning()
        {
            ListCommisioningCombo.Add(cb_8_00_TipoSonda);
            ListCommisioningCombo.Add(cb_0_01_AI1);
            ListCommisioningCombo.Add(cb_0_02_AI2);
            ListCommisioningCombo.Add(cb_2_00_OutputConfig);
            ListCommisioningCombo.Add(cb_7_00_ModGestione);

            ListCommisioningLabel.Add(lbl_0_07_AI1);
            ListCommisioningLabel.Add(lbl_0_08_AI2);
            ListCommisioningLabel.Add(lbl_0_05_NTC1);
            ListCommisioningLabel.Add(lbl_0_17_NTC1descr);
            ListCommisioningLabel.Add(lbl_0_06_NTC2);
            ListCommisioningLabel.Add(lbl_0_23_NTC2descr);
            ListCommisioningLabel.Add(lbl_0_12_DI5logic);
            ListCommisioningLabel.Add(lbl_6_01_AbVentMan);
            ListCommisioningLabel.Add(lbl_6_05_TensMinAttiv);
            ListCommisioningLabel.Add(lbl_6_06_GiriMin);
            ListCommisioningLabel.Add(lbl_7_00_ModGestione);
            ListCommisioningLabel.Add(lbl_7_07_TensPortMin);
            ListCommisioningLabel.Add(lbl_7_08_TensPortMax);
            ListCommisioningLabel.Add(lbl_8_00_TipoSonda);
            ListCommisioningLabel.Add(lbl_9_01_IsteresiIntasFiltro);
            ListCommisioningLabel.Add(lbl_9_02_SogliaAltraPress);
            ListCommisioningLabel.Add(lbl_9_03_IstSogliaAltraPress);
            ListCommisioningLabel.Add(lbl_9_04_SogliaBassaPress);
            ListCommisioningLabel.Add(lbl_9_05_IstSogliaBassaPress);
            ListCommisioningLabel.Add(lbl_9_06_RitAllarmeBassaPressione);
            ListCommisioningLabel.Add(lbl_10_00_tempSicur);
            ListCommisioningLabel.Add(lbl_10_01_istTempSicur);

            ListCommisioningNumericUpDown.Add(nud_6_05_TensMinAttiv);
            ListCommisioningNumericUpDown.Add(nud_6_06_GiriMin);
            ListCommisioningNumericUpDown.Add(nud_7_07_TensPortMin);
            ListCommisioningNumericUpDown.Add(nud_7_08_TensPortMax);
            ListCommisioningNumericUpDown.Add(nud_9_01_IsteresiIntasFiltro);
            ListCommisioningNumericUpDown.Add(nud_9_02_SogliaAltraPress);
            ListCommisioningNumericUpDown.Add(nud_9_03_IstSogliaAltraPress);
            ListCommisioningNumericUpDown.Add(nud_9_04_SogliaBassaPress);
            ListCommisioningNumericUpDown.Add(nud_9_05_IstSogliaBassaPress);
            ListCommisioningNumericUpDown.Add(nud_9_06_RitAllarmeBassaPressione);

            ListCommisioningPanel.Add(panel4);
            ListCommisioningPanel.Add(panel5);
            ListCommisioningPanel.Add(panel6);
            ListCommisioningPanel.Add(panel7);
            ListCommisioningPanel.Add(panel22);
            ListCommisioningPanel.Add(panel8);
            ListCommisioningPanel.Add(panel12);
            ListCommisioningPanel.Add(panel17);

            ListCommisioningGroupBox.Add(gb15_RegolazioneChangeOver);
            ListCommisioningGroupBox.Add(gb16_senspresest);


        }

        List<GroupBox> ListUserGroupBox = new List<GroupBox>();
        List<ComboBox> ListUserComboBox = new List<ComboBox>();
        List<Label> ListUserlabel = new List<Label>();
        List<Panel> ListUserpanel = new List<Panel>();

        void initListUser()
        {
            ListUserGroupBox.Add(gb0_Ingressi);
            ListUserGroupBox.Add(gb1_Ritardo);
            ListUserGroupBox.Add(gb2_uscite);
            ListUserGroupBox.Add(gb4_RegolazioneRiacaldamento);
            ListUserGroupBox.Add(gb5_RegolazioneRaffreddamento);
            ListUserGroupBox.Add(gb6_RegolazioneVentilatore);
            ListUserGroupBox.Add(gb15_RegolazioneChangeOver);
            ListUserGroupBox.Add(gb7_RegolazioneSerrandaFAir);
            ListUserGroupBox.Add(gb17_EconomyMode);
            ListUserGroupBox.Add(gb9_SensPress);
            ListUserGroupBox.Add(gb16_senspresest);
            ListUserGroupBox.Add(gb10_gestTempInt);
            ListUserGroupBox.Add(gb11_limTempMand);
            ListUserGroupBox.Add(gb12_FunzRampa);

            ListUserComboBox.Add(cb_8_00_TipoSonda);

            ListUserlabel.Add(lbl_3_00_Abilitazione);
            ListUserlabel.Add(lbl_8_00_TipoSonda);

            ListUserpanel.Add(panel16);
        }

        void setUserLevel()
        {
            for (int i = 0; i < ListUserGroupBox.Count; i++)
            {
                ListUserGroupBox[i].Enabled = false;
            }
            for (int i = 0; i < ListUserComboBox.Count; i++)
            {
                ListUserComboBox[i].Enabled = false;
            }
            for (int i = 0; i < ListUserlabel.Count; i++)
            {
                ListUserlabel[i].Enabled = false;
            }
            for (int i = 0; i < ListUserpanel.Count; i++)
            {
                ListUserpanel[i].Enabled = false;
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}


