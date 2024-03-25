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


        const string CONF_DIR = "\\Configurazione\\Cassette\\";
        const string MASTER_DIR = "\\Roccheggiani\\";





        static public void init()
        {
            // inizializzaione directory


            string docDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            configDir = docDir + MASTER_DIR + CONF_DIR;
            if (!System.IO.Directory.Exists(configDir))
                System.IO.Directory.CreateDirectory(configDir);
        }

        static public string getCassetteConfigDir() { return configDir; }

    }
}
