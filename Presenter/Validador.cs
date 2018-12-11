using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentador
{
    class Validador
    {
        public String stringVacioNullColocarSinInformacion(string value)
        {
            if (String.IsNullOrEmpty(value))
                return "sin información";
            return value;
        }

        public void StringNoNullVacio(string value, string value2)
        {
            if (String.IsNullOrEmpty(value)) throw new ArgumentException
                (value2);
        }
        
        public void comprobarIntNoNegativo(int value, string value2)
        {
                if (value < 0) throw new ArgumentException(value2);
        }


    }
}
