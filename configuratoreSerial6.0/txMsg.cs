using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace configuratore
{


    internal class txMsg
    {
        static byte[] txBuffer;

        static public void initDati()
        {
            txBuffer = new byte[1024];
        }

        // 0xF0 00 00 00 00 00 00 yy zz ... 0xF7
        //       |  |  |  |  |  |
        //       |  |  |  |  |  +-- 00 = DATA SET; 01= DATA REQUEST
        //       |  |  |  |  +-- versione 0    -- 0X7F UNIVERSAL
        //       |  |  |  +----- versione 1    -- 0X7F UNIVERSAL
        //       |  |  +-------- versione 2    -- 0X7F UNIVERSAL
        //       |  |  
        //       |  +----- 00 = cassette; 01= fancoil
        //       +--------- reserved

        static public void requireInfo()
        {
            txBuffer[0] = 0xf0;
            txBuffer[Costanti.RESERVED] = Costanti.UNDEFINED;
            txBuffer[Costanti.FANCAS] = Costanti.UNIVERSAL;
            txBuffer[Costanti.MSG_VERSION0] = Costanti.UNIVERSAL;
            txBuffer[Costanti.MSG_VERSION1] = Costanti.UNIVERSAL;
            txBuffer[Costanti.RESERVED_2] = 0;
            txBuffer[Costanti.DATASETGET] = Costanti.DATAGET;
            txBuffer[Costanti.MSG_H] = (Costanti.mINFO>>7)&0x7f;
            txBuffer[Costanti.MSG_L] = (Costanti.mINFO) & 0x7f;
            txBuffer[Costanti.MSG_L + 1] = 0xf7;
            clsSerial.txData(txBuffer, (Costanti.MSG_L + 2));
        }

        static public void rescanNetork()
        {
            txBuffer[0] = 0xf0;
            txBuffer[Costanti.RESERVED] = Costanti.UNDEFINED;
            txBuffer[Costanti.FANCAS] = Costanti.UNIVERSAL;
            txBuffer[Costanti.MSG_VERSION0] = Costanti.UNIVERSAL;
            txBuffer[Costanti.MSG_VERSION1] = Costanti.UNIVERSAL;
            txBuffer[Costanti.RESERVED_2] = 0;
            txBuffer[Costanti.DATASETGET] = Costanti.DATASET;
            txBuffer[Costanti.MSG_H] = (Costanti.RESCAN_NETWORK >> 7) & 0x7f;
            txBuffer[Costanti.MSG_L] = (Costanti.RESCAN_NETWORK) & 0x7f;
            txBuffer[Costanti.MSG_L + 1] = 0xf7;
            clsSerial.txData(txBuffer, (Costanti.MSG_L + 2));
        }
        static public void restartMaster()
        {
            txBuffer[0] = 0xf0;
            txBuffer[Costanti.RESERVED] = Costanti.UNDEFINED;
            txBuffer[Costanti.FANCAS] = Costanti.UNIVERSAL;
            txBuffer[Costanti.MSG_VERSION0] = Costanti.UNIVERSAL;
            txBuffer[Costanti.MSG_VERSION1] = Costanti.UNIVERSAL;
            txBuffer[Costanti.RESERVED_2] = 0;
            txBuffer[Costanti.DATASETGET] = Costanti.DATASET;
            txBuffer[Costanti.MSG_H] = (Costanti.RESTART_MASTER >> 7) & 0x7f;
            txBuffer[Costanti.MSG_L] = (Costanti.RESTART_MASTER) & 0x7f;
            txBuffer[Costanti.MSG_L + 1] = 0xf7;
            clsSerial.txData(txBuffer, (Costanti.MSG_L + 2));
        }
        static public void aggiornaRete()
        {
            txBuffer[0] = 0xf0;
            txBuffer[Costanti.RESERVED] = Costanti.UNDEFINED;
            txBuffer[Costanti.FANCAS] = Costanti.UNIVERSAL;
            txBuffer[Costanti.MSG_VERSION0] = Costanti.UNIVERSAL;
            txBuffer[Costanti.MSG_VERSION1] = Costanti.UNIVERSAL;
            txBuffer[Costanti.RESERVED_2] = 0;
            txBuffer[Costanti.DATASETGET] = Costanti.DATASET;
            txBuffer[Costanti.MSG_H] = (Costanti.AGGIORNA_NETWORK >> 7) & 0x7f;
            txBuffer[Costanti.MSG_L] = (Costanti.AGGIORNA_NETWORK) & 0x7f;
            txBuffer[Costanti.MSG_L + 1] = 0xf7;
            clsSerial.txData(txBuffer, (Costanti.MSG_L + 2));
        }

        static public void storeNetork(String jsonNet)
        {
            char[] jsonNetArray = jsonNet.ToCharArray();
            txBuffer[0] = 0xf0;
            txBuffer[Costanti.RESERVED] = Costanti.UNDEFINED;
            txBuffer[Costanti.FANCAS] = Costanti.UNIVERSAL;
            txBuffer[Costanti.MSG_VERSION0] = Costanti.UNIVERSAL;
            txBuffer[Costanti.MSG_VERSION1] = Costanti.UNIVERSAL;
            txBuffer[Costanti.RESERVED_2] = 0;
            txBuffer[Costanti.DATASETGET] = Costanti.DATASET;
            txBuffer[Costanti.MSG_H] = (Costanti.SALVA_NETWORK >> 7) & 0x7f;
            txBuffer[Costanti.MSG_L] = (Costanti.SALVA_NETWORK) & 0x7f;
            int k = Costanti.MSG_L + 1;
            for (int i = 0; i < jsonNet.Length;i++)
            {
                txBuffer[k] = (byte)jsonNetArray[i];
                k++;
            }
            txBuffer[k] = 0;
            txBuffer[k+1] = 0;
            txBuffer[k +2] = 0xf7;
            clsSerial.txData(txBuffer, k+3);

        }

        static public void requireNetworkStatus()
        {
            txBuffer[Costanti.RESERVED] = (byte)'N';
            txBuffer[Costanti.FANCAS] = (byte)'E';
            txBuffer[Costanti.MSG_VERSION0] = (byte)'T';
            txBuffer[Costanti.MSG_VERSION1] = (byte)'_';
            txBuffer[Costanti.RESERVED_2] = (byte)'I';
            txBuffer[Costanti.DATASETGET] = (byte)'N';
            txBuffer[Costanti.MSG_H] = (byte)'F';
            txBuffer[Costanti.MSG_L] = (byte)'O';
            txBuffer[Costanti.MSG_L + 1] = 0;
            txBuffer[Costanti.MSG_L + 2] = 0;
            txBuffer[Costanti.MSG_L + 4] = 0xF7;
            clsSerial.txData(txBuffer, (Costanti.MSG_L + 5));

        }

        static public void requireNetworkInfo()
        {
            txBuffer[0] = 0xf0;
            txBuffer[Costanti.RESERVED] = Costanti.UNDEFINED;
            txBuffer[Costanti.FANCAS] = Costanti.UNIVERSAL;
            txBuffer[Costanti.MSG_VERSION0] = Costanti.UNIVERSAL;
            txBuffer[Costanti.MSG_VERSION1] = Costanti.UNIVERSAL;
            txBuffer[Costanti.RESERVED_2] = 0;
            txBuffer[Costanti.DATASETGET] = Costanti.DATAGET;
            txBuffer[Costanti.MSG_H] = (Costanti.mNETINFO >> 7) & 0x7f;
            txBuffer[Costanti.MSG_L] = (Costanti.mNETINFO) & 0x7f;
            txBuffer[Costanti.MSG_L + 1] = 0xf7;
            clsSerial.txData(txBuffer, (Costanti.MSG_L + 2));
        }


        static public void requireParameter(int p,int tipoMessaggio,int richiestoDa)
        {
            txBuffer[0] = 0xf0;
            if ((richiestoDa & Costanti.RICHIESTA_DA_MASTER) != 0)
                txBuffer[Costanti.RESERVED] = (byte)(richiestoDa & (~Costanti.RICHIESTA_DA_MASTER));
            else
                txBuffer[Costanti.RESERVED] = clsHandler.getIndirizzo();
            richiestoDa = (byte)(richiestoDa & Costanti.RICHIESTA_DA_MASTER);
            txBuffer[Costanti.FANCAS] = (byte)tipoMessaggio;
            txBuffer[Costanti.MSG_VERSION0] = (byte)1;
            txBuffer[Costanti.MSG_VERSION1] = (byte)0;
            txBuffer[Costanti.RESERVED_2] = (byte)0;
            txBuffer[Costanti.DATASETGET] = (byte)(Costanti.DATAGET | richiestoDa);
            txBuffer[Costanti.MSG_H] = (byte)((p >> 7) & 0x7f);
            txBuffer[Costanti.MSG_L] = (byte)((p) & 0x7f);
            txBuffer[Costanti.MSG_L + 1] = 0xf7;
            
            clsSerial.txData(txBuffer, (Costanti.MSG_L + 2));
        }


        static public void txMsgOne(int m,int v, int richiestoDa)
        {
            if (m == 28)
                Debug.WriteLine("Trasmesso paramettro 28");
            txBuffer[0] = 0xf0;
            if ((richiestoDa & Costanti.RICHIESTA_DA_MASTER) != 0)
                txBuffer[Costanti.RESERVED] = (byte)(richiestoDa & (~Costanti.RICHIESTA_DA_MASTER));
            else
                txBuffer[Costanti.RESERVED] = clsHandler.getIndirizzo();
            richiestoDa = (byte)(richiestoDa & Costanti.RICHIESTA_DA_MASTER);
            txBuffer[Costanti.FANCAS] = Costanti.BITS_VIDEATA_PARAMETRI;
            txBuffer[Costanti.MSG_VERSION0] = (byte)1;
            txBuffer[Costanti.MSG_VERSION1] = (byte)0;
            txBuffer[Costanti.RESERVED_2] = (byte)0;
            txBuffer[Costanti.DATASETGET] =  (byte)(Costanti.DATASET | richiestoDa);
            txBuffer[Costanti.MSG_H] = (byte)((m >> 7) & 0x7f);
            txBuffer[Costanti.MSG_L] = (byte)(m & 0x7f);
            if(v<0)
            {
                v=-v;
                txBuffer[Costanti.SEGNO] = 1;
            } else
                txBuffer[Costanti.SEGNO] = 0;
            txBuffer[Costanti.DATA] = (byte)(v);
            txBuffer[Costanti.DATA + 1] = 0xf7;
            clsSerial.txData(txBuffer, (Costanti.DATA + 2));
        }

        static public void txMsg2(int m, int v, int richiestoDa)
        {
            txBuffer[0] = 0xf0;
            if ((richiestoDa & Costanti.RICHIESTA_DA_MASTER) != 0)
                txBuffer[Costanti.RESERVED] = (byte)(richiestoDa & (~Costanti.RICHIESTA_DA_MASTER));
            else
                txBuffer[Costanti.RESERVED] = clsHandler.getIndirizzo();
            richiestoDa = (byte)(richiestoDa & Costanti.RICHIESTA_DA_MASTER);
            txBuffer[Costanti.FANCAS] = Costanti.BITS_VIDEATA_PARAMETRI;
            txBuffer[Costanti.MSG_VERSION0] = (byte)1;
            txBuffer[Costanti.MSG_VERSION1] = (byte)0;
            txBuffer[Costanti.RESERVED_2] = (byte)0;
            txBuffer[Costanti.DATASETGET] = (byte)(Costanti.DATASET | richiestoDa);
            txBuffer[Costanti.MSG_H] = (byte)((m >> 7) & 0x7f);
            txBuffer[Costanti.MSG_L] = (byte)(m & 0x7f);
            if (v < 0)
            {
                v = -v;
                txBuffer[Costanti.SEGNO] = 1;
            }
            else
            {
                txBuffer[Costanti.SEGNO] = 0;
            }
            txBuffer[Costanti.DATA] = (byte)((v >> 7) & 0x7f);
            txBuffer[Costanti.DATA+1] = (byte)(v & 0x7f);
            txBuffer[Costanti.DATA + 2] = 0xf7;
            clsSerial.txData(txBuffer, (Costanti.DATA + 3));
        }

        static public void txMsg3(int m, int v, int richiestoDa)
        {
            txBuffer[0] = 0xf0;
            if ((richiestoDa & Costanti.RICHIESTA_DA_MASTER) != 0)
                txBuffer[Costanti.RESERVED] = (byte)(richiestoDa & (~Costanti.RICHIESTA_DA_MASTER));
            else
                txBuffer[Costanti.RESERVED] = clsHandler.getIndirizzo();
            richiestoDa = (byte)(richiestoDa & Costanti.RICHIESTA_DA_MASTER);
            txBuffer[Costanti.FANCAS] = Costanti.BITS_VIDEATA_PARAMETRI;
            txBuffer[Costanti.MSG_VERSION0] = (byte)1;
            txBuffer[Costanti.MSG_VERSION1] = (byte)0;
            txBuffer[Costanti.RESERVED_2] = (byte)0;
            txBuffer[Costanti.DATASETGET] = (byte)(Costanti.DATASET | richiestoDa);
            txBuffer[Costanti.MSG_H] = (byte)((m >> 7) & 0x7f);
            txBuffer[Costanti.MSG_L] = (byte)(m & 0x7f);
            if (v < 0)
            {
                v = -v;
                txBuffer[Costanti.SEGNO] = 1;
            }
            else
                txBuffer[Costanti.SEGNO] = 0;
            txBuffer[Costanti.DATA] = (byte)((v >> 13) & 0x7f);
            txBuffer[Costanti.DATA+1] = (byte)((v >> 7) & 0x7f);
            txBuffer[Costanti.DATA+2] = (byte)(v & 0x7f);
            txBuffer[Costanti.DATA + 3] = 0xf7;
            clsSerial.txData(txBuffer, (Costanti.DATA + 4));
        }
    }
}

