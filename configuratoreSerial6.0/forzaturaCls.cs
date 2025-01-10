using configuratore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace configuratoreSerial6._0
{
    internal class forzaturaCls
    {
        Button bOnOff;
        NumericUpDown Valore;
        Image imgOn = global::configuratoreSerial6._0.Resource1.FrecciaDestraON;
        Image imgOff = global::configuratoreSerial6._0.Resource1.FrecciaDestraOFF;
        int numeroControllo;
        int richiestoDa;
        int Stato;
        int myTimer = -1;
        private void bOnOff_Click(object sender, EventArgs e)
        {
            if(Stato==0)
            {
                // bottone OFF
                Stato = 1;
                comTask.setValore(numeroControllo, (int)Valore.Value); // forzo il valore
            } else
            {
                Stato = 0;
            }
            comTask.setOnOff(numeroControllo, Stato );
            // spedizione messaggio

            // txMsg.txMsgOne(parametro, (int)Valore.Value, richiestoDa);
        }

        public int getStato() { return Stato;  }

        private void cambioValore(object sender, EventArgs e)
        {
            if (Stato == 1)
            {
                if (myTimer < 0)
                {
                    // copia il valore sul task di trasmissione
                    // la forzatua è in ON e il valore MODBUS viene forzato
                    comTask.setValore(numeroControllo, (int)Valore.Value);
                }
            }
        }
        public forzaturaCls(Button b,NumericUpDown n,int nc ,int richDa)
        {
            // nc numero del controllo: Ventilaz. 0 , resist. 1 ....
            bOnOff = b;
            Valore=n;
            Stato = 0;
            bOnOff.Image = getImageButton();
            bOnOff.Click += bOnOff_Click;
            Valore.ValueChanged += cambioValore;
            numeroControllo = nc;
            richiestoDa = richDa;
            comTask.setRichiestoDa(richiestoDa);
        }

        Image getImageButton()
        {
            Image img;
            if (Stato == 0)
                img = imgOff;
            else
                img = imgOn;
            return img;
        }

        void setImageButtone(Image img)
        {
            bOnOff.Image = img;
        }

        void setStatoOnOff(int s)
        {
            Stato = s;
            setImageButtone(getImageButton());
        }

        public void TickTimer(int c)
        {
            // La funzione richiamata da timer
            // controlla che non ci siano variazioni tra i parametri ricevuti via modbus
            // e quelli impostati
            if (comTask.variazione(c)==true)
            {
                int s= comTask.getOnOffDaModbus(c);
                setStatoOnOff(s);
                if(s==1)
                {
                    // lo stato è in ON
                    // va a cambiare il valore
                    // prima inizializzo un timer in modi che, se il timer è attivo,
                    // la funzione ValueChanged non ha effetto.
                    myTimer = 4; // 200 ms
                    Valore.Value= comTask.getValoreDaModbus(c);
                }
            }
            if (myTimer >= 0)
                myTimer--;

        }
    }
}
