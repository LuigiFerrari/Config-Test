using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace configuratore
{

    // questa classe contiene i dti di formattazione dei
    // dati di stato
    // essa è in ordine progressico concordemente con i valori
    // da visualizzare nella frmStatoCassette

    struct sRecVakue
    {
        // il size del dato è sempre 3 byte
        // se è una stinga 
        public int decimali;    // numero di cifre comprese quelle a destra della vrgola es 34,2 ->1
        public char type;       // tipo On/Off Valore 
    }
    internal class tblCassetteStatus
    {
        
    }
}
