using System;
using System.Collections.Generic;
using System.Text;

namespace Loter
{
    class GameSelect
    {
        public string nomeJogo { get; set; }
        public int qtdDezPadrao { get; set; }

        public GameSelect()
        {

        }
        public GameSelect(string nomeJogo, int qtdDezPadrao)
        {
            this.nomeJogo = nomeJogo;
            this.qtdDezPadrao = qtdDezPadrao;
        }

        public List<int> item { get; set; }
    }
}
