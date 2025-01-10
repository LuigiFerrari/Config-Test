// #define DEBUGSYS

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Windows.Forms.VisualStyles;
using System.Net.Sockets;
using System.IO.Ports;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Linq.Expressions;
using Microsoft.Win32;
using System.Text.RegularExpressions;



namespace configuratore
{
    internal class clsSerial
    {
        const int SIZE_FIFO = 1024;
        static SerialPort serialPort;
        static String selectedPortName;
        //static byte[] rxFifo = new byte[SIZE_FIFO];
        //static int rdIndex;
        //static int wrIndex;
        static Boolean Connected;

        static List<String> comPorts = new List<String>();

        static byte[] myBuffer = new byte[SIZE_FIFO];

        static public sFifo[] fifo = new sFifo[Costanti.fifoType.Length];


        public static String getSelectedPortName() {  return selectedPortName; }



        public static void initSerial()
        {
            //rdIndex = 0;
            //wrIndex = 1;
            for (int i = 0; i < Costanti.fifoType.Length; i++)
            {
                fifo[i] = new sFifo(i);
            }
            //for (int i = 0; i < SIZE_FIFO; i++)
            //    rxFifo[i] = 0;
            Connected = false;
            updateComPorts();
        }
        public static Boolean serialPortIsOpen() { return serialPort.IsOpen; }
        public static void updateComPorts()
        {
            String[] lComPort  = SerialPort.GetPortNames();
            updateListPort();
            comPorts.Clear();
            
            for(int i=0;i< lComPort.Length;i++)
            {
                int trovato = -1;
                for (int j = 0; j < comPortsList.Count && trovato<0; j++)
                {
                    if (lComPort[i] == comPortsList[j].ComPort)
                    {
                        comPorts.Add(lComPort[i]);
                        trovato = i;
                    }
                }
            }            
        }

        struct serialDiveceRecord
        {
            // public SerialDevice deviceS;
            public String ComPort;
            public String intName;

        }

        static List<serialDiveceRecord> comPortsList;
        static void updateListPort()
        {
            String VID = "1FC9";
            String PID = "0094";
            if (comPortsList == null)
            {
                comPortsList = new List<serialDiveceRecord>();
            }
            else
            {
                comPortsList.Clear();
            }
            String pattern = String.Format("^VID_{0}.PID_{1}", VID, PID);
            Regex _rx = new Regex(pattern, RegexOptions.IgnoreCase);
            RegistryKey rk1 = Registry.LocalMachine;
            RegistryKey rk2 = rk1.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum");
            foreach (String s3 in rk2.GetSubKeyNames())
            {
                RegistryKey rk3 = rk2.OpenSubKey(s3);
                foreach (String s in rk3.GetSubKeyNames())
                {
                    if (_rx.Match(s).Success)
                    {
                        RegistryKey rk4 = rk3.OpenSubKey(s);
                        foreach (String s2 in rk4.GetSubKeyNames())
                        {
                            RegistryKey rk5 = rk4.OpenSubKey(s2);
                            RegistryKey rk6 = rk5.OpenSubKey("Device Parameters");
                            serialDiveceRecord tmpRec = new serialDiveceRecord();
                            tmpRec.ComPort = (string)rk6.GetValue("PortName");
                            tmpRec.intName = "";
                            comPortsList.Add(tmpRec);
                        }
                    }
                }
            }
        }

        static public Boolean isConnected() { return Connected; }

        static public void Disconnect()
        {
            if (Connected == true)
            {

                if (serialPort.IsOpen == true)
                {

                    Thread CloseDown = new Thread(new ThreadStart(CloseSerialOnExit)); //close port in new thread to avoid hang
                    CloseDown.Start(); //close port in new thread to avoid hang
                    // serialPort.Close();
                }
                else
                {
                    Connected = false;
                    updateComPorts();
                }

            }
        }

        static void CloseSerialOnExit()
        {
            try
            {
                Thread.Sleep(200);
                if (serialPort.IsOpen == true)
                {
                    serialPort.DataReceived -= SerialPortDataReceived;
                    serialPort.DiscardInBuffer();
                    serialPort.DiscardOutBuffer();
                    serialPort.Close();
                    Connected = false;
                    updateComPorts();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); //catch any serial port closing error messages
            }
            // this.Invoke(new EventHandler(NowClose)); //now close back in the main thread
        }


        static public void discardBuffers()
        {
            //serialPort.DiscardInBuffer();
            //serialPort.DiscardOutBuffer();
        }

        static public int getNumOfSerialPort() { return comPorts.Count; }
        static public String getSerialPortName(int i) { return comPorts[i]; }


        static public void openSelectedPort(String lselectedPortName)
        {
            if (lselectedPortName != null)
            {
                if (lselectedPortName != "")
                {
                    selectedPortName = lselectedPortName.Trim();



                    serialPort = new SerialPort(selectedPortName, 115200, Parity.None, 8, StopBits.One);
                    // serialPort = new SerialPort(selectedPortName, 9600, Parity.None, 8, StopBits.One);
                    if (serialPort.IsOpen == true)
                        serialPort.Close();

                    serialPort.Open();
                    serialPort.DataReceived += SerialPortDataReceived;
                    Connected = true;
                }
            }
        }

        static public void txData(byte[] txBuffer, int size)
        {

            // Debug.Write("serialPort ");
            // Debug.WriteLine(serialPort != null);





            if (serialPort != null)
            {
                // Debug.Write("serial port is open ");
                // Debug.WriteLine(serialPort.IsOpen);

                if (serialPort.IsOpen == true)
                {
                    //for (int i = 0; i < size; i++)
                    //{
                    //    Debug.Write(txBuffer[i].ToString("X2") + " ");
                    //}
                    //Debug.WriteLine("");
                    try
                    {
                        serialPort.Write(txBuffer, 0, size);
                    } catch(Exception e)
                    {
                        string message = loca.getStr(loca.indice.STARTUP_CONNECTION_ERROR);
                        string title = loca.getStr(loca.indice.MNET_MSG_ERROR); 
                        MessageBox.Show(message, title);
                        Application.Restart();
                    }
                }

            }
        }

        static int indiceSys = -1;

#if DEBUGSYS
        static int numsys;
#endif

        static private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var serialPort = (SerialPort)sender;
            int x;
            bool flg;
            flg = true;

            while (flg)
            {
                try
                {
                    if (serialPort.BytesToRead != 0)
                    {
                        x = serialPort.ReadByte();
                        if (x < 0)
                            flg = false;
                        else
                        {
#if DEBUGSYS
                            if (x == 0xf0)
                            {
                                Debug.Write(numsys.ToString() + " - ");
                                numsys++;
                            }
                            Debug.Write(" " + utility.convert2Hex((byte)x));
#endif
                            switch (x)
                            {
                                case 0xf0:
                                    indiceSys = 1;
                                    myBuffer[0] = 0xf0;
                                    
                                    break;
                                case 0xf7:
                                    if (indiceSys >= 0)
                                    {
                                        myBuffer[indiceSys] = (byte)x;
                                        indiceSys++;
                                        push(myBuffer, indiceSys);
                                        indiceSys = -1;
#if DEBUGSYS
                                        Debug.WriteLine("");
#endif

                                    }

                                    break;
                                default:
                                    if (indiceSys > 0)
                                    {
                                        myBuffer[indiceSys] = (byte)x;
                                        indiceSys++;
                                    }
                                    break;
                            }



                            //  push((byte)x);
                        }
                    }
                    else
                        flg = false;
                }
                catch
                {
                    if (serialPort.IsOpen == true)
                    {
                        serialPort.DiscardOutBuffer();
                        serialPort.DiscardInBuffer();
                        USBerrorRestart();

                    }
                    flg = false;
                }
            }
            // Debug.WriteLine(" END LOOP ");
            //Thread CloseDown = new Thread(new ThreadStart(CloseSerialOnExit)); //close port in new thread to avoid hang
            //CloseDown.Start(); //close port in new thread to avoid hang

        }

        static public void USBerrorRestart()
        {
            if (clsArbitrator.isOnClosing() == false) {
                clsArbitrator.setOnClosing();
                string message = loca.getStr(loca.indice.STARTUP_CONNECTION_ERROR);
                string title = loca.getStr(loca.indice.MNET_MSG_ERROR);
                MessageBox.Show(message, title);
                Application.Restart();
            }
        }

        static int trovaFifo(byte c)
        {
            int t = ((int)c & (Costanti.MASK_DEVICE | Costanti.MASK_VIDEATA));
            return trovaFifo(t);


        }

        static int trovaFifo(int t)
        {
            int trovato = -1;

            for (int i = 0; i < fifo.Length && trovato < 0; i++)
            {
                if (fifo[i] != null)
                {
                    if (t == fifo[i].fifoType)
                        trovato = i;
                }
            }
            return trovato;
        }
        static void push(byte[] d, int l)
        {

            /// alla posiziione xxx
            /// trova il tipo di fifo da selezionare
            /// 
            int tipo = trovaFifo(d[Costanti.FANCAS]);
            if (tipo >= 0)
            {
                for (int i = 0; i < l; i++)
                {
                    fifo[tipo].push(d[i]);
                }
            }
            else
            {
                Debug.WriteLine(String.Format("fifo non tovato {0:X2} ", (int)d[Costanti.FANCAS]));

            }
        }


        public static int pop(int t)
        {
            int outData;
            outData = -1;
            int tipo = trovaFifo(t);
            if (tipo >= 0)
            {
                outData = fifo[tipo].pop();
            }
            else
            {
                Debug.WriteLine(String.Format("fifo non tovato {0:X2} ", t));
            }
            return outData;
        }


    }


    public class sFifo
    {
        const int FIFO_SIZE = (2048);

        public byte[] myfifo;
        public int fifoRd;
        public int fifoWr;
        public int fifoType;

        public sFifo(int t)
        {
            fifoRd = 0;
            fifoWr = 1;
            myfifo = new byte[FIFO_SIZE];
            fifoType = Costanti.fifoType[t];
            for (int j = 0; j < FIFO_SIZE; j++)
            {
                myfifo[j] = 0;
            }
        }
        public void initType(int x)
        {
            fifoType = Costanti.fifoType[x];
        }
        public void push(byte x)
        {
            myfifo[fifoWr] = x;
            fifoWr++;
            if (fifoWr == FIFO_SIZE)
                fifoWr = 0;
        }

        public int pop()
        {
            int outData;
            outData = -1;

            int tmpInt = fifoRd + 1;
            if (tmpInt == FIFO_SIZE)
                tmpInt = 0;
            if (tmpInt != fifoWr)
            {
                outData = myfifo[tmpInt];
                fifoRd = tmpInt;
            }

            return outData;
        }

    }
}
