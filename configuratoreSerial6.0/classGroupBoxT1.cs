using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static configuratore.frmCassette;
using static configuratore.statoCassette.frmStatoCassette;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Diagnostics;



namespace configuratore
{
    internal class classGroupBoxT1
    {
        frmTermoT1 mainForm;
        int peogressivo;

        gbOxConfig GroupBpox;
        System.Windows.Forms.GroupBox myGbox;

        int richiestoDa;
        struct posControl
        {
            public int pos;
            public int riga;
            public string cont;

        }

        static int posTempoSpegnimentoP = -1;
        int posTempoSpegnimentoN = -1;



        public void UpdateDeviceLanguage()
        {
            int i;
            setLanguage();
            //for (i = 0; i < lblList.Count; i++)
            //    lblList[i].setLanguage();
        }

        void setLanguage()
        {
            int i;
            int j;
            GroupBpox.cfgGbox.gpBox.Text = loca.getStr(GroupBpox.cfgGbox.testo);
            if (GroupBpox.cfgLabel != null)
            {
                for (i = 0; i < GroupBpox.cfgLabel.Length; i++)
                {
                    GroupBpox.cfgLabel[i].lbl.Text = loca.getStr(GroupBpox.cfgLabel[i].testo);
                }
            }
            if (GroupBpox.cfgCombo != null)
            {
                // cancella lista precedente

                for (i = 0; i < GroupBpox.cfgCombo.Length; i++)
                {
                    int latestItemNum = GroupBpox.cfgCombo[i].combo.SelectedIndex;
                    GroupBpox.cfgCombo[i].combo.Items.Clear();
                    for (j = 0; j < GroupBpox.cfgCombo[i].lista.Length; j++)
                        GroupBpox.cfgCombo[i].combo.Items.Add(loca.getStr(GroupBpox.cfgCombo[i].lista[j]));
                    GroupBpox.cfgCombo[i].combo.SelectedIndex = latestItemNum;
                }
            }
            if (GroupBpox.cfgRadioButton != null)
            {
                for (i = 0; i < GroupBpox.cfgRadioButton.Length; i++)
                {
                    for (j = 0; j < GroupBpox.cfgRadioButton[i].rButton.Length; j++)
                    {
                        GroupBpox.cfgRadioButton[i].rButton[j].Text = loca.getStr(GroupBpox.cfgRadioButton[i].testo[j]);
                    }
                    // selezione item di  default
                }
            }
        }

        public void setGNnum6(int p,int n)
        {
             posTempoSpegnimentoP = p;
             posTempoSpegnimentoN = n;
        }

        public classGroupBoxT1(gbOxConfig GroupBpoxInfo, frmTermoT1 gForm)
        {
            int i;
            int j;
            mainForm = gForm;
            richiestoDa = gForm.getRichiestoDa();
            GroupBpox = GroupBpoxInfo;
            GroupBpoxInfo.cfgGbox.gpBox.Text = loca.getStr(GroupBpoxInfo.cfgGbox.testo);
            if (GroupBpoxInfo.cfgLabel != null)
            {
                for (i = 0; i < GroupBpoxInfo.cfgLabel.Length; i++)
                {
                    GroupBpoxInfo.cfgLabel[i].lbl.Text = loca.getStr(GroupBpoxInfo.cfgLabel[i].testo);
                }
            }
            if (GroupBpoxInfo.cfgCombo != null)
            {
                for (i = 0; i < GroupBpoxInfo.cfgCombo.Length; i++)
                {
                    for (j = 0; j < GroupBpoxInfo.cfgCombo[i].lista.Length; j++)
                        GroupBpoxInfo.cfgCombo[i].combo.Items.Add(loca.getStr(GroupBpoxInfo.cfgCombo[i].lista[j]));
                    GroupBpoxInfo.cfgCombo[i].combo.SelectedIndex = GroupBpoxInfo.cfgCombo[i].vDefault;
                    GroupBpoxInfo.cfgCombo[i].combo.SelectedIndexChanged += new System.EventHandler(SelectedIndexChanged);
                }
            }
            if (GroupBpoxInfo.cfgRadioButton != null)
            {
                for (i = 0; i < GroupBpoxInfo.cfgRadioButton.Length; i++)
                {
                    for (j = 0; j < GroupBpoxInfo.cfgRadioButton[i].rButton.Length; j++)
                    {
                        GroupBpoxInfo.cfgRadioButton[i].rButton[j].Text = loca.getStr(GroupBpoxInfo.cfgRadioButton[i].testo[j]);
                        GroupBpoxInfo.cfgRadioButton[i].rButton[j].Checked = (GroupBpoxInfo.cfgRadioButton[i].vDefault[j] == 1);
                        GroupBpoxInfo.cfgRadioButton[i].rButton[j].CheckedChanged += new System.EventHandler(CheckedChanged);
                    }
                    // selezione item di  default
                }
            }
            if (GroupBpoxInfo.cfgUpDown != null)
            {
                for (i = 0; i < GroupBpoxInfo.cfgUpDown.Length; i++)
                {

                    GroupBpoxInfo.cfgUpDown[i].numUpDown.Minimum = GroupBpoxInfo.cfgUpDown[i].vMin;
                    GroupBpoxInfo.cfgUpDown[i].numUpDown.Maximum = GroupBpoxInfo.cfgUpDown[i].vMax;
                    GroupBpoxInfo.cfgUpDown[i].numUpDown.Increment = GroupBpoxInfo.cfgUpDown[i].vInc;
                    GroupBpoxInfo.cfgUpDown[i].numUpDown.DecimalPlaces = GroupBpoxInfo.cfgUpDown[i].nDec;
                    GroupBpoxInfo.cfgUpDown[i].numUpDown.Value = GroupBpoxInfo.cfgUpDown[i].vDefault;
                    GroupBpoxInfo.cfgUpDown[i].numUpDown.ValueChanged += new System.EventHandler(ValueChanged);
                    GroupBpoxInfo.cfgUpDown[i].numUpDown.TextChanged += new System.EventHandler(Ctl_TextChanged);
                    GroupBpoxInfo.cfgUpDown[i].lTimer = -1;
                    GroupBpoxInfo.cfgUpDown[i].oldValue = -1000;
                    GroupBpoxInfo.cfgUpDown[i].UpDownFLG = 0;

                    

                    // selezione item di  default
                }
            }

            // Enable the Timer
           
        }


        public void Tick(gbOxConfig GroupBpox)
        {


            if (GroupBpox.cfgUpDown != null)
            {

                int i;
                for (i = 0; i < GroupBpox.cfgUpDown.Length; i++)
                {
                    if (GroupBpox.cfgUpDown[i].lTimer >= 0)
                    {
                        GroupBpox.cfgUpDown[i].lTimer--;
                        if (GroupBpox.cfgUpDown[i].lTimer < 0)
                        {
                            if (GroupBpox.cfgUpDown[i].numParametro == posTempoSpegnimentoP)
                            {
                                if (GroupBpox.cfgUpDown[i].numUpDown.Value == 0)
                                    GroupBpox.cfgUpDown[i].numUpDown.BackColor = Color.Black;
                                else
                                    GroupBpox.cfgUpDown[i].numUpDown.BackColor = Color.White;
                            } else
                                GroupBpox.cfgUpDown[i].numUpDown.BackColor = Color.White;
                            if (GroupBpox.cfgUpDown[i].numUpDown.Value > GroupBpox.cfgUpDown[i].numUpDown.Maximum)
                                GroupBpox.cfgUpDown[i].numUpDown.Value = GroupBpox.cfgUpDown[i].numUpDown.Maximum;
                            if (GroupBpox.cfgUpDown[i].numUpDown.Value < GroupBpox.cfgUpDown[i].numUpDown.Minimum)
                                GroupBpox.cfgUpDown[i].numUpDown.Value = GroupBpox.cfgUpDown[i].numUpDown.Minimum;


                        }
                    }
                }
            }
        }

        String aa;

        private void Ctl_TextChanged(object sender, System.EventArgs e)
        {
            int i;


            if (clsArbitrator.isDoNotLoop() == false)
            {
                for (i = 0; i < GroupBpox.cfgUpDown.Length; i++)
                {
                    if (sender == GroupBpox.cfgUpDown[i].numUpDown)
                    {
                        Debug.WriteLine("CAMBIATO VALUE CHANGED "+ GroupBpox.cfgUpDown[i].UpDownFLG.ToString());
                        if (GroupBpox.cfgUpDown[i].UpDownFLG == 0)
                        {
                            // non si è premuto Up Down ma è stato editato il  valore
                            GroupBpox.cfgUpDown[i].lTimer = 3;
                            GroupBpox.cfgUpDown[i].numUpDown.BackColor = Color.Yellow;
                        }
                        else
                        {
                            GroupBpox.cfgUpDown[i].UpDownFLG = 0;
                        }

                            
                    }
                }
            }
        }
  
        
        

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < GroupBpox.cfgCombo.Length; i++)
            {
                if (sender == GroupBpox.cfgCombo[i].combo)
                {
                    if (clsArbitrator.isDoNotLoop() == false)
                        txMsg.txMsgOne(GroupBpox.cfgCombo[i].numParametro, GroupBpox.cfgCombo[i].combo.SelectedIndex, richiestoDa);

                }
            }
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < GroupBpox.cfgRadioButton.Length; i++)
            {
                for (int j = 0; j < GroupBpox.cfgRadioButton[i].rButton.Length; j++)
                {
                    if (sender == GroupBpox.cfgRadioButton[i].rButton[j])
                    {
                        if (GroupBpox.cfgRadioButton[i].rButton[j].Checked)
                        {
                            if (clsArbitrator.isDoNotLoop() == false)
                                txMsg.txMsgOne(GroupBpox.cfgRadioButton[i].numParametro, j, richiestoDa);
                        }
                    }
                }

            }
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < GroupBpox.cfgUpDown.Length; i++)
            {
                if (sender == GroupBpox.cfgUpDown[i].numUpDown)
                {
                    
                    int nByte = utility.cacSize((int)GroupBpox.cfgUpDown[i].numUpDown.Minimum, (int)GroupBpox.cfgUpDown[i].numUpDown.Maximum, GroupBpox.cfgUpDown[i].numUpDown.DecimalPlaces);
                    int txData = (int)(GroupBpox.cfgUpDown[i].numUpDown.Value * utility.potDieci(GroupBpox.cfgUpDown[i].numUpDown.DecimalPlaces));
                    if (clsArbitrator.isDoNotLoop() == false)
                    {
                        switch (nByte)
                        {
                            case 1:
                                txMsg.txMsgOne(GroupBpox.cfgUpDown[i].numParametro, txData, richiestoDa);
                                break;
                            case 2:
                                txMsg.txMsg2(GroupBpox.cfgUpDown[i].numParametro, txData, richiestoDa);
                                break;
                            case 3:
                                txMsg.txMsg3(GroupBpox.cfgUpDown[i].numParametro, txData, richiestoDa);
                                break;
                        }
                        GroupBpox.cfgUpDown[i].lTimer = -1;

                        if (GroupBpox.cfgUpDown[i].numParametro == posTempoSpegnimentoP)
                        {
                            if (GroupBpox.cfgUpDown[i].numUpDown.Value == 0)
                                GroupBpox.cfgUpDown[i].numUpDown.BackColor = Color.Black;
                            else
                                GroupBpox.cfgUpDown[i].numUpDown.BackColor = Color.White;
                        }
                        else
                            GroupBpox.cfgUpDown[i].numUpDown.BackColor = Color.White;
                        GroupBpox.cfgUpDown[i].UpDownFLG = 2;
                        Debug.WriteLine("CAMBIATO UP/DOWN");
                    }
                    global.glbfrmT1.campoDinamico(GroupBpox.cfgUpDown[i].numParametro, txData);
                }
            }
        }

        public int getProgresivo() { return peogressivo; }

        public System.Windows.Forms.GroupBox getGroupBox() { return myGbox; }


    }
}

