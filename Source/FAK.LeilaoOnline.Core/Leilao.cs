using System;
using System.Collections.Generic;
using System.Linq;

namespace FAK.LeilaoOnline.Core
{
    public class Leilao
    {
        private IList<Lance> _lances;
        private Interessada _interessadaUltimoLance;        
        private readonly IModalidadeAvaliacao _avaliador;

        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; set; }
        public EstadoLeilao Estado { get; private set; }


        public Leilao(string peca, IModalidadeAvaliacao avaliador)
        {
            Peca = peca;
            _lances = new List<Lance>();
            Estado = EstadoLeilao.LeilaoAntesDoPregao;
            _avaliador = avaliador;
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            if (NovoLanceEhAceito(cliente))
            {
                _lances.Add(new Lance(cliente, valor));
                _interessadaUltimoLance = cliente;
            }
        }

        private bool NovoLanceEhAceito(Interessada cliente)
        {
            return Estado == EstadoLeilao.LeilaoEmAndamento && cliente != _interessadaUltimoLance;
        }

        public void IniciaPregao()
        {
            Estado = EstadoLeilao.LeilaoEmAndamento;
        }

        public void TerminaPregao()
        {
            if (Estado != EstadoLeilao.LeilaoEmAndamento)
            {
                throw new InvalidOperationException("Pregão não iniciado");
            }

            Ganhador = _avaliador.Avaliar(this);
            Estado = EstadoLeilao.LeilaoFinalizado;
        }
    }

    public enum EstadoLeilao
    {
        LeilaoAntesDoPregao,
        LeilaoEmAndamento,
        LeilaoFinalizado
    }
}
