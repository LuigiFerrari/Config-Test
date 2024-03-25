using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static configuratore.stato.costAl;

namespace configuratore.stato
{
    internal class costAlFanCoil
    {
        public const int FCS_MATRICOLA = 0;
        public const int FCS_INDIRIZZO_SLAVE = 1;
        public const int FCS_MASTER_SLAVE = 2;
        public const int FCS_DISP_PRIMARIO = 3;
        // ----------------
        public const int FCS_SONDA_REGOLAZIONE = 4;
        public const int FCS_TEMP_SONDA = 5;
        public const int FCS_SETPOINT_TEMP = 6;
        public const int FCS_TEMPERATURA_INTERNA = 7;
        public const int FCS_PRESSIONE_DIFFER = 8;
        public const int FCS_CO2 = 9;
        public const int FCS_VOC = 10;
        public const int FCS_DISCRETE_SETPOINT = 11;
        public const int FCS_TEMP_TERMOSTATO = 12;
        // ----------------
        public const int FCS_PERC_VENTILATORE = 13;
        public const int FCS_VOLT_VENTILATORE = 14;
        public const int FCS_VELOCITA_VENTILATORE = 15;
        public const int FCS_VALVOLA_FREDDA_PWM = 16;
        public const int FCS_VALVOLA_FREDDA_DCMAX = 17;
        public const int FCS_VALVOLA_FREDDA_MOD = 18;
        public const int FCS_VALVOLA_FREDDA_MODMAX = 19;
        public const int FCS_PERC_RES_ELETTRICA = 20;
        public const int FCS_DC_MASSIMO_IST_RES = 21;
        public const int FCS_VALVOLA_CALDA_PWM = 22;
        public const int FCS_VALVOLA_CALDA_DCMAX = 23;
        public const int FCS_VALVOLA_CALDA_MOD = 24;
        public const int FCS_VALVOLA_CALDA_MODMAX = 25;
        public const int FCS_VALVOLA_CHOVER = 26;
        public const int FCS_RID_RAFFREDDAMENTO = 27;
        public const int FCS_RIS_RISACALDAMENTO = 28;
        public const int FCS_SERRANDA_PERC = 29;
        public const int FCS_SERRANDA_VOLT = 30;
        public const int FCS_VENTILATORE_ONOFF = 31;
        // ----------------
        public const int FCS_SPENTO_BMS = 32;
        public const int FCS_SPENTO_TERMOSTATO = 33;
        public const int FCS_SPENTO_D1 = 34;
        public const int FCS_SPENTO_ECONOMY = 35;
        public const int FCS_FANCOIL_OFF = 36;
        public const int FCS_MOD_ECONOMY_MODBUS_DI1 = 37;
        public const int FCS_MOD_ECONOMY_MODBUS_DI2 = 38;
        public const int FCS_MOD_ECONOMY_MODBUS_DI3 = 39;
        public const int FCS_MOD_ECONOMY_DI1 = 40;
        public const int FCS_MOD_ECONOMY_DI2 = 41;
        public const int FCS_MOD_ECONOMY_DI3 = 42;
        public const int FCS_ECONOMY_TYPE = 43;
        public const int FCS_MOD_ECONOMY_RETE = 44;
        public const int FCS_MOD_ECONOMY_BMS_EN_SAVING = 45;
        public const int FCS_LIMITE_TEMP_MAND_RIS_RAFF = 46;
        public const int FCS_LIMITE_TEMP_SCHEDA = 47;
        public const int FCS_RAFF_RAPIDO = 48;
        public const int FCS_CONTATORE_FILTRO = 49;
        // ----------------
        public const int FCS_AL_SONDA_REGOLAZIONE = 50;
        public const int FCS_AL_SONDA_TEMP_RIPRESA = 51;
        public const int FCS_AL_SONDA_TEMP_MANDATA = 52;
        public const int FCS_AL_TEMP_SICUREZZA = 53;
        public const int FCS_AL_INTERVENTO_TERM_SICUREZZA = 54;
        public const int FCS_AL_TEMP_MANDATA_CALDO = 55;
        public const int FCS_AL_TEMP_MANDATA_FREDDO = 56;
        public const int FCS_AL_TER_STANZA_NON_COLL = 57;
        public const int FCS_AL_SONDA_TEMP_STANZA = 58;
        public const int FCS_AL_CIRC_RES_APERTO = 59;
        public const int FCS_AL_CIRC_INNESCO_RES = 60;
        public const int FCS_AL_GEN_FANCOIL = 61;
        public const int FCS_AL_INCENDIO_GENERALE = 62;
        public const int FCS_AL_CUMULATIVO = 63;
        public const int FCS_AL_VENTILATORE = 64;
        public const int FCS_AL_SERRANDA = 65;
        public const int FCS_AL_SENSORE_PRESS = 66;
        public const int FCS_AL_PRESS_BASSA = 67;
        public const int FCS_AL_PRESS_ALTA = 68;
        public const int FCS_AL_0_10_VALVOLA = 69;
        public const int FCS_AL_FILTRO_SPORCO = 70;
        // ----------------
        public const int FCS_TEMP_SCHEDA = 71;
        public const int FCS_FREQ_RETE = 72;
        public const int FCS_V24VOLT = 73;
        public const int FCS_RIDUZIONE_TEMP = 74;
        public const int FCS_V_RETE = 75;
        // ----------------
        public const int FCS_QUICK_COOLING = 76;
        public const int FCS_VELOCITA_AUTO_MAN = 77;
        public const int FCS_MOD_TERMOSTATICO_DI5 = 78;
        public const int FCS_FORZATURA_ONOFF_SETPOINT = 79;
        public const int FCS_FORZATURA_VALORE_SETPOINT = 80;





        public const int FCS_NUMERO_STATI = (FCS_MOD_TERMOSTATICO_DI5 + 1);

        static statoDevice[] parAlarm;
        static public void init()
        {
            parAlarm = new statoDevice[]
            {
new statoDevice() { decimali = 0 ,size =MAX_SIZE_STRING, tipo='S',iValore=-1,sValore=""},//           0 FCS_MATRICOLA                
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//           1 FCS_INDIRIZZO_SLAVE          
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//           2 FCS_MASTER_SLAVE
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//           3 FCS_DISP_PRIMARIO
// ----------------
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//           4 FCS_SONDA_REGOLAZIONE
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=-1,sValore=""},//           5 FCS_TEMP_SONDA
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=-1,sValore=""},//           6 FCS_SETPOINT_TEMP
new statoDevice() { decimali = 1 ,size =3, tipo='N',iValore=-1,sValore=""},//           7 FCS_TEMPERATURA_INTERNA
new statoDevice() { decimali = 1 ,size =3, tipo='N',iValore=-1,sValore=""},//           8 FCS_PRESSIONE_DIFFER
new statoDevice() { decimali = 1 ,size =3, tipo='N',iValore=-1,sValore=""},//           9 FCS_CO2
new statoDevice() { decimali = 1 ,size =3, tipo='N',iValore=-1,sValore=""},//          10 FCS_VOC
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=5,sValore=""},//          11 FCS_DISCRETE_SETPOINT
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=-1,sValore=""},//          12 FCS_TEMP_TERMOSTATO
// ----------------
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          13 FCS_PERC_VENTILATORE
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=-1,sValore=""},//          14 FCS_VOLT_VENTILATORE
new statoDevice() { decimali = 0 ,size =2, tipo='N',iValore=-1,sValore=""},//          15 FCS_VELOCITA_VENTILATORE
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          16 FCS_VALVOLA_FREDDA_PWM
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          17 FCS_VALVOLA_FREDDA_DCMAX
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          18 FCS_VALVOLA_FREDDA_MOD
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          19 FCS_VALVOLA_FREDDA_MODMAX
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          20 FCS_PERC_RES_ELETTRICA
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          21 FCS_DC_MASSIMO_IST_RES
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          22 FCS_VALVOLA_CALDA_PWM
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          23 FCS_VALVOLA_CALDA_DCMAX
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          24 FCS_VALVOLA_CALDA_MOD
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          25 FCS_VALVOLA_CALDA_MODMAX
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          26 FCS_VALVOLA_CHOVER
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          27 FCS_RID_RAFFREDDAMENTO
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          28 FCS_RIS_RISACALDAMENTO
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          29 FCS_SERRANDA_PERC
new statoDevice() { decimali = 1 ,size =3, tipo='N',iValore=-1,sValore=""},//          30 FCS_SERRANDA_VOLT
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          31 FCS_VENTILATORE_ONOFF
// ----------------
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          32 FCS_SPENTO_BMS
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          33 FCS_SPENTO_TERMOSTATO
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          34 FCS_SPENTO_D1
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          35 FCS_SPENTO_ECONOMY
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          36 FCS_FANCOIL_OFF
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          37 FCS_MOD_ECONOMY_MODBUS_DI1
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          38 FCS_MOD_ECONOMY_MODBUS_DI2
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          39 FCS_MOD_ECONOMY_MODBUS_DI3
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          40 FCS_MOD_ECONOMY_DI1
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          41 FCS_MOD_ECONOMY_DI2
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          42 FCS_MOD_ECONOMY_DI3
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          43 FCS_ECONOMY_TYPE
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          44 FCS_MOD_ECONOMY_RETE
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          45 FCS_MOD_ECONOMY_BMS_EN_SAVING
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          46 FCS_LIMITE_TEMP_MAND_RIS_RAFF
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          47 FCS_LIMITE_TEMP_SCHEDA
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          48 FCS_RAFF_RAPIDO
new statoDevice() { decimali = 0 ,size =2, tipo='N',iValore=0,sValore=""},//          49 FCS_CONTATORE_FILTRO
// ----------------
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          50 FCS_AL_SONDA_REGOLAZIONE
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          51 FCS_AL_SONDA_TEMP_RIPRESA
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          52 FCS_AL_SONDA_TEMP_MANDATA
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          53 FCS_AL_TEMP_SICUREZZA
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          54 FCS_AL_INTERVENTO_TERM_SICUREZZA
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          55 FCS_AL_TEMP_MANDATA_CALDO
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          56 FCS_AL_TEMP_MANDATA_FREDDO
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          57 FCS_AL_TER_STANZA_NON_COLL
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          58 FCS_AL_SONDA_TEMP_STANZA
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          59 FCS_AL_CIRC_RES_APERTO
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          60 FCS_AL_CIRC_INNESCO_RES
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          61 FCS_AL_GEN_FANCOIL
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          62 FCS_AL_INCENDIO_GENERALE
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          63 FCS_AL_CUMULATIVO
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          64 FCS_AL_VENTILATORE
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          65 FCS_AL_SERRANDA
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          66 FCS_AL_SENSORE_PRESS
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          67 FCS_AL_PRESS_BASSA
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          68 FCS_AL_PRESS_ALTA
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          69 FCS_AL_0_10_VALVOLA
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          70 FCS_AL_FILTRO_SPORCO
// ----------------
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=-1,sValore=""},//          71 FCS_TEMP_SCHEDA
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          72 FCS_FREQ_RETE
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=-1,sValore=""},//          73 FCS_V24VOLT
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          74 FCS_RIDUZIONE_TEMP
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          75 FCS_V_RETE
// ----------------
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          76 FCS_QUICK_COOLING
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          77 FCS_VELOCITA_AUTO_MAN
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          78 FCS_MOD_TERMOSTATICO_DI5
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          79 FCS_FORZATURA_ONOFF_SETPOINT
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=200,sValore=""},//          80 FCS_FORZATURA_VALORE_SETPOINT


            };
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
    }
}
