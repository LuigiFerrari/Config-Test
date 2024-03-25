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

namespace configuratore
{
    internal class clsSerial
    {
        const int SIZE_FIFO = 1024;
        static SerialPort serialPort;
        static string[] comPorts;
        static String selectedPortName;
        //static byte[] rxFifo = new byte[SIZE_FIFO];
        //static int rdIndex;
        //static int wrIndex;
        static Boolean Connected;

        static byte[] myBuffer = new byte[SIZE_FIFO];

        static public sFifo[] fifo = new sFifo[Costanti.fifoType.Length];


        public static String getSelectedPortName() {  return selectedPortName; }



        public static void initSerial()
        {
            comPorts = SerialPort.GetPortNames();
            //rdIndex = 0;
            //wrIndex = 1;
            for (int i = 0; i < Costanti.fifoType.Length; i++)
            {
                fifo[i] = new sFifo(i);
            }
            //for (int i = 0; i < SIZE_FIFO; i++)
            //    rxFifo[i] = 0;
            Connected = false;
        }
        public static Boolean serialPortIsOpen() { return serialPort.IsOpen; }
        public static void updateComPorts()
        {
            comPorts = SerialPort.GetPortNames();
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

        static public int getNumOfSerialPort() { return comPorts.Length; }
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
                    }
                }

            }
        }

        static int indiceSys = -1;

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
                            // Debug.Write(" " + utility.convert2Hex((byte)x));

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
                                        //Debug.WriteLine("");

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
                        serialPort.Close();
                    }
                    flg = false;
                }
            }
            // Debug.WriteLine(" END LOOP ");
            //Thread CloseDown = new Thread(new ThreadStart(CloseSerialOnExit)); //close port in new thread to avoid hang
            //CloseDown.Start(); //close port in new thread to avoid hang

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
            int tipo = 0;
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
            int tipo = 0;
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
