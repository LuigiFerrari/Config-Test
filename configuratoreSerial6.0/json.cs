using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace configuratore
{


    public class recordNode
    {

        public String m { get; set; }
        public int s { get; set; }
        public int t { get; set; }
        public int i { get; set; }
        public int p { get; set; }   // principale
        public int d { get; set; }   // subtype
        public string v { get; set; } // versione


    }

    public class ListaStatuscls
    {
        public int[] netStatus { get; set; }
    }

    public class ListaNodicls
    {
        public int errRete { get; set; }
        public recordNode[] netList { get; set; }

        
    }

    public class JsonNetlist
    {
        String JSONstr;
        ListaNodicls listaNodi;
        ListaStatuscls ListaStati;




        public int decodeNET(String xx)
        {
            JSONstr = xx;
            int retValue = 0;
            if (JSONstr.Contains("netList"))
            {
                listaNodi = JsonSerializer.Deserialize<ListaNodicls>(JSONstr);
                retValue = Costanti.NETLIST;
            }
            else
            {
                ListaStati = JsonSerializer.Deserialize<ListaStatuscls>(JSONstr);
                retValue = Costanti.NETSTATUS;

            }
            return retValue;
        }

            public String encodeNET(DataGridView net)
        {
            ListaNodicls newNet = new ListaNodicls();
            newNet.netList = new recordNode[net.RowCount];
            newNet.errRete = 0;
            for(int i=0;i< net.RowCount;i++)
            {
                newNet.netList[i] = new recordNode();
                newNet.netList[i].m = net.Rows[i].Cells["MATRICOLA"].Value.ToString();
                newNet.netList[i].i = i;
                newNet.netList[i].s = 0;
                newNet.netList[i].t = Convert.ToInt32(net.Rows[i].Cells["CODICE"].Value);
                newNet.netList[i].d = Convert.ToInt32(net.Rows[i].Cells["SUBTYPE"].Value);
                newNet.netList[i].p = Convert.ToInt32(net.Rows[i].Cells["FLAGPRINCIPALE"].Value);
                newNet.netList[i].v = net.Rows[i].Cells["VERSIONE"].Value.ToString();

            }
            string json = JsonSerializer.Serialize(newNet);
            return json;
        }

        public int getErrore() { return listaNodi.errRete;  }
        public int getNumOfNodi() { return listaNodi.netList.Length;  }

        public String getMatricola(int r) { return listaNodi.netList[r].m; }
        public int getTipo(int r) { return listaNodi.netList[r].t; }
        public int getStato(int r) { return listaNodi.netList[r].s; }

        public int getIndirizzo(int r ) { return listaNodi.netList[r].i; }

        public int getPrincipale(int r) { return listaNodi.netList[r].p; }

        public int getSubType(int r) { return listaNodi.netList[r].d; }

        public string getSwVersione(int r) { return listaNodi.netList[r].v;  }

        public int getNetStatus(int r)
        {
            int z = -1;
            if (r < ListaStati.netStatus.Length)
                z = ListaStati.netStatus[r];
            return z;
        }
    }


}
