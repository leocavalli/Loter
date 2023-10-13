using System;
using System.Collections.Generic;
using System.Text;

namespace Loter
{
    class TopNumber
    {
        public Dezenas par { get; set; }
        public int repeticao { get; set; }

        public TopNumber(Dezenas vPar, int vRepeticao)
        {
            this.par = vPar;
            this.repeticao = vRepeticao;
        }
    }
}
