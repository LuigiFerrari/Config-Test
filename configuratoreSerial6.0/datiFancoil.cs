using configuratore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace configuratoreSerial6._0
{
    internal class datiFancoil
    {
        static public DataTable tblFancoil;
        static private DataTable tblVersion;

        static public DataSet FancoilDataSet;

        static string gFilename;

        public struct sCampiTabella
        {
            public string NameField;
            public string TypeField;
            public int primaryKey;
        }
        public struct sTable
        {
            public DataTable Primaria;
            public string nomePrimaria;
            public DataTable Backup;

            public string nomeBackup;
            public sCampiTabella[] indiceCampi;
        }

        public struct sVocParametri
        {
            public string NomeParametro;
            public int IDParametro;
        }


        static sCampiTabella[] indiceTabellaFunzionamento =
        {
            new sCampiTabella() {NameField="ID",TypeField="System.Int32" ,primaryKey=1 },
            new sCampiTabella() {NameField="DESCRIZIONE",TypeField="System.String" ,primaryKey=1 },
            new sCampiTabella() {NameField="VALORE",TypeField="System.Int32" ,primaryKey=1 },
        };


        static public sTable[] elencoTabelle =
        {
            new sTable { Primaria = new DataTable(), nomePrimaria="tblParametriFancoil", Backup= new DataTable(), nomeBackup="tblParametriFancoilBck", indiceCampi=indiceTabellaFunzionamento },
        };

        static readonly int TBL_FANCOIL = 0;

        static void ResetTables()
        {
            int t;
            for (t = 0; t < elencoTabelle.Count(); t++)
            {
                if(elencoTabelle[t].Primaria!=null)
                {
                    elencoTabelle[t].Primaria.Clear();
                    elencoTabelle[t].Primaria.Reset();
                }
            }
        }
        static public void Initdati(string Filename)
        {

            tblVersion = new DataTable("Versione");
            if (FancoilDataSet == null)
                FancoilDataSet = new DataSet("FancoilDataSet");
            FancoilDataSet.Clear();
            FancoilDataSet.Reset();
            ResetTables();
            initTabelle_();
            gFilename = Filename;
            //if (AddEdit == Costanti.EDIT)
            //{
            if (File.Exists(gFilename))
            {
                FancoilDataSet.ReadXml(gFilename);
                tblVersion = FancoilDataSet.Tables["Versione"];
                if (utility.checkSameTblVersion(tblVersion, Costanti.tblIndice.TBLFANCOIL) == true)
                {

                    for (int i = 0; i < elencoTabelle.Count(); i++)
                    {
                        elencoTabelle[i].Primaria = FancoilDataSet.Tables[elencoTabelle[i].nomePrimaria];
                    }
                    copy2Bak();
                }
            }
            else
            {
                copy2Bak();
                utility.prepareVersion(tblVersion, Costanti.tblIndice.TBLCASSETTE);
                if (FancoilDataSet != null)
                {
                    FancoilDataSet.Clear();
                    FancoilDataSet.Reset();
                }

                for (int i = 0; i < elencoTabelle.Count(); i++)
                {
                    FancoilDataSet.Tables.Add(elencoTabelle[i].Primaria);
                }
                FancoilDataSet.Tables.Add(tblVersion);
                saveFile(gFilename);
                //}
            }
        }




        static void initDefault()
        {


        }

        static void initTabelle_()
        {
            int t;
            int c;
            for (t = 0; t < elencoTabelle.Count(); t++)
            {
                for (c = 0; c < elencoTabelle[t].indiceCampi.Count(); c++)
                {
                    DataColumn column;
                    column = new DataColumn();
                    column.DataType = System.Type.GetType(elencoTabelle[t].indiceCampi[c].TypeField);
                    column.ColumnName = elencoTabelle[t].indiceCampi[c].NameField;
                    elencoTabelle[t].Primaria.Columns.Add(column);
                }
                elencoTabelle[t].Primaria.TableName = elencoTabelle[t].nomePrimaria;
                elencoTabelle[t].Backup.TableName = elencoTabelle[t].nomeBackup;
            }
        }

        static int CompareRegistri(DataTable t1, DataTable tbck, List<string> NomiCampi)
        {
            int res = 0;
            if (NomiCampi.Count != 0)
            {
                if (t1.Rows.Count != tbck.Rows.Count)
                    res = -1;
                for (int i = 0; i < t1.Rows.Count && res == 0; i++)
                {
                    string str = "";
                    for (int k = 0; k < NomiCampi.Count; k++)
                    {
                        str = str + NomiCampi[k] + " = " + t1.Rows[i][NomiCampi[k]].ToString();
                        if (k < (NomiCampi.Count - 1))
                            str = str + " AND ";
                    }
                    DataRow[] dr = tbck.Select(str);
                    for (int r = 0; r < dr.Count() && res == 0; r++)
                    {
                        {
                            for (int j = 0; j < dr[r].ItemArray.Length && res == 0; j++)
                            {
                                if (t1.Rows[i][j].GetType().ToString() == "System.String")
                                {
                                    string str1 = dr[r][j].ToString();
                                    string str2 = t1.Rows[i][j].ToString();
                                    if (str1.CompareTo(str2) != 0)
                                        res = -1;
                                }
                                else
                                {
                                    int n1 = Convert.ToInt32(dr[r][j]);
                                    int n2 = Convert.ToInt32(t1.Rows[i][j]);
                                    if (n1 != n2)
                                        res = -1;
                                }
                            }
                        }
                    }
                }
            }
            return res;
        }

        static public int compareOldNew()
        {
            int res = 0;
            for (int i = 0; i < elencoTabelle.Count() && res == 0; i++)
            {
                List<string> listaCampi = new List<string>();
                for (int j = 0; j < elencoTabelle[i].indiceCampi.Count() && res == 0; j++)
                {
                    if (elencoTabelle[i].indiceCampi[j].primaryKey == 1)
                    {
                        listaCampi.Add(elencoTabelle[i].indiceCampi[j].NameField);
                    }
                }
                res = CompareRegistri(elencoTabelle[i].Primaria, elencoTabelle[i].Backup, listaCampi);
            }
            return res;
        }

        static public void copy2Bak()
        {
            for (int i = 0; i < elencoTabelle.Count(); i++)
            {
                elencoTabelle[i].Backup = elencoTabelle[i].Primaria.Copy();
            }
        }
        static public void RestoreTable()
        {
            for (int i = 0; i < elencoTabelle.Count(); i++)
            {
                elencoTabelle[i].Primaria = elencoTabelle[i].Backup.Copy();
            }
        }


        static public void saveFile(String filename)
        {
            FancoilDataSet.WriteXml(filename, XmlWriteMode.WriteSchema);
            copy2Bak();
        }

        static public void cancellaTabella()
        {
            elencoTabelle[TBL_FANCOIL].Primaria.Clear();
        }
        static public void salvaParametro(int ID, String descr, int valore)
        {
            elencoTabelle[TBL_FANCOIL].Primaria.Rows.Add();
            int i = elencoTabelle[TBL_FANCOIL].Primaria.Rows.Count - 1;
            elencoTabelle[TBL_FANCOIL].Primaria.Rows[i]["ID"] = ID;
            elencoTabelle[TBL_FANCOIL].Primaria.Rows[i]["DESCRIZIONE"] = descr;
            elencoTabelle[TBL_FANCOIL].Primaria.Rows[i]["VALORE"] = valore;
        }

        static public int getIDfromTabella(int r)
        {
            int dato=-1;
            int x;
            if(elencoTabelle[TBL_FANCOIL].Primaria.Rows[r]["ID"]!=null)
            {
                if (Int32.TryParse(elencoTabelle[TBL_FANCOIL].Primaria.Rows[r]["ID"].ToString(), out x))
                    dato = x;             
            }
            return dato;
        }

        static public int getValorefromTabella(int r)
        {
            int dato = -1;
            int x;
            if (elencoTabelle[TBL_FANCOIL].Primaria.Rows[r]["ID"] != null)
            {
                if (Int32.TryParse(elencoTabelle[TBL_FANCOIL].Primaria.Rows[r]["VALORE"].ToString(), out x))
                    dato = x;
            }
            return dato;
        }

        static public String getNomefromTabella(int r)
        {
            String dato = "";
            if (r < elencoTabelle[TBL_FANCOIL].Primaria.Rows.Count)
            {
                if (elencoTabelle[TBL_FANCOIL].Primaria.Rows[r]["DESCRIZIONE"] != null)
                {
                    dato = elencoTabelle[TBL_FANCOIL].Primaria.Rows[r]["DESCRIZIONE"].ToString();
                }                
            }
            return dato;
        }

        static public int getNumeroTtaleParametri() { return vocabolarioParametri.Length; }

        static public String getNomeParametro(int p)
        {
            String s = "";
            int i;
            for (i = 0; i < getNumeroTtaleParametri() && s == ""; i++)
            {
                if (vocabolarioParametri[i].IDParametro == p)
                {
                    s = vocabolarioParametri[i].NomeParametro;
                }
            }
            return s;
        }

        static public int getIDParametro(String s)
        {
            int i;
            int p = -1;
            for (i = 0; i < getNumeroTtaleParametri() && p < 0; i++)
            {
                if (vocabolarioParametri[i].NomeParametro == s)
                {
                    p = vocabolarioParametri[i].IDParametro;
                }
            }
            return p;
        }

        static sVocParametri[] vocabolarioParametri =
        {
            new sVocParametri() {NomeParametro="KF_DI1_TYPE",IDParametro=0},
            new sVocParametri() {NomeParametro="KF_DI1_ONOFF",IDParametro=1},
            new sVocParametri() {NomeParametro="KF_DI2_ONOFF",IDParametro=2},
            new sVocParametri() {NomeParametro="KF_DI3_ONOFF",IDParametro=3},
            new sVocParametri() {NomeParametro="KF_DI4_ONOFF",IDParametro=4},
            new sVocParametri() {NomeParametro="KF_DI5_ONOFF",IDParametro=5},
            new sVocParametri() {NomeParametro="KF_NTC1_ONOFF",IDParametro=6},
            new sVocParametri() {NomeParametro="KF_AI1_TYPE",IDParametro=7},
            new sVocParametri() {NomeParametro="KF_AI1_ONOFF",IDParametro=8},
            new sVocParametri() {NomeParametro="KF_AI2_TYPE",IDParametro=9},
            new sVocParametri() {NomeParametro="KF_AI2_ONOFF",IDParametro=10},
            new sVocParametri() {NomeParametro="KF_LOGIC_DI1_NANC",IDParametro=11},
            new sVocParametri() {NomeParametro="KF_LOGIC_DI2_NANC",IDParametro=12},
            new sVocParametri() {NomeParametro="KF_LOGIC_DI3_NANC",IDParametro=13},
            new sVocParametri() {NomeParametro="KF_LOGIC_DI4_NANC",IDParametro=14},
            new sVocParametri() {NomeParametro="KF_NTC2_ONOFF",IDParametro=15},
            // -------------
            new sVocParametri() {NomeParametro="KF_ATTIVAZIONE_DI1",IDParametro=16},
            new sVocParametri() {NomeParametro="KF_DISATTIVAZIONE_DI1",IDParametro=17},
            new sVocParametri() {NomeParametro="KF_ATTIVAZIONE_DI2",IDParametro=18},
            new sVocParametri() {NomeParametro="KF_DISATTIVAZIONE_DI2",IDParametro=19},
            new sVocParametri() {NomeParametro="KF_ATTIVAZIONE_DI3",IDParametro=20},
            new sVocParametri() {NomeParametro="KF_DISATTIVAZIONE_DI3",IDParametro=21},
            // -------------
            new sVocParametri() {NomeParametro="KF_CFG_USCITE",IDParametro=22},
            new sVocParametri() {NomeParametro="KF_AO2_ON_OFF",IDParametro=23},
            new sVocParametri() {NomeParametro="KF_TR2_ON_OFF",IDParametro=24},
            new sVocParametri() {NomeParametro="KF_TR1_ON_OFF",IDParametro=25},
            // -------------
            new sVocParametri() {NomeParametro="KF_ABILITAZIONE_SEG_FILTRO",IDParametro=26},
            new sVocParametri() {NomeParametro="KF_TEMPO_SEG_FILTRO",IDParametro=27},
            new sVocParametri() {NomeParametro="KF_BTN_RESET",IDParametro=28},
            // -------------
            new sVocParametri() {NomeParametro="KF_ZM_RISCALDAMENTO_HDZ",IDParametro=29},
            new sVocParametri() {NomeParametro="KF_BR_RISCALDAMENTO_HB",IDParametro=30},
            new sVocParametri() {NomeParametro="KF_KI_RISCALDAMENTO",IDParametro=31},
            new sVocParametri() {NomeParametro="KF_PERIODO_MODULAZIONE",IDParametro=32},
            new sVocParametri() {NomeParametro="KF_MINIMO_DCYCLE",IDParametro=33},
            new sVocParametri() {NomeParametro="KF_MASSIMO_DCYCLE",IDParametro=34},
            new sVocParametri() {NomeParametro="KF_ALLARME_RESISTENZA",IDParametro=35},
            // -------------
            new sVocParametri() {NomeParametro="KF_ZM_RAFFREDDAMENTO_CDZ",IDParametro=36},
            new sVocParametri() {NomeParametro="KF_BR_VALV_RAFFREDDAMENTO_CB",IDParametro=37},
            new sVocParametri() {NomeParametro="KF_KI_VALVOLA",IDParametro=38},
            new sVocParametri() {NomeParametro="KF_ISTERESI_VALVOLA",IDParametro=39},
            new sVocParametri() {NomeParametro="KF_PERIODO_MOD_VALVOLA",IDParametro=40},
            new sVocParametri() {NomeParametro="KF_MINIMO_DC_VALVOLA",IDParametro=41},
            new sVocParametri() {NomeParametro="KF_MASSIMO_DC_VALVOLA",IDParametro=42},
            new sVocParametri() {NomeParametro="KF_DURATA_RAFF_RAPIDO",IDParametro=43},
            new sVocParametri() {NomeParametro="KF_POT_RAFF_RAPIDO",IDParametro=44},
            // -------------
            new sVocParametri() {NomeParametro="KF_MOD_VEN_MINIMA_ZM_ONOFF",IDParametro=45},
            new sVocParametri() {NomeParametro="KF_ABILITAZ_VENT_MANUALE_ONOFF",IDParametro=46},
            new sVocParametri() {NomeParametro="KF_TEMPO_POST_VENTILAZIONE",IDParametro=47},
            new sVocParametri() {NomeParametro="KF_TENSIONE_VENT_AT_ZERO",IDParametro=48},
            new sVocParametri() {NomeParametro="KF_TENSIONE_VENT_AT_CENTO",IDParametro=49},
            new sVocParametri() {NomeParametro="KF_TENSIONE_MINIMA_ATTIVAZ",IDParametro=50},
            new sVocParametri() {NomeParametro="KF_GIRI_MINIMI_VENTOLA",IDParametro=51},
            new sVocParametri() {NomeParametro="KF_BANDA_REG_VENT_RISC_FHB",IDParametro=52},
            new sVocParametri() {NomeParametro="KF_BANDA_REG_VENT_RAFF_FCB",IDParametro=53},
            new sVocParametri() {NomeParametro="KF_KI_REGOLAZ_VENT",IDParametro=54},
            new sVocParametri() {NomeParametro="KF_AZIONE_OFF",IDParametro=55},
            // -------------
            new sVocParametri() {NomeParametro="KF_ISTERESI_VALV_CHOV",IDParametro=56},
            new sVocParametri() {NomeParametro="KF_LOGICA_VALVOLA",IDParametro=57},
            new sVocParametri() {NomeParametro="KF_TEMPO_RITARDO_ATTIV_USCITE",IDParametro=58},
            // -------------
            new sVocParametri() {NomeParametro="KF_MODALITA_GESTIONE_SERRANDA",IDParametro=59},
            new sVocParametri() {NomeParametro="KF_SETPOINT_CO2",IDParametro=60},
            new sVocParametri() {NomeParametro="KF_BANDA_REG_CO2",IDParametro=61},
            new sVocParametri() {NomeParametro="KF_SETPOINT_VOC",IDParametro=62},
            new sVocParametri() {NomeParametro="KF_BANDA_REGOLAZIONE_VOC",IDParametro=63},
            new sVocParametri() {NomeParametro="KF_APERTURA_MINIMA_SERRANDA",IDParametro=64},
            new sVocParametri() {NomeParametro="KF_APERTURA_MASSIMA_SERRANDA",IDParametro=65},
            new sVocParametri() {NomeParametro="KF_TENSIONE_ALLA_PORTATA_MINIMA",IDParametro=66},
            new sVocParametri() {NomeParametro="KF_TENSIONE_ALLA_PORTATA_MASSIMA",IDParametro=67},
            new sVocParametri() {NomeParametro="KF_PORTATA_MINIMA",IDParametro=68},
            new sVocParametri() {NomeParametro="KF_PORTATA_MASSIMA",IDParametro=69},
            new sVocParametri() {NomeParametro="KF_SETPOINT_PORTATA_CONFORT",IDParametro=70},
            new sVocParametri() {NomeParametro="KF_SETPOINT_PORTATA_ECONOMY",IDParametro=71},
            // -------------
            new sVocParametri() {NomeParametro="KF_TIPO_SONDA_REGOLAZ",IDParametro=72},
            new sVocParametri() {NomeParametro="KF_SETPOINT_TEMP_DEFAULT",IDParametro=73},
            new sVocParametri() {NomeParametro="KF_DEVIAZ_MAX_SETPOINT",IDParametro=74},
            // -------------
            new sVocParametri() {NomeParametro="KF_TIPO_ECONOMY_DI1",IDParametro=75},
            new sVocParametri() {NomeParametro="KF_TIPO_ECONOMY_DI2",IDParametro=76},
            new sVocParametri() {NomeParametro="KF_TIPO_ECONOMY_DI3",IDParametro=77},
            new sVocParametri() {NomeParametro="KF_PRIORITA_ECONOMY",IDParametro=78},
            new sVocParametri() {NomeParametro="KF_INCR_ZM_RISC_TIPO1",IDParametro=79},
            new sVocParametri() {NomeParametro="KF_INCR_ZM_RAFF_TIPO1",IDParametro=80},
            new sVocParametri() {NomeParametro="KF_INCR_ZM_RISC_TIPO2",IDParametro=81},
            new sVocParametri() {NomeParametro="KF_INCR_ZM_RAFF_TIPO2",IDParametro=82},
            // -------------
            new sVocParametri() {NomeParametro="KF_SOGLIA_INTASAMENTO_FILTRO",IDParametro=83},
            new sVocParametri() {NomeParametro="KF_ISTERESI_SOGLIA_INTASAMENTO",IDParametro=84},
            new sVocParametri() {NomeParametro="KF_SOGLIA_ALTA_PRESSIONE",IDParametro=85},
            new sVocParametri() {NomeParametro="KF_ISTERESI_SOGLIA_ALTA_PRESSIONE",IDParametro=86},
            new sVocParametri() {NomeParametro="KF_SOGLIA_BASSA_PRESSIONE",IDParametro=87},
            new sVocParametri() {NomeParametro="KF_ISTERESI_SOGLIA_BASSA_PRESSIONE",IDParametro=88},
            new sVocParametri() {NomeParametro="KF_RITARDO_ALLARME_BASSA_PRESSIONE",IDParametro=89},
            // -------------
            new sVocParametri() {NomeParametro="KF_RANGE_TENSIONE",IDParametro=90},
            new sVocParametri() {NomeParametro="KF_RANGE_PRESSIONE",IDParametro=91},
            new sVocParametri() {NomeParametro="KF_SOGLIA_ALLARME",IDParametro=92},
            // -------------
            new sVocParametri() {NomeParametro="KF_SOGLIA_TEMP_SICUREZZA",IDParametro=93},
            new sVocParametri() {NomeParametro="KF_ISTERESI_TEMP_SICUREZZA",IDParametro=94},
            // -------------
            new sVocParametri() {NomeParametro="KF_SETPOINT_LIMITE_MINIMO_LLSP",IDParametro=95},
            new sVocParametri() {NomeParametro="KF_ISTERESI_LIMITE_MINIMO_CLHY",IDParametro=96},
            new sVocParametri() {NomeParametro="KF_SETPOINT_LIMITE_MASSIMO_HLSP",IDParametro=97},
            new sVocParametri() {NomeParametro="KF_BANDA_DI_REGOLAZIONE_LB",IDParametro=98},
            // -------------
            new sVocParametri() {NomeParametro="KF_ABILITAZIONE_RAMPA_ONOFF",IDParametro=99},
            new sVocParametri() {NomeParametro="KF_TEMPO_RAMPA",IDParametro=100},
            // -------------
            new sVocParametri() {NomeParametro="KF_TIPO_DISPOSITIVO_MS",IDParametro=101},
            new sVocParametri() {NomeParametro="KF_INDIRIZZO",IDParametro=102},
            new sVocParametri() {NomeParametro="KF_BAUDRATE",IDParametro=103},
            new sVocParametri() {NomeParametro="KF_PARITA",IDParametro=104},
            new sVocParametri() {NomeParametro="KF_BITSTOP",IDParametro=105},
            // -------------
            new sVocParametri() {NomeParametro="KF_INDIRIZZO_SLAVE",IDParametro=106},
            // -------------
            new sVocParametri() {NomeParametro="KF_KV_FORZATURA_SETPOINT_ONOFF",IDParametro=107},
            new sVocParametri() {NomeParametro="KF_KV_VALORE_FORZATURA_SETPOINT",IDParametro=108},
            new sVocParametri() {NomeParametro="KF_KV_CMD_VENTILATORE",IDParametro=109},
            new sVocParametri() {NomeParametro="KF_KV_CMD_RISCALDAMENTO",IDParametro=110},
            new sVocParametri() {NomeParametro="KF_KV_CMD_RAFFREDDAMENTO",IDParametro=111},
            new sVocParametri() {NomeParametro="KF_KV_CMD_SERRANDA",IDParametro=112},
            new sVocParametri() {NomeParametro="KF_KV_PERC_VENTILATORE",IDParametro=113},
            new sVocParametri() {NomeParametro="KF_KV_PERC_RISCALDAMENTO",IDParametro=114},
            new sVocParametri() {NomeParametro="KF_KV_PERC_RAFFREDDAMENTO",IDParametro=115},
            new sVocParametri() {NomeParametro="KF_KV_PERC_SERRANDA",IDParametro=116},


        };

    }
}
