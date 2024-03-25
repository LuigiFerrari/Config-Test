using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace configuratore
{
    internal class dir
    {

        static string configDir;
        static String dataDir;


        const string CONF_DIR = "\\Configurazione\\";
        const string MASTER_DIR = "\\Roccheggiani\\";





        static public void init()
        {
            // inizializzaione directory


            string docDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dataDir = docDir + MASTER_DIR;
            if (!System.IO.Directory.Exists(dataDir))
                System.IO.Directory.CreateDirectory(dataDir);

            configDir = docDir + MASTER_DIR + CONF_DIR;
            if (!System.IO.Directory.Exists(configDir))
                System.IO.Directory.CreateDirectory(configDir);
        }

        static public string getConfigDir() { return configDir; }
        static public string getDataDir() { return dataDir; }

    }
}
