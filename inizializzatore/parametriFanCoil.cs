using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace configuratore
{
    internal class parametriFanCoil
    {
        public const int KF_DI1_TYPE = 0;
        public const int KF_DI1_ONOFF = 1;
        public const int KF_DI2_ONOFF = 2;
        public const int KF_DI3_ONOFF = 3;
        public const int KF_DI4_ONOFF = 4;
        public const int KF_DI5_ONOFF = 5;
        public const int KF_NTC2_TYPE = 6;
        public const int KF_NTC2_ONOFF = 7;
        public const int KF_AI2_TYPE = 8;
        public const int KF_AI2_ONOFF = 9;
        public const int KF_LOGIC_DI1_NANC = 10;
        public const int KF_LOGIC_DI2_NANC = 11;
        public const int KF_LOGIC_DI3_NANC = 12;
        public const int KF_LOGIC_DI4_NANC = 13;
        // -----------------------------
        public const int KF_ATTIVAZIONE_DI1 = 14;
        public const int KF_DISATTIVAZIONE_DI1 = 15;
        public const int KF_ATTIVAZIONE_DI2 = 16;
        public const int KF_DISATTIVAZIONE_DI2 = 17;
        public const int KF_ATTIVAZIONE_DI3 = 18;
        public const int KF_DISATTIVAZIONE_DI3 = 19;
        // -----------------------------
        public const int KF_CFG_USCITE = 20;
        public const int KF_AO2_ON_OFF = 21;
        public const int KF_TR2_ON_OFF = 22;
        public const int KF_TR1_ON_OFF = 23;
        // -----------------------------
        public const int KF_ABILITAZIONE_SEG_FILTRO = 24;
        public const int KF_TEMPO_SEG_FILTRO = 25;
        public const int KF_BTN_RESET = 26;
        // -----------------------------
        public const int KF_ZM_RISCALDAMENTO_HDZ = 27;
        public const int KF_BR_RISCALDAMENTO_EHB = 28;
        public const int KF_KI_RISCALDAMENTO = 29;
        public const int KF_PERIODO_MODULAZIONE = 30;
        public const int KF_MINIMO_DCYCLE = 31;
        public const int KF_MASSIMO_DCYCLE = 32;
        public const int KF_ALLARME_RESISTENZA = 33;
        // -----------------------------
        public const int KF_ZM_RAFFREDDAMENTO_CDZ = 34;
        public const int KF_BR_VALV_RAFFREDDAMENTO_VCB = 35;
        public const int KF_KI_VALVOLA = 36;
        public const int KF_ISTERESI_VALVOLA = 37;
        public const int KF_PERIODO_MOD_VALVOLA = 38;
        public const int KF_MINIMO_DC_VALVOLA = 39;
        public const int KF_MASSIMO_DC_VALVOLA = 40;
        public const int KF_DURATA_RAFF_RAPIDO = 41;
        public const int KF_POT_RAFF_RAPIDO = 42;
        // -----------------------------
        public const int KF_MOD_VEN_MINIMA_ZM_ONOFF = 43;
        public const int KF_ABILITAZ_VENT_MANUALE_ONOFF = 44;
        public const int KF_TEMPO_POST_VENTILAZIONE = 45;
        public const int KF_TENSIONE_VENT_AT_ZERO = 46;
        public const int KF_TENSIONE_VENT_AT_CENTO = 47;
        public const int KF_TENSIONE_MINIMA_ATTIVAZ = 48;
        public const int KF_GIRI_MINIMI_VENTOLA = 49;
        public const int KF_BANDA_REG_VENT_RISC = 50;
        public const int KF_BANDA_REG_VENT_RAFF = 51;
        public const int KF_KI_REGOLAZ_VENT = 52;
        // -----------------------------
        public const int KF_ISTERESI_VALV_CHOV = 53;
        public const int KF_LOGICA_VALVOLA = 54;
        public const int KF_TEMPO_RITARDO_ATTIV_USCITE = 55;
        // -----------------------------
        public const int KF_MODALITA_GESTIONE_SERRANDA = 56;
        public const int KF_SETPOINT_CO2 = 57;
        public const int KF_BANDA_REG_CO2 = 58;
        public const int KF_SETPOINT_VOC = 59;
        public const int KF_BANDA_REGOLAZIONE_VOC = 60;
        public const int KF_APERTURA_MINIMA_SERRANDA = 61;
        public const int KF_APERTURA_MASSIMA_SERRANDA = 62;
        public const int KF_TENSIONE_ALLA_PORTATA_MINIMA = 63;
        public const int KF_TENSIONE_ALLA_PORTATA_MASSIMA = 64;
        public const int KF_PORTATA_MINIMA = 65;
        public const int KF_PORTATA_MASSIMA = 66;
        public const int KF_SETPOINT_PORTATA_CONFORT = 67;
        public const int KF_SETPOINT_PORTATA_ECONOMY = 68;
        // -----------------------------
        public const int KF_TIPO_SONDA_REGOLAZ = 69;
        public const int KF_SETPOINT_TEMP_DEFAULT = 70;
        public const int KF_DEVIAZ_MAX_SETPOINT = 71;
        // -----------------------------
        public const int KF_TIPO_ECONOMY_DI1 = 72;
        public const int KF_TIPO_ECONOMY_DI2 = 73;
        public const int KF_TIPO_ECONOMY_DI3 = 74;
        public const int KF_PRIORITA_ECONOMY = 75;
        public const int KF_INCR_ZM_RISC_TIPO1 = 76;
        public const int KF_INCR_ZM_RAFF_TIPO1 = 77;
        public const int KF_INCR_ZM_RISC_TIPO2 = 78;
        public const int KF_INCR_ZM_RAFF_TIPO2 = 79;
        // -----------------------------
        public const int KF_SOGLIA_INTASAMENTO_FILTRO = 80;
        public const int KF_ISTERESI_SOGLIA_INTASAMENTO = 81;
        public const int KF_SOGLIA_ALTA_PRESSIONE = 82;
        public const int KF_ISTERESI_SOGLIA_ALTA_PRESSIONE = 83;
        public const int KF_SOGLIA_BASSA_PRESSIONE = 84;
        public const int KF_ISTERESI_SOGLIA_BASSA_PRESSIONE = 85;
        public const int KF_RITARDO_ALLARME_BASSA_PRESSIONE = 86;
        // -----------------------------
        public const int KF_RANGE_TENSIONE = 87;
        public const int KF_RANGE_PRESSIONE = 88;
        public const int KF_SOGLIA_ALLARME = 89;
        // -----------------------------
        public const int KF_SOGLIA_TEMP_SICUREZZA = 90;
        public const int KF_ISTERESI_TEMP_SICUREZZA = 91;
        // -----------------------------
        public const int KF_SETPOINT_LIMITE_MINIMO_LLSP = 92;
        public const int KF_ISTERESI_LIMITE_MINIMO_CLHY = 93;
        public const int KF_SETPOINT_LIMITE_MASSIMO_HLSP = 94;
        public const int KF_BANDA_DI_REGOLAZIONE_LB = 95;
        // -----------------------------
        public const int KF_ABILITAZIONE_RAMPA_ONOFF = 96;
        public const int KF_TEMPO_RAMPA = 97;
        // -----------------------------
        public const int KF_TIPO_DISPOSITIVO_MS = 98;
        public const int KF_INDIRIZZO = 99;
        public const int KF_BAUDRATE = 100;
        public const int KF_PARITA = 101;
        public const int KF_BITSTOP = 102;
        // -----------------------------
        public const int KF_TIPO_FANCOIL = 103;






    }
}
