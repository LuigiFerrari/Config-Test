using configuratore.statoCassette;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static configuratore.Costanti;
using static configuratore.statoCassette.frmStatoCassette;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using configuratoreSerial6._0;

namespace configuratore
{


    public partial class frmCassette : Form
    {
        int parametroDaRichiedere;
        int rchiedi;
        String FileName;
        clsRxBuffer rxBuffer;
        public struct comboInfo
        {
            public ComboBox combo;
            public loca.indice[] lista;
            public int vDefault;
            public int numParametro;
            System.EventHandler SelectedIndexChanged;
            public int Enabled;
            public int Visible;
        }
        public struct upDownInfo
        {
            public NumericUpDown numUpDown;
            public decimal vDefault;
            public decimal vMin;
            public decimal vMax;
            public decimal vInc;
            public int nDec;
            public int numParametro;
            public int Enabled;
            public int Visible;
            public int lTimer;
            public int UpDownFLG;
            public decimal oldValue;
        }


        public struct radioButtonInfo
        {
            public RadioButton[] rButton;
            public int[] vDefault;
            public loca.indice[] testo;
            public int numParametro;
            public int[] Enabled;
            public int Visible;
        }


        List<classGroupBoxCassette> gBox;
        frmStartUp parent;
        gbOxConfig[] LayOutCassetteGrp;

        int progressivo;
        List<Object> listOggetti = new List<Object>();
        int richiestoDa;
        int indirizzo;



        // parametri disabilitabili se non è primario
        int oldPrimaryValue;
        Label[] DisabPrimaryLblArray;
        NumericUpDown[] DisabPrimaryNudArray;
        ComboBox[] DisabPrimaryCBArray;

        String CurrentFileName = "";


        public int getRichiestoDa() { return richiestoDa; }
        public int getIndirizzo() { return indirizzo; }

        public frmCassette(String Type, String Info, frmStartUp lparent, Boolean DefaultData, int lrichiestoDa)
        {
            global.glbfrmCassette = this;
            InitializeComponent();
            initDatiLayout();
            initDisabilitazioni();

            parent = lparent;
            FileName = "";
            String sRichiestoDa = "";
            gBox = new List<classGroupBoxCassette>();
            progressivo = 0;
            richiestoDa = lrichiestoDa & Costanti.RICHIESTA_DA_MASTER;
            if (richiestoDa != 0)
                sRichiestoDa = " (MASTER)";  // inica se sono collegato alla pagina dal MASTER oppure sono connesso direttamente allo slave
            indirizzo = lrichiestoDa & (~Costanti.RICHIESTA_DA_MASTER);
            for (int i = 0; i < LayOutCassetteGrp.Length; i++)
            {

                classGroupBoxCassette gbTest = new classGroupBoxCassette(LayOutCassetteGrp[i], this);
                progressivo = gbTest.getProgresivo();
                this.Controls.Add(gbTest.getGroupBox());
                gBox.Add(gbTest);
            }
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
        }

        public byte[] getRxBuffr() { return rxBuffer.getRxBuffer(); }
        public clsRxBuffer getRxBufferClass() { return rxBuffer; }
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

                txMsg.requireParameter(parametroDaRichiedere, Costanti.BITS_DEVICE_CASSETTE | Costanti.BITS_VIDEATA_PARAMETRI, richiestoDa | indirizzo);
                Debug.Write("Parametro da richiedere "); Debug.WriteLine(parametroDaRichiedere);
                labelIndice.Width = (int)((double)parametroDaRichiedere * ((double)labelFondo.Width / parametriCassetta.NUMERO_PARAMETRI_KK));
                labelPleaseWait.Text = loca.getStr(loca.indice.STR_CARICA_PARAMETRI) + "(" + (parametroDaRichiedere + 1).ToString() + "/" + parametriCassetta.NUMERO_PARAMETRI_KK.ToString() + ")";
                rchiedi = 0;
            }
        }

        void continuaRichiesta()
        {
            if (parametroDaRichiedere >= 0)
            {
                rchiedi = 1;
                parametroDaRichiedere++;
                if (parametroDaRichiedere < parametriCassetta.NUMERO_PARAMETRI_KK)
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




        public void setLangage()
        {
            for (int i = 0; i < gBox.Count; i++)
            {
                classGroupBoxCassette gbTest = gBox[i];
                gbTest.UpdateDeviceLanguage();


            }
        }

        private void frmCassette_Load(object sender, EventArgs e)
        {
            this.Icon = global::configuratoreSerial6._0.Resource1.AppIcona;
            this.MaximizeBox = false;
        }

        //void DataWindow_Closing(object sender, CancelEventArgs e)
        //{
        //    MessageBox.Show("Closing called");

        //    // If data is dirty, notify user and ask for a response
        //    if (this.isDataDirty)
        //    {
        //        string msg = "Data is dirty. Close without saving?";
        //        MessageBoxResult result =
        //          MessageBox.Show(
        //            msg,
        //            "Data App",
        //            MessageBoxButton.YesNo,
        //            MessageBoxImage.Warning);
        //        if (result == MessageBoxResult.No)
        //        {
        //            // If user doesn't want to close, cancel closure
        //            e.Cancel = true;
        //        }
        //    }
        //}

        private void frmCassette_FormClosing(object sender, FormClosingEventArgs e)
        {
            // startupData.getgfrmStartUp().enableDevice(); 
            chiudi();

        }

        void chiudi()
        {
            clsArbitrator.clrEsecuzione();
            //clsArbitrator.clrLoadingParameter();
            if (richiestoDa == 0)
                parent.abilitaMenu();
            else
                clsArbitrator.setriabilitaBottoni();
            global.abilitaChiusuraStatoCassette();
            clsArbitrator.clsFinestraAperta();
            global.frmStatoCassette.Close();
        }




        public struct gbInfo
        {
            public GroupBox gpBox;
            public loca.indice testo;
            public int Enabled;
            public int Visible;
        }

        public struct lblInfo
        {
            public Label lbl;
            public loca.indice testo;
            public int Enabled;
            public int Visible;
        }

        public struct btnInfo
        {
            public Button btn;
            public loca.indice testo;
            public int Enabled;
            public int Visible;
        }




        public struct gbOxConfig
        {
            public gbInfo cfgGbox;
            public lblInfo[] cfgLabel;
            public comboInfo[] cfgCombo;
            public upDownInfo[] cfgUpDown;
            public radioButtonInfo[] cfgRadioButton;
            public Label[] valLabel;
            public Button[] btnCmd;
            public btnInfo[] cfgButton;
        }

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

            for (g = 0; g < LayOutCassetteGrp.Length && trovato < 0; g++)
            {
                if (LayOutCassetteGrp[g].cfgCombo != null)
                {
                    for (j = 0; j < LayOutCassetteGrp[g].cfgCombo.Length && trovato < 0; j++)
                    {
                        if (LayOutCassetteGrp[g].cfgCombo[j].numParametro == p)
                        {
                            // trovato
                            trovato = j;
                            v = utility.conv728(buffer, pos + 1, nbyte);
                            LayOutCassetteGrp[g].cfgCombo[j].combo.SelectedIndex = v;
                            campoDinamico(p, g, j, v);
                        }

                    }

                }
                // ----------------------------------
                if (LayOutCassetteGrp[g].cfgUpDown != null)
                {
                    for (j = 0; j < LayOutCassetteGrp[g].cfgUpDown.Length && trovato < 0; j++)
                    {
                        if (LayOutCassetteGrp[g].cfgUpDown[j].numParametro == p)
                        {
                            // trovato
                            trovato = j;
                            // trasformare decimali
                            v = utility.conv728(buffer, pos + 1, nbyte);
                            decimal d = utility.convert2Decimal(v, LayOutCassetteGrp[g].cfgUpDown[j].nDec);
                            if (d > LayOutCassetteGrp[g].cfgUpDown[j].numUpDown.Maximum)
                                d = LayOutCassetteGrp[g].cfgUpDown[j].numUpDown.Maximum;
                            if (d < LayOutCassetteGrp[g].cfgUpDown[j].numUpDown.Minimum)
                                d = LayOutCassetteGrp[g].cfgUpDown[j].numUpDown.Minimum;

                            LayOutCassetteGrp[g].cfgUpDown[j].numUpDown.Value = d;
                            calcoli(p);
                            campoDinamico(p, g, j, v);
                        }

                    }
                }
                // ----------------------------------
                if (LayOutCassetteGrp[g].cfgRadioButton != null)
                {
                    for (j = 0; j < LayOutCassetteGrp[g].cfgRadioButton.Length && trovato < 0; j++)
                    {
                        if (LayOutCassetteGrp[g].cfgRadioButton[j].numParametro == p)
                        {
                            // trovato
                            trovato = j;
                            v = utility.conv728(buffer, pos + 1, nbyte);
                            for (int k = 0; k < LayOutCassetteGrp[g].cfgRadioButton[trovato].rButton.Length; k++)
                            {
                                LayOutCassetteGrp[g].cfgRadioButton[trovato].rButton[k].Checked = (k == v);
                            }
                            campoDinamico(p, g, j, v);
                        }

                    }
                }
                // ----------------------------------

            }
            if (trovato < 0)
            {
                Debug.WriteLine("Parametro non trovato" + p.ToString());
                clsArbitrator.clrDoNotLoop2();
            }
            continuaRichiesta();

        }


        void initDatiLayout()
        {
            LayOutCassetteGrp = new gbOxConfig[]
            {
                new gbOxConfig() { // ------------------------------  FUNZIONAMENTO 0                    
                    cfgGbox = new gbInfo()
                    {
                        gpBox = gbFunzionamentoCassetta,
                        testo = loca.indice.GB0_FUNZIONAMENTO_CASSETTA
                    },
                     cfgLabel = new lblInfo[] {
                         new lblInfo() {
                             lbl = lbl_Funzionamento,
                             testo = loca.indice.FUNZIONAMENTO
                         },
                     },
                     cfgCombo = new comboInfo[]
                     {
                         new comboInfo() {
                             combo = comboFunzionamento,
                             lista = new loca.indice[] { loca.indice.VAV, loca.indice.STANDARD },
                             vDefault = 1,
                             numParametro = parametriCassetta.KK_FUNZIONAMENTO,

                        }
                     }
                }, // END ------------------------------  FUNZIONAMENTO 0
                new gbOxConfig() { // ------------------------------  REGOLAZIONE RISCALDAMENTO 1  
                    cfgGbox = new gbInfo()
                    {
                        gpBox = gbRiepilogoRiscaldamento,
                        testo = loca.indice.GB1_FUNZIONAMENTO_CASSETTA
                    },
                    cfgLabel = new lblInfo[] {      // LABELS
                         new lblInfo() {
                             lbl = lbl_ZomaMortaRiscaldamento,
                             testo = loca.indice.ZONA_MORTA_RISC_HDZ
                         },
                         new lblInfo() {
                             lbl = lbl_BandaDiregolazione,
                             testo = loca.indice.BANDA_REGOLAZIONE_RISC_HB
                         },
                        new lblInfo() {
                             lbl = lbl_KIRegolazioneRiscaldamento,
                             testo = loca.indice.KI_REGOLAZIONE_RISCALDAMENTO
                         },
                         new lblInfo() {
                             lbl = lbl_PeriodoModulazionePWM,
                             testo = loca.indice.PERIODO_MODULAZIONE_PWM
                         },
                         new lblInfo() {
                             lbl = lbl_MinimoDutyCycle,
                             testo = loca.indice.MINIMO_DC_RESISTENZA
                         },
                         new lblInfo() {
                             lbl = lbl_MassimoDutyCycle,
                             testo = loca.indice.MASSIMO_DC_RESISTENZA
                         },
                        new lblInfo() {
                             lbl = lbl_PotenzaNominaleResistenza,
                             testo = loca.indice.POTENZA_NOMINALE_RESISTENZA
                         },
                         new lblInfo() {
                             lbl = lbl_PresenzaResistenza,
                             testo = loca.indice.PRESENZA_RESISTENZA
                         },

                     },
                    cfgUpDown = new upDownInfo[]
                    {
                        new upDownInfo
                        {
                            numUpDown = nud_ZonaMortaRiscaldamento,     // 0
                            numParametro = parametriCassetta.KK_ZONA_MORTA_RISC_HDZ,
                            vDefault =(decimal) 0.5, vMin =(decimal) 0, vMax =(decimal) 5, vInc =(decimal) 0.1, nDec =(int) 1 ,
                        },
                        new upDownInfo
                        {
                            numUpDown = nud_BandaDiregolazione,         // 1
                            numParametro = parametriCassetta.KK_BANDA_REGOLAZIONE_RISC_HB,
                            vDefault =(decimal) 1, vMin =(decimal) 0.5, vMax =(decimal) 10, vInc =(decimal) 0.1, nDec =(int) 1 ,
                        },
                        new upDownInfo
                        {
                            numUpDown = nud_KIRegolazioneRiscaldamento, // 2
                            numParametro = parametriCassetta.KK_KI_REGOLAZIONE_RISCALDAMENTO,
                            vDefault =(decimal) 0, vMin =(decimal) 0, vMax =(decimal) 100, vInc =(decimal) 1, nDec =(int) 0 ,
                        },
                        new upDownInfo
                        {
                            numUpDown = nud_PeriofoModulazionePWM, // 3
                            numParametro = parametriCassetta.KK_PERIODO_MODULAZIONE_PWM,
                            vDefault =(decimal) 3, vMin =(decimal) 1, vMax =(decimal) 30, vInc =(decimal) 0.1, nDec =(int) 1 ,
                        },
                        new upDownInfo
                        {
                            numUpDown = nud_MinimoDutyCycle, // 4
                            numParametro = parametriCassetta.KK_MINIMO_DC_RESISTENZA,
                            vDefault =(decimal) 0, vMin =(decimal) 0, vMax =(decimal) 100, vInc =(decimal) 1, nDec =(int) 0 ,
                        },
                        new upDownInfo
                        {
                            numUpDown = nud_MassimoDutyCycle, // 5
                            numParametro = parametriCassetta.KK_MASSIMO_DC_RESISTENZA,
                            vDefault =(decimal) 100, vMin =(decimal) 0, vMax =(decimal) 100, vInc =(decimal) 1, nDec =(int) 0 ,
                        },
                        new upDownInfo
                        {
                            numUpDown = nud_PotenzaNominaleResistenza, // 6
                            numParametro = parametriCassetta.KK_POTENZA_NOMINALE_RESISTENZA,
                            vDefault =(decimal) 1800, vMin =(decimal) 800, vMax =(decimal) 2400, vInc =(decimal) 10, nDec =(int) 0
                        },
                    },
                    cfgRadioButton = new radioButtonInfo[]
                    {
                            new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_PresenzaResistenzaOFF, rb_PresenzaResistenzaON },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.OFF, loca.indice.ON },
                                vDefault = new int[] { 0, 1 },
                                numParametro = parametriCassetta.KK_PRESENZA_RESISTENZA,
                            }
                        }
                    },// END ------------------------------  REGOLAZIONE RISCALDAMENTO 1  
                new gbOxConfig() { // ------------------------------  FUNZIONAMENTO MAX POT RESISTEZA IN FUNAZIONE DELLA PORTATA  2
                    cfgGbox = new gbInfo()
                    {
                        gpBox = gbMaxPotenzaResistenzaFunzPortata,
                        testo = loca.indice.GB2_MAX_POT_RES
                    },
                    cfgLabel = new lblInfo[] {      // LABELS
                         new lblInfo() {
                             lbl = lbl_LimPotMaxResistenza,
                             testo = loca.indice.LIM_POT_MAX
                         },
                         new lblInfo() {
                             lbl = lbl_TenpAriaPrimaria,
                             testo = loca.indice.TEMP_ARIA_PRIM
                         },


                     },
                    cfgRadioButton = new radioButtonInfo[]
                    {
                            new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_LimPotMaxResistenzaOFF, rb_LimPotMaxResistenzaON },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.OFF, loca.indice.ON },
                                vDefault = new int[] { 0, 1 },
                                numParametro = parametriCassetta.KK_LIM_POT_MAX
                            }
                        },
                    cfgUpDown = new upDownInfo[]
                    {
                        new upDownInfo
                        {
                            numUpDown = nud_TempAriaPrimaria,
                            numParametro = parametriCassetta.KK_TEMP_ARIA_PRIM,
                            vDefault =(decimal) 15, vMin =(decimal) 10, vMax =(decimal) 20, vInc =(decimal) 1, nDec =(int) 0
                        },

                    },
                }, // END ------------------------------  FUNZIONAMENTO MAX POT RESISTEZA IN FUNAZIONE DELLA PORTATA  2
                new gbOxConfig() { // ------------------------------  Impostazione regolazione ambiente  3
                    cfgGbox = new gbInfo()
                    {
                        gpBox = gbImpostazioneRegolazioneAmbiente,
                        testo = loca.indice.GB3_IMP_REG_AMP
                    },
                    cfgLabel = new lblInfo[] {      // LABELS
                         new lblInfo() {
                             lbl = lbl_SetPointDefault,
                             testo = loca.indice.SETPOINT_DEFAULT
                         },
                         new lblInfo() {
                             lbl = lbl_deviazMaxSetpoint,
                             testo = loca.indice.DEV_MAX_SETPOINT
                         },
                         new lblInfo() {
                             lbl = lbl_IncZMEconomy,
                             testo = loca.indice.INCR_ZONA_MORTA_DZI
                         },

                     },
                    cfgUpDown = new upDownInfo[]
                    {
                        new upDownInfo
                        {
                            numUpDown = nud_SetPointDefault,
                            numParametro = parametriCassetta.KK_SETPOINT_DEFAULT,
                            vDefault =(decimal) 23, vMin =(decimal) 20, vMax =(decimal) 28, vInc =(decimal) 0.1, nDec =(int) 1 ,
                        },
                         new upDownInfo
                        {
                            numUpDown = nud_deviazMaxSetpoint,
                            numParametro = parametriCassetta.KK_DEV_MAX_SETPOINT,
                            vDefault =(decimal) 3, vMin =(decimal) 0, vMax =(decimal) 20, vInc =(decimal) 0.1, nDec =(int) 1 ,
                        }, new upDownInfo
                        {
                            numUpDown = nud_IncZMEconomy,
                            numParametro = parametriCassetta.KK_INCR_ZONA_MORTA_DZI,
                            vDefault =(decimal) 0.5, vMin =(decimal) 0, vMax =(decimal) 10, vInc =(decimal) 0.1, nDec =(int) 1
                        },
                    },

                }, // END ------------------------------  Impostazione regolazione ambiente 3
                new gbOxConfig() { // ------------------------------  4 Gestione temperatura  interna
                    cfgGbox = new gbInfo()
                    {
                        gpBox = gbGestioneTemperaturaInterna,
                        testo = loca.indice.GB4_REGOLAZIONTEMP_INTERNA
                    },
                    cfgLabel = new lblInfo[] {      // LABELS
                         new lblInfo() {
                             lbl = lbl_PrimaSogliaOFFResitenza,
                             testo = loca.indice.PRIMA_SOGLIA
                         },
                         new lblInfo() {
                             lbl = lbl_IsteresiPrimaSoglia,
                             testo = loca.indice.IST_PRIMA_SOGLIA
                         },
                         new lblInfo() {
                             lbl = lbl_SecondaSogliaOFFResitenza,
                             testo = loca.indice.SEC_SOGLIA
                         },
                         new lblInfo() {
                             lbl = lbl_IsteresiSecondaSoglia,
                             testo = loca.indice.IST_SECONDA_SOGLIA
                         },

                     },
                    cfgUpDown = new upDownInfo[]
                    {
                        new upDownInfo
                        {
                            numUpDown = nud_PrimaSogliaOFFResitenza,
                            numParametro = parametriCassetta.KK_PRIMA_SOGLIA,
                            vDefault =(decimal) 45, vMin =(decimal) 30, vMax =(decimal) 50, vInc =(decimal) 1, nDec =(int) 0 ,
                        },
                        new upDownInfo
                        {
                            numUpDown = nud__IsteresiPrimaSoglia,
                            numParametro = parametriCassetta.KK_IST_PRIMA_SOGLIA,
                            vDefault =(decimal) 2, vMin =(decimal) 0.5, vMax =(decimal) 5, vInc =(decimal) 0.1, nDec =(int) 1 ,
                        },
                         new upDownInfo
                        {
                            numUpDown = nud_SecondaSogliaOFFResitenza,
                            numParametro = parametriCassetta.KK_SEC_SOGLIA,
                            vDefault =(decimal) 55, vMin =(decimal) 20, vMax =(decimal) 60, vInc =(decimal) 1, nDec =(int) 0 ,
                        },
                        new upDownInfo
                        {
                            numUpDown = nud_IsteresiSecondaSoglia,
                            numParametro = parametriCassetta.KK_IST_SECONDA_SOGLIA,
                            vDefault =(decimal) 5, vMin =(decimal) 0.5, vMax =(decimal) 10, vInc =(decimal) 0.1, nDec =(int) 1
                        },
                    },

                }, // END ------------------------------  4 Gestione temperatura  interna
                new gbOxConfig() { // ------------------------------  5 Geometria cassetta                  
                    cfgGbox = new gbInfo()
                    {
                        gpBox = gbGeometriaCassetta,
                        testo = loca.indice.GB5_GEOMETRIA_CASSETTA
                    },
                     cfgLabel = new lblInfo[] {
                         new lblInfo() {
                             lbl = lbl_Diffusione,
                             testo = loca.indice.DIFFUSIONE
                         },
                     },
                     cfgCombo = new comboInfo[]
                     {
                         new comboInfo() {
                             combo = comboDiffusione,
                             lista = new loca.indice[] { loca.indice.DAL_BASSO, loca.indice.IN_LINEA },
                             numParametro = parametriCassetta.KK_DIFFUSIONE,
                             vDefault =0
                         }
                     }
                }, // END ------------------------------  5 Geometria cassetta
                new gbOxConfig() { // ------------------------------  6 Limiti temperatura mandata
                    cfgGbox = new gbInfo()
                    {
                        gpBox = gbLimitiTemperaturaMandata,
                        testo = loca.indice.GB6_LIMITE_TEMP_MANDATA
                    },
                    cfgLabel = new lblInfo[] {      // LABELS
                         new lblInfo() {
                             lbl = lbl_SetpointLimiteMassimoHLSP,
                             testo = loca.indice.SETPOINT_LIM_MAX_HLSP
                         },
                         new lblInfo() {
                             lbl = lbl_BandaRegolazioneLimiti,
                             testo = loca.indice.BANDA_REGOLAZIONE_LB
                         },
                     },
                    cfgUpDown = new upDownInfo[]
                    {
                         new upDownInfo
                        {
                            numUpDown = nud_SetpointLimiteMassimoHLSP,
                            numParametro = parametriCassetta.KK_SETPOINT_LIM_MAX_HLSP,
                            vDefault =(decimal) 40, vMin =(decimal) 20, vMax =(decimal) 80, vInc =(decimal) 1, nDec =(int) 0 ,
                        }, new upDownInfo
                        {
                            numUpDown = nud_BandaRegolazioneLimiti,
                            numParametro = parametriCassetta.KK_BANDA_REGOLAZIONE_LB,
                            vDefault =(decimal) 5, vMin =(decimal) 0, vMax =(decimal) 50, vInc =(decimal) 1, nDec =(int) 0
                        },
                    },

                }, // END ------------------------------  6 Limiti temperatura mandata
                new gbOxConfig() { // ------------------------------  7 Regolazione serranda1  
                    cfgGbox = new gbInfo()
                    {
                        gpBox = gbRegolazioneSerranda,
                        testo = loca.indice.GB7_REGOLAZIONESERRANDA
                    },
                    cfgLabel = new lblInfo[] {      // LABELS
                        new lblInfo() {
                             lbl = lbl_ZonaMortaSerrandaDDZ,
                             testo = loca.indice.ZONA_MORTA_SERRANDA_DDZ
                         },
                         new lblInfo() {
                             lbl = lbl_BandaDiRegolazioneSerranda,
                             testo = loca.indice.BANDA_DI_REG_SERRANDA_DB
                         },
                         new lblInfo() {
                             lbl = lbl_KIRegolazioneSerranda,
                             testo = loca.indice.KI_REGOLAZIONE_SERRANDA
                         },
                         new lblInfo() {
                             lbl = lbl_AperturaSerrandaMinima,
                             testo = loca.indice.APERT_SERRANDA_MIN
                         },
                        new lblInfo() {
                             lbl = lbl_AperturaserrandaMassima,
                             testo = loca.indice.APERT_SERRANDA_MAX
                         },
                         new lblInfo() {
                             lbl = lbl_PresenzaSerranda,
                             testo = loca.indice.PRESENZA_SERRANDA
                         },
                        new lblInfo() {
                             lbl = lbl_TensioneSerrandaMinima,
                             testo = loca.indice.TENSIONE_SERRANDA_MINIMA
                         },
                         new lblInfo() {
                             lbl = lbl_TensioneSerrandaMassima,
                             testo = loca.indice.TENSIONE_SERRANDA_MASSIMA
                         },
                         new lblInfo() {
                             lbl = lbl_LogicaFunzSerranda,  // 9
                             testo = loca.indice.LOGICA_FUNZIONAMENTO_SERRANDA
                         },

                     },
                    cfgUpDown = new upDownInfo[]
                    {
                        new upDownInfo
                        {
                            numUpDown = nud_ZonaMortaSerrandaDDZ,
                            numParametro = parametriCassetta.KK_ZONA_MORTA_SERRANDA_DDZ,
                            vDefault =(decimal) 0.5, vMin =(decimal) 0, vMax =(decimal) 5, vInc =(decimal) 0.1, nDec =(int) 1 ,
                        },
                        new upDownInfo
                        {
                            numUpDown = nud_BandaDiRegolazioneSerranda,
                            numParametro = parametriCassetta.KK_BANDA_DI_REG_SERRANDA_DB,
                            vDefault =(decimal) 1, vMin =(decimal) 0.5, vMax =(decimal) 10, vInc =(decimal) 0.1, nDec =(int) 1 ,
                        },
                        new upDownInfo
                        {
                            numUpDown = nud_KIRegolazioneSerranda,
                            numParametro = parametriCassetta.KK_KI_REGOLAZIONE_SERRANDA,
                            vDefault =(decimal) 0, vMin =(decimal) 0, vMax =(decimal) 100, vInc =(decimal) 1, nDec =(int) 0 ,
                        },
                        new upDownInfo
                        {
                            numUpDown = nud_AperturaSerrandaMinima,
                            numParametro = parametriCassetta.KK_APERT_SERRANDA_MIN,
                            vDefault =(decimal) 0, vMin =(decimal) 0, vMax =(decimal) 95, vInc =(decimal) 0.1, nDec =(int) 1 ,
                        },
                        new upDownInfo
                        {
                            numUpDown = nud_AperturaserrandaMassima,
                            numParametro = parametriCassetta.KK_APERT_SERRANDA_MAX,
                            vDefault =(decimal) 100, vMin =(decimal) 5, vMax =(decimal) 100, vInc =(decimal) 0.1, nDec =(int) 1
                        },
                        new upDownInfo
                        {
                            numUpDown = nud_TensioneSerrandaMinima,
                            numParametro = parametriCassetta.KK_TENSIONE_SERRANDA_MIN,
                            vDefault =(decimal)2,vMin =(decimal) 0,vMax =(decimal) 9.9,vInc =(decimal) 0.1,nDec =(int) 1
                        },
                        new upDownInfo
                        {
                            numUpDown = nud_TensioneSerrandaMassima,
                            numParametro = parametriCassetta.KK_TENSIONE_SERRANDA_MAX,
                            vDefault =(decimal)10,vMin =(decimal) 0.1,vMax =(decimal) 10,vInc =(decimal) 0.1,nDec =(int) 1
                        },

                    },
                    cfgRadioButton = new radioButtonInfo[]
                    {
                         new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_LogicaDir, rb_LogicaInv },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.DIRETTA, loca.indice.INVERSA },
                                numParametro = parametriCassetta.KK_LOGOCA_DIR,
                                vDefault = new int[] { 1,0},
                            },
                            new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_PresenzaSerrandaOFF, rb_PresenzaSerrandaON },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.OFF, loca.indice.ON },
                                vDefault = new int[] { 0, 1 },
                                numParametro = parametriCassetta.KK_PRESENZA_SERRANDA,
                            }
                        }
                    },// END ------------------------------  7 Regolazione serranda 
                new gbOxConfig() { // ------------------------------  8 Gestione modalità economy
                    cfgGbox = new gbInfo()
                    {
                        gpBox = gbGestioneModalitaEconomy,
                        testo = loca.indice.GB8_GEST_MOD_ECONOMY
                    },
                    cfgLabel = new lblInfo[] {      // LABELS
                         new lblInfo() {
                             lbl = lbl_TipoEconomy,
                             testo = loca.indice.TIPO_ECONOMY
                         },
                         new lblInfo() {
                             lbl = lbl_TastoEconomyRiduzione,
                             testo = loca.indice.TASTO_ECONOMY
                         },


                     },
                     cfgCombo = new comboInfo[]
                     {
                         new comboInfo() {
                             combo = comboTipoEcomomy,
                             lista = new loca.indice[] { loca.indice.T2_AUMENTO_ZM_E_BANDA, loca.indice.T3_OFF },
                             numParametro = parametriCassetta.KK_TIPO_ECONOMY,
                             vDefault = 0
                         }
                     },
                    cfgUpDown = new upDownInfo[]
                    {
                        new upDownInfo
                        {
                            numUpDown = nud_TastoEconomyRiduzione,
                            numParametro = parametriCassetta.KK_TASTO_ECONOMY_RID,
                            vDefault =(decimal) 0, vMin =(decimal) 0, vMax =(decimal) 100, vInc =(decimal) 1, nDec =(int) 0 ,

                        },

                    },
                }, // END ------------------------------  8 Gestione modalità economy
                new gbOxConfig() { // ------------------------------  9 Gestione portata
                    cfgGbox = new gbInfo()
                    {
                        gpBox = gbGestionePortata,
                        testo = loca.indice.GB9_GESTIONE_PORTATA
                    },
                   cfgLabel = new lblInfo[] {      // LABELS
                         new lblInfo() {
                             lbl = lbl_AbilitaDisabilitaPortataIstantanea,          // 0
                             testo = loca.indice.ABILITA_VIS_PORT_IST
                         },
                         new lblInfo() {
                             lbl = lbl_PortataMinima,   // 1
                             testo = loca.indice.PORT_MIN
                         },
                        new lblInfo() {
                             lbl = lbl_PortataMassima,  // 2
                             testo = loca.indice.PORT_MAX
                         },
                         new lblInfo() {
                             lbl = lbl_PortataMinimaSicurezza,  // 3
                             testo = loca.indice.PORT_MIN_SICUREZZA
                         },
                         new lblInfo() {
                             lbl = lbl_SezionePerMisiurazPortata,  // 4
                             testo = loca.indice.SEZIONE
                         },
                         new lblInfo() {
                             lbl = lbl_OffsetMisurazioneDiPortata,  // 5
                             testo = loca.indice.OFFSET_MIS_PORTATA
                         },
                        new lblInfo() {
                             lbl = lbl_TempoLetturaSensore,  // 6
                             testo = loca.indice.TEMP_LETT_SENSORE
                         },
                        // -------------------------------------------------------
                         new lblInfo() {
                             lbl = lbl_KApertura_0_10,  // 7
                             testo = loca.indice.K_APERT_SERR_0_10
                         },
                         new lblInfo() {
                             lbl = lbl_KApertura_10_20,  // 8
                             testo = loca.indice.K_APERT_SERR_10_20
                         },
                         new lblInfo() {
                             lbl = lbl_KApertura_20_30,  // 9
                             testo = loca.indice.K_APERT_SERR_20_30
                         },
                        new lblInfo() {
                             lbl = lbl_KApertura_30_40,  // 10
                             testo = loca.indice.K_APERT_SERR_30_40
                         },
                         new lblInfo() {
                             lbl = lbl_KApertura_40_50,  // 11
                             testo = loca.indice.K_APERT_SERR_40_50
                         },
                         new lblInfo() {
                             lbl = lbl_KApertura_50_60,  // 12
                             testo = loca.indice.K_APERT_SERR_50_60
                         },
                         new lblInfo() {
                             lbl = lbl_KApertura_60_70,  // 13
                             testo = loca.indice.K_APERT_SERR_60_70
                         },
                        new lblInfo() {
                             lbl = lbl_KApertura_70_80,  // 14
                             testo = loca.indice.K_APERT_SERR_70_80
                         },
                         new lblInfo() {
                             lbl = lbl_KApertura_80_90,  // 15
                             testo = loca.indice.K_APERT_SERR_80_90
                         },
                         new lblInfo() {
                             lbl = lbl_KApertura_90_100,  // 16
                             testo = loca.indice.K_APERT_SERR_90_100
                         },
                         // ------------------------------------------------
                         new lblInfo() {
                             lbl = lbl_PortataMinimaLS,  // 17
                             testo = loca.indice.PORTATA_LS
                         },
                        new lblInfo() {
                             lbl = lbl_PortataMassimaLS,  // 18
                             testo = loca.indice.PORTATA_LS
                         },
                                                new lblInfo() {
                             lbl = lbl_PortataMinimaSicurezzaLS,  // 19
                             testo = loca.indice.PORTATA_LS
                         },
                    },
                    cfgRadioButton = new radioButtonInfo[]
                    {
                            new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_AbilitaDisabilitaPortataIstantaneaOFF, rb_AbilitaDisabilitaPortataIstantaneaON },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.OFF, loca.indice.ON },
                                numParametro = parametriCassetta.KK_ABILITA_VIS_PORT_IST,
                                vDefault = new int[] { 1, 0 },
                            }
                        },
                    cfgUpDown = new upDownInfo[]
                    {
                        new upDownInfo
                        {
                            numUpDown = nud_PortataMinima, // 1
                            numParametro = parametriCassetta.KK_PORT_MIN,
                            vDefault =(decimal) 80, vMin =(decimal) 6, vMax =(decimal) 822, vInc =(decimal) 1, nDec =(int) 0 ,
                        },
                         new upDownInfo
                        {
                            numUpDown = nud_PortataMassima, // 2
                            numParametro = parametriCassetta.KK_PORT_MAX,
                            vDefault =(decimal) 300, vMin =(decimal) 6, vMax =(decimal) 822, vInc =(decimal) 1, nDec =(int) 0 ,
                        },
                          new upDownInfo
                        {
                            numUpDown = nud_PortataMinimaSicurezza, // 3
                            numParametro = parametriCassetta.KK_PORT_MIN_SICUREZZA,
                            vDefault =(decimal) 30, vMin =(decimal) 5, vMax =(decimal) 822, vInc =(decimal) 1, nDec =(int) 0 ,
                        },
                           new upDownInfo
                        {
                            numUpDown = nud_SezionePerMisiurazPortata, // 4
                            numParametro = parametriCassetta.KK_SEZIONE,
                            vDefault =(decimal) 80, vMin =(decimal) 50, vMax =(decimal) 500, vInc =(decimal) 1, nDec =(int) 0 ,
                        },
                        new upDownInfo
                        {
                            numUpDown = nud_OffsetMisurazioneDiPortata, // 5
                            numParametro = parametriCassetta.KK_OFFSET_MIS_PORTATA,
                            vDefault =(decimal) 0, vMin =(decimal) -40, vMax =(decimal) 50, vInc =(decimal) 1, nDec =(int) 0 ,
                        },
                         new upDownInfo
                        {
                            numUpDown = nud_TempoLetturaSensore, // 6
                            numParametro = parametriCassetta.KK_TEMP_LETT_SENSORE,
                            vDefault =(decimal) 8, vMin =(decimal) 5, vMax =(decimal) 30, vInc =(decimal) 1, nDec =(int) 0 ,
                        },
                         // -------------------------------------------------
                          new upDownInfo
                        {
                            numUpDown = nud_KApertura_0_10, // 7
                            numParametro = parametriCassetta.KK_K_APERT_SERR_0_10,
                            vDefault =(decimal) 1, vMin =(decimal) 0.3, vMax =(decimal) 2, vInc =(decimal) 0.001, nDec =(int) 3 ,
                        },
                           new upDownInfo
                        {
                            numUpDown = nud_KApertura_10_20, // 8
                            numParametro = parametriCassetta.KK_K_APERT_SERR_10_20,
                            vDefault =(decimal) 1, vMin =(decimal) 0.3, vMax =(decimal) 2, vInc =(decimal) 0.001, nDec =(int) 3 ,
                        },
                        new upDownInfo
                        {
                            numUpDown = nud_KApertura_20_30, // 9
                            numParametro = parametriCassetta.KK_K_APERT_SERR_20_30,
                            vDefault =(decimal) 1, vMin =(decimal) 0.3, vMax =(decimal) 2, vInc =(decimal) 0.001, nDec =(int) 3 ,
                        },
                         new upDownInfo
                        {
                            numUpDown = nud_KApertura_30_40, // 10
                            numParametro = parametriCassetta.KK_K_APERT_SERR_30_40,
                            vDefault =(decimal) 1, vMin =(decimal) 0.3, vMax =(decimal) 2, vInc =(decimal) 0.001, nDec =(int) 3 ,
                        },
                          new upDownInfo
                        {
                            numUpDown = nud_KApertura_40_50, // 11
                            numParametro = parametriCassetta.KK_K_APERT_SERR_40_50,
                            vDefault =(decimal) 1, vMin =(decimal) 0.3, vMax =(decimal) 2, vInc =(decimal) 0.001, nDec =(int) 3 ,
                        },
                           new upDownInfo
                        {
                            numUpDown = nud_KApertura_50_60, // 12
                            numParametro = parametriCassetta.KK_K_APERT_SERR_50_60,
                            vDefault =(decimal) 1, vMin =(decimal) 0.3, vMax =(decimal) 2, vInc =(decimal) 0.001, nDec =(int) 3 ,
                        },
                        new upDownInfo
                        {
                            numUpDown = nud_KApertura_60_70, // 13
                            numParametro = parametriCassetta.KK_K_APERT_SERR_60_70,
                            vDefault =(decimal) 1, vMin =(decimal) 0.3, vMax =(decimal) 2, vInc =(decimal) 0.001, nDec =(int) 3 ,
                        },
                         new upDownInfo
                        {
                            numUpDown = nud_KApertura_70_80, // 14
                            numParametro = parametriCassetta.KK_K_APERT_SERR_70_80,
                            vDefault =(decimal) 1, vMin =(decimal) 0.3, vMax =(decimal) 2, vInc =(decimal) 0.001, nDec =(int) 3 ,
                        },
                          new upDownInfo
                        {
                            numUpDown = nud_KApertura_80_90, // 15
                            numParametro = parametriCassetta.KK_K_APERT_SERR_80_90,
                            vDefault =(decimal) 1, vMin =(decimal) 0.3, vMax =(decimal) 2, vInc =(decimal) 0.001, nDec =(int) 3 ,
                        },
                           new upDownInfo
                        {
                            numUpDown = nud_KApertura_90_100, // 16
                            numParametro = parametriCassetta.KK_K_APERT_SERR_90_100,
                            vDefault =(decimal) 1, vMin =(decimal) 0.3, vMax =(decimal) 2, vInc =(decimal) 0.001, nDec =(int) 3 ,
                        },

                    },
                }, // END ------------------------------  9 Gestione portata
                new gbOxConfig() { // ------------------------------  10 Ingressi
                    cfgGbox = new gbInfo()
                    {
                        gpBox = gbIngressi,
                        testo = loca.indice.GB10_INGRESSI
                    },
                   cfgLabel = new lblInfo[] {      // LABELS
                         new lblInfo() {
                             lbl = lbl_IngressoDigitaleD1,          // 0
                             testo = loca.indice.INPUT_D1
                         },
                         new lblInfo() {
                             lbl = lbl_IngressoDigitaleD2,   // 1
                             testo = loca.indice.INPUT_D2
                         },
                        new lblInfo() {
                             lbl = lbl_IngressoDigitaleD3,  // 2
                             testo = loca.indice.INPUT_D3
                         },
                         new lblInfo() {
                             lbl = lbl_IngressoDigitaleNTC1,  // 3
                             testo = loca.indice.INPUT_NTC1
                         },
                         new lblInfo() {
                             lbl = lbl_IngressoDigitaleNTC2,  // 4
                             testo = loca.indice.INPUT_NTC2
                         },
                         new lblInfo() {
                             lbl = lbl_LogocaD1,  // 5
                             testo = loca.indice.LOGICA_D1
                         },
                        new lblInfo() {
                             lbl = lbl_LogocaD2,  // 6
                             testo = loca.indice.LOGICA_D2
                         },
                         new lblInfo() {
                             lbl = lbl_LogocaD3,  // 7
                             testo = loca.indice.LOGICA_D3
                         },


                         new lblInfo() {
                             lbl = lbl_Int_IntMandata,  // 10
                             testo = loca.indice.STR_INT_MANDATA
                         },
                    },
                   // -------------------
                     cfgCombo = new comboInfo[]
                     {
                         new comboInfo() {
                             combo = comboIngressoDigitaleD1,
                             lista = new loca.indice[] { loca.indice.TERM_RESISTENZA, loca.indice.ONOFF_DAREMOTO,loca.indice.STR_ECONOMY  },
                             numParametro = parametriCassetta.KK_ING_DIG_D1,
                             vDefault = 0
                         },
                          new comboInfo() {
                             combo = comboIngressoDigitaleD2,
                             lista = new loca.indice[] { loca.indice.TERM_RESISTENZA, loca.indice.ONOFF_DAREMOTO,loca.indice.STR_ECONOMY  },
                             numParametro = parametriCassetta.KK_ING_DIG_D2,
                             vDefault = 0
                         },
                           new comboInfo() {
                             combo = comboIngressoDigitaleD3,
                             lista = new loca.indice[] { loca.indice.TERM_RESISTENZA, loca.indice.ONOFF_DAREMOTO,loca.indice.STR_ECONOMY  },
                             numParametro = parametriCassetta.KK_ING_DIG_D3,
                             vDefault = 0
                         },
                         //   new comboInfo() {
                         //    combo = comboIngressoDigitaleNTC1,
                         //    // lista = new loca.indice[] { loca.indice.SONDA_INT, loca.indice.SONDA_MAND, loca.indice.SONDA_AMB  },
                         //    lista = new loca.indice[] { loca.indice.SONDA_INT  },
                         //    numParametro = parametriCassetta.KK_ING_DIG_NTC1,
                         //    vDefault = 0
                         //},
                         //    new comboInfo() {
                         //    combo = comboIngressoDigitaleNTC2,
                         //    // lista = new loca.indice[] { loca.indice.TERM_RESISTENZA, loca.indice.ONOFF_DAREMOTO, loca.indice.STR_ECONOMY,loca.indice.SONDA_INT, loca.indice.SONDA_MAND, loca.indice.SONDA_AMB },
                         //    lista = new loca.indice[] { loca.indice.SONDA_MAND, loca.indice.SONDA_AMB },
                         //    numParametro = parametriCassetta.KK_ING_DIG_NTC2,
                         //    vDefault = 0
                         //},
                     },

                    cfgRadioButton = new radioButtonInfo[]
                    {

                        new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_D1OFF, rb_D1ON },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.VUOTO, loca.indice.VUOTO },
                                numParametro = parametriCassetta.KK_ING_DIG_D1_ONOFF,
                                vDefault = new int[] { 0,1},
                            },

                        new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_D2OFF, rb_D2ON },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.VUOTO, loca.indice.VUOTO },
                                numParametro = parametriCassetta.KK_ING_DIG_D2_ONOFF,
                                vDefault = new int[] { 1, 0 },
                            },

                        new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_D3OFF, rb_D3ON },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.VUOTO, loca.indice.VUOTO },
                                numParametro = parametriCassetta.KK_ING_DIG_D3_ONOFF,
                                vDefault = new int[] { 1, 0 },
                            }   ,
                       
                        //new radioButtonInfo()
                        //    {
                        //        rButton = new RadioButton[] { rb_NTC2OFF, rb_NTC2ON },
                        //        testo = new loca.indice[] { loca.indice.VUOTO, loca.indice.VUOTO },
                        //        numParametro = parametriCassetta.KK_ING_DIG_NTC2_ONOFF,
                        //        vDefault = new int[] { 0,1},
                        //    },
                        new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_NTC2_SAmbiente, rb_NTC2_SMandata,rb_NTC2_OFF },
                                Enabled = new int[] { 0,0 ,0 },
                                testo = new loca.indice[] { loca.indice.SONDA_AMB, loca.indice.SONDA_MAND,loca.indice.OFF },
                                numParametro = parametriCassetta.KK_ING_DIG_NTC2,
                                vDefault = new int[] { 1,0,0},
                            },
                        // --------------------------------------------------------------
                        new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_NOD1, rb_NCD1 },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.NORM_AP, loca.indice.NORM_CH },
                                numParametro = parametriCassetta.KK_ING_DIG_D1_NCNO,
                                vDefault = new int[] { 0,1},
                            },
                        new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_NOD2, rb_NCD2 },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.NORM_AP, loca.indice.NORM_CH },
                                numParametro = parametriCassetta.KK_ING_DIG_D2_NCNO,
                                vDefault = new int[] { 0,1},
                            },
                        new radioButtonInfo()
                            {
                                rButton = new RadioButton[] { rb_NOD3, rb_NCD3 },
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.NORM_AP, loca.indice.NORM_CH },
                                numParametro = parametriCassetta.KK_ING_DIG_D3_NCNO,
                                vDefault = new int[] { 0,1},
                            },



                        },

                }, // END ------------------------------  10 Ingressi
                new gbOxConfig() { // ------------------------------  FUNZIONAMENTO 0                    
                    cfgGbox = new gbInfo()
                    {
                        gpBox = gbIntensitaLED,
                        testo = loca.indice.GB11_INTENSITALED
                    },
                     cfgLabel = new lblInfo[] {
                         new lblInfo() {
                             lbl = lblIntensitaLED,
                             testo = loca.indice.STR_SET_INTENSITALED
                         },
                     },
                    cfgUpDown = new upDownInfo[]
                    {
                        new upDownInfo
                        {
                            numUpDown = nud_IntensitaLED,
                            numParametro = parametriCassetta.KK_INTENSITA_LED,
                            vDefault =(decimal)1,vMin =(decimal) 0,vMax =(decimal) 1,vInc =(decimal) 1,nDec =(int) 0
                        },

                    },
                }, // END ------------------------------  FUNZIONAMENTO 0
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
                                Enabled = new int[] { 0,0 },
                                testo = new loca.indice[] { loca.indice.FC_RB_LBL_13_00, loca.indice.FC_RB_LBL_13_01 },
                                numParametro = parametriCassetta.KK_TIPO_DISPOSITIVO_MS,
                                vDefault = new int[] { 0,1},
                            },  // 1
                          },

                    cfgUpDown = new upDownInfo[]
                    {

                        new upDownInfo
                        {
                           numUpDown = nud_13_01_Indirizzo, // 1
                           numParametro = parametriCassetta.KK_INDIRIZZO,
                           vDefault =(decimal)0,vMin =(decimal) 0,vMax =(decimal) 255,vInc =(decimal) 1,nDec =(int) 0
                        },
                    },
                     cfgCombo = new comboInfo[]
                     {
                         new comboInfo() {
                             combo = cb_13_02_Baudrate,
                             lista = new loca.indice[] { loca.indice.FC_CB_13_00_2400, loca.indice.FC_CB_13_00_4800, loca.indice.FC_CB_13_00_9600, loca.indice.FC_CB_13_00_19200, loca.indice.FC_CB_13_00_38400, loca.indice.FC_CB_13_00_57600,loca.indice.FC_CB_13_00_115200, },
                             vDefault = 2,
                             numParametro = parametriCassetta.KK_BAUDRATE,
                        },
                           new comboInfo() {
                             combo = cb_13_03_Parita,
                             lista = new loca.indice[] { loca.indice.FC_CB_13_01_00_NESSUNA, loca.indice.FC_CB_13_01_00_PARI, loca.indice.FC_CB_13_01_00_DISPARI, },
                             vDefault = 0,
                             numParametro = parametriCassetta.KK_PARITA,
                        },
                             new comboInfo() {
                             combo = cb_13_04_StopBit,
                             lista = new loca.indice[] { loca.indice.FC_CB_13_02_BITSTOP_1, loca.indice.FC_BC_13_02_BITSTOP_2 },
                             vDefault = 0,
                             numParametro = parametriCassetta.KK_BITSTOP,
                        },
                     },
                },// ------------------------------ // PARAMETRI RETE 13             
            };
        }

        private void gbGestioneTemperaturaInterna_Enter(object sender, EventArgs e)
        {

        }

        private void lbl_KApertura_0_10_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void timerRxDati_Tick(object sender, EventArgs e)
        {
            int d;
            d = clsSerial.pop(Costanti.BITS_DEVICE_CASSETTE | Costanti.BITS_VIDEATA_PARAMETRI);
            while (d >= 0)
            {
                byte b = (byte)(d & 0xff);
                clsHandler.decode(b, this);
                d = clsSerial.pop(Costanti.BITS_DEVICE_CASSETTE | Costanti.BITS_VIDEATA_PARAMETRI);
                // handelrData
            }
        }


        public void calcoli(int p)
        {
            if (p == parametriCassetta.KK_PORT_MIN || p == parametriCassetta.KK_PORT_MAX || p == parametriCassetta.KK_PORT_MIN_SICUREZZA)
            {
                // converte l/s
                double pr = (double)nud_PortataMinima.Value / 3.6;
                string s = pr.ToString("F1") + " [l/s]";
                lbl_PortataMinimaLS.Text = s;

                pr = (double)nud_PortataMassima.Value / 3.6;
                s = pr.ToString("F1") + " [l/s]";
                lbl_PortataMassimaLS.Text = s;

                pr = (double)nud_PortataMinimaSicurezza.Value / 3.6;
                s = pr.ToString("F1") + " [l/s]";
                lbl_PortataMinimaSicurezzaLS.Text = s;

            }

        }

        const int GB_REG_SERRANDA = 7;
        const int GB_CFG_GESTIONE_PORTATA = 9;
        const int DISAB_PRESENZA_ON_OFF = 0x01;

        const int GB_CFG_INGRESSI = 10;



        public void campoDinamico(int parametro, int gruppo, int campo, int valore)
        {
            int i;
            // in base al valore di un campo ne setta altri
            switch (parametro)
            {
                case parametriCassetta.KK_TIPO_DISPOSITIVO_MS:
                    disabEnableModBus(valore);
                    for (i = 1; i < LayOutCassetteGrp[gruppo].cfgLabel.Length; i++) // salta la label Master/Slave
                        LayOutCassetteGrp[gruppo].cfgLabel[i].Enabled = 1;
                    for (i = 1; i < LayOutCassetteGrp[gruppo].cfgCombo.Length; i++)
                        LayOutCassetteGrp[gruppo].cfgCombo[i].Enabled = 1;
                    break;
                case parametriCassetta.KK_ING_DIG_NTC2:
                    if (valore == 1)       // abilitata MANDATA
                        clsArbitrator.setAbilitaMandata();
                    else
                    {
                        if (LayOutCassetteGrp[10].cfgLabel[8].testo == loca.indice.STR_INT_MANDATA)
                        {
                            clsArbitrator.setAbilitaMandata();
                        }
                        else
                        {
                            clsArbitrator.clrAbilitaMandata();
                        }
                    }
                    break;
                case parametriCassetta.KK_DIFFUSIONE:

                    if (valore == parametriCassetta.DAL_BASSO)
                    {

                        setNTC1Str(loca.indice.STR_INT_MANDATA);
                    }
                    else
                    {
                        setNTC1Str(loca.indice.SONDA_INT);
                    }
                    setLangage();
                    break;
                case parametriCassetta.KK_PRESENZA_SERRANDA:
                    {
                        // presenza serranda ON

                        for (i = 0; i < LayOutCassetteGrp[GB_REG_SERRANDA].cfgLabel.Length; i++)
                        {
                            if (LayOutCassetteGrp[GB_REG_SERRANDA].cfgLabel[i].lbl != lbl_PresenzaSerranda)
                            {
                                if (valore == 1)
                                {
                                    LayOutCassetteGrp[GB_REG_SERRANDA].cfgLabel[i].Enabled = LayOutCassetteGrp[GB_REG_SERRANDA].cfgLabel[i].Enabled & (~DISAB_PRESENZA_ON_OFF);
                                }
                                else
                                {
                                    LayOutCassetteGrp[GB_REG_SERRANDA].cfgLabel[i].Enabled = LayOutCassetteGrp[GB_REG_SERRANDA].cfgLabel[i].Enabled | DISAB_PRESENZA_ON_OFF;

                                }
                            }
                        }

                        for (i = 0; i < LayOutCassetteGrp[GB_REG_SERRANDA].cfgUpDown.Length; i++)
                        {
                            if (valore == 1)
                            {
                                LayOutCassetteGrp[GB_REG_SERRANDA].cfgUpDown[i].Enabled = LayOutCassetteGrp[GB_REG_SERRANDA].cfgUpDown[i].Enabled & (~DISAB_PRESENZA_ON_OFF);
                            }
                            else
                            {
                                LayOutCassetteGrp[GB_REG_SERRANDA].cfgUpDown[i].Enabled = LayOutCassetteGrp[GB_REG_SERRANDA].cfgUpDown[i].Enabled | DISAB_PRESENZA_ON_OFF;

                            }
                        }
                        for (i = 0; i < LayOutCassetteGrp[GB_REG_SERRANDA].cfgRadioButton.Length; i++)
                        {
                            if (LayOutCassetteGrp[GB_REG_SERRANDA].cfgRadioButton[i].numParametro != parametriCassetta.KK_PRESENZA_SERRANDA)
                            {
                                for (int j = 0; j < LayOutCassetteGrp[GB_REG_SERRANDA].cfgRadioButton[i].rButton.Length; j++)
                                    if (valore == 1)
                                    {
                                        LayOutCassetteGrp[GB_REG_SERRANDA].cfgRadioButton[i].Enabled[j] = LayOutCassetteGrp[GB_REG_SERRANDA].cfgRadioButton[i].Enabled[j] & (~DISAB_PRESENZA_ON_OFF);
                                    }
                                    else
                                    {
                                        LayOutCassetteGrp[GB_REG_SERRANDA].cfgRadioButton[i].Enabled[j] = LayOutCassetteGrp[GB_REG_SERRANDA].cfgRadioButton[i].Enabled[j] | DISAB_PRESENZA_ON_OFF;

                                    }
                            }
                        }


                        for (i = 7; i < LayOutCassetteGrp[GB_CFG_GESTIONE_PORTATA].cfgLabel.Length - 4; i++)
                        {
                            if (valore == 1)
                            {
                                LayOutCassetteGrp[GB_CFG_GESTIONE_PORTATA].cfgLabel[i].Enabled = LayOutCassetteGrp[GB_CFG_GESTIONE_PORTATA].cfgLabel[i].Enabled & (~DISAB_PRESENZA_ON_OFF);
                                LayOutCassetteGrp[GB_CFG_GESTIONE_PORTATA].cfgUpDown[i - 1].Enabled = LayOutCassetteGrp[GB_CFG_GESTIONE_PORTATA].cfgUpDown[i - 1].Enabled & (~DISAB_PRESENZA_ON_OFF);
                            }
                            else
                            {
                                LayOutCassetteGrp[GB_CFG_GESTIONE_PORTATA].cfgLabel[i].Enabled = LayOutCassetteGrp[GB_CFG_GESTIONE_PORTATA].cfgLabel[i].Enabled | DISAB_PRESENZA_ON_OFF;
                                LayOutCassetteGrp[GB_CFG_GESTIONE_PORTATA].cfgUpDown[i - 1].Enabled = LayOutCassetteGrp[GB_CFG_GESTIONE_PORTATA].cfgUpDown[i - 1].Enabled | DISAB_PRESENZA_ON_OFF;

                            }
                        }

                    }
                    break;
            }
            abilitaDisabilita();

        }


        void abilitaDisabilita()
        {

            int i;
            int j;
            for (int g = 0; g < LayOutCassetteGrp.Length; g++)
            {

                gbOxConfig GroupBpox = LayOutCassetteGrp[g];
                if (GroupBpox.cfgGbox.gpBox != gb_13_impMODBUS)
                {
                    if (GroupBpox.cfgGbox.Enabled == 0)
                        GroupBpox.cfgGbox.gpBox.Enabled = true;
                    else
                        GroupBpox.cfgGbox.gpBox.Enabled = false;
                    if (GroupBpox.cfgLabel != null)
                    {
                        for (i = 0; i < GroupBpox.cfgLabel.Length; i++)
                        {
                            GroupBpox.cfgLabel[i].lbl.Enabled = (GroupBpox.cfgLabel[i].Enabled == 0);
                        }
                    }
                    if (GroupBpox.cfgCombo != null)
                    {
                        // cancella lista precedente

                        for (i = 0; i < GroupBpox.cfgCombo.Length; i++)
                        {
                            GroupBpox.cfgCombo[i].combo.Enabled = (GroupBpox.cfgCombo[i].Enabled == 0);
                        }
                    }
                    if (GroupBpox.cfgRadioButton != null)
                    {
                        for (i = 0; i < GroupBpox.cfgRadioButton.Length; i++)
                        {
                            for (j = 0; j < GroupBpox.cfgRadioButton[i].rButton.Length; j++)
                            {
                                GroupBpox.cfgRadioButton[i].rButton[j].Enabled = (GroupBpox.cfgRadioButton[i].Enabled[j] == 0);
                            }
                            // selezione item di  default
                        }
                    }
                    if (GroupBpox.cfgUpDown != null)
                    {
                        for (i = 0; i < GroupBpox.cfgUpDown.Length; i++)
                        {

                            GroupBpox.cfgUpDown[i].numUpDown.Enabled = (GroupBpox.cfgUpDown[i].Enabled == 0);

                            // selezione item di  default
                        }
                    }
                }
            }
        }

        public void setNTC1Str(loca.indice t)
        {
            LayOutCassetteGrp[10].cfgLabel[8].testo = t;
            LayOutCassetteGrp[10].cfgLabel[8].lbl.Text = loca.getStr(LayOutCassetteGrp[10].cfgLabel[8].testo);

            if (t == loca.indice.STR_INT_MANDATA)
            {
                LayOutCassetteGrp[10].cfgRadioButton[3].rButton[1].Enabled = false;
                if (LayOutCassetteGrp[10].cfgRadioButton[3].rButton[1].Checked == true)
                {
                    LayOutCassetteGrp[10].cfgRadioButton[3].rButton[1].Checked = false;
                    LayOutCassetteGrp[10].cfgRadioButton[3].rButton[0].Checked = true;
                }
                clsArbitrator.setAbilitaMandata();
                LayOutCassetteGrp[10].cfgRadioButton[3].Enabled[1] = LayOutCassetteGrp[10].cfgRadioButton[3].Enabled[1] | DISAB_PRESENZA_ON_OFF;
            }
            else
            {
                // IN LINEA
                // NTC1 sonda INTERNA
                if (LayOutCassetteGrp[GB_CFG_INGRESSI].cfgRadioButton[3].rButton[1].Checked == true)
                // selezionato per NTC2 sonda mandata
                {
                    clsArbitrator.setAbilitaMandata();
                }
                else
                {
                    clsArbitrator.clrAbilitaMandata();
                }
                LayOutCassetteGrp[10].cfgRadioButton[3].Enabled[1] = LayOutCassetteGrp[10].cfgRadioButton[3].Enabled[1] & (~DISAB_PRESENZA_ON_OFF);
            }
            abilitaDisabilita();
        }

        void setAllVisibleInvisibile(int visInvis)
        {
            int i;
            int j;
            for (int g = 0; g < LayOutCassetteGrp.Length; g++)
            {
                gbOxConfig GroupBpox = LayOutCassetteGrp[g];
                LayOutCassetteGrp[g].cfgGbox.Visible = visInvis;


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
            for (int g = 0; g < LayOutCassetteGrp.Length; g++)
            {
                gbOxConfig GroupBpox = LayOutCassetteGrp[g];

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
                gb_14_impPrinc.Visible = false; // elimina selezione Principale/Secondario
            }
        }
        // --------------------------------------------------------------------
        // 
        //   ██████╗██╗      ██████╗ ███████╗███████╗
        //  ██╔════╝██║     ██╔═══██╗██╔════╝██╔════╝
        //  ██║     ██║     ██║   ██║███████╗█████╗  
        //  ██║     ██║     ██║   ██║╚════██║██╔══╝  
        //  ╚██████╗███████╗╚██████╔╝███████║███████╗
        //   ╚═════╝╚══════╝ ╚═════╝ ╚══════╝╚══════╝
        //                                           
        // --------------------------------------------------------------------



        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chiudi();

            this.Close();
        }

        void salvaFile()
        {
            int i;
            datiCassette.cancellaTabella();
            for (i = 0; i < parametriCassetta.NUMERO_PARAMETRI_KK; i++)
            {
                int v = getValoreParametro(i);
                datiCassette.salvaParametro(i, "", v);
            }
            datiCassette.saveFile("aa");
        }

        int getValoreParametro(int p)
        // p = numero parametro
        // buffer = buffer ricezione (F0 ... F7
        // pos = posizione del segno
        {
            int g;
            int j;
            int v = 0;
            int trovato = -1;

            for (g = 0; g < LayOutCassetteGrp.Length && trovato < 0; g++)
            {
                if (LayOutCassetteGrp[g].cfgCombo != null)
                {
                    for (j = 0; j < LayOutCassetteGrp[g].cfgCombo.Length && trovato < 0; j++)
                    {
                        if (LayOutCassetteGrp[g].cfgCombo[j].numParametro == p)
                        {
                            // trovato
                            trovato = j;
                            v = LayOutCassetteGrp[g].cfgCombo[j].combo.SelectedIndex;
                        }

                    }

                }

                if (LayOutCassetteGrp[g].cfgUpDown != null)
                {
                    for (j = 0; j < LayOutCassetteGrp[g].cfgUpDown.Length && trovato < 0; j++)
                    {
                        if (LayOutCassetteGrp[g].cfgUpDown[j].numParametro == p)
                        {
                            // trovato
                            trovato = j;
                            // trasformare decimali
                            v = utility.convert2Int(LayOutCassetteGrp[g].cfgUpDown[j].numUpDown.Value, LayOutCassetteGrp[g].cfgUpDown[j].nDec);
                        }

                    }

                }

                if (LayOutCassetteGrp[g].cfgRadioButton != null)
                {
                    for (j = 0; j < LayOutCassetteGrp[g].cfgRadioButton.Length && trovato < 0; j++)
                    {
                        if (LayOutCassetteGrp[g].cfgRadioButton[j].numParametro == p)
                        {
                            // trovato
                            trovato = j;
                            for (int k = 0; k < LayOutCassetteGrp[g].cfgRadioButton[trovato].rButton.Length; k++)
                            {
                                if (LayOutCassetteGrp[g].cfgRadioButton[trovato].rButton[k].Checked)
                                    v = k;
                            }
                        }
                    }
                }
            }
            return v;
        }

        private void salvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentFileName != null)
            {
                datiConfig.setDefaultDirFancoil(CurrentFileName);
                datiConfig.saveFile();
                datiCassette.saveFile(CurrentFileName);
            }
            else
            {
                saveAs();
            }
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

        private void rb_13_00_TipDisp_SLAVE_CheckedChanged(object sender, EventArgs e)
        {
            disabEnableModBus(Costanti.SLAVE);
        }

        private void fILEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        const int TIPO_PRINCIPALE = 0;
        const int TIPO_SECONDARIA = 0;
        private void rb_14_00_sec_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void timerTick_Tick(object sender, EventArgs e)
        {
            if (!clsSerial.serialPortIsOpen())
                this.Close();
        }






        // struttura label, parametro, value (un'altra label)
        struct lblNud
        {
            public Label l;
            public Label v;
        }

        void initDisabilitazioni()
        {
            DisabPrimaryLblArray = new Label[] {
                lbl_ZomaMortaRiscaldamento,
                lbl_BandaDiregolazione,
                lbl_KIRegolazioneRiscaldamento ,
                lbl_PeriodoModulazionePWM,
                lbl_SetPointDefault,
                lbl_deviazMaxSetpoint,
                lbl_IncZMEconomy,
                lbl_SetpointLimiteMassimoHLSP,
                lbl_BandaRegolazioneLimiti,
                lbl_TipoEconomy,
                lbl_TastoEconomyRiduzione,
                 };
            DisabPrimaryNudArray = new NumericUpDown[]
            {
                nud_ZonaMortaRiscaldamento,
                nud_BandaDiregolazione,
                nud_KIRegolazioneRiscaldamento,
                nud_PeriofoModulazionePWM,
                nud_SetPointDefault,
                nud_deviazMaxSetpoint,
                nud_IncZMEconomy,
                nud_SetpointLimiteMassimoHLSP,
                nud_BandaRegolazioneLimiti,
                nud_TastoEconomyRiduzione,
            };
            DisabPrimaryCBArray = new ComboBox[] { comboTipoEcomomy };

            oldPrimaryValue = 0;
        }

        void forzaDisabilitazioni()
        {
            oldPrimaryValue = -1;
            clsArbitrator.clrPrimario();
        }

        void timerAbilitaDisabilitaPrimary()
        {
            int i;
            int p = clsArbitrator.getPrimario();
            if (p != oldPrimaryValue)
            {
                oldPrimaryValue = p;
                for (i = 0; i < DisabPrimaryLblArray.Length; i++)
                {
                    DisabPrimaryLblArray[i].Enabled = (p != 0);
                }
                for (i = 0; i < DisabPrimaryNudArray.Length; i++)
                {
                    DisabPrimaryNudArray[i].Enabled = (p != 0);
                }
                for (i = 0; i < DisabPrimaryCBArray.Length; i++)
                {
                    DisabPrimaryCBArray[i].Enabled = (p != 0);
                }
            }
        }

        private void systemTimer_Tick(object sender, EventArgs e)
        {
            timerAbilitaDisabilitaPrimary();
            comTask.setAddressMasterSlave(nud_13_01_Indirizzo.Value, rb_13_00_TipDisp_MASTER.Checked);


        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String Filename = datiConfig.getDefaultDirFancoil();
            String directoryName = Path.GetDirectoryName(Filename);
            String myFile = Path.GetFileName(Filename);

            openFileDialog1.FileName = myFile;
            openFileDialog1.InitialDirectory = directoryName;
            openFileDialog1.Filter = "Cassette parameter (*.prm)|*.prm|All files (*.*)|*.*";
            openFileDialog1.DefaultExt = "s19";

            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                Filename = openFileDialog1.FileName;
                datiConfig.setDefaultDirFancoil(Filename);
                datiConfig.saveFile();
                datiCassette.Initdati(Filename);
                AggiornaCampi();
                CurrentFileName = Filename;
            }
        }


        void AggiornaCampi()
        {
            for (int r = 0; r < datiCassette.getNumeroTtaleParametri(); r++)
            {
                String Nome = datiCassette.getNomefromTabella(r);
                int p = datiCassette.getIDParametro(Nome);
                if (p >= 0)
                {
                    int v = datiCassette.getValorefromTabella(r);
                    aggiornaParametroDaFile(p, v);
                }
            }
        }

        public void aggiornaParametroDaFile(int p, int v)
        // p = numero parametro
        // v = valore parametro

        {
            Debug.WriteLine("Par: " + p.ToString());
            int g;
            int j;
            int trovato = -1;

            for (g = 0; g < LayOutCassetteGrp.Length && trovato < 0; g++)
            {
                if (LayOutCassetteGrp[g].cfgCombo != null)
                {
                    for (j = 0; j < LayOutCassetteGrp[g].cfgCombo.Length && trovato < 0; j++)
                    {
                        if (LayOutCassetteGrp[g].cfgCombo[j].numParametro == p)
                        {
                            // trovato
                            trovato = j;
                            LayOutCassetteGrp[g].cfgCombo[j].combo.SelectedIndex = v;
                            // campoDinamico(p, g, j, v);
                        }

                    }

                }
                // ----------------------------------
                if (LayOutCassetteGrp[g].cfgUpDown != null)
                {
                    for (j = 0; j < LayOutCassetteGrp[g].cfgUpDown.Length && trovato < 0; j++)
                    {
                        if (LayOutCassetteGrp[g].cfgUpDown[j].numParametro == p)
                        {
                            // trovato
                            trovato = j;
                            // trasformare decimali
                            decimal d = utility.convert2Decimal(v, LayOutCassetteGrp[g].cfgUpDown[j].nDec);
                            LayOutCassetteGrp[g].cfgUpDown[j].numUpDown.Value = d;
                            // calcoli(p);
                            // campoDinamico(p, g, j, v);
                        }

                    }
                }
                // ----------------------------------
                if (LayOutCassetteGrp[g].cfgRadioButton != null)
                {
                    for (j = 0; j < LayOutCassetteGrp[g].cfgRadioButton.Length && trovato < 0; j++)
                    {
                        if (LayOutCassetteGrp[g].cfgRadioButton[j].numParametro == p)
                        {
                            // trovato
                            trovato = j;
                            for (int k = 0; k < LayOutCassetteGrp[g].cfgRadioButton[trovato].rButton.Length; k++)
                            {
                                LayOutCassetteGrp[g].cfgRadioButton[trovato].rButton[k].Checked = (k == v);
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

        void saveAs()
        {
            String Filename = datiConfig.getDefaultDirCassette();
            String directoryName = Path.GetDirectoryName(Filename);
            saveFileDialog1.InitialDirectory = directoryName;
            saveFileDialog1.DefaultExt = "prm";
            saveFileDialog1.Filter = "Cassette parameter (*.prm)|*.prm";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Filename = saveFileDialog1.FileName;
                preparaTabellaDatiParametri();
                datiConfig.setDefaultDirCassette(Filename);
                datiConfig.saveFile();
                datiCassette.saveFile(Filename);
                // datiFancoil.Initdati(Filename);
                CurrentFileName = Filename;

            }
        }

        private void salvaComeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAs();
        }

        void preparaTabellaDatiParametri()
        {
            // legge tutti i dati dei parametri e li salva nella relativa tabella
            int g;
            int j;
            int v;
            datiCassette.cancellaTabella();
            int numeroTotaleParametri = datiCassette.getNumeroTtaleParametri();
            for (g = 0; g < LayOutCassetteGrp.Length; g++)
            {
                if (LayOutCassetteGrp[g].cfgCombo != null)
                {
                    for (j = 0; j < LayOutCassetteGrp[g].cfgCombo.Length; j++)
                    {
                        int ID = LayOutCassetteGrp[g].cfgCombo[j].numParametro;
                        String nomeParametro = datiCassette.getNomeParametro(ID);
                        v = LayOutCassetteGrp[g].cfgCombo[j].combo.SelectedIndex;
                        datiCassette.salvaParametro(ID, nomeParametro, v);



                    }

                }
                // ----------------------------------
                if (LayOutCassetteGrp[g].cfgUpDown != null)
                {
                    for (j = 0; j < LayOutCassetteGrp[g].cfgUpDown.Length; j++)
                    {

                        int ID = LayOutCassetteGrp[g].cfgUpDown[j].numParametro;
                        String nomeParametro = datiCassette.getNomeParametro(ID);
                        decimal x = LayOutCassetteGrp[g].cfgUpDown[j].numUpDown.Value;
                        v = (int)(x * (decimal)utility.potDieci(LayOutCassetteGrp[g].cfgUpDown[j].nDec));

                        datiCassette.salvaParametro(ID, nomeParametro, v);
                    }
                }
                // ----------------------------------
                if (LayOutCassetteGrp[g].cfgRadioButton != null)
                {
                    for (j = 0; j < LayOutCassetteGrp[g].cfgRadioButton.Length; j++)
                    {

                        int ID = LayOutCassetteGrp[g].cfgRadioButton[j].numParametro;
                        String nomeParametro = datiCassette.getNomeParametro(ID);
                        for (int k = 0; k < LayOutCassetteGrp[g].cfgRadioButton[j].rButton.Length; k++)
                        {

                            if (LayOutCassetteGrp[g].cfgRadioButton[j].rButton[k].Checked)
                            {
                                v = k;
                                datiCassette.salvaParametro(ID, nomeParametro, v);
                            }
                        }
                        // campoDinamico(p, g, j, v);
                    }

                }
            }
            //// ----------------------------------

        }

        private void lbl_TensioneSerrandaMinima_Click(object sender, EventArgs e)
        {

        }

        private void nud_TensioneSerrandaMinima_ValueChanged(object sender, EventArgs e)
        {
            if (nud_TensioneSerrandaMinima.Value >= nud_TensioneSerrandaMassima.Value)
            {
                if (nud_TensioneSerrandaMassima.Value != 0)
                    nud_TensioneSerrandaMinima.Value = nud_TensioneSerrandaMassima.Value - (decimal)0.1;
            }

        }

        private void nud_TensioneSerrandaMassima_ValueChanged(object sender, EventArgs e)
        {
            if (nud_TensioneSerrandaMassima.Value <= nud_TensioneSerrandaMinima.Value)
                nud_TensioneSerrandaMassima.Value = nud_TensioneSerrandaMinima.Value + (decimal)0.1;
        }

        private void lblIntensitaLED_Click(object sender, EventArgs e)
        {

        }

        private void lbl_ZomaMortaRiscaldamento_Click(object sender, EventArgs e)
        {

        }
        // tabella disabilitazione

    }
}


