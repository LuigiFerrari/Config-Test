using configuratore.statoCassette;
using configuratoreSerial6._0;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static configuratore.statoCassette.frmStatoCassette;

namespace configuratore.stato
{
    public partial class frmStatoFanCoil : Form
    {
        gbOx[] statoFancoilGrp;
        clsRxBuffer rxBuffer;
        int statoDaRichiedere;
        int rchiedi;
        int richiestoDa;
        int indirizzo;

        Label[] labelGialle;

        public bool forzaChiusura = true;
        public frmStatoFanCoil(String Type, String Info, int lrichiestoDa)
        {
            InitializeComponent();
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, val_2_13.Width, val_2_13.Height);

            this.val_2_13.Region = new Region(path);

            costAlFanCoil.init();
            initStatoFancoil();
            rxBuffer = new clsRxBuffer();
            abilitaTimerRichiesta();
            richiestoDa = lrichiestoDa;// & Costanti.RICHIESTA_DA_MASTER;
            indirizzo = lrichiestoDa & (~Costanti.RICHIESTA_DA_MASTER);
            if (lrichiestoDa >= 0)
                timerTick.Enabled = true;
            String sRichiestoDa = "";
            if (richiestoDa != 0)
                sRichiestoDa = " (MASTER)";
            this.Text = Type + Info + sRichiestoDa;
            initButtonArray();
            global.setStatoFanCoil(this);
            initForzarure();
            labelGialle = cercaLabel(val_3_00); //  val_3_00)
        }

        public byte[] getRxBuffr() { return rxBuffer.getRxBuffer(); }
        public clsRxBuffer getRxBufferClass() { return rxBuffer; }
        void abilitaTimerRichiesta()
        {
            statoDaRichiedere = 0;
            rchiedi = 1;
        }

        private void frmStatoFanCoil_Load(object sender, EventArgs e)
        {
            setLangage();
            // costAl.
            updateAllLAbel();

            richiedi();
            this.MaximizeBox = false;

        }

        public void setLangage()
        {
            int i;
            int j;
            for (i = 0; i < statoFancoilGrp.Length; i++)
            {
                statoFancoilGrp[i].SgpBox.gpBox.Text = lStat.getStr(statoFancoilGrp[i].SgpBox.text);
                for (j = 0; j < statoFancoilGrp[i].infoLabel.Length; j++)
                    statoFancoilGrp[i].infoLabel[j].mlabel.Text = lStat.getStr(statoFancoilGrp[i].infoLabel[j].text);
            }
        }

        void updateAllLAbel()
        {
            int g;
            int l;
            costAl.lbl r;
            for (g = 0; g < statoFancoilGrp.Length; g++)
            {
                if (statoFancoilGrp[g].valLabel != null)
                {
                    for (l = 0; l < statoFancoilGrp[g].valLabel.Length; l++)
                    {
                        int p = statoFancoilGrp[g].vvParametro[l];

                        r = costAlFanCoil.getFormatStato(p);
                        statoFancoilGrp[g].valLabel[l].Text = r.Text;
                        if (r.NochangeColor == true)
                        {
                            statoFancoilGrp[g].valLabel[l].BackColor = r.bckColor;
                        }

                    }
                }
            }
        }

        Boolean isGialla(Label l)
        {
            Boolean trovato = false;
            for (int i = 0; i < labelGialle.Length && trovato == false; i++)
            {
                if (l == labelGialle[i])
                {
                    trovato = true;
                }
            }
            return trovato;
        }

        void setAlarm(Label l, int v)
        {
            if (v == 0 || v < 0)
            {
                l.BackColor = Color.Gray;
                l.Text = "";
            }
            else
            {
                if (v != 0)
                {
                    if (isGialla(l))
                        l.BackColor = Color.Yellow;
                    else
                        l.BackColor = Color.Red;
                    l.Text = "";
                }
            }
        }


        // in realtà aggiorna lo stato anche se si chiama aggiorna parametro

        String[] bStati = new string[costAlFanCoil.FCS_NUMERO_STATI];
        public void aggiornaParametro(int p, byte[] buffer, int pos)
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
            int nbyte = costAlFanCoil.getSizeStato(p);
            //Debug.Write("Stato ");
            //Debug.Write(p);
            //Debug.Write(" nbyte ");
            //Debug.Write(nbyte);
            //Debug.Write("  ");

            for (g = 0; g < statoFancoilGrp.Length && trovato < 0; g++)
            {
                if (statoFancoilGrp[g].vvParametro != null)
                {
                    for (j = 0; j < statoFancoilGrp[g].vvParametro.Length && trovato < 0; j++)
                    {
                        if (statoFancoilGrp[g].vvParametro[j] == p)
                        {
                            // trovato
                            trovato = j;
                            switch (costAlFanCoil.getTipoParametro(p))
                            {
                                case 'B':
                                    v = utility.conv728(buffer, pos + 1, nbyte);
                                    s = v.ToString();
                                    setAlarm(statoFancoilGrp[g].valLabel[j], v);
                                    // Debug.WriteLine(v);

                                    break;
                                case 'S':
                                    s = "";
                                    for (int i = 0; i < costAl.MAX_SIZE_STRING; i++)
                                        s = s + (char)buffer[pos + i + 1];
                                    statoFancoilGrp[g].valLabel[j].Text = s;
                                    skipNum = costAl.MAX_SIZE_STRING / 2;
                                    // Debug.WriteLine(s);
                                    break;
                                case 'V':
                                    s = "";
                                    for (int i = 0; i < costAl.MAX_SIZE_VERSIONE; i++)
                                        s = s + (char)buffer[pos + i + 1];
                                    statoFancoilGrp[g].valLabel[j].Text = s;
                                    // Debug.WriteLine(s);
                                    skipNum = costAl.MAX_SIZE_VERSIONE / 2;
                                    break;
                                case 'N':
                                    v = utility.conv728(buffer, pos + 1, nbyte);
                                    int d = costAlFanCoil.getdecimali(p);
                                    s = utility.convertToString(v, d);
                                    switch (p)
                                    {
                                        case costAlFanCoil.FCS_TEMPERATURA_RIPRESA:
                                            if (!global.isNTC2on())
                                                s = "--";
                                            break;
                                        case costAlFanCoil.FCS_TEMPERATURA_MANDATA:
                                            if (!global.isNTC1on())
                                                s = "--";
                                            break;
                                        //case costAlFanCoil.FCS_AL_SONDA_TEMP_MANDATA:
                                        //    if()
                                        case costAlFanCoil.FCS_SONDA_REGOLAZIONE:
                                            switch (v)
                                            {
                                                case 0:
                                                    s = loca.getStr(loca.indice.FC_CB_8_00_01);
                                                    break;
                                                case 1:
                                                    s = loca.getStr(loca.indice.FC_CB_8_00_02);
                                                    break;
                                                case 2:
                                                    s = loca.getStr(loca.indice.FC_CB_8_00_03);
                                                    break;
                                                case 3:
                                                    s = loca.getStr(loca.indice.FC_CB_8_00_04);
                                                    break;

                                            }
                                            break;
                                        case costAlFanCoil.FCS_ECONOMY_TYPE:
                                            String str = "";
                                            switch (v)
                                            {
                                                case 0:
                                                    str = "";
                                                    break;
                                                case 1:
                                                    str = loca.getStr(loca.indice.FC_CB_17_00_TIPO_ECONOMY_00);
                                                    break;
                                                case 2:
                                                    str = loca.getStr(loca.indice.FC_CB_17_00_TIPO_ECONOMY_01);
                                                    break;
                                                case 3:
                                                    str = loca.getStr(loca.indice.FC_CB_17_00_TIPO_ECONOMY_02);
                                                    break;
                                                case 4:
                                                    str = loca.getStr(loca.indice.FC_CB_17_00_TIPO_ECONOMY_03);
                                                    break;
                                            }
                                            s = str;
                                            break;
                                        case costAlFanCoil.FCS_MASTER_SLAVE:
                                            if (v == 0)
                                            {
                                                s = "M";
                                                // se MASTER disabilito indirizzo Slave
                                                lbl_0_01.Enabled = false;
                                                val_0_01_Indirizzo.Enabled = false;
                                            }
                                            else
                                            {
                                                s = "S";
                                                lbl_0_01.Enabled = true;
                                                val_0_01_Indirizzo.Enabled = true;
                                            }
                                            break;
                                        case costAlFanCoil.FCS_DISP_PRIMARIO:
                                            if (v == 0)
                                            {
                                                pictureBoxPrimaryDevice.Image = global::configuratoreSerial6._0.Resource1.PrincipaleOFF;
                                                clsArbitrator.clrPrimario();
                                            }
                                            else
                                            {
                                                pictureBoxPrimaryDevice.Image = global::configuratoreSerial6._0.Resource1.PrincipaleON;
                                                clsArbitrator.setPrimario();
                                            }
                                            break;
                                    }
                                    statoFancoilGrp[g].valLabel[j].Text = s;
                                    // Debug.WriteLine(s);
                                    break;
                            }

                        }

                    }

                }
            }
            bStati[p] = s;
            if (trovato < 0)
            {
                // Debug.WriteLine("Stato " + p.ToString() + " non in videata");
                switch (p)
                {
                    case costAlFanCoil.FCS_TIPO_SENS_PRESSIONE:
                        v = utility.conv728(buffer, pos + 1, nbyte);
                        if (v == 0)
                        {
                            // sensore di press. differenziale
                            lbl_1_03.Text = lStat.getStr(lStat.Indice.FS_LBL_1_03);
                        }
                        else
                        {
                            lbl_1_03.Text = lStat.getStr(lStat.Indice.FS_LBL_1_07);

                        }
                        break;
                }
            }
            continuaRichiesta(skipNum);
        }



        void richiedi()
        {
            if (rchiedi == 1)
            {
                txMsg.requireParameter(statoDaRichiedere, Costanti.BITS_DEVICE_FANCOIL | Costanti.BITS_VIDEATA_STATO, richiestoDa | indirizzo);
                // Debug.Write("Stato da richiedere "); Debug.WriteLine(statoDaRichiedere);
                rchiedi = 0;
            }
        }

        void continuaRichiesta(int skipNum)
        {
            if (statoDaRichiedere >= 0)
            {
                rchiedi = 1;
                statoDaRichiedere = statoDaRichiedere + skipNum;
                if (statoDaRichiedere < costAlFanCoil.FCS_NUMERO_STATI)
                {
                    richiedi();
                }
                else
                {
                    rchiedi = 0;
                    statoDaRichiedere = -1;
                    timerRefresh.Enabled = true;

                }
            }
        }


        Label[] cercaLabel(Label lbl) //  val_3_00)
        {
            int g;
            int trovato = -1;
            int trovatog = -1;
            for (g = 0; g < statoFancoilGrp.Length && trovatog < 0; g++)
            {
                if (statoFancoilGrp[g].valLabel != null)
                {
                    for (int k = 0; k < statoFancoilGrp[g].valLabel.Length && trovato < 0; k++)
                    {
                        if (statoFancoilGrp[g].valLabel[k] == lbl)
                        {
                            trovato = k;
                            trovatog = g;
                        }
                    }
                }
            }
            return statoFancoilGrp[trovatog].valLabel;
        }

        void initStatoFancoil()
        {

            statoFancoilGrp = new gbOx[]
            {
                new gbOx()    // ---------- 0
                {
                    SgpBox = new box()
                        {
                            gpBox = gb_0_InfoMatricola,
                            text = lStat.Indice.FS_GB_0_FANCOIL
                        },
                    infoLabel = new sLabel[]
                    {
                        new sLabel()
                        {
                            mlabel = lbl_0_00,
                            text = lStat.Indice.FS_LBL_0_00,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_0_01,
                            text = lStat.Indice.FS_LBL_0_01,
                        },

                        new sLabel()
                        {
                            mlabel = lbl_0_02,
                            text = lStat.Indice.FS_LBL_0_02,
                        },

                        new sLabel()
                        {
                            mlabel = lbl_0_03,
                            text = lStat.Indice.FS_LBL_0_03,
                        },

                    },
                    valLabel = new Label[] { val_0_00_Matricola, val_0_01_Indirizzo, val_0_02_MS, val_0_03_PS,val_SoftwareRelease },
                    vvParametro = new int[] { costAlFanCoil.FCS_MATRICOLA_00, costAlFanCoil.FCS_INDIRIZZO_SLAVE, costAlFanCoil.FCS_MASTER_SLAVE, costAlFanCoil.FCS_DISP_PRIMARIO, costAlFanCoil.FCS_VERSIONE_00 }
                },   // ---------- 0

                new gbOx()    // ---------- 1
                {
                    SgpBox = new box()
                        {
                            gpBox = gb_1_Ingressi,
                            text = lStat.Indice.FS_GB_1_INGRESSI
                        },
                    infoLabel = new sLabel[]
                    {
                        new sLabel()
                        {
                            mlabel = lbl_1_00,
                            text = lStat.Indice.FS_LBL_1_00,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_1_01,
                            text = lStat.Indice.FS_LBL_1_01,
                        },

                        new sLabel()
                        {
                            mlabel = lbl_1_02,
                            text = lStat.Indice.FS_LBL_1_02,
                        },

                        new sLabel()
                        {
                            mlabel = lbl_1_03,
                            text = lStat.Indice.FS_LBL_1_03,
                        },
                                                new sLabel()
                        {
                            mlabel = lbl_1_04,
                            text = lStat.Indice.FS_LBL_1_04,
                        },

                        new sLabel()
                        {
                            mlabel = lbl_1_05,
                            text = lStat.Indice.FS_LBL_1_05,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_1_07,
                            text = lStat.Indice.LBL_57_ADJTEMPTERM,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_1_08,
                            text = lStat.Indice.FS_LBL_1_06,
                        },
                         new sLabel()
                        {
                            mlabel = lbl_1_09,
                            text = lStat.Indice.FS_LBL_1_08,
                        },

                    },
                    valLabel = new Label[] { val_1_00, val_1_01, val_1_02, val_1_03, val_1_09, val_1_04, val_1_05, val_1_06,val_1_07 ,val_1_08},
                    vvParametro = new int[] { costAlFanCoil.FCS_SONDA_REGOLAZIONE,
                        costAlFanCoil.FCS_TEMP_SONDA,
                        costAlFanCoil.FCS_SETPOINT_TEMP   ,
                        costAlFanCoil.FCS_TEMPERATURA_MANDATA,
                        costAlFanCoil.FCS_TEMPERATURA_RIPRESA,
                        costAlFanCoil.FCS_PRESSIONE_DIFFER,
                        costAlFanCoil.FCS_CO2,
                        costAlFanCoil.FCS_VOC,
                        costAlFanCoil.FCS_DISCRETE_SETPOINT ,
                        costAlFanCoil.FCS_TEMP_TERMOSTATO}
                },   // ---------- 1
                new gbOx()    // ---------- 2
                {
                    SgpBox = new box()
                        {
                            gpBox = gb_2_Regolazioni,
                            text = lStat.Indice.FS_GB_2_REGOLAZIONE
                        },
                    infoLabel = new sLabel[]
                    {
                        new sLabel()
                        {
                            mlabel = lbl_2_00,
                            text = lStat.Indice.FS_LBL_2_00,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_2_01,
                            text = lStat.Indice.FS_LBL_2_01,
                        },

                        new sLabel()
                        {
                            mlabel = lbl_2_02,
                            text = lStat.Indice.FS_LBL_2_02,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_2_02Sub,
                            text = lStat.Indice.FS_LBL_2_02Sub,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_2_03,
                            text = lStat.Indice.FS_LBL_2_03,
                        },
                                                new sLabel()
                        {
                            mlabel = lbl_2_03Sub,
                            text = lStat.Indice.FS_LBL_2_03Sub,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_2_04,
                            text = lStat.Indice.FS_LBL_2_04,
                        },
                                                new sLabel()
                        {
                            mlabel = lbl_2_04Sub,
                            text = lStat.Indice.FS_LBL_2_04Sub,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_2_05,
                            text = lStat.Indice.FS_LBL_2_05,
                        },
                                                new sLabel()
                        {
                            mlabel = lbl_2_05Sub,
                            text = lStat.Indice.FS_LBL_2_05Sub,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_2_06,
                            text = lStat.Indice.FS_LBL_2_06,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_2_06Sub,
                            text = lStat.Indice.FS_LBL_2_06Sub,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_2_07,
                            text = lStat.Indice.FS_LBL_2_07,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_2_08,
                            text = lStat.Indice.FS_LBL_2_08,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_2_09,
                            text = lStat.Indice.FS_LBL_2_09,
                        },
                                                new sLabel()
                        {
                            mlabel = lbl_2_10,
                            text = lStat.Indice.FS_LBL_2_10,
                        },

                    },
                    valLabel = new Label[] {
                        val_2_00,
                        val_2_01,
                        val_2_02,
                        val_2_03,
                        val_2_03Sub,
                        val_2_04,
                        val_2_04Sub,
                        val_2_05,
                        val_2_05Sub,
                        val_2_06,
                        val_2_06Sub,
                        val_2_07,
                        val_2_07Sub,
                        val_2_08,
                        val_2_09,
                        val_2_10,
                        val_2_11,
                        val_2_12,
                        val_2_13

                    },
                    vvParametro = new int[] {
                        costAlFanCoil.FCS_PERC_VENTILATORE,
                        costAlFanCoil.FCS_VOLT_VENTILATORE,
                        costAlFanCoil.FCS_VELOCITA_VENTILATORE,
                        costAlFanCoil.FCS_VALVOLA_FREDDA_PWM,
                        costAlFanCoil.FCS_VALVOLA_FREDDA_DCMAX,
                        costAlFanCoil.FCS_VALVOLA_FREDDA_MOD,
                        costAlFanCoil.FCS_VALVOLA_FREDDA_MODMAX,
                        costAlFanCoil.FCS_PERC_RES_ELETTRICA,
                        costAlFanCoil.FCS_DC_MASSIMO_IST_RES,
                        costAlFanCoil.FCS_VALVOLA_CALDA_PWM,
                        costAlFanCoil.FCS_VALVOLA_CALDA_DCMAX,
                        costAlFanCoil.FCS_VALVOLA_CALDA_MOD,
                        costAlFanCoil.FCS_VALVOLA_CALDA_MODMAX,
                        costAlFanCoil.FCS_VALVOLA_CHOVER,
                        costAlFanCoil.FCS_RID_RAFFREDDAMENTO,
                        costAlFanCoil.FCS_RIS_RISACALDAMENTO,
                        costAlFanCoil.FCS_SERRANDA_PERC,
                        costAlFanCoil.FCS_SERRANDA_VOLT,
                        costAlFanCoil.FCS_VENTILATORE_ONOFF
                    }
                },   // ---------- 2
                 
                new gbOx()    // ---------- 3
                {
                    SgpBox = new box()
                        {
                            gpBox = gb_3_stati,
                            text = lStat.Indice.FS_GB_3_STATI
                        },
                    infoLabel = new sLabel[]
                    {
                        new sLabel()
                        {
                            mlabel = lbl_3_00,
                            text = lStat.Indice.FS_LBL_3_00,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_3_01,
                            text = lStat.Indice.FS_LBL_3_01,
                        },

                        new sLabel()
                        {
                            mlabel = lbl_3_02,
                            text = lStat.Indice.FS_LBL_3_02,
                        },

                        new sLabel()
                        {
                            mlabel = lbl_3_03,
                            text = lStat.Indice.FS_LBL_3_03,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_3_04,
                            text = lStat.Indice.FS_LBL_3_04,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_3_05,
                            text = lStat.Indice.FS_LBL_3_05,
                        },

                        new sLabel()
                        {
                            mlabel = lbl_3_06,
                            text = lStat.Indice.FS_LBL_3_06,
                        },

                        new sLabel()
                        {
                            mlabel = lbl_3_07,
                            text = lStat.Indice.FS_LBL_3_07,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_3_08,
                            text = lStat.Indice.FS_LBL_3_08,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_3_09,
                            text = lStat.Indice.FS_LBL_3_09,
                        },

                        new sLabel()
                        {
                            mlabel = lbl_3_10,
                            text = lStat.Indice.FS_LBL_3_10,
                        },
                       new sLabel()
                        {
                            mlabel = lbl_3_11,
                            text = lStat.Indice.FS_LBL_3_11,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_3_12,
                            text = lStat.Indice.FS_LBL_3_12,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_3_13,
                            text = lStat.Indice.FS_LBL_3_13,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_3_14,
                            text = lStat.Indice.FS_LBL_3_14,
                        },

                    },
                    valLabel = new Label[] { val_3_00, val_3_01,val_3_02, val_3_03,val_3_04,val_3_05,val_3_06, val_3_07, val_3_08,val_3_09,val_3_10,val_3_11,val_3_12,val_3_13,val_3_14 },
                    vvParametro = new int[] {
costAlFanCoil.FCS_SPENTO_BMS,
costAlFanCoil.FCS_SPENTO_DA_TASTO,
costAlFanCoil.FCS_SPENTO_D1,
costAlFanCoil.FCS_SPENTO_ECONOMY,
costAlFanCoil.FCS_MOD_ECONOMY_DI1,
costAlFanCoil.FCS_MOD_ECONOMY_DI2,
costAlFanCoil.FCS_MOD_ECONOMY_DI3,
costAlFanCoil.FCS_ECONOMY_TYPE,
costAlFanCoil.FCS_MOD_ECONOMY_RETE,
costAlFanCoil.FCS_MOD_ECONOMY_BMS_EN_SAVING,
costAlFanCoil.FCS_LIMITE_TEMP_MAND_RIS_RAFF,
costAlFanCoil.FCS_LIMITE_TEMP_SCHEDA,
costAlFanCoil.FCS_QUICK_COOLING,
costAlFanCoil.FCS_CONTATORE_FILTRO,
costAlFanCoil.FCS_FANCOIL_OFF

                    }
                },   // ---------- 3

                new gbOx()    // ---------- 4
                {
                    SgpBox = new box()
                        {
                            gpBox = gb_4_Allarmi,
                            text = lStat.Indice.FS_GB_4_ALLARMI
                        },
                    infoLabel = new sLabel[]
                    {
                        new sLabel()
                        {
                            mlabel = lbl_4_00,
                            text = lStat.Indice.FS_LBL_4_00,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_4_01,
                            text = lStat.Indice.FS_LBL_4_01,
                        },

                        new sLabel()
                        {
                            mlabel = lbl_4_02,
                            text = lStat.Indice.FS_LBL_4_02,
                        },

                        new sLabel()
                        {
                            mlabel = lbl_4_03,
                            text = lStat.Indice.FS_LBL_4_03,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_4_04,
                            text = lStat.Indice.FS_LBL_4_04,
                        },
                        //new sLabel()
                        //{
                        //    mlabel = lbl_4_05,
                        //    text = lStat.Indice.FS_LBL_4_05,
                        //},

                        //new sLabel()
                        //{
                        //    mlabel = lbl_4_06,
                        //    text = lStat.Indice.FS_LBL_4_06,
                        //},

                        new sLabel()
                        {
                            mlabel = lbl_4_07,
                            text = lStat.Indice.FS_LBL_4_07,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_4_08,
                            text = lStat.Indice.FS_LBL_4_08,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_4_09,
                            text = lStat.Indice.FS_LBL_4_09,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_4_10,
                            text = lStat.Indice.FS_LBL_4_10,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_4_11,
                            text = lStat.Indice.FS_LBL_4_11,
                         },
                        new sLabel()
                        {
                            mlabel = lbl_4_12,
                            text = lStat.Indice.FS_LBL_4_12,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_4_13,
                            text = lStat.Indice.FS_LBL_4_13,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_4_14,
                            text = lStat.Indice.FS_LBL_4_14,
                        },

                        new sLabel()
                        {
                            mlabel = lbl_4_15,
                            text = lStat.Indice.FS_LBL_4_15,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_4_16,
                            text = lStat.Indice.FS_LBL_4_16,
                        },
                       new sLabel()
                        {
                            mlabel = lbl_4_17,
                            text = lStat.Indice.FS_LBL_4_17,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_4_18,
                            text = lStat.Indice.FS_LBL_4_18,
                        },

                        new sLabel()
                        {
                            mlabel = lbl_4_19,
                            text = lStat.Indice.FS_LBL_4_19,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_4_20,
                            text = lStat.Indice.FS_LBL_4_20,
                        },
                },
                        valLabel = new Label[] { val_4_00, val_4_01, val_4_02, val_4_03, val_4_04,val_4_07, val_4_08, val_4_09, val_4_10, val_4_11, val_4_12, val_4_13, val_4_14, val_4_15, val_4_16 , val_4_17 , val_4_18 , val_4_19 , val_4_20 },
                        // valLabel = new Label[] { val_4_00, val_4_01, val_4_02, val_4_03, val_4_04, val_4_05, val_4_06, val_4_07, val_4_08, val_4_09, val_4_10, val_4_11, val_4_12, val_4_13, val_4_14, val_4_15, val_4_16 , val_4_17 , val_4_18 , val_4_19 , val_4_20 },
                    vvParametro = new int[] {
                        costAlFanCoil.FCS_AL_SONDA_REGOLAZIONE,
                        costAlFanCoil.FCS_AL_SONDA_TEMP_RIPRESA,
                        costAlFanCoil.FCS_AL_SONDA_TEMP_MANDATA,
                        costAlFanCoil.FCS_AL_TEMP_SICUREZZA,
                        costAlFanCoil.FCS_AL_INTERVENTO_TERM_SICUREZZA,
                        //costAlFanCoil.FCS_AL_TEMP_MANDATA_CALDO,
                        //costAlFanCoil.FCS_AL_TEMP_MANDATA_FREDDO,
                        costAlFanCoil.FCS_AL_TER_STANZA_NON_COLL,
                        costAlFanCoil.FCS_AL_SONDA_TEMP_STANZA,
                        costAlFanCoil.FCS_AL_CIRC_RES_APERTO,
                        costAlFanCoil.FCS_AL_CIRC_INNESCO_RES,
                        costAlFanCoil.FCS_AL_GEN_FANCOIL,
                        costAlFanCoil.FCS_AL_INCENDIO_GENERALE,
                        costAlFanCoil.FCS_AL_CUMULATIVO,
                        costAlFanCoil.FCS_AL_VENTILATORE,
                        costAlFanCoil.FCS_AL_SERRANDA,
                        costAlFanCoil.FCS_AL_SENSORE_PRESS,
                        costAlFanCoil.FCS_AL_PRESS_BASSA,
                        costAlFanCoil.FCS_AL_PRESS_ALTA,
                        costAlFanCoil.FCS_AL_0_10_VALVOLA,
                        costAlFanCoil.FCS_AL_FILTRO_SPORCO,
                },   // ---------- 4
                },
                new gbOx()    // ---------- 5
                {
                    SgpBox = new box()
                        {
                            gpBox = gb_5_forzature,
                            text = lStat.Indice.FS_GB_5_FORZATURE
                        },
                    infoLabel = new sLabel[]
                    {
                        new sLabel()
                        {
                            mlabel = lbl_5_00,
                            text = lStat.Indice.FS_LBL_5_00,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_5_01,
                            text = lStat.Indice.FS_LBL_5_01,
                        },

                        new sLabel()
                        {
                            mlabel = lbl_5_02,
                            text = lStat.Indice.FS_LBL_5_02,
                        },

                        new sLabel()
                        {
                            mlabel = lbl_5_03,
                            text = lStat.Indice.FS_LBL_5_03,
                        },
                    },
                },  // ---------- 5

               new gbOx()    // ---------- 6
                {
                    SgpBox = new box()
                        {
                            gpBox = gb_6_PLC,
                            text = lStat.Indice.TXT_gbPLC
                        },
                    infoLabel = new sLabel[]
                    {
                        new sLabel()
                        {
                            mlabel = lbl_6_00,
                            text = lStat.Indice.LBL_50_TemperaturaScheda,
                        },
                        new sLabel()
                        {
                            mlabel = lbl_6_01,
                            text = lStat.Indice.LBL_51_FrequenzaRete,
                        },

                        new sLabel()
                        {
                            mlabel = lbl_6_02,
                            text = lStat.Indice.LBL_52_24Volt,
                        },
                         new sLabel()
                        {
                            mlabel = lbl_6_03,
                            text = lStat.Indice.LBL_53_RiduzioneTemperatura,
                        },
                    },
                    valLabel = new Label[] { val_6_00,val_6_01,val_6_02,val_6_03},
                    vvParametro = new int[] { costAlFanCoil.FCS_TEMP_SCHEDA, costAlFanCoil.FCS_FREQ_RETE, costAlFanCoil.FCS_V24VOLT, costAlFanCoil. FCS_RIDUZIONE_TEMP},

                },  // ---------- 6

            };
        }

        private void timerTick_Tick(object sender, EventArgs e)
        {
            if (!clsSerial.serialPortIsOpen())
            {
                this.Close();
                clsSerial.USBerrorRestart();
            }

        }

        private void timerRxParametri_Tick(object sender, EventArgs e)
        {
            int d;
            d = clsSerial.pop(Costanti.BITS_DEVICE_FANCOIL | Costanti.BITS_VIDEATA_STATO);
            while (d >= 0)
            {
                byte b = (byte)(d & 0xff);
                clsHandler.decode(b, this);
                d = clsSerial.pop(Costanti.BITS_DEVICE_FANCOIL | Costanti.BITS_VIDEATA_STATO);
                // handelrData
            }

        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            abilitaTimerRichiesta();
            richiedi();
            timerRefresh.Enabled = false;
        }




        Button[] lButton = new Button[4];
        forzaturaCls[] forzatura;

        void initButtonArray()
        {
            lButton[0] = btn60_AccensioneVentilatore;
            lButton[1] = btn61_ComandoRiscaldamento;
            lButton[2] = btn62_ComandoRaffreddamento;
            lButton[3] = btn63_ComandoAperturaSerranda;
        }

        void initForzarure()
        {
            forzatura = new forzaturaCls[4];

            forzatura[0] = new forzaturaCls(btn60_AccensioneVentilatore, nud_5_00_PercVentola, 0, richiestoDa | indirizzo);
            forzatura[1] = new forzaturaCls(btn61_ComandoRiscaldamento, nud_5_01_PercRisc, 1, richiestoDa | indirizzo);
            forzatura[2] = new forzaturaCls(btn62_ComandoRaffreddamento, nud_5_02_PercRaff, 2, richiestoDa | indirizzo);
            forzatura[3] = new forzaturaCls(btn63_ComandoAperturaSerranda, nud_5_03_PercSerr, 3, richiestoDa | indirizzo);

        }

        private void systemTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                forzatura[i].TickTimer(i);
                //if (comTask.isOn(i) == true)
                //{
                //    if (forzatura[0].getStato() == 0)
                //        // forzatura è in ON
                //        setStatoOn(lButton[i]);
                //}
                //else
                //{
                //    if (getStato(lButton[i]) == 1)
                //        // forzatura è in ON
                //        setStatoOff(lButton[i]);
                //}
            }
        }

        private void frmStatoFanCoil_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = forzaChiusura;
        }

        private void btn60_AccensioneVentilatore_Click(object sender, EventArgs e)
        {

        }
    }
}
