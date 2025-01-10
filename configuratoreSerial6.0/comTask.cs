using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace configuratoreSerial6._0
{
    internal class comTask
    {
        struct sForzature
        {
            public int valore;
            public int onOff;
        }
        static sForzature[] ForzatureFanCoil = new sForzature[4];
        static sForzature[] OldForzatureFanCoil = new sForzature[4];
        static int[] ForzatureModbus = new int[4];
        static int[] OldForzatureModbus = new int[4];
        static int[] Parametro = new int[4];
        static int richiestoDa;
        static int[] OldParametro = new int[4];


    
        
        public static void InitcomTask()
        {
            for (int i = 0; i < 4; i++)
            {
                Parametro[i] = 0xffff;
                OldParametro[i] = 0xffff;
                OldForzatureModbus[i] = 0xffff;
                ForzatureModbus[i] = 0xffff;
            }
        }

        static public void setRichiestoDa(int rd)
        {
            richiestoDa = rd;
        }

        static public int getRichiestoDa()
        {
            return richiestoDa;
        }

        static public int getParametro(int n)
        {
            int z = -1;
            if ((Parametro[n] & 0xffff) != 0xffff)
            {
                z = Parametro[n];
            }
            return z;
        }
        static Boolean modbusIsOn(int i)
        {
            return (!(ForzatureModbus[i] == -1 || ForzatureModbus[i] == 0xffff));
        }

        static Boolean modbusIsOff(int i)
        {
            return (ForzatureModbus[i] == -1 || ForzatureModbus[i] == 0xffff);
        }

        static public int variazioneParametro()
        {
            // qui testa se è stato cambiato qualcosa da pulsante on off
            // o da valore
            int cambiato = 0;
            for (int i = 0; i < Parametro.Length; i++)
            {
                if (Parametro[i] != OldParametro[i])
                {
                    cambiato = cambiato | (1 << i);
                    OldParametro[i] = Parametro[i];                    
                }
            }
            return cambiato;
        }

        static public bool variazione(int i)
        {
            bool flg = false;
            // va a vedere se è in On o Off
            if (ForzatureFanCoil[i].onOff != OldForzatureFanCoil[i].onOff)
            {
                // c'è stata una variazione da videata On->Off o Of->On
                OldForzatureFanCoil[i].onOff = ForzatureFanCoil[i].onOff; // riallinea la variazione
                if (ForzatureFanCoil[i].onOff == 1)
                {  // è andata in On
                   // scrive il valore su MODBUS
                    ForzatureModbus[i] = ForzatureFanCoil[i].valore;
                    flg = true;
                }
                else
                {
                    // è andata in OFF
                    ForzatureModbus[i] = 0xffff;
                    flg = true;
                }
                OldForzatureModbus[i] = ForzatureModbus[i];
                Parametro[i] = ForzatureModbus[i];
            }
            else
            {
                // non c'è stata alcuna variazione On Off da pulsante
                // controllo che on ci sia ariazione da modbus
                if (ForzatureModbus[i] != OldForzatureModbus[i])
                {
                    // c'è stata una variazone da MODBUS
                    if (modbusIsOn(i))
                    {  // variazione on ON
                        ForzatureFanCoil[i].onOff = 1;
                        ForzatureFanCoil[i].valore = ForzatureModbus[i];

                    }
                    else
                    {
                        // forzatura in OFF da MODBUS
                        ForzatureFanCoil[i].onOff = 0;
                    }
                    OldForzatureModbus[i] = ForzatureModbus[i];
                    OldForzatureFanCoil[i] = ForzatureFanCoil[i];
                    Parametro[i] = ForzatureModbus[i];
                    OldParametro[i] = ForzatureModbus[i];
                    flg = true;
                }
                else
                {
                    // non c'è stata nessuna variazione da modbus.
                    // vado a vedere se c'è stata una variazione da numeric up/down e se lo stato 
                    // di On Off è ON
                    if (ForzatureFanCoil[i].onOff == 1)
                    {
                        if (ForzatureFanCoil[i].valore != Parametro[i])
                        {
                            Parametro[i] = ForzatureFanCoil[i].valore;
                        }
                    }
                }
            }
            return flg;
        }




        static public int getOnOffDaModbus(int i) { return ForzatureFanCoil[i].onOff; }
        static public int getValoreDaModbus(int i) { return ForzatureModbus[i]; }

        static public void setValore(int i, int valore)
        {
            ForzatureFanCoil[i].valore = valore;
        }

        static public void setValoreDaModbus(int i, int valore)
        {
            ForzatureModbus[i] = valore;
        }




        static public void setOnOff(int f, int OnOff)
        {
            ForzatureFanCoil[f].onOff = OnOff;
        }
        // -------- FORZATURE TERMOSTATO --------

        static int onOffSetPoint;
        static decimal setPointValue = 20;

        public static void writeOnOffSetPoint(int onOff)
        { onOffSetPoint = onOff; }
        public static int readOnOffSetPoint() {  return onOffSetPoint; }

        public static void writeSetPointValue(decimal x) { setPointValue = x;    }
        public static decimal readSetPointValue() { return setPointValue; }

        // --------------------------------------------------
        struct sMasterSlave
        {
            public Boolean MasterSlave;
            public decimal Indirizzo;

        }

        static sMasterSlave ms;

        static public void  setAddressMasterSlave(decimal indirizzo, Boolean  masla)
        {
            if(indirizzo!=ms.Indirizzo)
            {
                ms.Indirizzo = indirizzo;
            }
            if (masla != ms.MasterSlave)
            {
                ms.MasterSlave = masla;
            }
        }


        static public Boolean ImMaster() {  return ms.MasterSlave; }

        
        static public decimal getIndirizzoMaster() { return ms.Indirizzo; }



    }
}

