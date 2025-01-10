using configuratore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UniqueID;

namespace configuratoreSerial6._0.uniqueID
{
    internal class uniqueID
    {

        static int configurazione;
        static String HwID;

        public static void setConfigurazione(int x) { configurazione=x; }
        public static String getHWid() { return HwID; }
       
        
        public int getConfigurazione() { return configurazione; }
        public uniqueID()
        {
            UHWIDEngine.setUniqueID();
            HwID = UHWIDEngine.getSimpleUid();
            configurazione = testConfig(datiConfig.getUniqueID());
            if (configurazione == -1)
            {
                frmRequireCOnfig frmRequire = new frmRequireCOnfig();
                frmRequire.ShowDialog();
                configurazione = frmRequire.getConfig();
                // apre dialog box per configurazione
            } 
            if(configurazione>=0)
            {
                global.setLivello(configurazione);
            }
        }
        static String[] s = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
        

        static public int testConfig(String myID)
        {
            int config = -1;
            String id = myID;
            if (id != null)
            {
                if (id.Length == 24)
                {
                    // ID valido
                    String[] localID = getIDsFromHW();
                    for (int k = 0; k < localID.Length && config < 0; k++)
                    {
                        if (localID[k] == id)
                        {
                            config = k;
                        }
                    }
                }
            }
            return config;
        }

            static String[] getIDsFromHW()
            {
                String HWid = UHWIDEngine.getSimpleUid();
                return getStribgheConfigurazione(HWid);

            }

            static String[] getStribgheConfigurazione(String HWid)
            {
                int i;
                String[] ret = new String[3];
                Int128 dSeme = 0;
                Int128 pot16 = 1;
                for (i = 0; i < HWid.Length; i++)
                {
                    dSeme = dSeme + convert2Hex(HWid[i]) * pot16;
                    pot16 = pot16 * 16;
                }
                mysrand(dSeme);
                Int128[] nweRND = new Int128[3];
                nweRND[0] = myrand();
                nweRND[1] = myrand();
                nweRND[2] = myrand();
                ret[0] = fmt4(nweRND[0]);
                ret[1] = fmt4(nweRND[1]);
                ret[2] = fmt4(nweRND[2]);

                return ret;
            }
            static int convert2Hex(char n)
            {
                int z = 0;
                if (n >= '0' && n <= '9')
                {
                    z = n - '0';
                }
                else
                {
                    if (n >= 'A' && n <= 'F')
                        z = n - 'A' + 10;
                }
                return z;
            }
            static Int128 rand_next;
            static void mysrand(Int128 seed)
            {
                rand_next = seed;
            }
            static Int128 myrand()
            {
                /*
                    rand_next = rand_next * (unsigned long long)1103515245;  ( 2^32-1)
                     rand_next = rand_next       + (unsigned long long)12345;
                */
                rand_next = rand_next * (Int128)1103515245; // ( 2^32-1)
                rand_next = rand_next + (Int128)12345;
                BigInteger bi = (BigInteger)rand_next;
                byte[] ba = bi.ToByteArray();
                rand_next = 0;
                Int128 potenza;
                potenza = 1;
                for (int i = 0; i < 12; i++)
                {
                    rand_next = rand_next + ba[i] * potenza;
                    potenza = potenza * 256;
                }
                return (Int128)rand_next;
            }
            static String fmt4(Int128 x)
            {
                int i, j;
                j = 0;

                BigInteger bi = (BigInteger)x;
                byte[] ba = bi.ToByteArray();

                String z = "";
                for (i = 11; i >= 0; i--)
                {
                    int x0 = (int)ba[i] & 0x0f;
                    int x1 = ((int)ba[i] >> 4) & 0x0f;
                    z = z + s[x1] + s[x0];

                }
                return z;
            }
            static public String fmt4(String x)
            {
                int i, j;
                j = 0;
                String z = "";
                for (i = 0; i < x.Length; i++)
                {
                    z = z + x[i];
                    j++;
                    if (j == 4)
                    {
                        z = z + " ";
                        j = 0;
                    }
                }
                return z;
            }

            static public String[] fmt4Split(String x)
            {
                int i, j;
                j = 0;
                String[] z = new String[6];
                String a = "";
                int k = 0;
                for (i = 0; i < x.Length; i++)
                {
                    a = a + x[i];
                    j++;
                    if (j == 4)
                    {
                        z[k] = a;
                        a = "";
                        j = 0;
                        k++;
                    }
                }
                return z;
            }
        }
    }
