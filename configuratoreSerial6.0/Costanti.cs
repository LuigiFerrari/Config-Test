using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace configuratore
{
    internal class Costanti
    {
        public const int X0 = 25;               // coordinata X etichetta
        public const int Y0 = 30;               // coordinata Y etichetta
        public const int GAPY = 30;             // spazio Y tra etichette

        public const int EDIT = 0;
        public const int NEW = 1;

        public const int DATAGET = 0;
        public const int DATASET = 1;
        public const int UNIVERSAL = 0x7f;

        public const int UNDEFINED = 0x7f;

        public const int CASSETTE = 0;
        public const int FANCOIL = 1;
        public const int T1 = 2;
        public const int T2 = 3;
        public const int T3 = 4;    // TFT

        public const int IM_MASTER = 0x8;
        public const int MASK_MASTER = 0x07;


        public const int RESERVED = 1;
        public const int FANCAS = 2;
        public const int MSG_VERSION0 = 3;
        public const int MSG_VERSION1 = (MSG_VERSION0 + 1);
        public const int RESERVED_2 = (MSG_VERSION0 + 2);
        public const int MSG_VERSION = MSG_VERSION0;
        public const int SIZE_OF_VER = ((MSG_VERSION1 - MSG_VERSION0) + 1);

        public const int DATASETGET = (RESERVED_2 + 1);

        public const int MSG_H = (DATASETGET + 1);
        public const int MSG_L = (MSG_H + 1);
        public const int MSG = MSG_H;
        public const int SEGNO = (MSG_L + 1);
        public const int DATA = (SEGNO + 1);


        public const int RICHIESTA_DA_MASTER =(1<<5);
        public const int RICHIESTA_DA_LOCALE = 0;


        // messaggi
        public const int mINFO = 0x3fff;
        public const int mNETINFO = 0x3ffe;
        public const int RESCAN_NETWORK = 0x3ffd;
        public const int AGGIORNA_NETWORK = 0x3ffc;
        public const int SALVA_NETWORK = 0x3ffb;
        public const int RESTART_MASTER = 0x3ffa;

        public const int UNCONNECTED = 0;
        public const int CONNECTING = 1;
        public const int CONNECTED = 2;
        public const int DISCONNECTING = 3;

        public const int OK = 1;
        public const int CANCEL = 0;


        public const int NETLIST=0;
        public const int NETSTATUS=1;


        static public string[] FUNZIONAMENTO =
        {
            "STANDARD",
            "VAV"
        };

        public struct datiVer
        {
            public string tVersion;
            public string tNote;
        }

        static public string[] DEVICESTRING =
        {
            "CASSETTE",
            "FANCOIL"
        };

        
        static public Boolean isCassetteOrFancoil(int dispositivo)
        {
            int d = dispositivo & 0x07;
            return (d == CASSETTE || d == FANCOIL);
        }

        static public String getNomeDispositivo(int dispositivo,int subType)
        {
            String str = "";
            int d = dispositivo;
            switch (d)
            {
                case CASSETTE:
                    str = "CASSETTE";
                    break;
                case FANCOIL:
                    str = "FANCOIL";
                    break;
                case T1:
                    str = "ANALOG THERMOSTAT";
                    break;
                case T2:
                    str = "TOUCH THERMOSTAT ";
                    switch (subType)
                    {
                        case 0:
                            str = str + "6 Switches";
                            break;
                        case 1:
                            str = str + "5 Switches +Quick Cooling";
                            break;
                        case 2:
                            str = str + "5 Switches";
                            break;
                        case 3:
                            str = str + "4 Switches";
                            break;
                        case 4:
                            str = str + "3 Switches";
                            break;
                        case 5:
                            str = str + "2 Switches";
                            break;
                    }
                    break;
                case T3:
                    str = "TFT THERMOSTAT";
                    break;
            }
            return str;
        }


        public enum tblIndice
        {
            TBLCONFIG,                          // CONFIG
            TBLCASSETTE,                        // CASSETTE
            TBLFANCOIL

        };

        static datiVer[] datiVersione =
            new datiVer[]{
                new datiVer() { tVersion="0.0.0", tNote = "" }, // CONFIG
                new datiVer() { tVersion="1.0.0", tNote = "" }, // CASSETTE         
                new datiVer() { tVersion="1.0.0", tNote = "" }, // FANCOIL         
            };

        static public String getCurrVersionH(tblIndice typ)
        {
            return getCurrVersion(typ, 0);
        }

        static public String getCurrVersionL(tblIndice typ)
        {
            return getCurrVersion(typ, 1);
        }


        static String getCurrVersion(tblIndice type, int hl)
        {
            int k = (int)type;
            string[] x = datiVersione[k].tVersion.Split('.');
            return x[hl];

        }
        static public string getVersion(string v, int k)
        {
            int kk;
            string[] x = datiVersione[k].tVersion.Split('.');
            kk = 0;
            switch (v)
            {
                case "v0":
                    kk = 0;
                    break;
                case "v1":
                    kk = 1;
                    break;
                case "v2":
                    kk = 2;
                    break;
            }
            return x[kk];
        }

        static public string getNote(int k)
        {
            return datiVersione[k].tNote;
        }
        // 6 5 4 3 2 1 0
        // x x x x x x x
        // | | | | | | |
        // | | | | | | +-> bit 0 dispositivo
        // | | | | | +---> bit 1 dispositivo
        // | | | | +-----> bit 2 dispositivo
        // | | | +-------> bit 3 MASTER/SLAVE
        // | | +---------> bit 4 videata
        // | +-----------> but 6 videata
        // +-------------> bit 6 videata       
        //        0 -> MASTER
        //        1 -> SLAVE

        public const int BIT_DEVICE = 0;  // bit 0,1,2,3
        public const int BIT_VIDEATA = 4; // bit,4,...
        public const int IM_MASTER_ = 3;

        public const int VIDEATA_MASTER = 0;
        public const int VIDEATA_STATO = 1;
        public const int VIDEATA_PARAMETRI = 2;
        public const int VIDEATA_NETWORK = 3;

        public const int BITS_DEVICE_CASSETTE = (CASSETTE << BIT_DEVICE);
        public const int BITS_DEVICE_FANCOIL = (FANCOIL << BIT_DEVICE);
        public const int BITS_DEVICE_TERMOT1 = (T1 << BIT_DEVICE);
        public const int BITS_DEVICE_TERMOT2 = (T2 << BIT_DEVICE);
        public const int BITS_DEVICE_TERMOT3 = (T3 << BIT_DEVICE);  // TFT

        public const int BIT_IM_MASTER = (1 << IM_MASTER_);




        public const int BITS_VIDEATA_MASTER = (VIDEATA_MASTER << BIT_VIDEATA);
        public const int BITS_VIDEATA_STATO = (VIDEATA_STATO << BIT_VIDEATA);
        public const int BITS_VIDEATA_PARAMETRI = (VIDEATA_PARAMETRI << BIT_VIDEATA);
        public const int BITS_VIDEATA_NETWORK = (VIDEATA_NETWORK << BIT_VIDEATA);


        public const int MASK_DEVICE = 0x0f;
        public const int MASK_VIDEATA = (7 << BIT_VIDEATA);

        // metto tutti su un array per semplicità di ricerca
        public static readonly int[] fifoType = {
            BITS_DEVICE_CASSETTE | BITS_VIDEATA_MASTER,
            BITS_DEVICE_CASSETTE | BITS_VIDEATA_STATO,
            BITS_DEVICE_CASSETTE | BITS_VIDEATA_PARAMETRI,

            BITS_DEVICE_FANCOIL | BITS_VIDEATA_MASTER,
            BITS_DEVICE_FANCOIL | BITS_VIDEATA_STATO,
            BITS_DEVICE_FANCOIL | BITS_VIDEATA_PARAMETRI,

            BITS_DEVICE_TERMOT1 | BITS_VIDEATA_MASTER,
            BITS_DEVICE_TERMOT1 | BITS_VIDEATA_STATO,
            BITS_DEVICE_TERMOT1 | BITS_VIDEATA_PARAMETRI,

            BITS_DEVICE_TERMOT2 | BITS_VIDEATA_MASTER,
            BITS_DEVICE_TERMOT2 | BITS_VIDEATA_STATO,
            BITS_DEVICE_TERMOT2 | BITS_VIDEATA_PARAMETRI,

            BITS_DEVICE_TERMOT3 | BITS_VIDEATA_MASTER,
            BITS_DEVICE_TERMOT3 | BITS_VIDEATA_STATO,
            BITS_DEVICE_TERMOT3 | BITS_VIDEATA_PARAMETRI,


            // ----------------- MASTER ------------------

            BIT_IM_MASTER,

           BIT_IM_MASTER | BITS_DEVICE_CASSETTE | BITS_VIDEATA_MASTER,
           BIT_IM_MASTER | BITS_DEVICE_CASSETTE | BITS_VIDEATA_STATO,
           BIT_IM_MASTER | BITS_DEVICE_CASSETTE | BITS_VIDEATA_PARAMETRI,

            BIT_IM_MASTER | BITS_DEVICE_FANCOIL | BITS_VIDEATA_MASTER,
            BIT_IM_MASTER | BITS_DEVICE_FANCOIL | BITS_VIDEATA_STATO,
            BIT_IM_MASTER | BITS_DEVICE_FANCOIL | BITS_VIDEATA_PARAMETRI,

            BIT_IM_MASTER | BITS_DEVICE_TERMOT1 | BITS_VIDEATA_MASTER,
            BIT_IM_MASTER | BITS_DEVICE_TERMOT1 | BITS_VIDEATA_STATO,
            BIT_IM_MASTER | BITS_DEVICE_TERMOT1 | BITS_VIDEATA_PARAMETRI,

            BIT_IM_MASTER | BITS_DEVICE_TERMOT2 | BITS_VIDEATA_MASTER,
            BIT_IM_MASTER | BITS_DEVICE_TERMOT2 | BITS_VIDEATA_STATO,
            BIT_IM_MASTER | BITS_DEVICE_TERMOT2 | BITS_VIDEATA_PARAMETRI,

            BIT_IM_MASTER | BITS_DEVICE_TERMOT3 | BITS_VIDEATA_MASTER,
            BIT_IM_MASTER | BITS_DEVICE_TERMOT3 | BITS_VIDEATA_STATO,
            BIT_IM_MASTER | BITS_DEVICE_TERMOT3 | BITS_VIDEATA_PARAMETRI,






        };

        public const int MASTER = 0;
        public const int SLAVE = 1;

    }
}
