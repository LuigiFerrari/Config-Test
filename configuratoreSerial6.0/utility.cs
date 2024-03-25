using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static configuratore.frmCassette;

namespace configuratore
{
    internal class utility
    {
        static int[] pdieci = { 1, 10, 100, 1000, 10000 };

        public const int SET_INVISIBLE_START = 0x01;

        static public void prepareVersion(DataTable t, Costanti.tblIndice tblNumx)
        {

            int tblNum = (int)tblNumx;

            DataColumn column;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "v0";
            t.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "v1";
            t.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "v2";
            t.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "note";
            t.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "data";
            t.Columns.Add(column);

            t.Rows.Add();
            t.Rows[0]["v0"] = Costanti.getVersion("v0", tblNum);
            t.Rows[0]["v1"] = Costanti.getVersion("v1", tblNum);
            t.Rows[0]["v2"] = Costanti.getVersion("v2", tblNum);
            t.Rows[0]["note"] = Costanti.getNote(tblNum);
            t.Rows[0]["data"] = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

        static public Boolean checkSameTblVersion(DataTable t, Costanti.tblIndice tblNumx)
        {
            // controlla solo se V0 e V1 sono diversi
            // l'ultimo numero, se cambia, non succede niente
            Boolean fl;
            int tblNum;
            tblNum = (int)tblNumx;
            fl = false;
            if (t.Rows[0]["v0"].ToString() == Costanti.getVersion("v0", tblNum) && t.Rows[0]["v1"].ToString() == Costanti.getVersion("v1", tblNum))
                fl = true;
            return fl;
        }

        static public string getTblVersion(DataTable t)
        {
            String v = "";
            v = t.Rows[0]["v0"].ToString() + "." + t.Rows[0]["v1"].ToString() + "." + t.Rows[0]["v2"].ToString();
            return v;
        }

        static public void UpdateVersion(DataTable t, Costanti.tblIndice tblNumx)
        {
            int tblNum;
            tblNum = (int)tblNumx;
            t.Rows[0]["v0"] = Costanti.getVersion("v0", tblNum);
            t.Rows[0]["v1"] = Costanti.getVersion("v1", tblNum);
            t.Rows[0]["v2"] = Costanti.getVersion("v2", tblNum);
            t.Rows[0]["data"] = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            t.Rows[0]["note"] = "";
        }

        static public string LeggiVersione(DataTable t)
        {
            return t.Rows[0]["v0"].ToString() + "." + t.Rows[0]["v1"].ToString();
        }

        static public string LeggiVersioneProgramma(Costanti.tblIndice tblNum)
        {
            return Costanti.getVersion("v0", (int)tblNum) + "." + Costanti.getVersion("v1", (int)tblNum);
        }

        static public Boolean CompareTablesNoORA(DataTable t1, DataTable t2)
        {
            if (t1.Rows.Count != t2.Rows.Count || t1.Columns.Count != t2.Columns.Count)
                return true;


            for (int i = 0; i < t1.Rows.Count; i++)
            {
                for (int c = 0; c < t1.Columns.Count; c++)
                {
                    if (c != 8)
                    {
                        if (!Equals(t1.Rows[i][c], t2.Rows[i][c]))
                            return true;
                    }
                }
            }
            return false;
            // 
        }

        static public int getCommand(byte[] b)
        {
            int command = -1;
            command = (int)(b[Costanti.MSG_H]) << 7;
            command = command | (int)(b[Costanti.MSG_L]);
            return command;
        }

        static public int cacSize(int min, int max, int potenza)
        {
            int d;
            int size;

            // vede quale è il piu' grande tra minimo e massimo
            int amin = Math.Abs(min);
            int amax = Math.Abs(max);
            if (amax > amin)
                d = amax;
            else
                d = amin;
            d = d * utility.potDieci(potenza);

            if (d < 128)
            {
                size = 1;
            }
            else
            {
                if (d >= 128 && d <= 16384)
                {
                    size = 2;
                }
                else
                {
                    size = 3;
                }
            }
            return (size);
        }
        static public int potDieci(int x)
        {
            return pdieci[x];
        }

        static public int convert2Int(decimal d,int ndec)
        {
            int i = 0;
            i = (int)d;
            i = i * potDieci(ndec);
            return i;
        }

        static public decimal convert2Decimal(int v,int d)
            {
            // converte in decimale per aggiustare il campo 
            decimal x = 0;
            x = (decimal)((double)v / (double)potDieci(d));
            return x;
            }
        static public int conv728(byte[] buffer, int pos, int nbyte)
        {
            int ret = -1;
            byte[] b = new byte[10];
            for(int i=0;i<nbyte;i++)
                b[i] = buffer[pos+i];
            switch(nbyte)
            {
                case 1:
                    ret = cnv1byte7to8(b);
                    break;
                case 2:
                    ret = cnv2byte7to8(b);
                    break;
                case 3:
                    ret = cnv3byte7to8(b);
                    break;
                case 4:
                    ret = cnv4byte7to8(b);
                    break;

            }
            if (buffer[Costanti.SEGNO] != 0)
                ret = -ret;
            return ret;
        }

        static public int cnv1byte7to8(byte[] msg)
            {
            int x =(int) msg[0];
            return x;
        }

        static public int cnv2byte7to8(byte[] msg)
        {
            int x = (int)msg[0];
            x = x << 7;
            x = x | (int)msg[1];
            return x;
        }

        static public int cnv3byte7to8(byte[] msg)
        {
            int x= cnv1byte7to8(msg);
            x = x << 14;
            byte[] xx = new byte[2];
            xx[0] = msg[1];
            xx[1] = msg[2];
            x = x+ cnv2byte7to8(xx);
            return x;
        }

        static public int cnv4byte7to8(byte[]  msg)
        {
            int y = 0;
            y = cnv2byte7to8(msg); // parte alta
            y = y << 14;
            byte[] xx = new byte[2];
            xx[0] = msg[2];
            xx[1] = msg[3];
            y = y | cnv2byte7to8(xx); // parte bassa
            return y;
        }
        static public void setAllVisibleInvisibile(int visInvis, gbOxConfig[] LayOutCassetteGrp)
        {
            int i;
            int j;
            for (int g = 0; g < LayOutCassetteGrp.Length; g++)
            {
                gbOxConfig GroupBpox = LayOutCassetteGrp[g];
                LayOutCassetteGrp[g].cfgGbox.Visible = visInvis;


                if (GroupBpox.cfgLabel != null)
                {
                    for (i = 0; i < GroupBpox.cfgLabel.Length; i++)
                    {
                        GroupBpox.cfgLabel[i].Visible = visInvis;
                    }
                }
                if (GroupBpox.cfgCombo != null)
                {
                    // cancella lista precedente

                    for (i = 0; i < GroupBpox.cfgCombo.Length; i++)
                    {
                        GroupBpox.cfgCombo[i].Visible = visInvis;
                    }
                }
                if (GroupBpox.cfgRadioButton != null)
                {
                    for (i = 0; i < GroupBpox.cfgRadioButton.Length; i++)
                    {
                        for (j = 0; j < GroupBpox.cfgRadioButton[i].rButton.Length; j++)
                        {
                            GroupBpox.cfgRadioButton[i].Visible = visInvis;
                        }
                        // selezione item di  default
                    }
                }
                if (GroupBpox.cfgUpDown != null)
                {
                    for (i = 0; i < GroupBpox.cfgUpDown.Length; i++)
                    {

                        GroupBpox.cfgUpDown[i].Visible = visInvis;

                        // selezione item di  default
                    }
                }
            }
        }
        static public string convertToString(int v, int d)
        {
            string s = "";
            bool flg=false;
            if (v < 0)
            {
                flg = true;
                v = -v;
            }
            if (d == 0)
                s = v.ToString();
            else
            {
                int pi = v / utility.potDieci(d);
                int pd = v % utility.potDieci(d);
                string fmt = "D" + d.ToString();
                s = pi.ToString() + "." + pd.ToString(fmt);
            }
            if (flg == true)
                s = "-" + s;
            return s;
        }

        static public float fromStringToFolat(String s)
        {
            float r = 0;
            if(s!="")
                r= float.Parse(s,System.Globalization.CultureInfo.InvariantCulture);

            return r;
        }

        
      
        static public String convert2Hex(byte b)
        {
            String hex = "0123456789ABCDEF";
            int pbalta = b / 16;
            String z = hex[pbalta].ToString();
            int pbassa = b %16;
            z=z+ hex[pbassa].ToString();
            return z;


        }
        static public void visibileInvisibile(gbOxConfig[] LayOutCassetteGrp )
        {

            int i;
            int j;
            for (int g = 0; g < LayOutCassetteGrp.Length; g++)
            {
                gbOxConfig GroupBpox = LayOutCassetteGrp[g];

                GroupBpox.cfgGbox.gpBox.Visible = GroupBpox.cfgGbox.Visible == 0;

                if (GroupBpox.cfgLabel != null)
                {
                    for (i = 0; i < GroupBpox.cfgLabel.Length; i++)
                    {
                        GroupBpox.cfgLabel[i].lbl.Visible = (GroupBpox.cfgLabel[i].Visible == 0);
                    }
                }
                if (GroupBpox.cfgCombo != null)
                {
                    // cancella lista precedente

                    for (i = 0; i < GroupBpox.cfgCombo.Length; i++)
                    {
                        GroupBpox.cfgCombo[i].combo.Visible = (GroupBpox.cfgCombo[i].Visible == 0);
                    }
                }
                if (GroupBpox.cfgRadioButton != null)
                {
                    for (i = 0; i < GroupBpox.cfgRadioButton.Length; i++)
                    {
                        for (j = 0; j < GroupBpox.cfgRadioButton[i].rButton.Length; j++)
                        {
                            GroupBpox.cfgRadioButton[i].rButton[j].Visible = (GroupBpox.cfgRadioButton[i].Visible == 0);
                        }
                        // selezione item di  default
                    }
                }
                if (GroupBpox.cfgUpDown != null)
                {
                    for (i = 0; i < GroupBpox.cfgUpDown.Length; i++)
                    {

                        GroupBpox.cfgUpDown[i].numUpDown.Visible = (GroupBpox.cfgUpDown[i].Visible == 0);

                        // selezione item di  default
                    }
                }
            }
        }
    }

    
}
