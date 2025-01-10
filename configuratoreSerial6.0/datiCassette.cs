using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace configuratore
{
    internal class datiCassette
    {
        static public DataTable tblCassette;
        static private DataTable tblVersion;

        static public DataSet CassetteDataSet;

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
            new sTable { Primaria = new DataTable(), nomePrimaria="tblParameterCassette", Backup= new DataTable(), nomeBackup="tblParameterCassetteBck", indiceCampi=indiceTabellaFunzionamento },
        };

        static readonly int TBL_CASSETTE = 0;

        static void ResetTables()
        {
            int t;
            for (t = 0; t < elencoTabelle.Count(); t++)
            {
                if (elencoTabelle[t].Primaria != null)
                {
                    elencoTabelle[t].Primaria.Clear();
                    elencoTabelle[t].Primaria.Reset();
                }
            }
        }
        static public void Initdati(string Filename)
        {

            tblVersion = new DataTable("Versione");
            if (CassetteDataSet == null)
                CassetteDataSet = new DataSet("CassetteDataSet");
            CassetteDataSet.Clear();
            CassetteDataSet.Reset();
            ResetTables();
            initTabelle_();
            gFilename = Filename;
            //  if (AddEdit == Costanti.EDIT)
            // {
            if (File.Exists(gFilename))
            {
                CassetteDataSet.ReadXml(gFilename);
                tblVersion = CassetteDataSet.Tables["Versione"];
                if (utility.checkSameTblVersion(tblVersion, Costanti.tblIndice.TBLCASSETTE) == true)
                {

                    for (int i = 0; i < elencoTabelle.Count(); i++)
                    {
                        elencoTabelle[i].Primaria = CassetteDataSet.Tables[elencoTabelle[i].nomePrimaria];
                    }
                    copy2Bak();
                }
            }

            else
            {
                copy2Bak();
                utility.prepareVersion(tblVersion, Costanti.tblIndice.TBLCASSETTE);
                if (CassetteDataSet != null)
                {
                    CassetteDataSet.Clear();
                    CassetteDataSet.Reset();
                }

                for (int i = 0; i < elencoTabelle.Count(); i++)
                {
                    CassetteDataSet.Tables.Add(elencoTabelle[i].Primaria);
                }
                CassetteDataSet.Tables.Add(tblVersion);
                if(gFilename!="")
                    saveFile(gFilename);
                //}
            }
        }





        static void initDefault()
        {


        }

        static public void initTabelle_()
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
            if (t1 != null && tbck != null)
            {
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
                if(elencoTabelle[i].Primaria != null)
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
            CassetteDataSet.WriteXml(filename, XmlWriteMode.WriteSchema);
            copy2Bak();
        }

        static public void cancellaTabella()
        {
            elencoTabelle[TBL_CASSETTE].Primaria.Clear();
        }
        static public void salvaParametro(int ID, String descr, int valore)
        {
            elencoTabelle[TBL_CASSETTE].Primaria.Rows.Add();
            int i = elencoTabelle[TBL_CASSETTE].Primaria.Rows.Count - 1;
            elencoTabelle[TBL_CASSETTE].Primaria.Rows[i]["ID"] = ID;
            elencoTabelle[TBL_CASSETTE].Primaria.Rows[i]["DESCRIZIONE"] = descr;
            elencoTabelle[TBL_CASSETTE].Primaria.Rows[i]["VALORE"] = valore;
        }
        static public String getNomefromTabella(int r)
        {
            String dato = "";
            if (r < elencoTabelle[TBL_CASSETTE].Primaria.Rows.Count)
            {
                if (elencoTabelle[TBL_CASSETTE].Primaria.Rows[r]["DESCRIZIONE"] != null)
                {
                    dato = elencoTabelle[TBL_CASSETTE].Primaria.Rows[r]["DESCRIZIONE"].ToString();
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

        static public int getValorefromTabella(int r)
        {
            int dato = -1;
            int x;
            if (elencoTabelle[TBL_CASSETTE].Primaria.Rows[r]["ID"] != null)
            {
                if (Int32.TryParse(elencoTabelle[TBL_CASSETTE].Primaria.Rows[r]["VALORE"].ToString(), out x))
                    dato = x;
            }
            return dato;
        }

        static sVocParametri[] vocabolarioParametri =
{
        new sVocParametri() { NomeParametro = "KK_FUNZIONAMENTO",IDParametro = 0},
// -------------
new sVocParametri() { NomeParametro = "KK_ZONA_MORTA_RISC_HDZ",IDParametro = 1},
new sVocParametri() { NomeParametro = "KK_BANDA_REGOLAZIONE_RISC_HB",IDParametro = 2},
new sVocParametri() { NomeParametro = "KK_KI_REGOLAZIONE_RISCALDAMENTO",IDParametro = 3},
new sVocParametri() { NomeParametro = "KK_PERIODO_MODULAZIONE_PWM",IDParametro = 4},
new sVocParametri() { NomeParametro = "KK_MINIMO_DC_RESISTENZA",IDParametro = 5},
new sVocParametri() { NomeParametro = "KK_MASSIMO_DC_RESISTENZA",IDParametro = 6},
new sVocParametri() { NomeParametro = "KK_POTENZA_NOMINALE_RESISTENZA",IDParametro = 7},
new sVocParametri() { NomeParametro = "KK_PRESENZA_RESISTENZA",IDParametro = 8},
// -------------
new sVocParametri() { NomeParametro = "KK_LIM_POT_MAX",IDParametro = 9},
new sVocParametri() { NomeParametro = "KK_TEMP_ARIA_PRIM",IDParametro = 10},
// -------------
new sVocParametri() { NomeParametro = "KK_SETPOINT_DEFAULT",IDParametro = 11},
new sVocParametri() { NomeParametro = "KK_DEV_MAX_SETPOINT",IDParametro = 12},
new sVocParametri() { NomeParametro = "KK_INCR_ZONA_MORTA_DZI",IDParametro = 13},
// -------------
new sVocParametri() { NomeParametro = "KK_PRIMA_SOGLIA",IDParametro = 14},
new sVocParametri() { NomeParametro = "KK_IST_PRIMA_SOGLIA",IDParametro = 15},
new sVocParametri() { NomeParametro = "KK_SEC_SOGLIA",IDParametro = 16},
new sVocParametri() { NomeParametro = "KK_IST_SECONDA_SOGLIA",IDParametro = 17},
// -------------
new sVocParametri() { NomeParametro = "KK_DIFFUSIONE",IDParametro = 18},
// -------------
new sVocParametri() { NomeParametro = "KK_SETPOINT_LIM_MAX_HLSP",IDParametro = 19},
new sVocParametri() { NomeParametro = "KK_BANDA_REGOLAZIONE_LB",IDParametro = 20},
// -------------
new sVocParametri() { NomeParametro = "KK_ZONA_MORTA_SERRANDA_DDZ",IDParametro = 21},
new sVocParametri() { NomeParametro = "KK_BANDA_DI_REG_SERRANDA_DB",IDParametro = 22},
new sVocParametri() { NomeParametro = "KK_KI_REGOLAZIONE_SERRANDA",IDParametro = 23},
new sVocParametri() { NomeParametro = "KK_APERT_SERRANDA_MIN",IDParametro = 24},
new sVocParametri() { NomeParametro = "KK_APERT_SERRANDA_MAX",IDParametro = 25},
new sVocParametri() { NomeParametro = "KK_TENSIONE_SERRANDA_MIN",IDParametro = 26},
new sVocParametri() { NomeParametro = "KK_TENSIONE_SERRANDA_MAX",IDParametro = 27},
new sVocParametri() { NomeParametro = "KK_LOGOCA_DIR",IDParametro = 28},
new sVocParametri() { NomeParametro = "KK_PRESENZA_SERRANDA",IDParametro = 29},
// -------------
new sVocParametri() { NomeParametro = "KK_TIPO_ECONOMY",IDParametro = 30},
new sVocParametri() { NomeParametro = "KK_TASTO_ECONOMY_RID",IDParametro = 31},
// -------------
new sVocParametri() { NomeParametro = "KK_ABILITA_VIS_PORT_IST",IDParametro = 32},
new sVocParametri() { NomeParametro = "KK_PORT_MIN",IDParametro = 33},
new sVocParametri() { NomeParametro = "KK_PORT_MAX",IDParametro = 34},
new sVocParametri() { NomeParametro = "KK_PORT_MIN_SICUREZZA",IDParametro = 35},
new sVocParametri() { NomeParametro = "KK_SEZIONE",IDParametro = 36},
new sVocParametri() { NomeParametro = "KK_OFFSET_MIS_PORTATA",IDParametro = 37},
new sVocParametri() { NomeParametro = "KK_TEMP_LETT_SENSORE",IDParametro = 38},
new sVocParametri() { NomeParametro = "KK_K_APERT_SERR_0_10",IDParametro = 39},
new sVocParametri() { NomeParametro = "KK_K_APERT_SERR_10_20",IDParametro = 40},
new sVocParametri() { NomeParametro = "KK_K_APERT_SERR_20_30",IDParametro = 41},
new sVocParametri() { NomeParametro = "KK_K_APERT_SERR_30_40",IDParametro = 42},
new sVocParametri() { NomeParametro = "KK_K_APERT_SERR_40_50",IDParametro = 43},
new sVocParametri() { NomeParametro = "KK_K_APERT_SERR_50_60",IDParametro = 44},
new sVocParametri() { NomeParametro = "KK_K_APERT_SERR_60_70",IDParametro = 45},
new sVocParametri() { NomeParametro = "KK_K_APERT_SERR_70_80",IDParametro = 46},
new sVocParametri() { NomeParametro = "KK_K_APERT_SERR_80_90",IDParametro = 47},
new sVocParametri() { NomeParametro = "KK_K_APERT_SERR_90_100",IDParametro = 48},
// -------------
new sVocParametri() { NomeParametro = "KK_ING_DIG_D1",IDParametro = 49},
new sVocParametri() { NomeParametro = "KK_ING_DIG_D2",IDParametro = 50},
new sVocParametri() { NomeParametro = "KK_ING_DIG_D3",IDParametro = 51},
new sVocParametri() { NomeParametro = "KK_ING_DIG_NTC2",IDParametro = 52},
new sVocParametri() { NomeParametro = "KK_ING_DIG_D1_ONOFF",IDParametro = 53},
new sVocParametri() { NomeParametro = "KK_ING_DIG_D2_ONOFF",IDParametro = 54},
new sVocParametri() { NomeParametro = "KK_ING_DIG_D3_ONOFF",IDParametro = 55},
new sVocParametri() { NomeParametro = "KK_ING_DIG_D1_NCNO",IDParametro = 56},
new sVocParametri() { NomeParametro = "KK_ING_DIG_D2_NCNO",IDParametro = 57},
new sVocParametri() { NomeParametro = "KK_ING_DIG_D3_NCNO",IDParametro = 58},
// -------------
new sVocParametri() { NomeParametro = "KK_INTENSITA_LED",IDParametro = 59},
        };
    }
}
