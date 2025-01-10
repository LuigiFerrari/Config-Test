using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace configuratoreSerial6._0
{
    internal class parametriFanCoil
    {
        public const int KF_DI1_TYPE = 0;
        public const int KF_DI1_ONOFF = 1;
        public const int KF_DI2_ONOFF = 2;
        public const int KF_DI3_ONOFF = 3;
        public const int KF_DI4_ONOFF = 4;
        public const int KF_DI5_ONOFF = 5;
        public const int KF_NTC1_ONOFF = 6;
        public const int KF_AI1_TYPE = 7;
        public const int KF_AI1_ONOFF = 8;
        public const int KF_AI2_TYPE = 9;
        public const int KF_AI2_ONOFF = 10;
        public const int KF_LOGIC_DI1_NANC = 11;
        public const int KF_LOGIC_DI2_NANC = 12;
        public const int KF_LOGIC_DI3_NANC = 13;
        public const int KF_LOGIC_DI5_NANC = 14;
        public const int KF_NTC2_ONOFF = 15;
        // -----------------------------
        public const int KF_ATTIVAZIONE_DI1 = 16;
        public const int KF_DISATTIVAZIONE_DI1 = 17;
        public const int KF_ATTIVAZIONE_DI2 = 18;
        public const int KF_DISATTIVAZIONE_DI2 = 19;
        public const int KF_ATTIVAZIONE_DI3 = 20;
        public const int KF_DISATTIVAZIONE_DI3 = 21;
        // -----------------------------
        public const int KF_CFG_USCITE = 22;
        public const int KF_AO2_ON_OFF = 23;
        public const int KF_TR2_ON_OFF = 24;
        public const int KF_TR1_ON_OFF = 25;
        // -----------------------------
        public const int KF_ABILITAZIONE_SEG_FILTRO = 26;
        public const int KF_TEMPO_SEG_FILTRO = 27;
        public const int KF_BTN_RESET = 28;
        // -----------------------------
        public const int KF_ZM_RISCALDAMENTO_HDZ = 29;
        public const int KF_BR_RISCALDAMENTO_HB = 30;
        public const int KF_KI_RISCALDAMENTO = 31;
        public const int KF_PERIODO_MODULAZIONE = 32;
        public const int KF_MINIMO_DCYCLE = 33;
        public const int KF_MASSIMO_DCYCLE = 34;
        public const int KF_ALLARME_RESISTENZA = 35;
        // -----------------------------
        public const int KF_ZM_RAFFREDDAMENTO_CDZ = 36;
        public const int KF_BR_VALV_RAFFREDDAMENTO_CB = 37;
        public const int KF_KI_VALVOLA = 38;
        public const int KF_ISTERESI_VALVOLA = 39;
        public const int KF_PERIODO_MOD_VALVOLA = 40;
        public const int KF_MINIMO_DC_VALVOLA = 41;
        public const int KF_MASSIMO_DC_VALVOLA = 42;
        public const int KF_DURATA_RAFF_RAPIDO = 43;
        public const int KF_POT_RAFF_RAPIDO = 44;
        // -----------------------------
        public const int KF_MOD_VEN_MINIMA_ZM_ONOFF = 45;
        public const int KF_ABILITAZ_VENT_MANUALE_ONOFF = 46;
        public const int KF_TEMPO_POST_VENTILAZIONE = 47;
        public const int KF_TENSIONE_VENT_AT_ZERO = 48;
        public const int KF_TENSIONE_VENT_AT_CENTO = 49;
        public const int KF_TENSIONE_MINIMA_ATTIVAZ = 50;
        public const int KF_GIRI_MINIMI_VENTOLA = 51;
        public const int KF_BANDA_REG_VENT_RISC_FHB = 52;
        public const int KF_BANDA_REG_VENT_RAFF_FCB = 53;
        public const int KF_KI_REGOLAZ_VENT = 54;
        public const int KF_AZIONE_OFF = 55;
        // -----------------------------
        public const int KF_ISTERESI_VALV_CHOV = 56;
        public const int KF_LOGICA_VALVOLA = 57;
        public const int KF_TEMPO_RITARDO_ATTIV_USCITE = 58;
        // -----------------------------
        public const int KF_MODALITA_GESTIONE_SERRANDA = 59;
        public const int KF_SETPOINT_CO2 = 60;
        public const int KF_BANDA_REG_CO2 = 61;
        public const int KF_SETPOINT_VOC = 62;
        public const int KF_BANDA_REGOLAZIONE_VOC = 63;
        public const int KF_APERTURA_MINIMA_SERRANDA = 64;
        public const int KF_APERTURA_MASSIMA_SERRANDA = 65;
        public const int KF_TENSIONE_ALLA_PORTATA_MINIMA = 66;
        public const int KF_TENSIONE_ALLA_PORTATA_MASSIMA = 67;
        public const int KF_PORTATA_MINIMA = 68;
        public const int KF_PORTATA_MASSIMA = 69;
        public const int KF_SETPOINT_PORTATA_CONFORT = 70;
        public const int KF_SETPOINT_PORTATA_ECONOMY = 71;
        // -----------------------------
        public const int KF_TIPO_SONDA_REGOLAZ = 72;
        public const int KF_SETPOINT_TEMP_DEFAULT = 73;
        public const int KF_DEVIAZ_MAX_SETPOINT = 74;
        // -----------------------------
        public const int KF_TIPO_ECONOMY_DI1 = 75;
        public const int KF_TIPO_ECONOMY_DI2 = 76;
        public const int KF_TIPO_ECONOMY_DI3 = 77;
        public const int KF_PRIORITA_ECONOMY = 78;
        public const int KF_INCR_ZM_RISC_TIPO1 = 79;
        public const int KF_INCR_ZM_RAFF_TIPO1 = 80;
        public const int KF_INCR_ZM_RISC_TIPO2 = 81;
        public const int KF_INCR_ZM_RAFF_TIPO2 = 82;
        // -----------------------------
        public const int KF_SOGLIA_INTASAMENTO_FILTRO = 83;
        public const int KF_ISTERESI_SOGLIA_INTASAMENTO = 84;
        public const int KF_SOGLIA_ALTA_PRESSIONE = 85;
        public const int KF_ISTERESI_SOGLIA_ALTA_PRESSIONE = 86;
        public const int KF_SOGLIA_BASSA_PRESSIONE = 87;
        public const int KF_ISTERESI_SOGLIA_BASSA_PRESSIONE = 88;
        public const int KF_RITARDO_ALLARME_BASSA_PRESSIONE = 89;
        // -----------------------------
        public const int KF_RANGE_TENSIONE = 90;
        public const int KF_RANGE_PRESSIONE = 91;
        public const int KF_SOGLIA_ALLARME = 92;
        // -----------------------------
        public const int KF_SOGLIA_TEMP_SICUREZZA = 93;
        public const int KF_ISTERESI_TEMP_SICUREZZA = 94;
        // -----------------------------
        public const int KF_SETPOINT_LIMITE_MINIMO_LLSP = 95;
        public const int KF_ISTERESI_LIMITE_MINIMO_CLHY = 96;
        public const int KF_SETPOINT_LIMITE_MASSIMO_HLSP = 97;
        public const int KF_BANDA_DI_REGOLAZIONE_LB = 98;
        // -----------------------------
        public const int KF_ABILITAZIONE_RAMPA_ONOFF = 99;
        public const int KF_TEMPO_RAMPA = 100;
        // -----------------------------
        public const int KF_INCR_ZM_RISC_TIPO1_MBUS = 101;
        public const int KF_INCR_ZM_RAFF_TIPO1_MBUS = 102;
        public const int KF_INCR_ZM_RISC_TIPO2_MBUS = 103;
        public const int KF_INCR_ZM_RAFF_TIPO2_MBUS = 104;
        public const int KF_ECONOMY_TYPE_MBUS = 105;
        // -----------------------------
        public const int KF_TIPO_DISPOSITIVO_MS = 106;
        public const int KF_INDIRIZZO = 107;
        public const int KF_BAUDRATE = 108;
        public const int KF_PARITA = 109;
        public const int KF_BITSTOP = 110;
        // -----------------------------
        public const int KF_INDIRIZZO_SLAVE = 111;
        // -----------------------------
        public const int KF_KV_FORZATURA_SETPOINT_ONOFF = 112;
        public const int KF_KV_VALORE_FORZATURA_SETPOINT = 113;
        public const int KF_MBUS_FORZATURA_VENTILATORE = 114;
        public const int KF_MBUS_FORZATURA_RISCALDAMENTO = 115;
        public const int KF_MBUS_FORZATURA_RAFFREDDAMENTO = 116;
        public const int KF_MBUS_FORZATURA_SERRANDA = 117;



        public const int NUMERO_PARAMETRI_KF = (KF_MBUS_FORZATURA_SERRANDA + 1);

    }
}
