using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace configuratore
{
	internal static class parametriCassetta
	{

        // GB0_FUNZIONAMENTO_CASSETTA, Funzionamento cassetta
        public const int KK_FUNZIONAMENTO = 0;
        // GB1_FUNZIONAMENTO_CASSETTA, Regolazione riscaldamento
        public const int KK_ZONA_MORTA_RISC_HDZ = 1;
        public const int KK_BANDA_REGOLAZIONE_RISC_HB = 2;
        public const int KK_KI_REGOLAZIONE_RISCALDAMENTO = 3;
        public const int KK_PERIODO_MODULAZIONE_PWM = 4;
        public const int KK_MINIMO_DC_RESISTENZA = 5;
        public const int KK_MASSIMO_DC_RESISTENZA = 6;
        public const int KK_POTENZA_NOMINALE_RESISTENZA = 7;
        public const int KK_PRESENZA_RESISTENZA = 8;
        // GB2_MAX_POT_RES, Max potenza resistenza in funzione della portata
        public const int KK_LIM_POT_MAX = 9;
        public const int KK_TEMP_ARIA_PRIM = 10;
        // GB3_IMP_REG_AMP, Impostazione regolazione ambiente
        public const int KK_SETPOINT_DEFAULT = 11;
        public const int KK_DEV_MAX_SETPOINT = 12;
        public const int KK_INCR_ZONA_MORTA_DZI = 13;
        // GB4_REGOLAZIONTEMP_INTERNA, Regolazione temperatura interna
        public const int KK_PRIMA_SOGLIA = 14;
        public const int KK_IST_PRIMA_SOGLIA = 15;
        public const int KK_SEC_SOGLIA = 16;
        public const int KK_IST_SECONDA_SOGLIA = 17;
        // GB5_GEOMETRIA_CASSETTA, Geometria cassetta
        public const int KK_DIFFUSIONE = 18;
        // GB6_LIMITE_TEMP_MANDATA, Limiti temperatura mandata
        public const int KK_SETPOINT_LIM_MAX_HLSP = 19;
        public const int KK_BANDA_REGOLAZIONE_LB = 20;
        // GB7_REGOLAZIONESERRANDA, Recolazione serranda
        public const int KK_ZONA_MORTA_SERRANDA_DDZ = 21;
        public const int KK_BANDA_DI_REG_SERRANDA_DB = 22;
        public const int KK_KI_REGOLAZIONE_SERRANDA = 23;
        public const int KK_APERT_SERRANDA_MIN = 24;
        public const int KK_APERT_SERRANDA_MAX = 25;
        public const int KK_TENSIONE_SERRANDA_MIN = 26;
        public const int KK_TENSIONE_SERRANDA_MAX = 27;
        public const int KK_LOGOCA_DIR = 28;
        public const int KK_PRESENZA_SERRANDA = 29;
        // GB8_GEST_MOD_ECONOMY
        public const int KK_TIPO_ECONOMY = 30;
        public const int KK_TASTO_ECONOMY_RID = 31;
        // GB9_GESTIONE_PORTATA, Gestione portata
        public const int KK_ABILITA_VIS_PORT_IST = 32;
        public const int KK_PORT_MIN = 33;
        public const int KK_PORT_MAX = 34;
        public const int KK_PORT_MIN_SICUREZZA = 35;
        public const int KK_SEZIONE = 36;
        public const int KK_OFFSET_MIS_PORTATA = 37;
        public const int KK_TEMP_LETT_SENSORE = 38;
        public const int KK_K_APERT_SERR_0_10 = 39;
        public const int KK_K_APERT_SERR_10_20 = 40;
        public const int KK_K_APERT_SERR_20_30 = 41;
        public const int KK_K_APERT_SERR_30_40 = 42;
        public const int KK_K_APERT_SERR_40_50 = 43;
        public const int KK_K_APERT_SERR_50_60 = 44;
        public const int KK_K_APERT_SERR_60_70 = 45;
        public const int KK_K_APERT_SERR_70_80 = 46;
        public const int KK_K_APERT_SERR_80_90 = 47;
        public const int KK_K_APERT_SERR_90_100 = 48;
        // GB10_INGRESSI, Ingressi
        public const int KK_ING_DIG_D1 = 49;
        public const int KK_ING_DIG_D2 = 50;
        public const int KK_ING_DIG_D3 = 51;
        public const int KK_ING_DIG_NTC2 = 52;
        public const int KK_ING_DIG_D1_ONOFF = 53;
        public const int KK_ING_DIG_D2_ONOFF = 54;
        public const int KK_ING_DIG_D3_ONOFF = 55;
        public const int KK_ING_DIG_D1_NCNO = 56;
        public const int KK_ING_DIG_D2_NCNO = 57;
        public const int KK_ING_DIG_D3_NCNO = 58;
        // INTEN_LED
        public const int KK_INTENSITA_LED = 59;
        // TIPOLOGUA
        public const int KK_TIPO_CASSETTA = 60;
        // -------------
        public const int KK_TIPO_DISPOSITIVO_MS = 61;
        public const int KK_INDIRIZZO = 62;
        public const int KK_BAUDRATE = 63;
        public const int KK_PARITA = 64;
        public const int KK_BITSTOP = 65;
        // INDIRIZZO ORIZ.
        public const int KK_INDIRIZZO_SLAVE = 66;
        // FORZATURE
        public const int KK_KV_APERTURA_SERRANDA_PERC = 67;
        public const int KK_KV_APERTURA_SERRANDA_ONOFF = 68;
        public const int KK_KV_TRESISTENZA_PERC = 69;
        public const int KK_KV_TRESISTENZA_ONOFF = 70;
        public const int KK_KV_MAX_FREDDO_ONOFF = 71;







        public const int NUMERO_PARAMETRI_KK = (KK_INDIRIZZO_SLAVE + 1); //66











#if false



        public const int KK_FUNZIONAMENTO = 0; // 0
        public const int KK_ZONA_MORTA_RISC_HDZ = KK_FUNZIONAMENTO + 1; // 1
        public const int KK_BANDA_REGOLAZIONE_RISC_HB = KK_ZONA_MORTA_RISC_HDZ + 1; // 2
        public const int KK_KI_REGOLAZIONE_RISCALDAMENTO = KK_BANDA_REGOLAZIONE_RISC_HB + 1; // 3
        public const int KK_PERIODO_MODULAZIONE_PWM = KK_KI_REGOLAZIONE_RISCALDAMENTO + 1; // 4
        public const int KK_MINIMO_DC_RESISTENZA = KK_PERIODO_MODULAZIONE_PWM + 1; // 5
        public const int KK_MASSIMO_DC_RESISTENZA = KK_MINIMO_DC_RESISTENZA + 1; // 6
        public const int KK_POTENZA_NOMINALE_RESISTENZA = KK_MASSIMO_DC_RESISTENZA + 1; // 7
        public const int KK_PRESENZA_RESISTENZA = KK_POTENZA_NOMINALE_RESISTENZA + 1; // 8
        public const int KK_LIM_POT_MAX = KK_PRESENZA_RESISTENZA + 1; // 9
        public const int KK_TEMP_ARIA_PRIM = KK_LIM_POT_MAX + 1; // 10
        public const int KK_SETPOINT_DEFAULT = KK_TEMP_ARIA_PRIM + 1; // 11
        public const int KK_DEV_MAX_SETPOINT = KK_SETPOINT_DEFAULT + 1; // 12
        public const int KK_INCR_ZONA_MORTA_DZI = KK_DEV_MAX_SETPOINT + 1; // 13
        public const int KK_PRIMA_SOGLIA = KK_INCR_ZONA_MORTA_DZI + 1; // 14
        public const int KK_IST_PRIMA_SOGLIA = KK_PRIMA_SOGLIA + 1; // 15
        public const int KK_SEC_SOGLIA = KK_IST_PRIMA_SOGLIA + 1; // 16
        public const int KK_IST_SECONDA_SOGLIA = KK_SEC_SOGLIA + 1; // 17
        public const int KK_DIFFUSIONE = KK_IST_SECONDA_SOGLIA + 1; // 18
        public const int KK_SETPOINT_LIM_MAX_HLSP = KK_DIFFUSIONE + 1; // 19
        public const int KK_BANDA_REGOLAZIONE_LB = KK_SETPOINT_LIM_MAX_HLSP + 1; // 20
        public const int KK_ZONA_MORTA_SERRANDA_DDZ = KK_BANDA_REGOLAZIONE_LB + 1; // 21
        public const int KK_BANDA_DI_REG_SERRANDA_DB = KK_ZONA_MORTA_SERRANDA_DDZ + 1; // 22
        public const int KK_KI_REGOLAZIONE_SERRANDA = KK_BANDA_DI_REG_SERRANDA_DB + 1; // 23
        public const int KK_APERT_SERRANDA_MIN = KK_KI_REGOLAZIONE_SERRANDA + 1; // 24
        public const int KK_APERT_SERRANDA_MAX = KK_APERT_SERRANDA_MIN + 1; // 25
        public const int KK_TENSIONE_SERRANDA_MIN = KK_APERT_SERRANDA_MAX + 1; // 26
        public const int KK_TENSIONE_SERRANDA_MAX = KK_TENSIONE_SERRANDA_MIN + 1; // 27
        public const int KK_PRESENZA_SERRANDA = KK_TENSIONE_SERRANDA_MAX + 1; // 28
        public const int KK_TIPO_ECONOMY = KK_PRESENZA_SERRANDA + 1; // 29
        public const int KK_TASTO_ECONOMY_RID = KK_TIPO_ECONOMY + 1; // 30
        public const int KK_ABILITA_VIS_PORT_IST = KK_TASTO_ECONOMY_RID + 1; // 31
        public const int KK_PORT_MIN = KK_ABILITA_VIS_PORT_IST + 1; // 32
        public const int KK_PORT_MAX = KK_PORT_MIN + 1; // 33
        public const int KK_PORT_MIN_SICUREZZA = KK_PORT_MAX + 1; // 34
        public const int KK_SEZIONE = KK_PORT_MIN_SICUREZZA + 1; // 35
        public const int KK_OFFSET_MIS_PORTATA = KK_SEZIONE + 1; // 36
        public const int KK_TEMP_LETT_SENSORE = KK_OFFSET_MIS_PORTATA + 1; // 37
        public const int KK_K_APERT_SERR_0_10 = KK_TEMP_LETT_SENSORE + 1; // 38
        public const int KK_K_APERT_SERR_10_20 = KK_K_APERT_SERR_0_10 + 1; // 39
        public const int KK_K_APERT_SERR_20_30 = KK_K_APERT_SERR_10_20 + 1; // 40
        public const int KK_K_APERT_SERR_30_40 = KK_K_APERT_SERR_20_30 + 1; // 41
        public const int KK_K_APERT_SERR_40_50 = KK_K_APERT_SERR_30_40 + 1; // 42
        public const int KK_K_APERT_SERR_50_60 = KK_K_APERT_SERR_40_50 + 1; // 43
        public const int KK_K_APERT_SERR_60_70 = KK_K_APERT_SERR_50_60 + 1; // 44
        public const int KK_K_APERT_SERR_70_80 = KK_K_APERT_SERR_60_70 + 1; // 45
        public const int KK_K_APERT_SERR_80_90 = KK_K_APERT_SERR_70_80 + 1; // 46
        public const int KK_K_APERT_SERR_90_100 = KK_K_APERT_SERR_80_90 + 1; // 47
        public const int KK_ING_DIG_D1 = KK_K_APERT_SERR_90_100 + 1; // 48
        public const int KK_ING_DIG_D2 = KK_ING_DIG_D1 + 1; // 49
        public const int KK_ING_DIG_D3 = KK_ING_DIG_D2 + 1; // 50
        public const int KK_ING_DIG_NTC2 = KK_ING_DIG_D3 + 1; // 51
        public const int KK_ING_DIG_D1_ONOFF = KK_ING_DIG_NTC2 + 1; // 52
        public const int KK_ING_DIG_D2_ONOFF = KK_ING_DIG_D1_ONOFF + 1; // 53
        public const int KK_ING_DIG_D3_ONOFF = KK_ING_DIG_D2_ONOFF + 1; // 54
        public const int KK_ING_DIG_D1_NCNO = KK_ING_DIG_D3_ONOFF + 1; // 55
        public const int KK_ING_DIG_D2_NCNO = KK_ING_DIG_D1_NCNO + 1; // 56
        public const int KK_ING_DIG_D3_NCNO = KK_ING_DIG_D2_NCNO + 1; // 57
        public const int KK_LOGOCA_DIR = KK_ING_DIG_D3_NCNO + 1; // 58
        public const int KK_INTENSITA_LED = KK_LOGOCA_DIR + 1; // 59


        public const int KK_TIPO_DISPOSITIVO_MS = KK_INTENSITA_LED + 1;  // 60
        public const int KK_INDIRIZZO = KK_TIPO_DISPOSITIVO_MS + 1;       // 61
        public const int KK_BAUDRATE = KK_INDIRIZZO + 1;        // 62
        public const int KK_PARITA = KK_BAUDRATE + 1;         // 63
        public const int KK_BITSTOP = KK_PARITA + 1;        // 64
        // -----------------------------
        public const int KK_TIPO_CASSETTA = KK_BITSTOP + 1; // 65




        public const int NUMERO_PARAMETRI_KK = (KK_TIPO_CASSETTA + 1); //66

        // parametri 'volatili' (non vengono memorizzati su flash)

        public const int KV_APERTURA_SERRANDA_PERC = (KK_TIPO_CASSETTA + 1);
        public const int KV_APERTURA_SERRANDA_ONOFF = (KV_APERTURA_SERRANDA_PERC + 1);
        public const int KV_TRESISTENZA_PERC = (KV_APERTURA_SERRANDA_ONOFF + 1);
        public const int KV_TRESISTENZA_ONOFF = (KV_TRESISTENZA_PERC + 1);
        public const int KV_MAX_FREDDO_ONOFF = (KV_TRESISTENZA_ONOFF + 1);

#endif
        public const int DAL_BASSO = 0;
        public const int IN_LINEA = 1;




    }
}
