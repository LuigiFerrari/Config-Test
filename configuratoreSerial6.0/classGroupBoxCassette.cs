using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static configuratore.frmCassette;

namespace configuratore
{
    internal class classGroupBoxCassette
    {
        const int Ystart = 26;
        const int XstartLbl = 24;
        const int XstartCombo = 230;
        const int Wcombo = 100;
        const int DeltaY = 26;
        const int udW = 80;
        const int xStartud = XstartCombo + Wcombo - udW;
        const int XstartRadio = XstartCombo;
        System.Windows.Forms.GroupBox myGbox;
        List<System.Windows.Forms.ComboBox> comboList;
        List<System.Windows.Forms.NumericUpDown> udList;
        List<System.Windows.Forms.RadioButton> radioList;

        int peogressivo;

        frmCassette mainForm;

        gbOxConfig GroupBpox;

        int richiestoDa;
        int indirizzo;

        struct posControl
        {
            public int pos;
            public int riga;
            public string cont;

        }

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



        public classGroupBoxCassette(gbOxConfig GroupBpoxInfo, frmCassette gForm)
        {
            int i;
            int j;
            mainForm = gForm;
            richiestoDa = gForm.getRichiestoDa();
            indirizzo = gForm.getIndirizzo();
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

                    // selezione item di  default
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
                    if (clsArbitrator.isDoNotLoop1or2() == false)
                    {
                        txMsg.txMsgOne(GroupBpox.cfgCombo[i].numParametro, GroupBpox.cfgCombo[i].combo.SelectedIndex, richiestoDa | indirizzo);
                    }
                        if (GroupBpox.cfgCombo[i].numParametro == parametriCassetta.KK_DIFFUSIONE)
                    {
                        // qui aggiorna le label di NTC1 e NTC2

                        if (GroupBpox.cfgCombo[i].combo.SelectedIndex == parametriCassetta.DAL_BASSO)
                        {
                            mainForm.setNTC1Str(loca.indice.STR_INT_MANDATA);
                        }
                        else
                        {
                            mainForm.setNTC1Str(loca.indice.SONDA_INT);                           
                        }
                    }
                    clsArbitrator.clrDoNotLoop2();
                }
            }
           
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            int i;
            int k = 0;
            for (i = 0; i < GroupBpox.cfgRadioButton.Length; i++)
            {
                for (int j = 0; j < GroupBpox.cfgRadioButton[i].rButton.Length; j++)
                {
                    if (sender == GroupBpox.cfgRadioButton[i].rButton[j])
                    {
                        if (GroupBpox.cfgRadioButton[i].rButton[j].Checked)
                        {
                            if (clsArbitrator.isDoNotLoop1or2() == false)
                            {
                                txMsg.txMsgOne(GroupBpox.cfgRadioButton[i].numParametro, j, richiestoDa | indirizzo);
                            }
                            k = 1;
                        }
                        
                        if (GroupBpox.cfgRadioButton[i].numParametro == parametriCassetta.KK_PRESENZA_SERRANDA)
                        {
                            if (GroupBpox.cfgRadioButton[i].rButton[j].Checked)
                                mainForm.campoDinamico(GroupBpox.cfgRadioButton[i].numParametro, i, -1,j);
                        }
                        if (GroupBpox.cfgRadioButton[i].numParametro == parametriCassetta.KK_ING_DIG_NTC2)
                        {
                            if (GroupBpox.cfgRadioButton[i].rButton[j].Checked)
                                mainForm.campoDinamico(GroupBpox.cfgRadioButton[i].numParametro, i, -1, j);
                        }

                    }
                }

            }
            if(k==1)
                clsArbitrator.clrDoNotLoop2();

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
                    global.glbfrmCassette.calcoli(GroupBpox.cfgUpDown[i].numParametro);
                    if (clsArbitrator.isDoNotLoop1or2() == false)
                    {
                        switch (nByte)
                        {
                            case 1:
                                txMsg.txMsgOne(GroupBpox.cfgUpDown[i].numParametro, txData, richiestoDa | indirizzo);
                                break;
                            case 2:
                                txMsg.txMsg2(GroupBpox.cfgUpDown[i].numParametro, txData, richiestoDa | indirizzo);
                                break;
                            case 3:
                                txMsg.txMsg3(GroupBpox.cfgUpDown[i].numParametro, txData, richiestoDa | indirizzo);
                                break;
                        }
                    }
                    clsArbitrator.clrDoNotLoop2();
                }
            }
            

        }

        public int getProgresivo() { return peogressivo; }

        public System.Windows.Forms.GroupBox getGroupBox() { return myGbox; }


    }
}
