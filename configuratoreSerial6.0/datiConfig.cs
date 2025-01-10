using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace configuratore
{
    internal class datiConfig
    {
        static public DataTable tblLinguaggio;
        static public DataTable tblDefaultDir;
        static private DataTable tblVersion;
        static private DataTable tblID;

        static public DataSet ConfigDataSet;
        const string ConfigFile = "config.xml";
        const string BckConfigFile = "bck_" + ConfigFile;
        static string FilenameyName;
        static string BckFilenameyName;


        static public readonly string[] NameFieldLinguaggio = { "ID", };
        static public readonly string[] TypeFieldLinguaggio = { "System.Int32", };

        static public readonly string[] NameFieldDefaultDir = { "DEFAULTDIR", };
        static public readonly string[] TypeFieldDefaultDir = { "System.String", };

        static public readonly string[] NameFieldUniqueID = { "UNIQUEID", };
        static public readonly string[] TypeFieldUniqueID = { "System.String", };



        static public void Initdati()
        {
            tblVersion = new DataTable("Versione");

            ConfigDataSet = new DataSet("configurazione");
            // carica voice library
            FilenameyName = dir.getConfigDir() + ConfigFile;
            BckFilenameyName = dir.getConfigDir() + BckConfigFile;
            int ok=compareFile(BckFilenameyName, FilenameyName);
            if (File.Exists(FilenameyName) && ok==0)
            {
                ConfigDataSet.ReadXml(FilenameyName);
                tblVersion = ConfigDataSet.Tables["Versione"];
                if (utility.checkSameTblVersion(tblVersion, Costanti.tblIndice.TBLCONFIG) == true)
                {
                    tblLinguaggio = ConfigDataSet.Tables["Indice linguaggio"];
                    tblDefaultDir = ConfigDataSet.Tables["DefaultDir"];
                    tblID = ConfigDataSet.Tables["UniqueID"];
                } else
                {
                    tblLinguaggio = ConfigDataSet.Tables["Indice linguaggio"];
                    tblDefaultDir = ConfigDataSet.Tables["DefaultDir"];
                    String versone = utility.getTblVersion(tblVersion);
                    Boolean flgExit = false;
                    while (!flgExit)
                    {
                        switch (versone)
                        {
                            case "0.0.0":
                                // 0.0.0 -> 0.0.1 aggiunge default dir parametri termostato
                                converti000_001("0.0.1");
                                break;
                            case "0.0.1":
                                // converti da 0.0.1 a 0.0.2
                                // Aggiunge tabella Unique ID
                                converti001_002("0.0.2");
                                flgExit = true;
                                saveFile();
                                break;

                        }
                    }
                }
            }
            else
            {
                tblLinguaggio = new DataTable("Indice linguaggio");
                tblDefaultDir = new DataTable("DefaultDir");
                tblID = new DataTable("UniqueID");
                

                prepareRowsOriginal();
                initDefault();
                utility.prepareVersion(tblVersion, Costanti.tblIndice.TBLCONFIG);
                ConfigDataSet.Tables.Add(tblID);
                ConfigDataSet.Tables.Add(tblLinguaggio);
                ConfigDataSet.Tables.Add(tblDefaultDir);
                ConfigDataSet.Tables.Add(tblVersion);
                saveFile();
            }   
        }

        static public void saveFile()
        {
            
            ConfigDataSet.WriteXml(FilenameyName, XmlWriteMode.WriteSchema);
            ConfigDataSet.WriteXml(BckFilenameyName, XmlWriteMode.WriteSchema);

        }


        static public void setLinguaggio(int l)
        {
            tblLinguaggio.Rows[0]["ID"] = l;
        }

        static public int getLinguaggio()
        {
            return Convert.ToInt32(tblLinguaggio.Rows[0]["ID"]);
        }

        static public string getDefaultDir() {
            String strDir = tblDefaultDir.Rows[0][NameFieldDefaultDir[0]].ToString();
            if (!Directory.Exists(strDir))
                strDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return strDir;
        }

        //static public void setDefaultDirCassette(string Dir)
        //{
        //    tblDefaultDir.Rows[0][NameFieldDefaultDir[0]] = Dir;
        //}

        //static public void setDefaultDirThermostat(string Dir)
        //{
        //    tblDefaultDir.Rows[2][NameFieldDefaultDir[0]] = Dir;
        //}

        //static public void setDefaultDirFanCoil(string Dir)
        //{
        //    tblDefaultDir.Rows[2][NameFieldDefaultDir[0]] = Dir;
        //}

        static void initDefault()
        {
            tblLinguaggio.Rows.Add();
            tblLinguaggio.Rows[0]["ID"] = loca.ITALIANO;

            tblDefaultDir.Rows.Add();
            tblDefaultDir.Rows[0][NameFieldDefaultDir[0]] = dir.getDataDir() + "CassetteParam.prm";
            tblDefaultDir.Rows.Add();
            tblDefaultDir.Rows[1][NameFieldDefaultDir[0]] = dir.getDataDir() + "FanCoilParam.prm";
            tblDefaultDir.Rows.Add();
            tblDefaultDir.Rows[2][NameFieldDefaultDir[0]] = dir.getDataDir() + "ThermostatParam.prm";
            loca.setLinguaggio(getLinguaggio());
            tblID.Rows.Add();
            tblID.Rows[0][NameFieldUniqueID[0]] = "";
        }


        static void converti000_001(string nextVersion)
        {
            tblDefaultDir.Rows.Add();
            tblDefaultDir.Rows[2][NameFieldDefaultDir[0]] = dir.getDataDir() + "ThermostatParam.prm";
            utility.UpdateVersion(tblVersion, nextVersion);
        }

        static void converti001_002(string nextVersion)
        {
            tblID = new DataTable("UniqueID");
            tblID.Rows.Add();
            creaColonnetblID();
            ConfigDataSet.Tables.Add(tblID);
            utility.UpdateVersion(tblVersion, nextVersion);
        }

        static void creaColonnetblID()
        {
            for (int i = 0; i < NameFieldUniqueID.Count(); i++)
            {
                DataColumn column;
                column = new DataColumn();
                column.DataType = System.Type.GetType(TypeFieldUniqueID[i]);
                column.ColumnName = NameFieldUniqueID[i];
                tblID.Columns.Add(column);
            }
        }


        static public void setDefaultDirFancoil(string Dir)
        {
            if(tblDefaultDir.Rows.Count < 2)
            {
                tblDefaultDir.Rows.Add();
                tblDefaultDir.Rows[1]["DEFAULTDIR"] = dir.getDataDir()+"\\FanCoilParam.prm";
            } else
            {
                tblDefaultDir.Rows[1]["DEFAULTDIR"] = Dir;

            }
        }

        static public String getDefaultDirFancoil() {
            if (tblDefaultDir.Rows.Count < 2)
            {
                tblDefaultDir.Rows.Add();
                tblDefaultDir.Rows[1]["DEFAULTDIR"] = dir.getDataDir() + "\\FanCoilParam.prm";
            }
            return tblDefaultDir.Rows[1]["DEFAULTDIR"].ToString();
        }

        static public void setDefaultDirCassette(string Dir)
        {
            if (tblDefaultDir.Rows.Count < 2)
            {
                tblDefaultDir.Rows.Add();
                tblDefaultDir.Rows[1]["DEFAULTDIR"] = dir.getDataDir() + "\\CassetteParam.prm";
            }
            else
            {
                tblDefaultDir.Rows[1]["DEFAULTDIR"] = Dir;

            }
        }
        static public String getDefaultDirCassette()
        {
            if (tblDefaultDir.Rows.Count < 2)
            {
                tblDefaultDir.Rows.Add();
                tblDefaultDir.Rows[1]["DEFAULTDIR"] = dir.getDataDir() + "\\CassetteParam.prm";
            }
            return tblDefaultDir.Rows[1]["DEFAULTDIR"].ToString();
        }

        static public String getDefaultDirTermostato()
        {
            if (tblDefaultDir.Rows.Count < 3)
            {
                tblDefaultDir.Rows.Add();
                tblDefaultDir.Rows[2]["DEFAULTDIR"] = dir.getDataDir() + "\\ThermostatParam.prm";
            }
            return tblDefaultDir.Rows[2]["DEFAULTDIR"].ToString();
        }

        static public void setDefaultDirTermostato(string Dir)
        {
            if (tblDefaultDir.Rows.Count < 3)
            {
                tblDefaultDir.Rows.Add();
                tblDefaultDir.Rows[1]["DEFAULTDIR"] = dir.getDataDir() + "\\ThermostatParam.prm";
            }
            else
            {
                tblDefaultDir.Rows[1]["DEFAULTDIR"] = Dir;

            }
        }


        static void prepareRowsOriginal()
        {
            int i;
            for (i = 0; i < NameFieldLinguaggio.Count(); i++)
            {
                DataColumn column;
                column = new DataColumn();
                column.DataType = System.Type.GetType(TypeFieldLinguaggio[i]);
                column.ColumnName = NameFieldLinguaggio[i];
                tblLinguaggio.Columns.Add(column);
            }
            for (i = 0; i < NameFieldDefaultDir.Count(); i++)
            {
                DataColumn column;
                column = new DataColumn();
                column.DataType = System.Type.GetType(TypeFieldDefaultDir[i]);
                column.ColumnName = NameFieldDefaultDir[i];
                tblDefaultDir.Columns.Add(column);
            }
            creaColonnetblID();


        }

        static public string getUniqueID() { return tblID.Rows[0]["UNIQUEID"].ToString();  }

        static public void setUniqueID(String id) { 
            tblID.Rows[0]["UNIQUEID"] = id;
            saveFile();
        }

        static int compareFile(String f1, String f2)
        {
            int x = 0;
            if (!File.Exists(f1))
                x = -1;
            if (!File.Exists(f2))
                x = -1;
            if (x == 0)
            {
                String s1 = File.ReadAllText(f1);
                String s2 = File.ReadAllText(f2);
                if (s1 != s2)
                    x = -1;
            }
            return x;
        }
    }
}
