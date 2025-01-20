using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace configuratore
{
    internal class clsHandler
    {
        static byte[] rxBuffer;
        static byte Indirizzo;
        static JsonNetlist jsonMsg;

        public static void initData()
        {
            rxBuffer = new byte[256];
        }

        static string z = "<- ";

        // public static byte[] getRxdataBuffer() { return rxBuffer;  }

        public static int decodifica(byte x, clsRxBuffer rxBufferClass)
        {
            string y = String.Format("{0:X2} ", (int)x);
            int ret = -1;
            if (x == 0xf7)
            {
                z = z + y;
                //  Debug.WriteLine(z);
                z = "<- ";
            }
            else
            {
                // Debug.Write(y);
                z = z + y;
            }
            switch (x)
            {

                case 0xf0:
                    rxBufferClass.primoDato(0xf0);
                    break;
                case 0xf7:
                    if(rxBufferClass.getIndice()>0)
                    {
                        rxBufferClass.addByte(0xf7);

                        
                        ret = rxBufferClass.getIndice();
                        rxBufferClass.ResetIndice();
                    }
                    break;
                default:
                    rxBufferClass.addByte(x);
                    break;
            }
            return ret;
        }
        public static int decode(byte x, frmStartUp f)
        {
            int fineDecodifica = decodifica(x,f.getRxBufferClass());
            if (fineDecodifica >= 0)
            {
                f.setErrorVerify(decodeMsg(f.getRxBuffr(), fineDecodifica, f));
            }
            return fineDecodifica;
        }

        static private String convert2Json(byte[] buffer)
        {
            String xx = "";
            int i;
            int j;
            for (j = 0; buffer[j] != 0xf7; j++)
            {
                if (((int)buffer[j] & 0x80)==0 && buffer[j]!=0)
                    xx = xx + (char)buffer[j];
            }
            return xx;
        }

        static public byte[] convertForTx(String x)
        {
            int i;
            byte[] bytes = Encoding.ASCII.GetBytes(x);
            byte[] bytesTx = new byte[bytes.Length + 2];
            bytesTx[0] = 0xf0;
            for( i=0;i< bytes.Length;i++)
                bytesTx[i+1]= (byte)bytes[i];
            bytesTx[i + 1] = 0xf7;
            return bytesTx;

        }

        static public byte getIndirizzo() { return Indirizzo; }
        static int decodeMsg(byte[] rxBuffer, int lx, frmStartUp pForm)
        {
            int ret = 0;
            // dal buffer rxBuffer toglie F0 ed F7 e manda la stringa a json
            byte[] msg = new byte[lx];
            String strJson = convert2Json(rxBuffer).Trim();
            jsonMsg = new JsonNetlist();
            int tm = jsonMsg.decodeNET(strJson);

                switch (tm)
                {
                    case 0:
                        if (pForm.flgVerify == 0)
                        {

                            pForm.setMatricola(jsonMsg.getMatricola());

                            pForm.setMasterSlave(jsonMsg.getMasterSlave());

                            pForm.setIndirizzoMaster(jsonMsg.getIndirizzoMaster());

                            pForm.setVersone(jsonMsg.getVersione());

                            pForm.setDispositivo(jsonMsg.getDispositivo());
                            ret = -1;
                        }
                        else
                        {
                            if (jsonMsg.getMatricola() != pForm.getMatricola())
                                ret = 1;
                            if (jsonMsg.getMasterSlave() != pForm.getMasterSlave())
                                ret = 1;
                            if (jsonMsg.getIndirizzoMaster() != pForm.getIndirizzoMaster())
                                ret = 1;

                        }
                        break;
                    case 1:

                        // test mode
                        pForm.setDI(jsonMsg.getD15());
                        pForm.setLblADC(jsonMsg.getADC1(), 0);
                        pForm.setLblADC(jsonMsg.getADC2(), 1);
                        pForm.setNTC(jsonMsg.getNTC11(), 0);
                        pForm.setNTC(jsonMsg.getNTC12(), 1);
                        pForm.setPressSens(jsonMsg.getPRESS());
                        pForm.setRS485(jsonMsg.getRS485());
                        ret = -1;
                        break;
                    case 2:
                        pForm.setPotAnal(jsonMsg.getPotenzometroAnal());
                        pForm.setOnOffAnal(jsonMsg.getOnOffanal());
                        pForm.setNTC1Anal(jsonMsg.getNTC1anal(), jsonMsg.getNTC1Error());
                        pForm.setNTC2Anal(jsonMsg.getNTC2anal(), jsonMsg.getNTC2Error());
                        pForm.SetRS48513Anal(jsonMsg.getRS48513anal());
                        ret = -1;
                        break;

                }
            
            return ret;
           //  pForm.textBoxMatricola.Text = jsonMsg.getMatricola();
        }






        // -----------------------------------------------------------------------------------------








    }

}
