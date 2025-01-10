using System;
using System.Collections.Generic;
using System.Diagnostics;
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

    public class ms
    {
        public String m { get; set; }
        public int s { get; set; }
        public String v { get; set; }
    }

    public class ListaStatuscls
    {
        public ms[] netStatus { get; set; }
    }
    public class RichiediStato
    {
        public int getStato { get; set; }
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

            try
            {
                // Debug.WriteLine(JSONstr);

                if (JSONstr.Contains("netList"))
                {
                    listaNodi = JsonSerializer.Deserialize<ListaNodicls>(JSONstr);
                    retValue = Costanti.NETLIST;
                }
                else
                {
                    if (JSONstr.Contains("netStatus"))
                    {
                        // stato rete
                        ListaStati = JsonSerializer.Deserialize<ListaStatuscls>(JSONstr);
                        retValue = Costanti.STATO_RETE;
                    }
                    else
                    {
                        ListaStati = JsonSerializer.Deserialize<ListaStatuscls>(JSONstr);
                        retValue = Costanti.STATO_RETE;
                    }

                }
            }
            catch (Exception e)
            {
                retValue = -1;
            }
            return retValue;
        }

        public String encodeNET(DataGridView net)
        {
            ListaNodicls newNet = new ListaNodicls();
            newNet.netList = new recordNode[net.RowCount];
            newNet.errRete = 0;
            for (int i = 0; i < net.RowCount; i++)
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


        public String richiediStato()
        {
            RichiediStato r = new RichiediStato();
            r.getStato = 1;
            string json = JsonSerializer.Serialize(r);
            return json;

        }

        public int getNumOfStati()
        {
            //  = JsonSerializer.Deserialize<ListaStatuscls>(JSONstr);
            return ListaStati.netStatus.Length;
        }

        public String getM(int i) { return ListaStati.netStatus[i].m; }
        public String getV(int i) { return ListaStati.netStatus[i].v; }
        public int getS(int i) { return ListaStati.netStatus[i].s; }

        public int getErrore() { return listaNodi.errRete; }
        public int getNumOfNodi() { return listaNodi.netList.Length; }

        public String getMatricola(int r) { return listaNodi.netList[r].m; }
        public int getTipo(int r) { return listaNodi.netList[r].t; }
        public int getStato(int r) { return listaNodi.netList[r].s; }

        public int getIndirizzo(int r) { return listaNodi.netList[r].i; }

        public int getPrincipale(int r) { return listaNodi.netList[r].p; }

        public int getSubType(int r) { return listaNodi.netList[r].d; }

        public string getSwVersione(int r) { return listaNodi.netList[r].v; }

        public int getNetStatus(int r)
        {
            int z = -1;

            return z;
        }
    }


}
