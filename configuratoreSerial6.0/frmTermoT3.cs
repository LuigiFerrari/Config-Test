using configuratore;
using configuratore.costStatoT1;
using configuratore.statoCassette;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static configuratore.frmCassette;
using static configuratore.statoCassette.frmStatoCassette;

namespace configuratoreSerial6._0
{
    public partial class frmTermoT3 : Form
    {
        gbOxConfig[] LayOutT3Grp;
        clsRxBuffer rxBuffer;

        gbOx[] statoGrp;
        gbInfo cfgGbox;
        List<classGroupBoxT3> gBox;
        int progressivo;

        int parametroDaRichiedere;
        int statoDaRichiedere;
        int rchiedi;


        frmStartUp parent;
        int richiestoDa;

        classGroupBoxT3 gbTest;

        const String STR_MASTER = "0";

        public int getRichiestoDa() { return richiestoDa; }
        public frmTermoT3(String Type, String Info, frmStartUp lparent, Boolean DefaultData, int lrichiestoDa)
        {
            InitializeComponent();

            parent = lparent;
            richiestoDa = lrichiestoDa;
            initData();
            constStatoT2.init();
            initStato();
            global.glbfrmT3 = this;
            gBox = new List<classGroupBoxT3>();
            progressivo = 0;
            for (int i = 0; i < LayOutT3Grp.Length; i++)
            {
                gbTest = new classGroupBoxT3(LayOutT3Grp[i], this);
                // progressivo = gbTest.getProgresivo();
                // this.Controls.Add(gbTest.getGroupBox());
                gBox.Add(gbTest);
            }

            int fln = -1;
            int flg = -1;





            this.Text = Type + Info;

            clsArbitrator.setEsecuzione();
            //utility.setAllVisibleInvisibile(utility.SET_INVISIBLE_START, LayOutT1Grp);
            //utility.visibileInvisibile(LayOutT1Grp);


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
                labelFondo.Visible = true;
                labelIndice.Visible = true;
                tabControl.Visible = false;

            }
            else
            {
                labelFondo.Visible = false;
                labelIndice.Visible = false;
                labelPleaseWait.Visible = false;
            }
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
        private void btn_s1__00_LED_ROSSO_Click(object sender, EventArgs e)
        {

            int l = 0;
            OffAll(l);
            toggleStato(l);
            if (isStatoInON(l))
            {
                btn_s1__00_LED_ROSSO.Image = Resource1.LedRossoON;
            }
            else
            {
                btn_s1__00_LED_ROSSO.Image = global::configuratoreSerial6._0.Resource1.LedRossoOFF;
            }
            txMsg.txMsgOne(parametriT2.KT2_V_ROSSO, getStato(l), richiestoDa);
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

        int contatore;
        private void timerUnSecondo_Tick(object sender, EventArgs e)
        {
            val_temp_NTC1.Text = contatore.ToString();
            contatore++;
        }

        void initData()
        {
            LayOutT3Grp = new gbOxConfig[] {
                new gbOxConfig()
                {
                    cfgGbox = new gbInfo()
                    {
                        gpBox = t1_gb_0,
                        testo = loca.indice.T1_GB_0,
                    },
                     cfgLabel = new lblInfo[] {
                         new lblInfo() {
                             lbl = t1_lbl_0_02,
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
                     },

                     cfgUpDown = new upDownInfo[]
                    {
                      new upDownInfo
                        {
                            numUpDown = nud_0_04, // 5
                            numParametro = parametriT3.KT3_TIME_SLEEP_TIME,
                            vDefault =(decimal)0,vMin =(decimal) 0,vMax =(decimal) 180,vInc =(decimal) 1,nDec =(int) 0
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
                     },
                       cfgUpDown = new upDownInfo[]
                    {
                        new upDownInfo
                        {
                            numUpDown = t1_nud_1_01_Indirizzo, // 0
                            numParametro = parametriT1.KT2_INDIRIZZO,
                            vDefault =(decimal)1,vMin =(decimal) 0,vMax =(decimal) 255,vInc =(decimal) 1,nDec =(int) 0
                        },
                    }


                }, // GB 1
            };

        }


        void initStato()
        {
            statoGrp = new gbOx[]
            {
                new gbOx()
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
                        mlabel=lbl_temp_NTC1,
                        text=lStat.Indice.T1_LBL_S0_00,   // Temp NTC1
                    },
                        new sLabel()
                    {
                        mlabel=lbl_temp_NTC_ext,
                        text=lStat.Indice.T1_LBL_S0_02, // Temp NTC EXT
                    },
                                                new sLabel()
                    {
                        mlabel=lbl_temp_NTC2,
                        text=lStat.Indice.T1_LBL_S0_01, // Temp NTC EXT
                    },
                        new sLabel()
                    {
                        mlabel=lbl_temp_NTC_board,
                        text=lStat.Indice.T1_LBL_S0_03, // // Temp NTC BOARD
                    },
                        new sLabel()
                    {
                        mlabel=lbl_setpoint,
                        text=lStat.Indice.T1_LBL_S0_04,
                    },
                        new sLabel()
                    {
                        mlabel=lbl_tems_alim,
                        text=lStat.Indice.LBL_52_24Volt, // Fan
                    },
                             new sLabel()
                    {
                        mlabel=lbl_dev_max_sp,
                        text = lStat.Indice.T2_LBL_S2_01,
                    },
                                    new sLabel()
                    {
                        mlabel=lbl_setpoint_default,
                        text =lStat.Indice.T1_LBL_S0_07,
                    },

                        new sLabel()
                {
                    mlabel=lbl_errore_NTC1,
                    text=lStat.Indice.T1_LBL_S0_06,
                },
                        new sLabel()
                    {
                    mlabel=lbl_errore_NTC_ext,
                    text=lStat.Indice.T1_LBL_S0_06,
                },
                        new sLabel()
                {
                    mlabel=lbl_errore_NTC2,
                    text=lStat.Indice.T1_LBL_S0_06,
                },
                        new sLabel()
                {
                    mlabel=lbl_errore_NTC__board,
                    text=lStat.Indice.T2_LBL_S0_02,
                },
                        new sLabel()
                {
                    mlabel=lbl_ebabòe_disable,
                    text=lStat.Indice.T2_LBL_S0_03,
                },


                    },
                    valLabel = new Label[] {
                        val_temp_NTC1,          // 1
                        val_temp_NTC_ext,       // 2
                        val_temp_NTC2,          // 3
                        val_temp_NTC_BOARD,     // 4
                        val_setpoint,           // 5
                        val_v_alim,             // 6
                        val_dev_max_sp,         // 7
                        val_default_setpoint,   // 8
                        val_err_NTC1,           // 9
                        val_err_TTX_EXT,        // 10
                        val_err_NTC2,           // 11
                        val_err_NTC_BOARD,      // 12
                        val_DND,                // 13  
                        val_MKR,                // 14
                        val_QC                  // 15
                    },
                    vvParametro = new int[] {
                        constStatoT2.T2S_TEMP_NTC1,            // 1  
                        constStatoT2.T2S_TEMP_NTCEXT,          // 2 
                        constStatoT2.T2S_TEMP_NTC2,            // 3
                        constStatoT2.T2S_TEMP_NTCBOARD,        // 4
                        constStatoT2.T2S_TEMP_SETPOINT,        // 5 // setpoint discreto 0 ~ 10
                        constStatoT2.T2S_ALIM_VOLT,            // 6
                        constStatoT2.T2S_DEVIAZIONE_SETPOINT,  // 7
                        constStatoT2.T2S_DEFAULT_SETPOINT,     // 8                                                                      
                        constStatoT2.T2S_ERR_NTC1,           // 9
                        constStatoT2.T2S_ERR_NTCEXT,             // 10
                        constStatoT2.T2S_ERR_NTC2,         // 11
                        constStatoT2.T2S_ERR_NTCBOARD,        // 12
                        constStatoT2.T2S_LED_DND,              // 13
                        constStatoT2.T2S_LED_MKR,              // 14
                        constStatoT2.T2S_QUICK_COOLING,   // 15
                    },
                },
                new  gbOx()
                {
                    SgpBox= new box()
                    {
                        gpBox = t1_gb_s2_matricola,
                        text = lStat.Indice.T1_GB_S2
                    },
                    infoLabel = new sLabel[]
                    {
                        new sLabel()
                        {
                            mlabel=t1_lbl_s2_00,
                            text=lStat.Indice.T1_LBL_S2_00,   // Matricola
                        },
                         new sLabel()
                        {
                            mlabel=t2_lbl_s2_01,
                            text=lStat.Indice.T1_LBL_S2_02,   // Indirizzo slave
                        },
                                                  new sLabel()
                        {
                            mlabel=t2_lbl_s2_02,
                            text=lStat.Indice.LBL_63_MasterSlave,   // Master/Slave
                        },
                                                                                                   new sLabel()
                        {
                            mlabel=lbl_sw_release,
                            text=lStat.Indice.T2_LBL_SW_R,   // sw. release
                        },
                    },
                    valLabel = new Label[] { t1_val_matricola, t1_val_s2_04_sw_rel, t1_val_s2_01,valMasterSlave},  // 
                    vvParametro = new int[] { constStatoT2.T2S_MATRICOLA_00, constStatoT2.T2S_INDIRIZZO_SLAVE, constStatoT2.T2S_MASTERSLAVE, constStatoT2.T2S_VERSIONE_00 },
                },

                new gbOx()    // ---------- 0
                 {
                    SgpBox = new box()
                        {
                            gpBox = t1_gb_s1_forzature,
                            text = lStat.Indice.TXT_gbForzature,
                        }
                  },   
                  // ---------- 1          
            };
        }

        private void frmTermoT3_Load(object sender, EventArgs e)
        {
            setLangage();
            // costAl.
            updateAllLAbel();
        }

        void updateAllLAbel()
        {
            int g;
            int l;
            constStatoT2.lbl r;
            for (g = 0; g < statoGrp.Length; g++)
            {
                if (statoGrp[g].valLabel != null)
                {
                    for (l = 0; l < statoGrp[g].valLabel.Length; l++)
                    {
                        int p = statoGrp[g].vvParametro[l];

                        r = constStatoT2.getFormatStato(p);
                        statoGrp[g].valLabel[l].Text = r.Text;
                        if (r.NochangeColor == true)
                        {
                            statoGrp[g].valLabel[l].BackColor = r.bckColor;
                        }

                    }
                }
            }
        }
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

            for (i = 0; i < LayOutT3Grp.Length; i++)
            {
                LayOutT3Grp[i].cfgGbox.gpBox.Text = loca.getStr(LayOutT3Grp[i].cfgGbox.testo);
                if (LayOutT3Grp[i].cfgLabel != null)
                {
                    for (j = 0; j < LayOutT3Grp[i].cfgLabel.Length; j++)
                        LayOutT3Grp[i].cfgLabel[j].lbl.Text = loca.getStr(LayOutT3Grp[i].cfgLabel[j].testo);
                }
            }

        }

        private void t1_rb_s0_1_0_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_s1__01_LED_VERDE_Click_1(object sender, EventArgs e)
        {
            int l = 1;
            OffAll(l);
            toggleStato(l);
            if (isStatoInON(l))
            {
                btn_s1__01_LED_VERDE.Image = Resource1.LedVerdeON;
            }
            else
            {
                btn_s1__01_LED_VERDE.Image = global::configuratoreSerial6._0.Resource1.LedVerdeOFF;
            }
            txMsg.txMsgOne(parametriT2.KT2_V_VERDE, getStato(l), richiestoDa);
        }
    }
}

