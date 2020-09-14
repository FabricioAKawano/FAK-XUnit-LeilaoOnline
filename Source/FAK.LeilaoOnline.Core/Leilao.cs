using System;
using System.Collections.Generic;
using System.Text;

namespace FAK.LeilaoOnline.Core
{
    public class Leilao
    {
        private IList<Lance> _lances;
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get;}

        public Leilao(string peca)
        {
            Peca = peca;
        }

        public void RecebeLance(Interessada cliente, decimal valor)
        {
            _lances.Add(new Lance(cliente, valor));
        }

        public void IniciaPregao()
        {

        }

        public void TerminaPregao()
        {

        }
    }
}
