using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace configuratore
{
    internal class clsMsg
    {
        static string Matricola;
        static string Versione;
        static string BldNum;
        static string dataVersion;
        static string MasterSlave;
        static sVerdins v;
        static public void getInfo(byte[] b)
        {
            // F0 00 00 30 30 31 01 7F 7F 30 2E 30 2E 31 00 30 30 30 31 32 33 00 30 00 F7 
            Versione = "";
            int i;
            for (i = Costanti.DATA; b[i] != 0; i++) {
                
                Versione = Versione + (char)b[i];
            }
            Debug.WriteLine("Versione sw: " + Versione);

            Matricola = "";
            i++;
            for (; b[i] != 0;i++)
                Matricola = Matricola + (char)b[i];
            Debug.WriteLine("Matricola: " + Matricola);


            i++;
            dataVersion = "";
            for (; b[i] != 0; i++)
                dataVersion = dataVersion + (char)b[i];
            Debug.WriteLine("Versione dati: " + dataVersion);

            i++;
            MasterSlave = "";
            for (; b[i] != 0; i++)
                MasterSlave = MasterSlave + (char)b[i];
            Debug.WriteLine("Master/Slave: " + MasterSlave);
        }

        static public string getMatricola() { return Matricola;  }
        static public string  getVersionStr() { return Versione;  }

        static public string getDataVersionStr() { return dataVersion; }

        static public string getMasterSlaveStr() { return MasterSlave; }

        static public String getDataVersionH()
        {
            string[] x = dataVersion.Split('.');
            return x[0];
        }
        static public String getDataVersionL()
        {
            string[] x = dataVersion.Split('.');
            return x[1];
        }

        static public String getInfoMsg()
        {
            return "Software release. " + Versione + " DataVersion: " + dataVersion + " Serial number: " + Matricola + " Master/slave: " + MasterSlave;
        }

       

        static public String getInfoMsg(String lMatricola, String lMasterSlave,String SlaveRelease)
        {
            return "Software release. " + SlaveRelease + " DataVersion: " + dataVersion + " Serial number: " + lMatricola + " Master/slave: " + lMasterSlave;
        }


    }
}
