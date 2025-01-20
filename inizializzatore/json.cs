using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace configuratore
{


    public class jEnterExitTest
    {
        public String TestString;
        public int TestMode;
    }




    public class jChangeParameter
    {
        public String Matricola  { get; set; }
        public int MasterSlave { get; set; }
        public int  IndirizzoMaster { get; set; }
        public String Versione { get; set; }

        public int Dispositivo { get; set; }
        //public int rp { get; set; }
        //public int rmb { get; set; }
        //public int rn { get; set; }
        //public int rma { get; set; }

    }

    public class jResetParameter
    {
        public int ResetParametri { get; set; }
        public int ResetModbus { get; set; }
        public int ResetNetlist { get; set; }
        public int ResetMatricola { get; set; }
    }

    public class jTestParameter
    {
        public int LED0 { get; set; }
        public int LED1 { get; set; }
        public int LED2 { get; set; }
        public int LED3 { get; set; }
        public int LED4 { get; set; }
        public int LED5 { get; set; }
        public int DAC0 { get; set; }
        public int DAC1 { get; set; }
        public int TRIAC1 { get; set; }
        public int TRIAC2 { get; set; }

    }

    public class jTestParameterRx
    {
        public int DI15 { get; set; }
        public int ADC0 { get; set; }
        public int ADC1 { get; set; }

        public int NTC0 { get; set; }
        public int NTC1 { get; set; }

        public int RS_48513 { get; set; }
        public int PRESS { get; set; }

    }

    public class jTestParameterRxTermoAnal
    {
        public int DEVICE { get; set; }
        public int POT { get; set; }
        public int NTC0 { get; set; }
        public int NTC0ERROR { get; set; }

        public int NTC1 { get; set; }
        public int NTC1ERROR { get; set; }

        public int RS_48513 { get; set; }
        public int ONOFF { get; set; }
    }

    public class jTestParameterTxTermoAnal
    {
        public int LEDR { get; set; }
        public int LEDG { get; set; }
        public int LEDB { get; set; }
        public int BEEP { get; set; }
    }


    public class JsonNetlist
    {
        String JSONstr;
        jChangeParameter jsonSetParametri;
        jResetParameter jsonResetParameter;
        jTestParameterRx jsonTestParameterRx;
        jTestParameterRxTermoAnal jsonTestParameterRxTermo;



        public int decodeNET(String xx)
        {
            JSONstr = xx;
            int test = 0;
            int retValue = 0;

            if (xx.Contains("Matricola"))
            {

                jsonSetParametri = JsonSerializer.Deserialize<jChangeParameter>(JSONstr);
            } else
            {
                if(xx.Contains("DI15"))
                {
                    jsonTestParameterRx = JsonSerializer.Deserialize<jTestParameterRx>(JSONstr);
                    test = 1;

                }
                if (xx.Contains("DEVICE"))
                {
                    jsonTestParameterRxTermo = JsonSerializer.Deserialize<jTestParameterRxTermoAnal>(JSONstr);
                    test = 2;
                }


            }
            return test;
       
        }

            public String encodeNET(frmStartUp frm)
        {
            jChangeParameter jsonPar = new jChangeParameter();
            jsonPar.Matricola = frm.getMatricola(); ;
            jsonPar.MasterSlave = frm.getMasterSlave(); 
            jsonPar.IndirizzoMaster = frm.getIndirizzoMaster();
            jsonPar.Versione = "";          // questo dato spedito al target è inifluente
            jsonPar.Dispositivo = 0;         // questo dato spedito al target è inifluente
            //jsonPar.rp = frm.rp;
            //jsonPar.rmb = frm.rmb;
            //jsonPar.rn = frm.rn;
            //jsonPar.rma = frm.rma;
            string json = JsonSerializer.Serialize(jsonPar);
            return json;
        }

        public string encodeJSONresetCommand(frmStartUp frm) {

            jResetParameter jsonPar = new jResetParameter();
            jsonPar.ResetParametri = frm.getResetParametri();
            jsonPar.ResetModbus = frm.getResetModbus();
            jsonPar.ResetNetlist = frm.getResetNetlist ();
            jsonPar.ResetMatricola = frm.getResetMatricola ();

            //jsonPar.rp = frm.rp;
            //jsonPar.rmb = frm.rmb;
            //jsonPar.rn = frm.rn;
            //jsonPar.rma = frm.rma;
            string json = JsonSerializer.Serialize(jsonPar);
            return json;
        }

        public string encodeJSONTestMode(int Mode)
        {
            jEnterExitTest jsonTest = new jEnterExitTest();
            jsonTest.TestString = "TESTMODE";
            jsonTest.TestMode = Mode;
            string json = JsonSerializer.Serialize(jsonTest);
            return json;
        }

        public string encodeTestParameter(frmStartUp frm)
        {
            jTestParameter jTest = new jTestParameter();
            jTest.LED0 = frm.getLED(0);
            jTest.LED1 = frm.getLED(1);
            jTest.LED2 = frm.getLED(2);
            jTest.LED3 = frm.getLED(3);
            jTest.LED4 = frm.getLED(4);
            jTest.LED5 = frm.getLED(5);
            jTest.DAC0 = frm.getDAC(0);
            jTest.DAC1 = frm.getDAC(1);
            jTest.TRIAC1 = frm.getTriac1();
            jTest.TRIAC2 = frm.getTriac2();
            string json = JsonSerializer.Serialize(jTest);
            return json;
        }

        public String encodeTestParameterTermoAnal(frmStartUp frm)
        {
            jTestParameterTxTermoAnal jTest = new jTestParameterTxTermoAnal();
            jTest.LEDR = frm.getLEDR();
            jTest.LEDG = frm.getLEDG();
            jTest.LEDB = frm.getLEDB();
            jTest.BEEP = frm.getBeep();
            string json = JsonSerializer.Serialize(jTest);
            return json;
        }

        public int getD15() {  return jsonTestParameterRx.DI15; }
        public int getADC1() { return jsonTestParameterRx.ADC0; }
        public int getADC2() { return jsonTestParameterRx.ADC1; }
        public int getNTC11() { return jsonTestParameterRx.NTC0; }
        public int getNTC12() { return jsonTestParameterRx.NTC1; }

        public int getRS485() { return jsonTestParameterRx.RS_48513; }
        public int getPRESS() {  return jsonTestParameterRx.PRESS; } 


        public String  getMatricola() { return jsonSetParametri.Matricola;  }
        public int getMasterSlave() { return jsonSetParametri.MasterSlave; }
        public String getVersione() { return jsonSetParametri.Versione; }

        public int getIndirizzoMaster() { return jsonSetParametri.IndirizzoMaster ; }

        public int getDispositivo() { return jsonSetParametri.Dispositivo; }

        public int getPotenzometroAnal() { return jsonTestParameterRxTermo.POT; }
        public int getNTC1anal() { return jsonTestParameterRxTermo.NTC0; }
        public int getNTC1Error() { return jsonTestParameterRxTermo.NTC0ERROR; }
        public int getNTC2anal() { return jsonTestParameterRxTermo.NTC1; }

        public int getNTC2Error() { return jsonTestParameterRxTermo.NTC1ERROR; }

        public int getRS48513anal() { return jsonTestParameterRxTermo.RS_48513; }
        public int getOnOffanal() { return jsonTestParameterRxTermo.ONOFF; }

    }


}
