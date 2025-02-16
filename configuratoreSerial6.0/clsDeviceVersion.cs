using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace configuratore
{
    // questa classe contiene le 
    // versioni dei dati dei dispositrivi 
    internal class clsDeviceVersion
    {
        static sVerdins[] versionCassette =
        {
            new sVerdins() { MM=1, Mm=0, mm=0 }
        };

        static sVerdins[] versionFancoil =
{
            new sVerdins() { MM=1, Mm=0, mm=0 }
        };


        static sVerdins[] versionTermoT1 =
{
            new sVerdins() { MM=1, Mm=0, mm=0 }     // analogico
        };

        static sVerdins[] versionTermoT2 =
{
            new sVerdins() { MM=1, Mm=0, mm=0 }     // Touch
        };
        static sVerdins[] versionTermoT3 =
{
            new sVerdins() { MM=1, Mm=0, mm=0 }     // Touch
        };
        public static int getNumOfVersioniCassette() { return versionCassette.Length; }
        public static int getNumOfVersioniFamcoil() { return versionFancoil.Length; }

        public static int getNumOfVersioniTermoT1() { return versionTermoT1.Length; }

        public static int getNumOfVersioniTermoT2() { return versionTermoT2.Length; }
        public static int getNumOfVersioniTermoT3() { return versionTermoT3.Length; }

        public static sVerdins getLastCassetteVersion()
        {
            int lx = versionCassette.Length - 1;
            return versionCassette[lx];
        }

        public sVerdins getLastFancoilVersion()
        {
            int lx = versionFancoil.Length - 1;
            return versionFancoil[lx];
        }


        public sVerdins getLastTermoT1Version()
        {
            int lx = versionTermoT1.Length - 1;
            return versionTermoT1[lx];
        }

        public sVerdins getLastTermoT2Version()
        {
            int lx = versionTermoT2.Length - 1;
            return versionTermoT2[lx];
        }


        static public int checkVersionFromRemote(int fancas,String dv)
        {
            int flg = 0;
            String[] z = dv.Split('.');
            sVerdins v;
            v.MM = Convert.ToInt32(z[0]);
            v.Mm = Convert.ToInt32(z[1]);
            v.mm = 0;
            flg = checkVersuinCompatibility(v,fancas);
            return flg;
        }

        static public int checkVersuinCompatibility(sVerdins v,int fancal)
        {
            int i;
            int comp;
            comp = -1;
            // resetta l'eventuale bit master
            fancal = fancal & Costanti.MASK_MASTER;
            switch (fancal)
            {
                case Costanti.CASSETTE:
                    for (i = 0; i < versionCassette.Length && comp < 0; i++)
                    {
                        if (v.MM == versionCassette[i].MM && v.Mm == versionCassette[i].Mm)
                            // trovata compatibilità
                            comp = i;
                    }
                    break;
                case Costanti.FANCOIL:
                    // FANCOIL
                    for (i = 0; i < versionFancoil.Length && comp < 0; i++)
                    {
                        if (v.MM == versionFancoil[i].MM && v.Mm == versionFancoil[i].Mm)
                            // trovata compatibilità
                            comp = i;
                    }
                    break;
                case Costanti.T1:
                    for (i = 0; i < versionTermoT1.Length && comp < 0; i++)
                    {
                        if (v.MM == versionTermoT1[i].MM && v.Mm == versionTermoT1[i].Mm)
                            // trovata compatibilità
                            comp = i;
                    }
                    break;
                case Costanti.T2:
                    for (i = 0; i < versionTermoT2.Length && comp < 0; i++)
                    {
                        if (v.MM == versionTermoT2[i].MM && v.Mm == versionTermoT2[i].Mm)
                            // trovata compatibilità
                            comp = i;
                    }
                    break;

            }

            return comp;
        }

        static public String getCassetteVersion(int i)
        {
            string x;
            x = String.Format("Ver. {0:D}.{1:D}.{2:D}", versionCassette[i].MM, versionCassette[i].Mm, versionCassette[i].mm);
            return x;
        }
        static public String getFancoilVersion(int i)
        {
            string x;
            x = String.Format("Ver. {0:D}.{1:D}.{2:D}", versionFancoil[i].MM, versionFancoil[i].Mm, versionFancoil[i].mm);
            return x;
        }

        static public String getTermoT1Version(int i)
        {
            string x;
            x = String.Format("Ver. {0:D}.{1:D}.{2:D}", versionTermoT1[i].MM, versionTermoT1[i].Mm, versionTermoT1[i].mm);
            return x;
        }

        static public String getTermoT2Version(int i)
        {
            string x;
            x = String.Format("Ver. {0:D}.{1:D}.{2:D}", versionTermoT2[i].MM, versionTermoT2[i].Mm, versionTermoT2[i].mm);
            return x;
        }

        static public String getTermoT3Version(int i)
        {
            string x;
            x = String.Format("Ver. {0:D}.{1:D}.{2:D}", versionTermoT3[i].MM, versionTermoT3[i].Mm, versionTermoT3[i].mm);
            return x;
        }
    }
}
