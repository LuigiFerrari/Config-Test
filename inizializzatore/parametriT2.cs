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
        public const int KT2_DEFAULT_SETPOINT = 20;
        public const int KT2_DEVIAZIONE_SETPOINT = 21;
        // -------------
        public const int KT2_TIPO_DISPOSITIVO_MS = 22;
        public const int KT2_INDIRIZZO = 23;
        public const int KT2_BAUDRATE = 24;
        public const int KT2_PARITA = 25;
        public const int KT2_BITSTOP = 26;
        // INDIRIZZO ORIZ.
        public const int KT2_INDIRIZZO_SLAVE = 27;
        // --- TIPOLOGIA
        public const int KT2_MODELLO = 28;
        // --- HIDDEN
        public const int KT2_SHARED_TEMPERATURE = 29;
        // ---- FORZATURE
        public const int KT2_V_ROSSO = 30;
        public const int KT2_V_VERDE = 31;
        public const int KT2_V_BLU = 32;
        public const int KT2_V_SETPOINT_REMOTO = 33;

        public const int NUMERO_PARAMETRI_KT2 = KT2_MODELLO + 1;

        static public int calcolaSizeParametro(int p)
        {
            return sizeParametri[p];
        }

        static int[] sizeParametri = new int[]
        {
// parametri
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
2, // KT2_DEFAULT_SETPOINT
1, // KT2_DEVIAZIONE_SETPOINT
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
1, // KT2_V_SETPOINT_REMOTO

        };
    }
}
