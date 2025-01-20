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
        static String docDir;

        const string MASTER_DIR = "\\Roccheggiani\\";

        const String TESTDIR = MASTER_DIR+"Test\\";
        const string TESTDIR_FANCOIL = TESTDIR + "Fancoil\\";
        const string TESTDIR_CASSETTE = TESTDIR + "Cassette\\";
        const string TESTDIR_T_ANAL = TESTDIR + "TermoAnalogico\\";
        const string TESTDIR_T_TOUCH = TESTDIR + "TermoTouch\\";
        const string TESTDIR_T_TFT = TESTDIR + "TermoTFT\\";
        const string CONFIG_DIR = TESTDIR + "Config\\";




        public static string getDir(int device)
        {
            String d = "";
            switch (device)
            {
                case Costanti.CASSETTE:
                    d = TESTDIR_CASSETTE;
                    break;
                case Costanti.FANCOIL:
                    d = TESTDIR_FANCOIL;
                    break;
                case Costanti.T1:  // Anal
                    d = TESTDIR_T_ANAL;
                    break;
                case Costanti.T2: // Touch
                    d = TESTDIR_T_TOUCH;
                    break;
                case Costanti.T3: // TFT
                    d = TESTDIR_T_TFT;
                    break;
            }
            return docDir+d;
        }

        static public String getTestConfigDir() { return configDir; }

        static public void init()
        {
            // inizializzaione directory


            docDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


            configDir = docDir + CONFIG_DIR;

            if (!System.IO.Directory.Exists(configDir))
                System.IO.Directory.CreateDirectory(configDir);
            
            String testDir; 

            for (int i=0;i<5;i++)
            {
                testDir =  getDir(i);
                if (!System.IO.Directory.Exists(testDir))
                    System.IO.Directory.CreateDirectory(testDir);
            }

        }
    }
}
