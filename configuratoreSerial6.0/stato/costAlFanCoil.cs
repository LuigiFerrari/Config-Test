﻿using System;
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
        public const int FCS_MATRICOLA_00 = 0;
        public const int FCS_MATRICOLA_02 = 1;
        public const int FCS_MATRICOLA_04 = 2;
        public const int FCS_MATRICOLA_06 = 3;
        public const int FCS_MATRICOLA_08 = 4;
        public const int FCS_MATRICOLA_10 = 5;
        public const int FCS_MATRICOLA_12 = 6;
        public const int FCS_MATRICOLA_14 = 7;
        public const int FCS_MATRICOLA_16 = 8;
        public const int FCS_MATRICOLA_18 = 9;
        public const int FCS_VERSIONE_00 = 10;
        public const int FCS_VERSIONE_01 = 11;
        public const int FCS_VERSIONE_02 = 12;
        public const int FCS_VERSIONE_03 = 13;
        public const int FCS_VERSIONE_04 = 14;
        public const int FCS_VERSIONE_05 = 15;
        public const int FCS_INDIRIZZO_SLAVE = 16;
        public const int FCS_MASTER_SLAVE = 17;
        public const int FCS_DISP_PRIMARIO = 18;
        // ----------------
        public const int FCS_SONDA_REGOLAZIONE = 19;
        public const int FCS_TEMP_SONDA = 20;
        public const int FCS_SETPOINT_TEMP = 21;
        public const int FCS_TEMPERATURA_RIPRESA = 22;
        public const int FCS_TEMPERATURA_MANDATA = 23;
        public const int FCS_PRESSIONE_DIFFER = 24;
        public const int FCS_CO2 = 25;
        public const int FCS_VOC = 26;
        public const int FCS_DISCRETE_SETPOINT = 27;
        public const int FCS_TEMP_TERMOSTATO = 28;
        // ----------------
        public const int FCS_PERC_VENTILATORE = 29;
        public const int FCS_VOLT_VENTILATORE = 30;
        public const int FCS_VELOCITA_VENTILATORE = 31;
        public const int FCS_VALVOLA_FREDDA_PWM = 32;
        public const int FCS_VALVOLA_FREDDA_DCMAX = 33;
        public const int FCS_VALVOLA_FREDDA_MOD = 34;
        public const int FCS_VALVOLA_FREDDA_MODMAX = 35;
        public const int FCS_PERC_RES_ELETTRICA = 36;
        public const int FCS_DC_MASSIMO_IST_RES = 37;
        public const int FCS_VALVOLA_CALDA_PWM = 38;
        public const int FCS_VALVOLA_CALDA_DCMAX = 39;
        public const int FCS_VALVOLA_CALDA_MOD = 40;
        public const int FCS_VALVOLA_CALDA_MODMAX = 41;
        public const int FCS_VALVOLA_CHOVER = 42;
        public const int FCS_RID_RAFFREDDAMENTO = 43;
        public const int FCS_RIS_RISACALDAMENTO = 44;
        public const int FCS_SERRANDA_PERC = 45;
        public const int FCS_SERRANDA_VOLT = 46;
        public const int FCS_VENTILATORE_ONOFF = 47;
        public const int FCS_RISCALDAMENTO = 48;
        public const int FCS_RAFFREDDAMENTO = 49;
        // ----------------
        public const int FCS_SPENTO_BMS = 50;
        public const int FCS_SPENTO_DA_TASTO = 51;
        public const int FCS_SPENTO_TERMOSTATO = 52;
        public const int FCS_SPENTO_D1 = 53;
        public const int FCS_SPENTO_ECONOMY = 54;
        public const int FCS_FANCOIL_OFF = 55;
        public const int FCS_MOD_ECONOMY_MODBUS_DI1 = 56;
        public const int FCS_MOD_ECONOMY_MODBUS_DI2 = 57;
        public const int FCS_MOD_ECONOMY_MODBUS_DI3 = 58;
        public const int FCS_MOD_ECONOMY_DI1 = 59;
        public const int FCS_MOD_ECONOMY_DI2 = 60;
        public const int FCS_MOD_ECONOMY_DI3 = 61;
        public const int FCS_ECONOMY_TYPE = 62;
        public const int FCS_MOD_ECONOMY_RETE = 63;
        public const int FCS_MOD_ECONOMY_BMS_EN_SAVING = 64;
        public const int FCS_LIMITE_TEMP_MAND_RIS_RAFF = 65;
        public const int FCS_LIMITE_TEMP_SCHEDA = 66;
        public const int FCS_QUICK_COOLING = 67;
        public const int FCS_CONTATORE_FILTRO = 68;
        public const int FCS_TEMP_MODBUS = 69;
        public const int FCS_ERR_TEMP_MODBUS = 70;
        public const int FCS_GLB_ECONOMY_MODE = 71;
        // ----------------
        public const int FCS_AL_SONDA_REGOLAZIONE = 72;
        public const int FCS_AL_SONDA_TEMP_RIPRESA = 73;
        public const int FCS_AL_SONDA_TEMP_MANDATA = 74;
        public const int FCS_AL_TEMP_SICUREZZA = 75;
        public const int FCS_AL_INTERVENTO_TERM_SICUREZZA = 76;
        public const int FCS_AL_TEMP_MANDATA_CALDO = 77;
        public const int FCS_AL_TEMP_MANDATA_FREDDO = 78;
        public const int FCS_AL_TER_STANZA_NON_COLL = 79;
        public const int FCS_AL_SONDA_TEMP_STANZA = 80;
        public const int FCS_AL_CIRC_RES_APERTO = 81;
        public const int FCS_AL_CIRC_INNESCO_RES = 82;
        public const int FCS_AL_GEN_FANCOIL = 83;
        public const int FCS_AL_INCENDIO_GENERALE = 84;
        public const int FCS_AL_CUMULATIVO = 85;
        public const int FCS_AL_VENTILATORE = 86;
        public const int FCS_AL_SERRANDA = 87;
        public const int FCS_AL_SENSORE_PRESS = 88;
        public const int FCS_AL_PRESS_BASSA = 89;
        public const int FCS_AL_PRESS_ALTA = 90;
        public const int FCS_AL_0_10_VALVOLA = 91;
        public const int FCS_AL_FILTRO_SPORCO = 92;
        public const int FCS_AL_AI1 = 93;
        // ----------------
        public const int FCS_TEMP_SCHEDA = 94;
        public const int FCS_FREQ_RETE = 95;
        public const int FCS_V24VOLT = 96;
        public const int FCS_RIDUZIONE_TEMP = 97;
        public const int FCS_V_RETE = 98;
        public const int FCS_PLC_NUMBERS = 99;
        // ----------------
        public const int FCS_VELOCITA_FAN_MAN = 100;
        public const int FCS_AUTO_MAN_FAN = 101;
        public const int FCS_MOD_TERMOSTATICO_DI5 = 102;
        public const int FCS_FORZATURA_ONOFF_SETPOINT = 103;
        public const int FCS_FORZATURA_VALORE_SETPOINT = 104;
        public const int FCS_DI1_ENABLE_ON_OFF = 105;
        public const int FCS_DI2_ENABLE_ON_OFF = 106;
        public const int FCS_DI3_ENABLE_ON_OFF = 107;
        public const int FCS_RESET_CONTATORE_GIORNI = 108;
        public const int FCS_FORZ_MODBUS_SETPOINT = 109;
        public const int FCS_COOLING_CMD = 110;
        public const int FCS_HEATING_CMD = 111;
        public const int FCS_DAY_OF_OPERATION = 112;
        public const int FCS_RESET_SETPOINT = 113;
        public const int FCS_ECONOMY_TYPE_BMS = 114;
        public const int FCS_TIPO_SENS_PRESSIONE = 115;
        public const int FCS_MOD_ECONOMY_MODBUS_DI5 = 116;










        public const int FCS_NUMERO_STATI = (FCS_MOD_ECONOMY_MODBUS_DI5 + 1);

        static statoDevice[] parAlarm;
        static public void init()
        {
            parAlarm = new statoDevice[]
            {
new statoDevice() { decimali = 0 ,size =MAX_SIZE_STRING, tipo='S',iValore=0,sValore=""},//           0 FCS_MATRICOLA_00
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           1 FCS_MATRICOLA_02
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           2 FCS_MATRICOLA_04
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           3 FCS_MATRICOLA_06
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           4 FCS_MATRICOLA_08
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           5 FCS_MATRICOLA_10
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           6 FCS_MATRICOLA_12
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           7 FCS_MATRICOLA_14
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           8 FCS_MATRICOLA_16
new statoDevice() { decimali = 0 ,size =2, tipo='S',iValore=0,sValore=""},//           9 FCS_MATRICOLA_18
new statoDevice() { decimali = 0 ,size =MAX_SIZE_VERSIONE, tipo='V',iValore=0,sValore=""},//          10 FCS_VERSIONE_00
new statoDevice() { decimali = 0 ,size =2, tipo='V',iValore=0,sValore=""},//          11 FCS_VERSIONE_01
new statoDevice() { decimali = 0 ,size =2, tipo='V',iValore=0,sValore=""},//          12 FCS_VERSIONE_02
new statoDevice() { decimali = 0 ,size =2, tipo='V',iValore=0,sValore=""},//          13 FCS_VERSIONE_03
new statoDevice() { decimali = 0 ,size =2, tipo='V',iValore=0,sValore=""},//          14 FCS_VERSIONE_04
new statoDevice() { decimali = 0 ,size =2, tipo='V',iValore=0,sValore=""},//          15 FCS_VERSIONE_05
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          16 FCS_INDIRIZZO_SLAVE          
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          17 FCS_MASTER_SLAVE
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=-1,sValore=""},//          18 FCS_DISP_PRIMARIO
// ----------------
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          19 FCS_SONDA_REGOLAZIONE
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=0,sValore=""},//          20 FCS_TEMP_SONDA
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=0,sValore=""},//          21 FCS_SETPOINT_TEMP
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=0,sValore=""},//          22 FCS_TEMPERATURA_RIPRESA
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=0,sValore=""},//          23 FCS_TEMPERATURA_MANDATA
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=0,sValore=""},//          24 FCS_PRESSIONE_DIFFER
new statoDevice() { decimali = 1 ,size =3, tipo='N',iValore=0,sValore=""},//          25 FCS_CO2
new statoDevice() { decimali = 1 ,size =3, tipo='N',iValore=0,sValore=""},//          26 FCS_VOC
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=5,sValore=""},//          27 FCS_DISCRETE_SETPOINT
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=0,sValore=""},//          28 FCS_TEMP_TERMOSTATO
// ----------------
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          29 FCS_PERC_VENTILATORE
new statoDevice() { decimali = 1 ,size =1, tipo='N',iValore=0,sValore=""},//          30 FCS_VOLT_VENTILATORE
new statoDevice() { decimali = 0 ,size =2, tipo='N',iValore=0,sValore=""},//          31 FCS_VELOCITA_VENTILATORE
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          32 FCS_VALVOLA_FREDDA_PWM
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          33 FCS_VALVOLA_FREDDA_DCMAX
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          34 FCS_VALVOLA_FREDDA_MOD
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          35 FCS_VALVOLA_FREDDA_MODMAX
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          36 FCS_PERC_RES_ELETTRICA
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          37 FCS_DC_MASSIMO_IST_RES
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          38 FCS_VALVOLA_CALDA_PWM
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          39 FCS_VALVOLA_CALDA_DCMAX
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          40 FCS_VALVOLA_CALDA_MOD
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          41 FCS_VALVOLA_CALDA_MODMAX
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          42 FCS_VALVOLA_CHOVER
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          43 FCS_RID_RAFFREDDAMENTO
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          44 FCS_RIS_RISACALDAMENTO
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          45 FCS_SERRANDA_PERC
new statoDevice() { decimali = 1 ,size =1, tipo='N',iValore=0,sValore=""},//          46 FCS_SERRANDA_VOLT
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          47 FCS_VENTILATORE_ONOFF
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          48 FCS_RISCALDAMENTO
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          49 FCS_RAFFREDDAMENTO
// ----------------
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          50 FCS_SPENTO_BMS
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          51 FCS_SPENTO_DA_TASTO
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          52 FCS_SPENTO_TERMOSTATO
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          53 FCS_SPENTO_D1
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          54 FCS_SPENTO_ECONOMY
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          55 FCS_FANCOIL_OFF
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          56 FCS_MOD_ECONOMY_MODBUS_DI1
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          57 FCS_MOD_ECONOMY_MODBUS_DI2
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          58 FCS_MOD_ECONOMY_MODBUS_DI3
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          59 FCS_MOD_ECONOMY_DI1
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          60 FCS_MOD_ECONOMY_DI2
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          61 FCS_MOD_ECONOMY_DI3
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          62 FCS_ECONOMY_TYPE
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          63 FCS_MOD_ECONOMY_RETE
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          64 FCS_MOD_ECONOMY_BMS_EN_SAVING
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          65 FCS_LIMITE_TEMP_MAND_RIS_RAFF
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          66 FCS_LIMITE_TEMP_SCHEDA
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          67 FCS_QUICK_COOLING
new statoDevice() { decimali = 0 ,size =2, tipo='N',iValore=0,sValore=""},//          68 FCS_CONTATORE_FILTRO
new statoDevice() { decimali = 1 ,size =3, tipo='N',iValore=0,sValore=""},//          69 FCS_TEMP_MODBUS
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          70 FCS_ERR_TEMP_MODBUS
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          71 FCS_GLB_ECONOMY_MODE
// ----------------
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          72 FCS_AL_SONDA_REGOLAZIONE
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          73 FCS_AL_SONDA_TEMP_RIPRESA
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          74 FCS_AL_SONDA_TEMP_MANDATA
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          75 FCS_AL_TEMP_SICUREZZA
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          76 FCS_AL_INTERVENTO_TERM_SICUREZZA
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          77 FCS_AL_TEMP_MANDATA_CALDO
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          78 FCS_AL_TEMP_MANDATA_FREDDO
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          79 FCS_AL_TER_STANZA_NON_COLL
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          80 FCS_AL_SONDA_TEMP_STANZA
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          81 FCS_AL_CIRC_RES_APERTO
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          82 FCS_AL_CIRC_INNESCO_RES
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          83 FCS_AL_GEN_FANCOIL
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          84 FCS_AL_INCENDIO_GENERALE
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          85 FCS_AL_CUMULATIVO
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          86 FCS_AL_VENTILATORE
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          87 FCS_AL_SERRANDA
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          88 FCS_AL_SENSORE_PRESS
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          89 FCS_AL_PRESS_BASSA
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          90 FCS_AL_PRESS_ALTA
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          91 FCS_AL_0_10_VALVOLA
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          92 FCS_AL_FILTRO_SPORCO
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          93 FCS_AL_AI1
// ----------------
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=0,sValore=""},//          94 FCS_TEMP_SCHEDA
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          95 FCS_FREQ_RETE
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=0,sValore=""},//          96 FCS_V24VOLT
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          97 FCS_RIDUZIONE_TEMP
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          98 FCS_V_RETE
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          99 FCS_PLC_NUMBERS
// ----------------
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          100 FCS_VELOCITA_FAN_MAN
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          101 FCS_AUTO_MAN_FAN
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          102 FCS_MOD_TERMOSTATICO_DI5
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          103 FCS_FORZATURA_ONOFF_SETPOINT
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=200,sValore=""},//          104 FCS_FORZATURA_VALORE_SETPOINT
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          105 FCS_DI1_ENABLE_ON_OFF
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          106 FCS_DI2_ENABLE_ON_OFF
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          107 FCS_DI3_ENABLE_ON_OFF
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          108 FCS_RESET_CONTATORE_GIORNI
new statoDevice() { decimali = 1 ,size =2, tipo='N',iValore=0,sValore=""},//          109 FCS_FORZ_MODBUS_SETPOINT
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          110 FCS_COOLING_CMD
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          111 FCS_HEATING_CMD
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=1,sValore=""},//          112 FCS_DAY_OF_OPERATION
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          113 FCS_RESET_SETPOINT
new statoDevice() { decimali = 0 ,size =1, tipo='N',iValore=0,sValore=""},//          114 FCS_ECONOMY_TYPE_BMS
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          115 FCS_TIPO_SENS_PRESSIONE
new statoDevice() { decimali = 0 ,size =1, tipo='B',iValore=0,sValore=""},//          116 FCS_MOD_ECONOMY_MODBUS_DI5




 


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
