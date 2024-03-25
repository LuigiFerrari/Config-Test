using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace configuratore
{
    // 

   
    public struct sVerdins
    {
        public int MM;
        public int Mm;
        public int mm;
    }
    internal class statusWinddows
    {
        // stato finestre

        static Boolean[] finestraAperta = new Boolean[4];

        static sVerdins versioni;
        static public  void initData()
        {
                versioni.MM = 0;
                versioni.Mm = 0;
                versioni.mm = 0;

            for(int i=0;i<4;i++)
            {
                finestraAperta[i] = false;
            }
        }

        static public void setFinestraAperta(int fin)
        {
            finestraAperta[fin] = true;
        }

        static public void clrFinestraAperta(int fin)
        {
            finestraAperta[fin] = false;
        }

        static public Boolean tstFinestraAperta(int fin)
        {
            return finestraAperta[fin];
        }

        static public void setVersion(sVerdins v)
        {
            versioni = v;
        }    
    }
}
