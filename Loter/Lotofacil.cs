using System;
using System.Collections.Generic;
using System.Text;

namespace Loter
{
    class Lotofacil
    {
        public int listaPares { get; set; }
        public int listaImpares { get; set; }

        public Lotofacil()
        {

        }
        public Lotofacil(int vListaPares, int vListaImpares)
        {
            this.listaPares = vListaPares;
            this.listaImpares = vListaImpares;
        }

        public override bool Equals(object o)
        {
            if (o is Lotofacil)
            {
                Lotofacil cli = (Lotofacil)o;
                if (this.listaPares == cli.listaPares && this.listaImpares == cli.listaImpares)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
