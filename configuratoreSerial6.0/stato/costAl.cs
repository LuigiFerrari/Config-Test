using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.ApplicationModel.Contacts;

namespace configuratore.stato
{
    internal class costAl
    {
        public struct statoDevice

        {
            public int size;            // numero di byte del messaggio
            public int decimali;        // numero di decimale da rappresentare
            public char tipo;           // tipo messaggio (N numerico S Stringa)
            public int iValore;
            public String sValore;
        }

        struct statoDeviceRif
        {
            public int iValore;
            public String sValore;
        }

        static statoDevice[] parAlarm;


        public const int MAX_SIZE_STRING = 20;
        public const int MAX_SIZE_VERSIONE = 12;

        static public void init()
        {
            parAlarm = new statoDevice[] {
new statoDevice() { decimali = 0 ,size =MAX_SIZE_STRING, tipo='S',iValore=0,sValore=""},//           0 VV_MATRICOLA_00
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           1 VV_MATRICOLA_02
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           2 VV_MATRICOLA_04
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           3 VV_MATRICOLA_06
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           4 VV_MATRICOLA_08
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           5 VV_MATRICOLA_10
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           6 VV_MATRICOLA_12
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           7 VV_MATRICOLA_14
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           8 VV_MATRICOLA_16
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           9 VV_MATRICOLA_18
new statoDevice() { decimali = 0 ,size =MAX_SIZE_VERSIONE, tipo='V',iValore=0,sValore=""},//          10 VV_VERSIONE_00
new statoDevice() { decimali = 0 ,size =2, tipo='V',iValore=0,sValore=""},//          11 VV_VERSIONE_01
new statoDevice() { decimali = 0 ,size =2, tipo='V',iValore=0,sValore=""},//          12 VV_VERSIONE_02
new statoDevice() { decimali = 0 ,size =2, tipo='V',iValore=0,sValore=""},//          13 VV_VERSIONE_03
new statoDevice() { decimali = 0 ,size =2, tipo='V',iValore=0,sValore=""},//          14 VV_VERSIONE_04
new statoDevice() { decimali = 0 ,size =2, tipo='V',iValore=0,sValore=""},//          15 VV_VERSIONE_05
new statoDevice() { decimali = 1 ,size =3, tipo='N',iValore=0,sValore=""},//          16 VV_PORTATA_ISTANTANEA       
new statoDevice() { decimali = 1 ,size =3, tipo='N',iValore=0,sValore=""},//          17 VV_DELTA_PRESS_IST          
new statoDevice() { decimali = 1 ,size =3, tipo='N',iValore=0,sValore=""},//          18 VV_PORTATA_MINIMA           
new statoDevice() { decimali = 1 ,size =3, tipo='N',iValore=0,sValore=""},//          19 VV_DELTA_PRESS_MIN          
new statoDevice() { decimali = 1 ,size =3, tipo='N',iValore=0,sValore=""},//          20 VV_PORTATA_MASSIMA          
new statoDevice() { decimali = 1 ,size =3, tipo='N',iValore=0,sValore=""},//          21 VV_DELTA_PRESS_MAX          
new statoDevice() { decimali = 1 ,size =3, tipo='N',iValore=0,sValore=""},//          22 VV_PORTATA_MINIMA_SICUREZZA 
new statoDevice() { decimali = 1 ,size =3, tipo='N',iValore=0,sValore=""},//          23 VV_DELTA_PRESS_SIC          
new statoDevice() { decimali = 1 ,size =3, tipo='N',iValore=0,sValore=""},//          24 VV_MODULAZIONE_SERRANDA     
new statoDevice() { decimali = 1 ,size =1, tipo='N',iValore=0,sValore=""},//          25 VV_TENSIONE_SERRANDA
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          26 VV_POSIZIONE_SERRANDA       
// ----------------
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=0,sValore=""},//          27 VV_TEMPERATURA_AMBIENTE     
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=0,sValore=""},//          28 VV_SETPOINT_TEMPERATURA
new statoDevice() { decimali = 0 ,size =3, tipo='N',iValore=0,sValore=""},//          29 VV_RESISTENZA_ELETTRICA     
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          30 VV_DC_MAX_ISTANTANEO        
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          31 VV_RIDUZIONE_RISCALDAMENTO  
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=0,sValore=""},//          32 VV_TEMPERATURA_INTERNA      
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=0,sValore=""},//          33 VV_TEMPERATURA_MANDATA      
// ----------------
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          34 VV_INDIRIZZO_SLAVE          
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          35 VV_MASTER_SLAVE
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          36 VV_DISP_PRIMARIO
// ----------------
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          37 VV_MODALITAOFFDAREMOTO      
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          38 VV_MODALITAECODATERMOSTATO  
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          39 VV_ECON_DISABLE_DA_MODBUS_ID1        
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          40 VV_ECON_DISABLE_DA_MODBUS_ID2        
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          41 VV_ECON_DISABLE_DA_MODBUS_ID3        
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          42 VV_MODALITAECONDAID1        
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          43 VV_MODALITAECONDAID2        
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          44 VV_MODALITAECONDAID3        
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          45 VV_MODALITAECONDAANAL       
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          46 VV_MODALITAECONDAPLCINRETE  
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          47 VV_MODALITAECONDAMODBUS     
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          48 VV_OFFRESISTPRIMASOGLIA     
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          49 VV_LIMITEMASSIMOTMANDATA    
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          50 VV_RIDUZIONEDCMAXRESPERPORT 
// ----------------
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          51 VV_SONDATEMPINTERNA         
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          52 VV_SONDATEMPMANDATA         
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          53 VV_SONDATEMPAMBIENTE        
new statoDevice() { decimali = 1 ,size =1, tipo='B',iValore=0,sValore=""},//          54 VV_ERR_NTC
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          55 VV_ALTATEMINTSECONDASOGLIA  
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          56 VV_INTERVENTOTERMRESISTENZA 
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          57 VV_TERMSTANZANONCOLLEGATO   
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          58 VV_SONDATEMSTANZA           
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          59 VV_CIRCRESISTENZAAPERTA     
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          60 VV_CIRCINNESCORES           
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          61 VV_SERRANDA                 
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          62 VV_SENSOREPRESSIONE         
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          63 VV_PORTATABASSA             
// ----------------
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=0,sValore=""},//          64 VV_TEMPERATURA_SCHEDA       
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          65 VV_FREQUENZ_RETE            
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=0,sValore=""},//          66 VV_24VOLT                   
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          67 VV_RIDUZIONETEMP            
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          68 VV_V_RETE
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          69 VV_RS485_ERROR_ORIZZ
// --------------
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=0,sValore=""},//          70 VV_TEMP_TERMOSTATO
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=5,sValore=""},//          71 VV_DISCRETE_SETPOINT
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          72 VV_ON_OFF_REMOTO
// VIRTUALI
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          73 VV_VRT_ON_OFF_SONDE
new statoDevice() { decimali = 0 ,size =3, tipo='N',iValore=0,sValore=""},//          74 VV_INGRESSI_FISICI



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


            if (parAlarm[p].tipo == 'S' || parAlarm[p].tipo == 'V')
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

        public const int VV_MATRICOLA_00 = 0;
        public const int VV_MATRICOLA_02 = 1;
        public const int VV_MATRICOLA_04 = 2;
        public const int VV_MATRICOLA_06 = 3;
        public const int VV_MATRICOLA_08 = 4;
        public const int VV_MATRICOLA_10 = 5;
        public const int VV_MATRICOLA_12 = 6;
        public const int VV_MATRICOLA_14 = 7;
        public const int VV_MATRICOLA_16 = 8;
        public const int VV_MATRICOLA_18 = 9;
        public const int VV_VERSIONE_00 = 10;
        public const int VV_VERSIONE_01 = 11;
        public const int VV_VERSIONE_02 = 12;
        public const int VV_VERSIONE_03 = 13;
        public const int VV_VERSIONE_04 = 14;
        public const int VV_VERSIONE_05 = 15;
        public const int VV_PORTATA_ISTANTANEA = 16;
        public const int VV_DELTA_PRESS_IST = 17;
        public const int VV_PORTATA_MINIMA = 18;
        public const int VV_DELTA_PRESS_MIN = 19;
        public const int VV_PORTATA_MASSIMA = 20;
        public const int VV_DELTA_PRESS_MAX = 21;
        public const int VV_PORTATA_MINIMA_SICUREZZA = 22;
        public const int VV_DELTA_PRESS_SIC = 23;
        public const int VV_MODULAZIONE_SERRANDA = 24;
        public const int VV_TENSIONE_SERRANDA = 25;
        public const int VV_POSIZIONE_SERRANDA = 26;
        // ----------------
        public const int VV_TEMPERATURA_AMBIENTE = 27;
        public const int VV_SETPOINT_TEMPERATURA = 28;
        public const int VV_RESISTENZA_ELETTRICA = 29;
        public const int VV_DC_MAX_ISTANTANEO = 30;
        public const int VV_RIDUZIONE_RISCALDAMENTO = 31;
        public const int VV_TEMPERATURA_INTERNA = 32;
        public const int VV_TEMPERATURA_MANDATA = 33;
        // ----------------
        public const int VV_INDIRIZZO_SLAVE = 34;
        public const int VV_MASTER_SLAVE = 35;
        public const int VV_DISP_PRIMARIO = 36;
        // ----------------
        public const int VV_MODALITAOFFDAREMOTO = 37;
        public const int VV_MODALITAECODATERMOSTATO = 38;
        public const int VV_ECON_DISABLE_DA_MODBUS_ID1 = 39;
        public const int VV_ECON_DISABLE_DA_MODBUS_ID2 = 40;
        public const int VV_ECON_DISABLE_DA_MODBUS_ID3 = 41;
        public const int VV_MODALITAECONDAID1 = 42;
        public const int VV_MODALITAECONDAID2 = 43;
        public const int VV_MODALITAECONDAID3 = 44;
        public const int VV_MODALITAECONDAANAL = 45;
        public const int VV_MODALITAECONDAPLCINRETE = 46;
        public const int VV_MODALITAECONDAMODBUS = 47;
        public const int VV_OFFRESISTPRIMASOGLIA = 48;
        public const int VV_LIMITEMASSIMOTMANDATA = 49;
        public const int VV_RIDUZIONEDCMAXRESPERPORT = 50;
        // ----------------
        public const int VV_SONDATEMPINTERNA = 51;
        public const int VV_SONDATEMPMANDATA = 52;
        public const int VV_SONDATEMPAMBIENTE = 53;
        public const int VV_ERR_NTC = 54;
        public const int VV_ALTATEMINTSECONDASOGLIA = 55;
        public const int VV_INTERVENTOTERMRESISTENZA = 56;
        public const int VV_TERMSTANZANONCOLLEGATO = 57;
        public const int VV_SONDATEMSTANZA = 58;
        public const int VV_CIRCRESISTENZAAPERTA = 59;
        public const int VV_CIRCINNESCORES = 60;
        public const int VV_SERRANDA = 61;
        public const int VV_SENSOREPRESSIONE = 62;
        public const int VV_PORTATABASSA = 63;
        // ----------------
        public const int VV_TEMPERATURA_SCHEDA = 64;
        public const int VV_FREQUENZ_RETE = 65;
        public const int VV_24VOLT = 66;
        public const int VV_RIDUZIONETEMP = 67;
        public const int VV_V_RETE = 68;
        public const int VV_RS485_ERROR_ORIZZ = 69;
        // --------------
        public const int VV_TEMP_TERMOSTATO = 70;
        public const int VV_DISCRETE_SETPOINT = 71;
        public const int VV_ON_OFF_REMOTO = 72;
        // VIRTUALI
        public const int VV_VRT_ON_OFF_SONDE = 73;
        public const int VV_INGRESSI_FISICI = 74;




        public const int VV_NUMERO_STATI = (VV_INGRESSI_FISICI + 1);                                // 52




    }
}
