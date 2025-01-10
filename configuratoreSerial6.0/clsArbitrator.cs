using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace configuratore
{
    internal class clsArbitrator
    {
        static int esecuzione;

        static int doNotLoop;

        static int abilitaMandata;

        static int riabilitaBottoni;

        static int loadingParameter;

        static int doNotLooop2;

        static int Primario; // dispositivo primario;
        static int FormAperta; // aperta una form da MasterNetwork

        static public void setFinestraAperta()
        {
            FormAperta = 1;
        }

        static public void clsFinestraAperta()
        {
            FormAperta = 0;
        }

        static public Boolean isFinestraAperta() { return FormAperta == 1;  }

        static int onClosing;

        static public void setOnClosing()
        {
            onClosing = 1;
        }

        static public void clrOnClosing()
        {
            onClosing = 0;
        }

        static public Boolean isOnClosing()
        {
            return (onClosing == 1);
        }

        static public void setPrimario()
        {
            Primario = 1;
        }

        static public void clrPrimario()
        {
            Primario = 0;
        }

        static public int getPrimario() { return Primario; }


        static public void setDoNotLoop2()
        {
            doNotLooop2 = 1;
        }

        static public void clrDoNotLoop2()
        {
            doNotLooop2 = 0;
        }

        static public Boolean isDoNotLoop2()
        {
            return (doNotLooop2 == 1);
        }

        static public Boolean isDoNotLoop1or2()
        {
            return ((doNotLooop2 == 1) || (doNotLoop == 1));
        }

        static public void setEsecuzione()
        {
            esecuzione = 1;
        }
        static public void clrEsecuzione()
        {
            esecuzione = 0;
        }
        static public Boolean isInEsecuzione()
        {
            return (esecuzione == 1);
        }


        static public void setDoNotLoop()
        {
            doNotLoop = 1;
        }
        static public void clrDoNotLoop()
        {
            doNotLoop = 0;
        }
        static public Boolean isDoNotLoop()
        {
            return (doNotLoop == 1);
        }

        static public void setAbilitaMandata()
        {
            abilitaMandata = 1;
        }
        static public void clrAbilitaMandata()
        {
            abilitaMandata = 0;
        }
        static public Boolean isAbilitaMandata()
        {
            return (abilitaMandata == 1);
        }

        static public void setriabilitaBottoni()
        {
            riabilitaBottoni = 1;
        }

        static public void clrriabilitaBottoni()
        {
            riabilitaBottoni = 0;
        }

        static public Boolean isriabilitaBottoni()
        {
            return(riabilitaBottoni ==1);
        }

        static public void setLoadingParameter()
        {
            loadingParameter = 1;
        }
        static public void clrLoadingParameter()
        {
            loadingParameter = 0;
        }

        static public Boolean isLoadingParameter()
        {
            return (loadingParameter == 1);
        }
    }
}
