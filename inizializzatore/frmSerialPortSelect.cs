using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace configuratore
{
    public partial class frmSerialPortSelect : Form
    {
         int okCancel;

        public   bool isSelectedOk() { return okCancel == Costanti.OK;  }
        public frmSerialPortSelect()
        {
            InitializeComponent();
        }

        List<string> ports = new List<string>();
        List<string> portsb = new List<string>();

        private void frmSerialPortSelect_Load(object sender, EventArgs e)
        {
            readPortList();
            updateListBox();
            copy2b();
        }

        void updateListBox()
        {
            listBoxPortList.Items.Clear();
            for (int i = 0; i < clsSerial.getNumOfSerialPort(); i++)
            {
                listBoxPortList.Items.Add(clsSerial.getSerialPortName(i));
                ports.Add(clsSerial.getSerialPortName(i));
            }
        }

        private void copy2b()
        {
            portsb.Clear();
            for (int i = 0; i < ports.Count; i++)
            {
                portsb.Add(ports[i]);
            }
        }

        private void readPortList()
        {
            ports.Clear();
            for (int i = 0; i < clsSerial.getNumOfSerialPort(); i++)
            {
                ports.Add(clsSerial.getSerialPortName(i));
            }

        }

        private bool compareb()
        {
            bool flg = false;
            if (ports.Count != portsb.Count)
            {
                flg = true;
            }
            else
            {
                for (int i = 0; i < ports.Count && flg == false; i++)
                {
                    if (portsb[i] != ports[i])
                        flg = false;
                }
            }
            return flg;
        }


        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            okCancel = Costanti.CANCEL;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (listBoxPortList.SelectedItem != null)
            {
                String p = listBoxPortList.GetItemText(listBoxPortList.SelectedItem);
                clsSerial.openSelectedPort(p);
            }
            okCancel = Costanti.OK;
            this.Close();
        }

        private void timerUpateList_Tick(object sender, EventArgs e)
        {
            clsSerial.updateComPorts();
            readPortList();
            if(compareb())
            {
                copy2b();
                updateListBox();
            }
        }
    }
}
