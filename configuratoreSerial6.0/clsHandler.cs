using configuratore.stato;
using configuratore.statoCassette;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
        public static void decode(byte x, frmStartUp f)
        {
            int fineDecodifica = decodifica(x,f.getRxBufferClass());
            if (fineDecodifica >= 0)
            {
                decodeMsg(f.getRxBuffr(), fineDecodifica, f);
            }
        }



        static public byte getIndirizzo() { return Indirizzo; }
        static void decodeMsg(byte[] rxBuffer, int lx, frmStartUp pForm)
        {
            // decodifica messaggio ricevuto da server

            // legge la versione
            // 0xF0 00 00 00 00 00 00 yy zz ... 0xF7
            //       |  |  |  |  |  |
            //       |  |  |  |  |  +-- 00 = DATA SET; 01= DATA REQUEST
            //       |  |  |  |  +-- versione 0    -- 0X7F UNIVERSAL
            //       |  |  |  +----- versione 1    -- 0X7F UNIVERSAL
            //       |  |  +-------- versione 2    -- 0X7F UNIVERSAL
            //       |  |  
            //       |  +----- 00 = cassette; 01= fancoil
            //       +--------- reserved

            int command;
            command = utility.getCommand(rxBuffer);
            int casfan = (int)rxBuffer[Costanti.FANCAS] & Costanti.MASK_DEVICE;
            Indirizzo = rxBuffer[Costanti.RESERVED];

            switch (command)
            {
                case Costanti.mINFO:
                    clsMsg.getInfo(rxBuffer);
                    pForm.openFromRemote(casfan, false,Costanti.RICHIESTA_DA_LOCALE,"");
                    break;
            }


            // controlla che non ci sia nessuna pagina aperta su fancoil o cassette

            //static public void requireInfo()
            //{
            //    txBuffer[0] = 0xf0;
            //    txBuffer[Costanti.RESERVED] = 0;
            //    txBuffer[Costanti.FANCAS] = Costanti.UNIVERSAL;
            //    txBuffer[Costanti.MSG_VERSION0] = Costanti.UNIVERSAL;
            //    txBuffer[Costanti.MSG_VERSION1] = Costanti.UNIVERSAL;
            //    txBuffer[Costanti.MSG_VERSION2] = Costanti.UNIVERSAL;
            //    txBuffer[Costanti.DATASETGET] = Costanti.DATAGET;
            //    txBuffer[Costanti.MSG_H] = (Costanti.mINFO >> 7) & 0x7f;
            //    txBuffer[Costanti.MSG_L] = (Costanti.mINFO) & 0x7f;
            //    txBuffer[Costanti.MSG_L + 1] = 0xf7;
            //    SocketClient.sendData(txBuffer, (Costanti.MSG_L + 2));


        }

        public static void decode(byte x, frmCassette f)
        {
            int fineDecodifica = decodifica(x,f.getRxBufferClass());
            if (fineDecodifica >= 0)
            {
                decodeMsg(f.getRxBuffr(), fineDecodifica, f);
            }
        }

        static void decodeMsg(byte[] rxBuffer, int lx, frmCassette pForm)
        {
            int parametro;
            parametro = utility.getCommand(rxBuffer);
            int casfan = (int)rxBuffer[Costanti.FANCAS] & Costanti.MASK_DEVICE;
            if (casfan == Costanti.BITS_DEVICE_CASSETTE)
            {
                if (((int)rxBuffer[Costanti.FANCAS] & Costanti.MASK_VIDEATA) == Costanti.BITS_VIDEATA_PARAMETRI)
                {
                    // conferma che siamo sulla videata giusta
                    // qui deve visualizzare il parametro
                    // 

                    pForm.aggiornaParametro(parametro, rxBuffer, Costanti.SEGNO); // viene passato il buffer di ricezione e l'indice del segno
                }
            }

        }


        // -----------------------------------------------------------------------------------------

        public static void decode(byte x, frmStatoCassette f)
        {
            int fineDecodifica = decodifica(x,f.getRxBufferClass());
            if (fineDecodifica >= 0)
            {
                decodeMsg(f.getRxBuffr(), fineDecodifica, f);
            }
        }

        static void decodeMsg(byte[] rxBuffer, int lx, frmStatoCassette pForm)
        {
            int parametro;
            parametro = utility.getCommand(rxBuffer);
            int casfan = (int)rxBuffer[Costanti.FANCAS] & Costanti.MASK_DEVICE;
            if (casfan == Costanti.BITS_DEVICE_CASSETTE)
            {
                if (((int)rxBuffer[Costanti.FANCAS] & Costanti.MASK_VIDEATA) == Costanti.BITS_VIDEATA_STATO)
                {
                    // conferma che siamo sulla videata giusta
                    // qui deve visualizzare il parametro
                    // 

                    pForm.aggiornaParametro(parametro, rxBuffer, Costanti.SEGNO); // viene passato il buffer di ricezione e l'indice del segno
                }
            }

        }
        // -------------------------------------------------------------
        public static void decode(byte x, frmTermoT1 f)
        {
            int fineDecodifica = decodifica(x, f.getRxBufferClass());
            if (fineDecodifica >= 0)
            {
                decodeMsg(f.getRxBuffr(), fineDecodifica, f);
            }
        }
        static void decodeMsg(byte[] rxBuffer, int lx, frmTermoT1 pForm)
        {
            int parametro;
            parametro = utility.getCommand(rxBuffer);
            int casfan = (int)rxBuffer[Costanti.FANCAS] & Costanti.MASK_DEVICE;
            if (casfan == Costanti.BITS_DEVICE_TERMOT1)
            {
                if (((int)rxBuffer[Costanti.FANCAS] & Costanti.MASK_VIDEATA) == Costanti.BITS_VIDEATA_PARAMETRI)
                {
                    // conferma che siamo sulla videata giusta
                    // qui deve visualizzare il parametro
                    // 

                    pForm.aggiornaParametro(parametro, rxBuffer, Costanti.SEGNO); // viene passato il buffer di ricezione e l'indice del segno
                }

                if (((int)rxBuffer[Costanti.FANCAS] & Costanti.MASK_VIDEATA) == Costanti.BITS_VIDEATA_STATO) {
                    pForm.aggiornaStato(parametro, rxBuffer, Costanti.SEGNO); // viene passato il buffer di ricezione e l'indice del segno
                    
                }
            }
        }
        // -------------------------------------------------------------
        public static void decode(byte x, frmTermoT2 f)
        {
            int fineDecodifica = decodifica(x, f.getRxBufferClass());
            if (fineDecodifica >= 0)
            {
                decodeMsg(f.getRxBuffr(), fineDecodifica, f);
            }
        }

        static void decodeMsg(byte[] rxBuffer, int lx, frmTermoT2 pForm)
        {
            int parametro;
            parametro = utility.getCommand(rxBuffer);
            int casfan = (int)rxBuffer[Costanti.FANCAS] & Costanti.MASK_DEVICE;
            if (casfan == Costanti.BITS_DEVICE_TERMOT2)
            {
                if (((int)rxBuffer[Costanti.FANCAS] & Costanti.MASK_VIDEATA) == Costanti.BITS_VIDEATA_PARAMETRI)
                {
                    // conferma che siamo sulla videata giusta
                    // qui deve visualizzare il parametro
                    // 

                    pForm.aggiornaParametro(parametro, rxBuffer, Costanti.SEGNO); // viene passato il buffer di ricezione e l'indice del segno
                }

                if (((int)rxBuffer[Costanti.FANCAS] & Costanti.MASK_VIDEATA) == Costanti.BITS_VIDEATA_STATO)
                    pForm.aggiornaStato(parametro, rxBuffer, Costanti.SEGNO); // viene passato il buffer di ricezione e l'indice del segno


            }
        }

        public static void decode(byte x, frmFanCoil f)
        {
            int fineDecodifica = decodifica(x, f.getRxBufferClass());
            if (fineDecodifica >= 0)
            {
                decodeMsg(f.getRxBuffr(), fineDecodifica, f);
            }
        }
        static void decodeMsg(byte[] rxBuffer, int lx, frmFanCoil pForm)
        {
            int parametro;
            parametro = utility.getCommand(rxBuffer);
            int casfan = (int)rxBuffer[Costanti.FANCAS] & Costanti.MASK_DEVICE;
            if (casfan == Costanti.BITS_DEVICE_FANCOIL)
            {
                if (((int)rxBuffer[Costanti.FANCAS] & Costanti.MASK_VIDEATA) == Costanti.BITS_VIDEATA_PARAMETRI)
                {
                    // conferma che siamo sulla videata giusta
                    // qui deve visualizzare il parametro
                    // 

                    pForm.aggiornaParametro(parametro, rxBuffer, Costanti.SEGNO); // viene passato il buffer di ricezione e l'indice del segno
                }
            }

        }

        public static void decode(byte x, frmStatoFanCoil f)
        {
            int fineDecodifica = decodifica(x, f.getRxBufferClass());
            if (fineDecodifica >= 0)
            {
                decodeMsg(f.getRxBuffr(), fineDecodifica, f);
            }
        }

        static void decodeMsg(byte[] rxBuffer, int lx, frmStatoFanCoil pForm)
        {
            int parametro;
            parametro = utility.getCommand(rxBuffer);
            int casfan = (int)rxBuffer[Costanti.FANCAS] & Costanti.MASK_DEVICE;
            if (casfan == Costanti.BITS_DEVICE_FANCOIL)
            {
                if (((int)rxBuffer[Costanti.FANCAS] & Costanti.MASK_VIDEATA) == Costanti.BITS_VIDEATA_STATO)
                {
                    // conferma che siamo sulla videata giusta
                    // qui deve visualizzare il parametro
                    // 

                    pForm.aggiornaParametro(parametro, rxBuffer, Costanti.SEGNO); // viene passato il buffer di ricezione e l'indice del segno
                }
            }

        }
    }

}
