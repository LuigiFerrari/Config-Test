using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace configuratore
{






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


    public class JsonNetlist
    {
        String JSONstr;
        jChangeParameter jsonSetParametri;
        jResetParameter jsonResetParameter;




        public void decodeNET(String xx)
        {
            JSONstr = xx;
            int retValue = 0;
    
            jsonSetParametri = JsonSerializer.Deserialize<jChangeParameter>(JSONstr);
       
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

        public String  getMatricola() { return jsonSetParametri.Matricola;  }
        public int getMasterSlave() { return jsonSetParametri.MasterSlave; }
        public String getVersione() { return jsonSetParametri.Versione; }

        public int getIndirizzoMaster() { return jsonSetParametri.IndirizzoMaster ; }

        public int getDispositivo() { return jsonSetParametri.Dispositivo; }

    }


}
