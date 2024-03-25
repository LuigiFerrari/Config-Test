using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace configuratore
{
    public class clsRxBuffer
    {
        byte[] rxBuffer;
        int Indice;

        public clsRxBuffer()
        {
            rxBuffer = new byte[512];
            Indice = 0;
        }

        public void  addByte(byte b)
        {
            if (Indice >= 0)
            {
                if (Indice == 1 && b != 123)
                { // messaggio non valido
                    ResetIndice();
                }
                else
                {
                    rxBuffer[Indice] = b;
                    Indice++;
                }
            }
        }

        public void primoDato(byte b) {
            rxBuffer[0] = b;
            Indice = 1;
        }

        public int getIndice() { return Indice;  }

        public void ResetIndice() {  Indice = -1; }

        public byte[] getRxBuffer() { return rxBuffer; }
    }
}
