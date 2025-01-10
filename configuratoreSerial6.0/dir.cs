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
        static string dataDir;


        static String tmpConfDir;


        const string CONF_DIR = "\\Configurazione\\";
        const string MASTER_DIR = "Roccheggiani";





        static public void init()
        {
            // inizializzaione directory

            String appData = Application.LocalUserAppDataPath;
            String ctmpDir = System.IO.Path.GetTempPath();
            string LocalAppdocDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string docDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            configDir = LocalAppdocDir + "\\" + MASTER_DIR + CONF_DIR;
            if (!System.IO.Directory.Exists(configDir))
                System.IO.Directory.CreateDirectory(configDir);

            dataDir = docDir + "\\" + MASTER_DIR;
            if (!System.IO.Directory.Exists(dataDir))
                System.IO.Directory.CreateDirectory(dataDir);

            tmpConfDir = ctmpDir + MASTER_DIR + CONF_DIR;
            if (!System.IO.Directory.Exists(configDir))
                System.IO.Directory.CreateDirectory(configDir);
        }

        public static String getDataDir() {  return dataDir; }
        public static string getTmpDir() { return tmpConfDir; }
        static public string getConfigDir() { return configDir; }

    }
}
