using configuratore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace configuratoreSerial6._0.uniqueID
{
    public partial class frmRequireCOnfig : Form
    {
        String hwID;
        char charToRemove;
        Label[] lblID = new Label[6];
        int configPLC = -1;
        public frmRequireCOnfig()
        {
            InitializeComponent();
            String[] h = uniqueID.fmt4Split(uniqueID.getHWid());
            lblID[0] = lblHWid1;
            lblID[1] = lblHWid2;
            lblID[2] = lblHWid3;
            lblID[3] = lblHWid4;
            lblID[4] = lblHWid5;
            lblID[5] = lblHWid6;
            for (int i = 0; i < 6; i++)
            {
                lblID[i].Text = h[i];
            }
            int lx = lblID[0].Right;
            for (int i = 1; i < 6; i++)
            {
                lblID[i].Left = lx;
                lx = lx + lblID[i].Width;
            }
            newIDMaskEditBox.Width = lblID[0].Width * 6;
            hwID = uniqueID.getHWid();
            newIDMaskEditBox.Text = datiConfig.getUniqueID();

        }

        private void frmRequireCOnfig_Load(object sender, EventArgs e)
        {

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(hwID);
        }

        String validText = "0123456789ABCDEFabcdef";


        void mkAlert(String x, char c)
        {
            string message = x + " (" + c + ")";
            string title = loca.getStr(loca.indice.MNET_MSG_ERROR);
            MessageBox.Show(message, title);
        }

        private int validaStringaInput(String s)
        {
            int valida = 0;
            for (int i = 0; i < s.Length && valida==0; i++)
            {
                char x = s[i];
                if (x != '_')
                {
                    if (!validText.Contains(x))
                    {
                        valida = 1;

                        mkAlert(loca.getStr(loca.indice.STARTUP_INVALID_CHAR), x);
                    }
                }
            }
            return valida;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (validaStringaInput(uniqueID.getHWid()) == 0)
            {
                configPLC = -1;
                String z = uniqueID.getHWid().Replace("_", "");
                z = z.ToUpper();
                configPLC = uniqueID.testConfig(z);
                if (configPLC >= 0)
                {
                    datiConfig.setUniqueID(z);
                }
              
            }
            
            this.Close();
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {

            newIDMaskEditBox.Text = Clipboard.GetText();

        }
        public int getConfig() { return configPLC;  }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if(validaStringaInput(newIDMaskEditBox.Text) ==0)
            {
                configPLC = -1;
                String z = newIDMaskEditBox.Text.Replace("_", "");
                z = z.ToUpper();
                configPLC = uniqueID.testConfig(z);
                if (configPLC>=0)
                {
                    datiConfig.setUniqueID(z);
                }
                this.Close();
            }
        }
    }

}