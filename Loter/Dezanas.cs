using System;
using System.Collections.Generic;
using System.Text;

namespace Loter
{
    class Dezenas
    {
        public int dezena { get; set; }
        public int quantidade { get; set; }

        public Dezenas()
        {

        }
        public Dezenas(int i, int q)
        {
            this.dezena = i;
            this.quantidade = q;
        }

        public override bool Equals(object o)
        {
            if (o is Dezenas)
            {
                Dezenas cli = (Dezenas)o;
                if (this.dezena == cli.dezena && this.quantidade == cli.quantidade)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
