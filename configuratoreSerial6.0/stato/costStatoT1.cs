using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static configuratore.stato.costAl;

namespace configuratore.costStatoT1
{
    internal class constStatoT1
    {
      

        struct statoDeviceRif
        {
            public int iValore;
            public String sValore;
        }

        static statoDevice[] parAlarm;


        public const int MAX_SIZE_STRING = 20;

        static public void init()
        {
            parAlarm = new statoDevice[]
           {
 new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           0 T2S_MATRICOLA_00
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           1 T2S_MATRICOLA_02
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           2 T2S_MATRICOLA_04
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           3 T2S_MATRICOLA_08
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           4 T2S_MATRICOLA_10
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           5 T2S_MATRICOLA_12
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           6 T2S_MATRICOLA_14
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           7 T2S_MATRICOLA_16
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           8 T2S_MATRICOLA_18
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           9 T2S_MATRICOLA_20
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=-1,sValore=""},//          10 T2S_TEMP_NTC1
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=-1,sValore=""},//          11 T2S_TEMP_NTC2
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=-1,sValore=""},//          12 T2S_TEMP_NTCEXT
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=-1,sValore=""},//          13 T2S_TEMP_NTCBOARD
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=5,sValore=""},//          14 T2S_TEMP_SETPOINT
new statoDevice() { decimali = 0 ,size =2, tipo='N',iValore=-1,sValore=""},//          15 T2S_FAN_SPEED
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          16 T2S_FAN_AUTO_MAN
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=-1,sValore=""},//          17 T2S_ALIM_VOLT
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          18 T2S_ERR_NTC1
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          19 T2S_ERR_NTCEXT
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          20 T2S_ERR_NTCBOARD
new statoDevice() { decimali = 1 ,size =1, tipo='B',iValore=1,sValore=""},//          21 T2S_ERR_NTC
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          22 T2S_LED_MKR
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          23 T2S_LED_DND
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          24 T2S_OVC_MKR
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          25 T2S_OVC_DND
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=-1,sValore=""},//          26 T2S_REAL_SETPOINT_TEMP
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          27 T2S_ON_OFF
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=-1,sValore=""},//          28 T2S_TEMP_AMBIENTE
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          29 T2S_ERR_TEMP_AMBIENTE
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=200,sValore=""},//          30 T2S_DEFAULT_SETPOINT
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=30,sValore=""},//          31 T2S_DEVIAZIONE_SETPOINT
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          32 T2S_DISCONNESSO
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          33 T2S_QUICK_COOLING
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          34 T2S_RESET_SETPOINT
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          35 T2S_MAN_SPEED_ADJ
new statoDevice() { decimali = 1 ,size =1, tipo='N',iValore=0,sValore=""},//          36 T2S_TEMP_OFFSET
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          37 T2S_PLC_NUMBERS
// ----------------
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          38 T2S_INDIRIZZO_SLAVE
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          39 T2S_MASTERSLAVE
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          40 T2S_RS485_ERROR_ORIZZ
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=0,sValore=""},//          41 T2S_FORZ_SETPOINT_VALORE
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          42 T2S_FORZ_SETPOINT_ONOFF

                
             };
            // setTestdefault();
                
        }

        
        static void setTestdefault()
        {
            for(int i=0;i< VV_NUMERO_STATI;i++)
            {
                switch(getTipoParametro(i))
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

        public const int T2S_MATRICOLA_00 = 0;
        public const int T2S_MATRICOLA_02 = 1;
        public const int T2S_MATRICOLA_04 = 2;
        public const int T2S_MATRICOLA_08 = 3;
        public const int T2S_MATRICOLA_10 = 4;
        public const int T2S_MATRICOLA_12 = 5;
        public const int T2S_MATRICOLA_14 = 6;
        public const int T2S_MATRICOLA_16 = 7;
        public const int T2S_MATRICOLA_18 = 8;
        public const int T2S_MATRICOLA_20 = 9;
        public const int T2S_TEMP_NTC1 = 10;
        public const int T2S_TEMP_NTC2 = 11;
        public const int T2S_TEMP_NTCEXT = 12;
        public const int T2S_TEMP_NTCBOARD = 13;
        public const int T2S_TEMP_SETPOINT = 14;
        public const int T2S_FAN_SPEED = 15;
        public const int T2S_FAN_AUTO_MAN = 16;
        public const int T2S_ALIM_VOLT = 17;
        public const int T2S_ERR_NTC1 = 18;
        public const int T2S_ERR_NTCEXT = 19;
        public const int T2S_ERR_NTCBOARD = 20;
        public const int T2S_ERR_NTC = 21;
        public const int T2S_LED_MKR = 22;
        public const int T2S_LED_DND = 23;
        public const int T2S_OVC_MKR = 24;
        public const int T2S_OVC_DND = 25;
        public const int T2S_REAL_SETPOINT_TEMP = 26;
        public const int T2S_ON_OFF = 27;
        public const int T2S_TEMP_AMBIENTE = 28;
        public const int T2S_ERR_TEMP_AMBIENTE = 29;
        public const int T2S_DEFAULT_SETPOINT = 30;
        public const int T2S_DEVIAZIONE_SETPOINT = 31;
        public const int T2S_DISCONNESSO = 32;
        public const int T2S_QUICK_COOLING = 33;
        public const int T2S_RESET_SETPOINT = 34;
        public const int T2S_MAN_SPEED_ADJ = 35;
        public const int T2S_TEMP_OFFSET = 36;
        public const int T2S_PLC_NUMBERS = 37;
        // ----------------
        public const int T2S_INDIRIZZO_SLAVE = 38;
        public const int T2S_MASTERSLAVE = 39;
        public const int T2S_RS485_ERROR_ORIZZ = 40;
        public const int T2S_FORZ_SETPOINT_VALORE = 41;
        public const int T2S_FORZ_SETPOINT_ONOFF = 42;






        public const int T2S_NUMERO_STATI = (T2S_RS485_ERROR_ORIZZ + 1);




    }
}
