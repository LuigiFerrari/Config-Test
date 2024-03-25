using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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


        static sCampiTabella[] indiceTabellaFunzionamento =
        {
            new sCampiTabella() {NameField="ID",TypeField="System.Int32" ,primaryKey=1 },
            new sCampiTabella() {NameField="DESCRIZIONE",TypeField="System.String" ,primaryKey=1 },
            new sCampiTabella() {NameField="VALORE",TypeField="System.Int32" ,primaryKey=1 },
        };


        static public sTable[] elencoTabelle =
        {
            new sTable { Primaria = new DataTable(), nomePrimaria="tblCassetteParameter", Backup= new DataTable(), nomeBackup="tblCassetteParameterBck", indiceCampi=indiceTabellaFunzionamento },
        };

        static readonly int TBL_CASSETTE = 0;


        static public void Initdati(string Filename, int AddEdit)
        {

            tblVersion = new DataTable("Versione");
            if (CassetteDataSet == null)
                CassetteDataSet = new DataSet("CassetteDataSet");
            CassetteDataSet.Clear();
            CassetteDataSet.Reset();
            initTabelle_();
            gFilename = Filename;
            if (AddEdit == Costanti.EDIT)
            {
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
                saveFile(gFilename);
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
            CassetteDataSet.WriteXml(filename, XmlWriteMode.WriteSchema);
            copy2Bak();
        }

        static public void cancellaTabella()
        {
            elencoTabelle[TBL_CASSETTE].Primaria.Clear();
        }
        static public void salvaParametro(int ID,String descr, int valore)
        {
            elencoTabelle[TBL_CASSETTE].Primaria.Rows.Add();
            int i = elencoTabelle[TBL_CASSETTE].Primaria.Rows.Count - 1;
            elencoTabelle[TBL_CASSETTE].Primaria.Rows[i]["ID"] = ID;
            elencoTabelle[TBL_CASSETTE].Primaria.Rows[i]["DESCRIZIONE"] = descr;
            elencoTabelle[TBL_CASSETTE].Primaria.Rows[i]["VALORE"] = valore;
        }
    }
}
