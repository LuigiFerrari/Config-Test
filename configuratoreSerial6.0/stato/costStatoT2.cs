using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static configuratore.stato.costAl;

namespace configuratore
{
    internal class costStatoT2
    {

        static statoDevice[] parAlarm;

        static public void init()
        {
            parAlarm = new statoDevice[]
           {
 new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=-1,sValore=""},//           0 T2S_TEMP_NTC1
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=-1,sValore=""},//           1 T2S_TEMP_NTC2
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=-1,sValore=""},//           2 T2S_TEMP_NTCEXT
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=-1,sValore=""},//           3 T2S_TEMP_NTCBOARD
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=5,sValore=""},//           4 T2S_TEMP_SETPOINT
new statoDevice() { decimali = 0 ,size =2, tipo='N',iValore=-1,sValore=""},//           5 T2S_FAN_SPEED
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//           6 T2S_FAN_AUTO_MAN
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=-1,sValore=""},//           7 T2S_ALIM_VOLT
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//           8 T2S_ERR_NTC1
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//           9 T2S_ERR_NTCEXT
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          10 T2S_ERR_NTCBOARD
new statoDevice() { decimali = 1 ,size =1, tipo='B',iValore=1,sValore=""},//          11 T2S_ERR_NTC
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          12 T2S_LED_MKR
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          13 T2S_LED_DND
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          14 T2S_OVC_MKR
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          15 T2S_OVC_DND
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=-1,sValore=""},//          16 T2S_REAL_SETPOINT_TEMP
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          17 T2S_ON_OFF
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=-1,sValore=""},//          18 T2S_TEMP_AMBIENTE
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          19 T2S_ERR_TEMP_AMBIENTE
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=200,sValore=""},//          20 T2S_DEFAULT_SETPOINT
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=30,sValore=""},//          21 T2S_DEVIAZIONE_SETPOINT
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          22 T2S_DISCONNESSO
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          23 T2S_QUICK_COOLING
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          24 T2S_RESET_SETPOINT
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          25 T2S_MAN_SPEED_ADJ
new statoDevice() { decimali = 1 ,size =1, tipo='N',iValore=0,sValore=""},//          26 T2S_TEMP_OFFSET
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          27 T2S_PLC_NUMBERS
// ----------------
new statoDevice() { decimali = 0 ,size =MAX_SIZE_STRING, tipo='S',iValore=-1,sValore=""},//          28 T2S_MATRICOLA
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          29 T2S_INDIRIZZO_SLAVE
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          30 T2S_MASTERSLAVE
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          31 T2S_RS485_ERROR_ORIZZ
// ----------------
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=0,sValore=""},//          32 T2S_FORZ_SETPOINT_VALORE
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          33 T2S_FORZ_SETPOINT_ONOFF

             };
            // setTestdefault();

        }
        static void setTestdefault()
        {
            for (int i = 0; i < VV_NUMERO_STATI; i++)
            {
                switch (getTipoParametro(i))
                {
                    case 'N':
                        parAlarm[i].iValore = i;
                        break;
                    case 'B':
                        parAlarm[i].iValore = i & 0x01;
                        break;
                    case 'S':
                        parAlarm[i].sValore = "AA" + i.ToString();
                        break;

                }
            }
        }




        static public char getTipoParametro(int p)
        {
            return parAlarm[p].tipo;
        }

        static public double getRealParametro(int p)
        {
            double ret;
            ret = (double)parAlarm[p].iValore / (double)utility.potDieci(parAlarm[p].decimali);
            return ret;
        }


        public static int getdecimali(int s)
        {
            return parAlarm[s].decimali;
        }


        public static int getSizeStato(int s)
        {
            return parAlarm[s].size;
        }


        public static int getParametro(int p)
        {
            return parAlarm[p].iValore;
        }

        public static String getStringParametro(int p)
        {
            return parAlarm[p].sValore;
        }

        public struct lbl
        {
            public String Text;
            public Color bckColor;
            public Boolean NochangeColor;
        }
        static public lbl getFormatStato(int p)
        {
            lbl r;
            r.bckColor = Color.Green;
            r.NochangeColor = false;
            r.Text = "";


            if (parAlarm[p].tipo == 'S')
                r.Text = parAlarm[p].sValore;
            else
            {
                if (parAlarm[p].tipo == 'B')
                {
                    r.Text = "";
                    if (parAlarm[p].iValore == 1)
                        r.bckColor = Color.Red;
                    else
                        r.bckColor = Color.Green;
                    r.NochangeColor = true;
                }
                else
                {
                    if (parAlarm[p].decimali == 0)
                        r.Text = parAlarm[p].iValore.ToString();
                    else
                        r.Text = String.Format("{0:F2}", getRealParametro(p));
                }
            }
            return r;
        }


        public const int T2S_TEMP_NTC1 = 0;
        public const int T2S_TEMP_NTC2 = 1;
        public const int T2S_TEMP_NTCEXT = 2;
        public const int T2S_TEMP_NTCBOARD = 3;
        public const int T2S_TEMP_SETPOINT = 4;
        public const int T2S_FAN_SPEED = 5;
        public const int T2S_FAN_AUTO_MAN = 6;
        public const int T2S_ALIM_VOLT = 7;
        public const int T2S_ERR_NTC1 = 8;
        public const int T2S_ERR_NTCEXT = 9;
        public const int T2S_ERR_NTCBOARD = 10;
        public const int T2S_ERR_NTC = 11;
        public const int T2S_LED_MKR = 12;
        public const int T2S_LED_DND = 13;
        public const int T2S_OVC_MKR = 14;
        public const int T2S_OVC_DND = 15;
        public const int T2S_REAL_SETPOINT_TEMP = 16;
        public const int T2S_ON_OFF = 17;
        public const int T2S_TEMP_AMBIENTE = 18;
        public const int T2S_ERR_TEMP_AMBIENTE = 19;
        public const int T2S_DEFAULT_SETPOINT = 20;
        public const int T2S_DEVIAZIONE_SETPOINT = 21;
        public const int T2S_DISCONNESSO = 22;
        public const int T2S_QUICK_COOLING = 23;
        public const int T2S_RESET_SETPOINT = 24;
        public const int T2S_MAN_SPEED_ADJ = 25;
        public const int T2S_TEMP_OFFSET = 26;
        public const int T2S_PLC_NUMBERS = 27;
        // ----------------
        public const int T2S_MATRICOLA = 28;
        public const int T2S_INDIRIZZO_SLAVE = 29;
        public const int T2S_MASTERSLAVE = 30;
        public const int T2S_RS485_ERROR_ORIZZ = 31;
        // ----------------
        public const int T2S_FORZ_SETPOINT_VALORE = 32;
        public const int T2S_FORZ_SETPOINT_ONOFF = 33;




        public const int T2S_NUMERO_STATI = (T2S_RS485_ERROR_ORIZZ + 1);


    }
}
