using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace configuratoreSerial6._0
{
    public struct structList
    {
        public String label;
        public int passFail;
    }



    // costanti TermoAnal







    internal class reportList
    {

        public const string T1LEDROSSO100  = "LEDROSSO 100%";
        public const string T1LEDROSSO50 = "LEDROSSO 50%";
        public const string T1LEDROSSO0 = "LEDROSSO 0%";
        public const string T1LEDVERDE100 = "LEDVERDE 100%";
        public const string T1LEDVERDE50 = "LEDVERDE 50%";
        public const string T1LEDVERDE0 = "LEDVERDE 0%";
        public const string T1LEDBLU100 = "LEDRBLU 100%";
        public const string T1LEDBLU50 = "LEDRBLU 50%";
        public const string T1LEDBLU0 = "LEDRBLU 0%";
        public const string T1NTC1 = "NTC1";
        public const string T1NTC2 = "NTC2";
        public const string T1TOUCH = "TOUCH";
        public const string T1BEEP = "BEEP";
        public const string T1POT = "POT";
        public const string T1RS48512 = "RS4851-2";
        public const string T1RS4852 = "RS4852";
        public const string T1RS48513 = "RS4851-3";
        public const string T1RS4853 = "RS4853";

        public const string FCLEDS = "LEDS";
        public const string FCDI = "DIGITAL INPUTS";
        public const string FCTRIAC = "TRIACS";
        public const string FCPRESS = "PRESSURE SENSOR";
        public const string FCAD1 = "DAC1 - ADC1";
        public const string FCAD2 = "DAC2 - ADC2";
        public const string FCRS4851 = "RS4851";
        public const string FCRS4852 = "RS4852";
        public const string FCNTC1 = "NTC1";
        public const string FCNTC2 = "NTC2";


        static List<structList> lista;
        static string[] ctrlFancoilCassette = {
            FCLEDS  ,
            FCDI    ,
            FCNTC1,
            FCNTC2,
            FCTRIAC ,
            FCPRESS ,
            FCAD1   ,
            FCAD2   ,
            FCRS4851,
            FCRS4852
        };

        static string[] ctrlTermoAn = {
            T1LEDROSSO100,
            T1LEDROSSO50,
            T1LEDROSSO0,
            T1LEDVERDE100,
            T1LEDVERDE50,
            T1LEDVERDE0,
            T1LEDBLU100,
            T1LEDBLU50,
            T1LEDBLU0,
            T1NTC1,
            T1NTC2,
            T1TOUCH,
            T1BEEP,
            T1POT,
            T1RS48512,
            T1RS4852,
            T1RS48513,
            T1RS4853
    };

        static int device;

        static public void setDevice(int d) {  device = d; }

        static public int getSizeList() {  return lista.Count; }
        static public String getLabelList(int i) { return lista[i].label;  }
        static public String getPassFailList(int i)
        {
            String pass = "FAIL";
            if (lista[i].passFail != 0)
                pass = "PASS";
            return pass;
        }


        static string[] getCTRLlist()
        {
            String[] xx = ctrlTermoAn;
            switch (device)
            {
                case 0:
                case 1:
                    xx = ctrlFancoilCassette;
                    break;
                case 2: // termostato analogico
                    xx = ctrlTermoAn;
                    break;
            }
            return xx;
        }
        static public void initreportList(int device)
        {
            lista = new List<structList>();
            for(int i=0;i< getCTRLlist().Length;i++)
            {
                structList rec;
                rec.passFail = 0;
                rec.label = getCTRLlist()[i];
                lista.Add(rec);
            }
        }

        static  public void setPass(String ctrl)
        {
            add2List(ctrl, 1);
        }

        static public void setPass(int ctrl)
        {
            add2List(ctrl, 1);
        }

        static public void add2List(String ctrl,int passFail)
        {
            int trovato = -1;
            for(int i=0;i< lista.Count && trovato <0;i++)
            {
                if (lista[i].label== ctrl)
                    trovato = i;
            }
            if(trovato>=0)
            {
                structList rec;
                rec = lista[trovato];
                rec.passFail = passFail;
                lista[trovato] = rec;
            }
        }

        static public void add2List(int ctrl, int passFail)
        {
          
            if (ctrl < lista.Count)
            {
                structList rec;
                rec = lista[ctrl];
                rec.passFail = passFail;
                lista[ctrl] = rec;
            }
        }
    }
}
