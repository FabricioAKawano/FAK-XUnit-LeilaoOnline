using FAK.LeilaoOnline.Core;
using System.Linq;
using Xunit;

namespace FAK.LeilaoOnline.Tests
{
    public class LeilaoRecebeLance
    {
        [Theory]
        [InlineData(4, new double[] { 40, 43, 46, 48 })]
        [InlineData(2, new double[] { 86, 95 })]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int quantidadeEsperada, double[] ofertas)
        {
            //Arrange
            IModalidadeAvaliacao modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var jose = new Interessada("José", leilao);
            var maria = new Interessada("Maria", leilao);
            leilao.IniciaPregao();
            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i % 2) == 0)
                {
                    leilao.RecebeLance(jose, valor);
                }
                else
                {
                    leilao.RecebeLance(maria, valor);
                }
            }
            leilao.TerminaPregao();

            //Action
            leilao.RecebeLance(jose, 1000);

            //Assert
            Assert.Equal(quantidadeEsperada, leilao.Lances.Count());
        }

        [Fact]
        public void NaoAceitaProximoLanceDadoMesmoClienteRealizouUltimoLance()
        {
            //Arrange
            IModalidadeAvaliacao modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var jose = new Interessada("José", leilao);
            leilao.IniciaPregao();

            //Action
            for (int i = 0; i < 2; i++)
            {
                leilao.RecebeLance(jose, i * 100);
            }

            //Assert
            Assert.Equal(1, leilao.Lances.Count());
        }

    }
}
