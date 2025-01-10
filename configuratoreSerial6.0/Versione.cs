using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace configuratore
{
    class Versione
    {
        const string vernum = "0.0.50";
        const string PCrelease = "0.0.050";
#if (DEBUG)
        const string debug = " (DEBUG) ";
#else
        const string debug ="";
#endif
        static string versioneStr = "Roccheggiani Rev. " + vernum + " " + debug;

        static public string versioneStrForm()
        {
            versioneStr = "Rev. " + PCrelease + " "+debug; //  + " Administrator";
            return versioneStr;
        }

        static public string getVersion()
        {
            // if (password.passwordOn() == true)
            versioneStr = "Rev. " + PCrelease + debug; //  + " Administrator";
            return versioneStr;
        }
    }
    // 0001 implementata apertura finestra da remoto

}
