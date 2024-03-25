using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace configuratore
{
    internal class parametriT2
    {
        // parametri
        public const int KT2_R_COMMAND = 0;
        public const int KT2_G_COMMAND = 1;
        public const int KT2_B_COMMAND = 2;
        public const int KT2_R_FAN = 3;
        public const int KT2_G_FAN = 4;
        public const int KT2_B_FAN = 5;
        public const int KT2_R_WARM = 6;
        public const int KT2_G_WARM = 7;
        public const int KT2_B_WARM = 8;
        public const int KT2_R_CENTRAL = 9;
        public const int KT2_G_CENTRAL = 10;
        public const int KT2_B_CENTRAL = 11;
        public const int KT2_R_COLD = 12;
        public const int KT2_G_COLD = 13;
        public const int KT2_B_COLD = 14;
        public const int KT2_FULL = 15;
        public const int KT2_TEMP_ON = 16;
        public const int KT2_DIMMER = 17;
        public const int KT2_TEMP_OFF = 18;
        public const int KT2_NTC_ENABLE = 19;
        public const int KT2_BUZZER_ON_OFF = 20;
        public const int KT2_COMP_P1 = 21;
        public const int KT2_COMP_P2 = 22;
        public const int KT2_B0_NTC_VALUE = 23;
        // -------------
        public const int KT2_TIPO_DISPOSITIVO_MS = 24;
        public const int KT2_INDIRIZZO = 25;
        public const int KT2_BAUDRATE = 26;
        public const int KT2_PARITA = 27;
        public const int KT2_BITSTOP = 28;
        // INDIRIZZO ORIZ.
        public const int KT2_INDIRIZZO_SLAVE = 29;
        // --- TIPOLOGIA
        public const int KT2_MODELLO = 30;
        // --- HIDDEN
        public const int KT2_SHARED_TEMPERATURE = 31;
        // ---- FORZATURE
        public const int KT2_V_ROSSO = 32;
        public const int KT2_V_VERDE = 33;
        public const int KT2_V_BLU = 34;
        public const int KT2_V_FORZ_SETPOINT_VALORE = 35;
        public const int KT2_V_FORZ_SETPOINT_ONOFF = 36;




        public const int NUMERO_PARAMETRI_KT2 = KT2_MODELLO + 1;

        static public int calcolaSizeParametro(int p)
        {
            return sizeParametri[p];
        }

        static int[] sizeParametri = new int[]
        {
2, // KT2_R_COMMAND
2, // KT2_G_COMMAND
2, // KT2_B_COMMAND
2, // KT2_R_FAN
2, // KT2_G_FAN
2, // KT2_B_FAN
2, // KT2_R_WARM
2, // KT2_G_WARM
2, // KT2_B_WARM
2, // KT2_R_CENTRAL
2, // KT2_G_CENTRAL
2, // KT2_B_CENTRAL
2, // KT2_R_COLD
2, // KT2_G_COLD
2, // KT2_B_COLD
1, // KT2_FULL
1, // KT2_TEMP_ON
1, // KT2_DIMMER
1, // KT2_TEMP_OFF
1, // KT2_NTC_ENABLE
1, // KT2_BUZZER_ON_OFF
1, // KT2_COMP_P1
2, // KT2_COMP_P2
2, // KT2_B0_NTC_VALUE
// -------------
1, // KT2_TIPO_DISPOSITIVO_MS
2, // KT2_INDIRIZZO
1, // KT2_BAUDRATE
1, // KT2_PARITA
1, // KT2_BITSTOP
// INDIRIZZO ORIZ.
2, // KT2_INDIRIZZO_SLAVE
// --- TIPOLOGIA
1, // KT2_MODELLO
// --- HIDDEN
2, // KT2_SHARED_TEMPERATURE
// ---- FORZATURE
1, // KT2_V_ROSSO
1, // KT2_V_VERDE
1, // KT2_V_BLU
2, // KT2_V_FORZ_SETPOINT_VALORE
1, // KT2_V_FORZ_SETPOINT_ONOFF



        };
    }
}
