using configuratore.statoCassette;
using configuratore.stato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace configuratore
{
  
    
        static class global
        {
            static public frmCassette glbfrmCassette;
        static public frmFanCoil glbfrmFanCoil;
        static public frmTermoT1 glbfrmT1;
        static public frmTermoT2 glbfrmT2;

        static public frmStatoCassette frmStatoCassette;
        static public frmStatoFanCoil frmStatoFanCoil;

        static public void setStatoCassette(frmStatoCassette f) { frmStatoCassette = f; }
        static public void abilitaChiusuraStatoCassette() { frmStatoCassette.forzaChiusura = false;  }

        static public void abilitaChiusuraStatoFanCoil() { frmStatoFanCoil.forzaChiusura = false; }
        static public void setStatoFanCoil(frmStatoFanCoil f) { frmStatoFanCoil = f; }

        static public Boolean isNTC1on()
        {
            return glbfrmFanCoil.isNTC1On();
        }

        static public Boolean isNTC2on()
        {
            return glbfrmFanCoil.isNTC2On();
        }

        static int Livello;

        static public void setLivello(int l) { Livello = l; }
        static public int getLivello() { return Livello; }

    }

}
