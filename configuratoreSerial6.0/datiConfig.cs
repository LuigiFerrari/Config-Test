using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace configuratore
{
    internal class datiConfig
    {
        static public DataTable tblLinguaggio;
        static public DataTable tblDefaultDir;
        static private DataTable tblVersion;

        static public DataSet ConfigDataSet;
        const string ConfigFile = "config.xml";
        static string FilenameyName;


        static public readonly string[] NameFieldLinguaggio = { "ID", };
        static public readonly string[] TypeFieldLinguaggio = { "System.Int32", };

        static public readonly string[] NameFieldDefaultDir = { "DEFAULTDIR", };
        static public readonly string[] TypeFieldDefaultDir = { "System.String", };




        static public void Initdati()
        {
            tblVersion = new DataTable("Versione");

            ConfigDataSet = new DataSet("configurazione");
            // carica voice library
            FilenameyName = dir.getConfigDir() + "\\" + ConfigFile;

            if (File.Exists(FilenameyName))
            {
                ConfigDataSet.ReadXml(FilenameyName);
                tblVersion = ConfigDataSet.Tables["Versione"];
                if (utility.checkSameTblVersion(tblVersion, Costanti.tblIndice.TBLCONFIG) == true)
                {
                    tblLinguaggio = ConfigDataSet.Tables["Indice linguaggio"];
                    tblDefaultDir = ConfigDataSet.Tables["DefaultDir"];
                }
            }
            else
            {
                tblLinguaggio = new DataTable("Indice linguaggio");
                tblDefaultDir = new DataTable("DefaultDir");

                prepareRowsOriginal();
                initDefault();
                utility.prepareVersion(tblVersion, Costanti.tblIndice.TBLCONFIG);

                ConfigDataSet.Tables.Add(tblLinguaggio);
                ConfigDataSet.Tables.Add(tblDefaultDir);
                ConfigDataSet.Tables.Add(tblVersion);
                saveFile();
            }
        }

        static public void saveFile()
        {
            ConfigDataSet.WriteXml(FilenameyName, XmlWriteMode.WriteSchema);

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

        static public void setDefaultDirCassette(string Dir)
        {
            tblDefaultDir.Rows[0][NameFieldDefaultDir[0]] = Dir;
        }

        static void initDefault()
        {
            tblLinguaggio.Rows.Add();
            tblLinguaggio.Rows[0]["ID"] = loca.ITALIANO;

            tblDefaultDir.Rows.Add();
            tblDefaultDir.Rows[0][NameFieldDefaultDir[0]] = dir.getDataDir() + "CassetteParam.prm";
            tblDefaultDir.Rows.Add();
            tblDefaultDir.Rows[1][NameFieldDefaultDir[0]] = dir.getDataDir() + "FanCoilParam.prm";
            loca.setLinguaggio(getLinguaggio());
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
            for (i = 0; i < NameFieldLinguaggio.Count(); i++)
            {
                DataColumn column;
                column = new DataColumn();
                column.DataType = System.Type.GetType(TypeFieldDefaultDir[i]);
                column.ColumnName = NameFieldDefaultDir[i];
                tblDefaultDir.Columns.Add(column);
            }
        }
    }
}
