using configuratore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace configuratoreSerial6._0
{
    internal class datiTermostato
    {
        static private DataTable tblVersion;
        static private DataTable tblModello;

        static public DataSet TermostatoDataSet;

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

        static sCampiTabella[] indiceTabellaMODELLO =
{
            new sCampiTabella() {NameField="MODELLO",TypeField="System.String" ,primaryKey=1 },
        };


        static public sTable[] elencoTabelle =
        {
            new sTable { Primaria = new DataTable(), nomePrimaria="tblParametriTermostato", Backup= new DataTable(), nomeBackup="tblParametriTermostatoBck", indiceCampi=indiceTabellaFunzionamento },
        };

        static readonly int TBL_TERMOSTATO = 0;

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
            tblModello = new DataTable("Modello");
            if (TermostatoDataSet == null)
                TermostatoDataSet = new DataSet("TermostatoDataSet");
            TermostatoDataSet.Clear();
            TermostatoDataSet.Reset();
            ResetTables();
            initTabelle_();
            gFilename = Filename;
            //if (AddEdit == Costanti.EDIT)
            //{
            if (File.Exists(gFilename))
            {
                TermostatoDataSet.ReadXml(gFilename);
                tblVersion = TermostatoDataSet.Tables["Versione"];
                if (utility.checkSameTblVersion(tblVersion, Costanti.tblIndice.TBLTERMOSTATO) == true)
                {

                    for (int i = 0; i < elencoTabelle.Count(); i++)
                    {
                        elencoTabelle[i].Primaria = TermostatoDataSet.Tables[elencoTabelle[i].nomePrimaria];
                    }
                    copy2Bak();
                }
            }
            else
            {
                copy2Bak();
                utility.prepareVersion(tblVersion, Costanti.tblIndice.TBLTERMOSTATO);
                utility.prepareModello(tblModello, "TERMOSTATO");
                if (TermostatoDataSet != null)
                {
                    TermostatoDataSet.Clear();
                    TermostatoDataSet.Reset();
                }

                for (int i = 0; i < elencoTabelle.Count(); i++)
                {
                    TermostatoDataSet.Tables.Add(elencoTabelle[i].Primaria);
                }
                TermostatoDataSet.Tables.Add(tblVersion);
                TermostatoDataSet.Tables.Add(tblModello);
                if(gFilename!="")
                    saveFile(gFilename);
                //}
            }
        }




        static void initDefault()
        {


        }

        static public void AggiornaData()
        {
            utility.updateDataversion(tblVersion, (int)Costanti.tblIndice.TBLTERMOSTATO);
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
            TermostatoDataSet.WriteXml(filename, XmlWriteMode.WriteSchema);
            copy2Bak();
        }

        static public void cancellaTabella()
        {
            elencoTabelle[TBL_TERMOSTATO].Primaria.Clear();
        }
        static public void salvaParametro(int ID, String descr, int valore)
        {
            elencoTabelle[TBL_TERMOSTATO].Primaria.Rows.Add();
            int i = elencoTabelle[TBL_TERMOSTATO].Primaria.Rows.Count - 1;
            elencoTabelle[TBL_TERMOSTATO].Primaria.Rows[i]["ID"] = ID;
            elencoTabelle[TBL_TERMOSTATO].Primaria.Rows[i]["DESCRIZIONE"] = descr;
            elencoTabelle[TBL_TERMOSTATO].Primaria.Rows[i]["VALORE"] = valore;
        }

        static public int getIDfromTabella(int r)
        {
            int dato = -1;
            int x;
            if (elencoTabelle[TBL_TERMOSTATO].Primaria.Rows[r]["ID"] != null)
            {
                if (Int32.TryParse(elencoTabelle[TBL_TERMOSTATO].Primaria.Rows[r]["ID"].ToString(), out x))
                    dato = x;
            }
            return dato;
        }

        static public int getValorefromTabella(int r)
        {
            int dato = -1;
            int x;
            if (elencoTabelle[TBL_TERMOSTATO].Primaria.Rows[r]["ID"] != null)
            {
                if (Int32.TryParse(elencoTabelle[TBL_TERMOSTATO].Primaria.Rows[r]["VALORE"].ToString(), out x))
                    dato = x;
            }
            return dato;
        }

        static public String getNomefromTabella(int r)
        {
            String dato = "";
            if (r < elencoTabelle[TBL_TERMOSTATO].Primaria.Rows.Count)
            {
                if (elencoTabelle[TBL_TERMOSTATO].Primaria.Rows[r]["DESCRIZIONE"] != null)
                {
                    dato = elencoTabelle[TBL_TERMOSTATO].Primaria.Rows[r]["DESCRIZIONE"].ToString();
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
            new sVocParametri() {NomeParametro="KT2_R_COMMAND",IDParametro=0},
            new sVocParametri() {NomeParametro="KT2_G_COMMAND",IDParametro=1},
            new sVocParametri() {NomeParametro="KT2_B_COMMAND",IDParametro=2},
            new sVocParametri() {NomeParametro="KT2_R_FAN",IDParametro=3},
            new sVocParametri() {NomeParametro="KT2_G_FAN",IDParametro=4},
            new sVocParametri() {NomeParametro="KT2_B_FAN",IDParametro=5},
            new sVocParametri() {NomeParametro="KT2_R_WARM",IDParametro=6},
            new sVocParametri() {NomeParametro="KT2_G_WARM",IDParametro=7},
            new sVocParametri() {NomeParametro="KT2_B_WARM",IDParametro=8},
            new sVocParametri() {NomeParametro="KT2_R_CENTRAL",IDParametro=9},
            new sVocParametri() {NomeParametro="KT2_G_CENTRAL",IDParametro=10},
            new sVocParametri() {NomeParametro="KT2_B_CENTRAL",IDParametro=11},
            new sVocParametri() {NomeParametro="KT2_R_COLD",IDParametro=12},
            new sVocParametri() {NomeParametro="KT2_G_COLD",IDParametro=13},
            new sVocParametri() {NomeParametro="KT2_B_COLD",IDParametro=14},
            new sVocParametri() {NomeParametro="KT2_FULL",IDParametro=15},
            new sVocParametri() {NomeParametro="KT2_TEMP_ON",IDParametro=16},
            new sVocParametri() {NomeParametro="KT2_DIMMER",IDParametro=17},
            new sVocParametri() {NomeParametro="KT2_TEMP_OFF",IDParametro=18},
            new sVocParametri() {NomeParametro="KT2_NTC_ENABLE",IDParametro=19},
            new sVocParametri() {NomeParametro="KT2_BUZZER_ON_OFF",IDParametro=20},
            new sVocParametri() {NomeParametro="KT2_COMP_P1",IDParametro=21},
            new sVocParametri() {NomeParametro="KT2_COMP_P2",IDParametro=22},
            new sVocParametri() {NomeParametro="KT2_B0_NTC_VALUE",IDParametro=23},
            // -------------
            new sVocParametri() {NomeParametro="KT2_TIPO_DISPOSITIVO_MS",IDParametro=24},
            new sVocParametri() {NomeParametro="KT2_INDIRIZZO",IDParametro=25},
            new sVocParametri() {NomeParametro="KT2_BAUDRATE",IDParametro=26},
            new sVocParametri() {NomeParametro="KT2_PARITA",IDParametro=27},
            new sVocParametri() {NomeParametro="KT2_BITSTOP",IDParametro=28},
            // -------------
            new sVocParametri() {NomeParametro="KT2_INDIRIZZO_SLAVE",IDParametro=29},
            // -------------
            new sVocParametri() {NomeParametro="KT2_MODELLO",IDParametro=30},
            // -------------
            new sVocParametri() {NomeParametro="KT2_SHARED_TEMPERATURE",IDParametro=31},
            // -------------
            new sVocParametri() {NomeParametro="KT2_V_ROSSO",IDParametro=32},
            new sVocParametri() {NomeParametro="KT2_V_VERDE",IDParametro=33},
            new sVocParametri() {NomeParametro="KT2_V_BLU",IDParametro=34},
            new sVocParametri() {NomeParametro="KT2_V_FORZ_SETPOINT_VALORE",IDParametro=35},
            new sVocParametri() {NomeParametro="KT2_V_FORZ_SETPOINT_ONOFF",IDParametro=36},




        };
    }
}
