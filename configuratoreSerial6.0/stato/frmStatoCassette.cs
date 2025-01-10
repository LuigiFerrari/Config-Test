using configuratore.stato;
using configuratoreSerial6._0;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Schema;
using static configuratore.statoCassette.frmStatoCassette;
using Label = System.Windows.Forms.Label;

namespace configuratore.statoCassette
{
    public partial class frmStatoCassette : Form
    {
        clsRxBuffer rxBuffer;

        public struct box
        {
            public GroupBox gpBox;
            public lStat.Indice text;
        }

        public struct sLabel
        {
            public Label mlabel;
            public lStat.Indice text;
        }

        public struct gbOx
        {
            public box SgpBox;
            public sLabel[] infoLabel;
            public Label[] valLabel;
            public int[] vvParametro;
            public NumericUpDown[] valUpDown;
            public Button[] btnCmd;

        }

        int statoDaRichiedere;
        int rchiedi;

        gbOx[] statoCassetteGrp;

        int richiestoDa;
        int indirizzo;
        public bool forzaChiusura = true;
        Label[] labelGialle;
        public frmStatoCassette(String Type, String Info, int lrichiestoDa)
        {
            InitializeComponent();
            costAl.init();
            initStato();
            abilitaTimerRichiesta();
            rxBuffer = new clsRxBuffer();
            richiestoDa = lrichiestoDa;// & Costanti.RICHIESTA_DA_MASTER;
            indirizzo = lrichiestoDa & (~Costanti.RICHIESTA_DA_MASTER);
            if (lrichiestoDa >= 0)
                timerTick.Enabled = true;
            String sRichiestoDa = "";
            if (richiestoDa != 0)
                sRichiestoDa = " (MASTER)";
            this.Text = Type + Info + sRichiestoDa;
            global.setStatoCassette(this);


        }

        public byte[] getRxBuffr() { return rxBuffer.getRxBuffer(); }
        public clsRxBuffer getRxBufferClass() { return rxBuffer; }
        void abilitaTimerRichiesta()
        {
            statoDaRichiedere = 0;
            rchiedi = 1;
        }

        private void frmStatoCassette_Load(object sender, EventArgs e)
        {
            setLangage();
            // costAl.
            updateAllLAbel();
            richiedi();
            this.MaximizeBox = false;
            labelGialle = cercaLabel(val30_ModalitaOffdaRemoto);

        }

        public void statoCassetteForm()
        {
            int i;
            int j;
            for (i = 0; i < statoCassetteGrp.Length; i++)
            {
                statoCassetteGrp[i].SgpBox.gpBox.Text = lStat.getStr(statoCassetteGrp[i].SgpBox.text);
                for (j = 0; j < statoCassetteGrp[i].infoLabel.Length; j++)
                    statoCassetteGrp[i].infoLabel[j].mlabel.Text = lStat.getStr(statoCassetteGrp[i].infoLabel[j].text);
            }

        }


        public void setLangage()
        {
            int i;
            int j;
            for (i = 0; i < statoCassetteGrp.Length; i++)
            {
                statoCassetteGrp[i].SgpBox.gpBox.Text = lStat.getStr(statoCassetteGrp[i].SgpBox.text);
                for (j = 0; j < statoCassetteGrp[i].infoLabel.Length; j++)
                    statoCassetteGrp[i].infoLabel[j].mlabel.Text = lStat.getStr(statoCassetteGrp[i].infoLabel[j].text);
            }
        }


        void updateAllLAbel()
        {
            int g;
            int l;
            costAl.lbl r;
            for (g = 0; g < statoCassetteGrp.Length; g++)
            {
                if (statoCassetteGrp[g].valLabel != null)
                {
                    for (l = 0; l < statoCassetteGrp[g].valLabel.Length; l++)
                    {
                        int p = statoCassetteGrp[g].vvParametro[l];

                        r = costAl.getFormatStato(p);
                        statoCassetteGrp[g].valLabel[l].Text = r.Text;
                        if (r.NochangeColor == true)
                        {
                            statoCassetteGrp[g].valLabel[l].BackColor = r.bckColor;
                        }

                    }
                }
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gbAllarmi_Enter(object sender, EventArgs e)
        {

        }

        private void gbForzature_Enter(object sender, EventArgs e)
        {

        }





        void richiedi()
        {
            if (rchiedi == 1)
            {
                txMsg.requireParameter(statoDaRichiedere, Costanti.BITS_DEVICE_CASSETTE | Costanti.BITS_VIDEATA_STATO, richiestoDa | indirizzo);
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
                if (statoDaRichiedere < costAl.VV_NUMERO_STATI)
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



        void initStato()
        {
            statoCassetteGrp = new gbOx[]
                {
                new gbOx()
        {
            SgpBox = new box()
            {
                gpBox = gpGestionePortata,
                text = lStat.Indice.TXT_gpGestionePortata
            },
                    infoLabel = new sLabel[]
                    {
                        new sLabel()
                        {
                            mlabel=lbl00_PortatataIstantanea,
                            text=lStat.Indice.LBL_00_PortatataIstantanea,
                        },
                    new sLabel()
                    {
                        mlabel=lbl01_deltaPortatataIstantanea,
                        text=lStat.Indice.LBL_01_deltaPortatataIstantanea,
                    },

                    new sLabel()
                    {
                        mlabel=lbl02_PortataMinima,
                        text=lStat.Indice.LBL_02_PortataMinima,
                    },

                    new sLabel()
                    {
                        mlabel=lbl03_deltaPressioneMinima,
                        text=lStat.Indice.LBL_03_deltaPressioneMinima,
                    },

                    new sLabel()
                    {
                        mlabel=lbl04_PortataMassima,
                        text=lStat.Indice.LBL_04_PortataMassima,
                    },

                    new sLabel()
                    {
                        mlabel=lbl05_deltaPressioneMassima,
                        text=lStat.Indice.LBL_05_deltaPressioneMassima,
                    },

                    new sLabel()
                    {
                        mlabel=lbl06_PortataMinimaSicurezza,
                        text=lStat.Indice.LBL_06_PortataMinimaSicurezza,
                    },

                    new sLabel()
                    {
                        mlabel=lbl07_deltaPressioneMinimaSicurezza,
                        text=lStat.Indice.LBL_07_deltaPressioneMinimaSicurezza,
                    },

                    new sLabel()
                    {
                        mlabel=lbl08_MofulazioneSerranda,
                        text=lStat.Indice.LBL_08_MofulazioneSerranda,
                    },
                                        new sLabel()
                    {
                        mlabel=lbl09_TensioneSerranda,
                        text=lStat.Indice.LBL_09_TensioneSerranda
                    },

                    new sLabel()
                    {
                        mlabel=lbl10_LetturaPosizioneSerranda,
                        text=lStat.Indice.LBL_09_LetturaPosizioneSerranda,
                    }

                 },
                 valLabel = new Label[] { val00_PortatataIstantanea, val06_LetturadeltaPressioneIstantanea, val01_PortataMinima, val07_LetturadeltaPressioneMinima, val02_PortataMassima, val08_LetturadeltaPressioneMassima, val03_PortataMinimaSicurezza, val09_LetturadeltaPressioneSicurezza, val04_MofulazioneSerranda, val10_TensioneSerranda, val06_LetturaPosizioneSerranda },
                 vvParametro = new int[] { costAl.VV_PORTATA_ISTANTANEA, costAl.VV_DELTA_PRESS_IST, costAl.VV_PORTATA_MINIMA, costAl.VV_DELTA_PRESS_MIN, costAl.VV_PORTATA_MASSIMA, costAl.VV_DELTA_PRESS_MAX, costAl.VV_PORTATA_MINIMA_SICUREZZA, costAl.VV_DELTA_PRESS_SIC, costAl.VV_MODULAZIONE_SERRANDA, costAl.VV_TENSIONE_SERRANDA, costAl.VV_POSIZIONE_SERRANDA }
             },
                // ---------- 1 
                    new gbOx()
        {
            SgpBox = new box()
            {
                gpBox = gpRegolazioneTempAmb,
                text = lStat.Indice.TXT_gpRegolazioneTempAmb
            },
                    infoLabel = new sLabel[]
                    {
                        new sLabel()
                        {
                            mlabel=lbl10_TemperaturaAnbienta,
                        text=lStat.Indice.LBL_10_TemperaturaAnbienta,
                    },

                    new sLabel()
                    {
                        mlabel=lbl11_SetpointTemperatura,
                        text=lStat.Indice.LBL_11_SetpointTemperatura,
                    },

                    new sLabel()
                    {
                        mlabel=lbl12_ResistenzaElettrica,
                        text=lStat.Indice.LBL_12_ResistenzaElettrica,
                    },

                new sLabel()
                    {
                        mlabel=lbl13_DCMassimoIstantaneo,
                        text=lStat.Indice.LBL_13_DCMassimoIstantaneo,
                    },

                new sLabel()
                    {
                        mlabel=lbl14_RiduzioneRiscaldamento,
                        text=lStat.Indice.LBL_14_RiduzioneRiscaldamento,
                    },

                new sLabel()
                    {
                        mlabel=lbl15_TemperaturaInterna,
                        text=lStat.Indice.LBL_15_TemperaturaInterna,
                    },

                new sLabel()
                    {
                        mlabel=lbl16_TemperaturaMandata,
                        text=lStat.Indice.LBL_16_TemperaturaMandata,
                    },
                                new sLabel()
                    {
                        mlabel=lbl17_TempTermostato,
                        text=lStat.Indice.LBL_56_TEMP_TERMOSTATO,
                    },
                                              new sLabel()
                    {
                        mlabel=lbl18_AsdjTmpSetpoint,
                        text=lStat.Indice.LBL_57_ADJTEMPTERM,
                    },
                },
                    valLabel = new Label[] { val10_TemperaturaAmbiente, val11_SetpointTemperatura, val12_ResistenzaElettrica, val16_DCmassimoIstantaneo, val13_RiduzioneRiscaldamento, val14_TemperaturaInterna, val15_TemperaturaMandata,val17_TempTermostato,val18_AdjSetp},
                    vvParametro = new int[] { costAl.VV_TEMPERATURA_AMBIENTE, costAl.VV_SETPOINT_TEMPERATURA, costAl.VV_RESISTENZA_ELETTRICA, costAl.VV_DC_MAX_ISTANTANEO,  costAl.VV_RIDUZIONE_RISCALDAMENTO, costAl.VV_TEMPERATURA_INTERNA, costAl.VV_TEMPERATURA_MANDATA ,costAl.VV_TEMP_TERMOSTATO,costAl.VV_DISCRETE_SETPOINT }


             },
            // ----- 2 -------
            new gbOx()
        {
            SgpBox = new box()
            {
                gpBox = gpInfoMatricola,
                text = lStat.Indice.TXT_gpInfoMatricola
            },
                infoLabel = new sLabel[] {
                    new sLabel()
                    {
                        mlabel=lbl20_Matricola,
                        text=lStat.Indice.LBL_20_Matricola,
                    },

                    new sLabel()
                    {
                        mlabel=lbl21_IndirizzoSlave,
                        text=lStat.Indice.LBL_21_IndirizzoSlave,
                    },
                     new sLabel()
                    {
                        mlabel=lbl22_MasterSlave,
                        text=lStat.Indice.LBL_63_MasterSlave,
                    },
                                          new sLabel()
                    {
                        mlabel=lbl23_Primary,
                        text=lStat.Indice.LBL_58_PRIMARYDEVICE,
                    }
                },
                    valLabel = new Label[] { val20_Matricola, val21_IndirizzoSlave,val22_MasterSlave,lbl_imgPS,val24_sw_release },
                    vvParametro = new int[] { costAl.VV_MATRICOLA_00, costAl.VV_INDIRIZZO_SLAVE , costAl .VV_MASTER_SLAVE, costAl.VV_DISP_PRIMARIO, costAl.VV_VERSIONE_00 }
            },
             // ----- 3 -------
            new gbOx()
        {
            SgpBox = new box()
            {
                gpBox = gpSegnalazioni,
                text = lStat.Indice.TXT_gpSegnalazioni
            },
                    infoLabel = new sLabel[] {
                       new sLabel()
            {
                mlabel=lbl30_ModalitaOffdaRemoto,
                text=lStat.Indice.LBL_30_ModalitaOffdaRemoto,
            },

                    new sLabel()
                    {
                        mlabel=lbl31_ModalitaEcoDaTermostato,
                        text=lStat.Indice.LBL_31_ModalitaEcoDaTermostato,
                    },

                    new sLabel()
                    {
                        mlabel=lbl32_ModalitaEconDaID1,
                        text=lStat.Indice.LBL_32_ModalitaEconDaID1,
                    },

                    new sLabel()
                    {
                        mlabel=lbl33_ModalitaEconDaID2,
                        text=lStat.Indice.LBL_33_ModalitaEconDaID2,
                    },

                    new sLabel()
                    {
                        mlabel=lbl34_ModalitaEconDaID3,
                        text=lStat.Indice.LBL_34_ModalitaEconDaID3,
                    },

                    new sLabel()
                    {
                        mlabel=lbl35_ModalitaEcondaAnal,
                        text=lStat.Indice.LBL_35_ModalitaEcondaAnal,
                    },

                    new sLabel()
                    {
                        mlabel=lbl36_ModalitaEcondaPLCinRete,
                        text=lStat.Indice.LBL_36_ModalitaEcondaPLCinRete,
                    },

                    new sLabel()
                    {
                        mlabel=lbl37_ModalitaEcondaMODBUS,
                        text=lStat.Indice.LBL_37_ModalitaEcondaMODBUS,
                    },

                    new sLabel()
                    {
                        mlabel=lbl38_OffResistPrimaSoglia,
                        text=lStat.Indice.LBL_38_OffResistPrimaSoglia,
                    },

                    new sLabel()
                    {
                        mlabel=lbl39_LimiteMassimoTMandata,
                        text=lStat.Indice.LBL_39_LimiteMassimoTMandata,
                    },

                    new sLabel()
                    {
                        mlabel=lbl3A_RiduzuineDCMaxResPerPort,
                        text=lStat.Indice.LBL_3A_RiduzuineDCMaxResPerPort,
                    },
                },
                    valLabel = new Label[] { val30_ModalitaOffdaRemoto, val31_ModalitaEcoDaTermostato, val32_ModalitaEconDaID1, val33_ModalitaEconDaID2, val34_ModalitaEconDaID3, val35_ModalitaEcondaAnal, val36_ModalitaEcondaPLCinRete, val37_ModalitaEcondaMODBUS, val38_OffResistPrimaSoglia, val39_LimiteMassimoTMandata, val3A_RiduzuineDCMaxResPerPort, },
                    vvParametro = new int[] { costAl.VV_MODALITAOFFDAREMOTO, costAl.VV_MODALITAECODATERMOSTATO, costAl.VV_MODALITAECONDAID1, costAl.VV_MODALITAECONDAID2, costAl.VV_MODALITAECONDAID3, costAl.VV_MODALITAECONDAANAL, costAl.VV_MODALITAECONDAPLCINRETE, costAl.VV_MODALITAECONDAMODBUS, costAl.VV_OFFRESISTPRIMASOGLIA, costAl.VV_LIMITEMASSIMOTMANDATA, costAl.VV_RIDUZIONEDCMAXRESPERPORT }

                },

                         // ----- 4 ------- ALLARMI
            new gbOx()
        {
            SgpBox = new box()
            {
                gpBox = gbAllarmi,
                text = lStat.Indice.TXT_gbAllarmi
            },
                    infoLabel = new sLabel[] {
                            new sLabel()
            {
                mlabel=lbl40_SondaTempInterna,
                text=lStat.Indice.LBL_40_SondaTempInterna,
            },

        new sLabel()
            {
                mlabel=lbl41_SondaTempMandata,
                text=lStat.Indice.LBL_41_SondaTempMandata,
            },

        new sLabel()
            {
                mlabel=lbl42_SondaTempAmbiente,
                text=lStat.Indice.LBL_42_SondaTempAmbiente,
            },

        new sLabel()
            {
                mlabel=lbl43_AltaTemIntSecondaSoglia,
                text=lStat.Indice.LBL_43_AltaTemIntSecondaSoglia,
            },

        new sLabel()
            {
                mlabel=lbl44_InterventoTermResistenza,
                text=lStat.Indice.LBL_44_InterventoTermResistenza,
            },

        new sLabel()
            {
                mlabel=lbl45_TermStanzaNonCollegato,
                text=lStat.Indice.LBL_45_TermStanzaNonCollegato,
            },

        new sLabel()
            {
                mlabel=lbl46_SondaTemStanza,
                text=lStat.Indice.LBL_46_SondaTemStanza,
            },

        new sLabel()
            {
                mlabel=lbl47_CircResistenzaAperta,
                text=lStat.Indice.LBL_47_CircResistenzaAperta,
            },

        new sLabel()
            {
                mlabel=lbl48_CircInnescoRes,
                text=lStat.Indice.LBL_48_CircInnescoRes,
            },

        new sLabel()
            {
                mlabel=lbl49_Serranda,
                text=lStat.Indice.LBL_49_Serranda,
            },

        new sLabel()
            {
                mlabel=lbl4A_SensorePressione,
                text=lStat.Indice.LBL_4A_SensorePressione,
            },

        new sLabel()
            {
                mlabel=lbl4B_PortataBassa,
                text=lStat.Indice.LBL_4B_PortataBassa,
            },
                },
                    valLabel = new Label[] { val40_SondaTempInterna, val41_SondaTempMandata, val42_SondaTempAmbiente, val43_AltaTemIntSecondaSoglia, val44_InterventoTermResistenza, val45_TermStanzaNonCollegato, val46_SondaTemStanza, val47_CircResistenzaAperta, val48_CircInnescoRes, val49_Serranda, val4A_SensorePressione, val4B_PortataBassa, },
                    vvParametro = new int[] { costAl.VV_SONDATEMPINTERNA, costAl.VV_SONDATEMPMANDATA, costAl.VV_SONDATEMPAMBIENTE, costAl.VV_ALTATEMINTSECONDASOGLIA, costAl.VV_INTERVENTOTERMRESISTENZA, costAl.VV_TERMSTANZANONCOLLEGATO, costAl.VV_SONDATEMSTANZA, costAl.VV_CIRCRESISTENZAAPERTA, costAl.VV_CIRCINNESCORES, costAl.VV_SERRANDA, costAl.VV_SENSOREPRESSIONE, costAl.VV_PORTATABASSA }
                },

                                     // ----- 5 ------- PLC


                   new gbOx()
        {
            SgpBox = new box()
            {
                gpBox = gbPLC,
                text = lStat.Indice.TXT_gbPLC
            },
                infoLabel = new sLabel[] {
                new sLabel()
                {
                    mlabel=lbl50_TemperaturaScheda,
                    text=lStat.Indice.LBL_50_TemperaturaScheda,
                },
                new sLabel()
                {
                    mlabel=lbl51_FrequenzaRete,
                    text=lStat.Indice.LBL_51_FrequenzaRete,
                },
                new sLabel()
                {
                    mlabel=lbl52_24Volt,
                    text=lStat.Indice.LBL_52_24Volt,
                },
                new sLabel()
                {
                    mlabel=lbl53_RiduzioneDC,
                    text=lStat.Indice.LBL_53_RiduzioneTemperatura,
                },
                new sLabel()
                {
                    mlabel=lbl55_RS485ErrOriz,
                    text=lStat.Indice.LBL_55_RS485_O_ERR
                },
                                new sLabel()
                {
                    mlabel=lbl54_VRete,
                    text=lStat.Indice.LBL_54_TensioneRete,
                },
            },
                    valLabel = new Label[] { val50_TemperaturaScheda,val51_FrequenzaRete,val52_24Volt,val52_RiduzioneDC,val54_vRete,val55_RS485ErrOriz},
                    vvParametro = new int[] { costAl.VV_TEMPERATURA_SCHEDA, costAl.VV_FREQUENZ_RETE, costAl.VV_24VOLT, costAl.VV_RIDUZIONETEMP , costAl.VV_V_RETE, costAl.VV_RS485_ERROR_ORIZZ }

            },

                    // ----- 6 ------- forzature
                     new gbOx()
        {
            SgpBox = new box()
            {
                gpBox = gbForzature,
                text = lStat.Indice.TXT_gbForzature
            },
                infoLabel = new sLabel[] {
                new sLabel()
            {
                mlabel=lbl60_ApertutaSerranda,
                text=lStat.Indice.LBL_60_ApertutaSerranda,
            },

        new sLabel()
            {
                mlabel=lbl61_ComadoResistenza,
                text=lStat.Indice.LBL_61_ComadoResistenza,
            },

        new sLabel()
            {
                mlabel=lbl62_RichMaxRaffreddamento,
                text=lStat.Indice.LBL_62_RichMaxRaffreddamento,
            },
                },
                    //valLabel = new Label[] { val50_TemperaturaScheda },
                    valUpDown = new NumericUpDown[] { num60_ApertutaSerranda, num61_ComadoResistenza },
                    btnCmd = new Button[] { btn60_ApertutaSerranda, btn61_ComadoResistenza, btn62_RichMaxRaffreddamento },
            },

                };
        }

        private void timerRxParametri_Tick(object sender, EventArgs e)
        {

            int d;
            d = clsSerial.pop(Costanti.BITS_DEVICE_CASSETTE | Costanti.BITS_VIDEATA_STATO);
            while (d >= 0)
            {
                byte b = (byte)(d & 0xff);
                clsHandler.decode(b, this);
                d = clsSerial.pop(Costanti.BITS_DEVICE_CASSETTE | Costanti.BITS_VIDEATA_STATO);
                // handelrData
            }

            lbl16_TemperaturaMandata.Visible = clsArbitrator.isAbilitaMandata();
            val15_TemperaturaMandata.Visible = clsArbitrator.isAbilitaMandata();
            val39_LimiteMassimoTMandata.Visible = clsArbitrator.isAbilitaMandata();
            lbl39_LimiteMassimoTMandata.Visible = clsArbitrator.isAbilitaMandata();



        }


        void setAlarm(Label l, int v)
        {
            if (v != 0)
            {
                if (isGialla(l))
                    l.BackColor = Color.Yellow;
                else
                    l.BackColor = Color.Red;
                l.Text = "";
            }
            else
            {
                l.BackColor = Color.Gray;
            }
        }


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
            int nbyte = costAl.getSizeStato(p);
            //Debug.Write("Stato ");
            //Debug.Write(p);
            //Debug.Write(" nbyte ");
            //Debug.Write(nbyte);
            //Debug.Write("  ");

            for (g = 0; g < statoCassetteGrp.Length && trovato < 0; g++)
            {
                if (statoCassetteGrp[g].vvParametro != null)
                {
                    for (j = 0; j < statoCassetteGrp[g].vvParametro.Length && trovato < 0; j++)
                    {
                        if (statoCassetteGrp[g].vvParametro[j] == p)
                        {
                            // trovato
                            trovato = j;
                            switch (costAl.getTipoParametro(p))
                            {
                                case 'B':
                                    v = utility.conv728(buffer, pos + 1, nbyte);

                                    setAlarm(statoCassetteGrp[g].valLabel[j], v);
                                    // Debug.WriteLine(v);
                                    break;
                                case 'S':
                                    s = "";
                                    for (int i = 0; i < costAl.MAX_SIZE_STRING; i++)
                                        s = s + (char)buffer[pos + i + 1];
                                    statoCassetteGrp[g].valLabel[j].Text = s;
                                    // Debug.WriteLine(s);
                                    skipNum = costAl.MAX_SIZE_STRING / 2;
                                    break;
                                case 'V':
                                    s = "";
                                    for (int i = 0; i < costAl.MAX_SIZE_VERSIONE; i++)
                                        s = s + (char)buffer[pos + i + 1];
                                    statoCassetteGrp[g].valLabel[j].Text = s;
                                    // Debug.WriteLine(s);
                                    skipNum = costAl.MAX_SIZE_VERSIONE / 2;
                                    break;
                                case 'N':
                                    v = utility.conv728(buffer, pos + 1, nbyte);
                                    int d = costAl.getdecimali(p);
                                    s = utility.convertToString(v, d);
                                    switch (p)
                                    {
                                        case costAl.VV_MASTER_SLAVE:
                                            if (v == 0)
                                                s = "M";
                                            else
                                                s = "S";
                                            break;
                                        case costAl.VV_DISP_PRIMARIO:
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
                                    statoCassetteGrp[g].valLabel[j].Text = s;
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
            continuaRichiesta(skipNum);
        }






        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            abilitaTimerRichiesta();
            richiedi();
            timerRefresh.Enabled = false;
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


        private void btn60_ApertutaSerranda_Click(object sender, EventArgs e)
        {
            retStat y;
            y = toggleStatus(btn60_ApertutaSerranda);

            btn60_ApertutaSerranda.Image = y.img;
            btn60_ApertutaSerranda.Text = y.txt;
            txMsg.txMsgOne(parametriCassetta.KK_KV_APERTURA_SERRANDA_ONOFF, getStato(btn60_ApertutaSerranda), richiestoDa);
        }

        private void btn61_ComadoResistenza_Click(object sender, EventArgs e)
        {

            retStat y;
            y = toggleStatus(btn61_ComadoResistenza);

            btn61_ComadoResistenza.Image = y.img;
            btn61_ComadoResistenza.Text = y.txt;
            txMsg.txMsgOne(parametriCassetta.KK_KV_TRESISTENZA_ONOFF, getStato(btn61_ComadoResistenza), richiestoDa);
        }

        private void btn62_RichMaxRaffreddamento_Click(object sender, EventArgs e)
        {
            retStat y;
            y = toggleStatus(btn62_RichMaxRaffreddamento);

            btn62_RichMaxRaffreddamento.Image = y.img;
            btn62_RichMaxRaffreddamento.Text = y.txt;
            txMsg.txMsgOne(parametriCassetta.KK_KV_MAX_FREDDO_ONOFF, getStato(btn62_RichMaxRaffreddamento), richiestoDa);
        }

        private void num60_ApertutaSerranda_ValueChanged(object sender, EventArgs e)
        {
            txMsg.txMsgOne(parametriCassetta.KK_KV_APERTURA_SERRANDA_PERC, (int)num60_ApertutaSerranda.Value, richiestoDa);
        }

        private void num61_ComadoResistenza_ValueChanged(object sender, EventArgs e)
        {
            txMsg.txMsgOne(parametriCassetta.KK_KV_TRESISTENZA_PERC, (int)num61_ComadoResistenza.Value, richiestoDa);

        }

        private void timerTick_Tick(object sender, EventArgs e)
        {
            if (!clsSerial.serialPortIsOpen())
                this.Close();
            else
            {

                    if(comTask.ImMaster()==true)
                    {
                        // master disabilita parametri slave
                        disabilitaInfoMaster();

                    } else
                    {
                        abilitaInfoMaster();
                    }

                
            }
        }

        private void disabilitaInfoMaster()
        {
            lbl21_IndirizzoSlave.Enabled = false;
            val21_IndirizzoSlave.Enabled = false;
        }

        private void abilitaInfoMaster()
        {
            lbl21_IndirizzoSlave.Enabled = true;
            val21_IndirizzoSlave.Enabled = true;
        }

        private void frmStatoCassette_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = forzaChiusura;
        }

        Label[] cercaLabel(Label lbl) //  val_3_00)
        {
            int g;
            int trovato = -1;
            int trovatog = -1;
            for (g = 0; g < statoCassetteGrp.Length && trovatog < 0; g++)
            {
                if (statoCassetteGrp[g].valLabel != null)
                {
                    for (int k = 0; k < statoCassetteGrp[g].valLabel.Length && trovato < 0; k++)
                    {
                        if (statoCassetteGrp[g].valLabel[k] == lbl)
                        {
                            trovato = k;
                            trovatog = g;
                        }
                    }
                }
            }
            return statoCassetteGrp[trovatog].valLabel;
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
    }


}
