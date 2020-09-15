using FAK.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FAK.LeilaoOnline.Tests
{
    public class LeilaoTestes
    {
        [Theory]
        [InlineData(1455, new double[] { 850, 950, 985, 1055, 1455 })]
        [InlineData(1455, new double[] { 850, 950, 985, 1455, 1055 })]
        [InlineData(850, new double[] {850})]
        public void LelilaoComVariosLances(double valorEsperado, double[] ofertas)
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            var jose = new Interessada("José", leilao);
            foreach (var item in ofertas)
            {
                leilao.RecebeLance(jose, item);
            }

            //Action
            leilao.TerminaPregao();

            //Assert
            Assert.Equal(valorEsperado, leilao.Ganhador.Valor);
        }

        [Fact]
        public void LeilaoSemLances()
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            
            //Action
            leilao.TerminaPregao();

            //Assert
            Assert.Equal(0, leilao.Ganhador.Valor);
        }

        //--------------- Testes substituidos por um unico teste "LelilaoComVariosLances" ---------------
        //[Fact]
        //public void LeilaoComTresClientes()
        //{
        //    //Arrange
        //    var leilao = new Leilao("Van Gogh");
        //    var jose = new Interessada("José", leilao);
        //    var maria = new Interessada("Maria", leilao);
        //    var joaquim = new Interessada("Joaquim", leilao);

        //    leilao.RecebeLance(jose, 850);
        //    leilao.RecebeLance(maria, 950);
        //    leilao.RecebeLance(maria, 985);
        //    leilao.RecebeLance(jose, 1055);
        //    leilao.RecebeLance(joaquim, 1455);


        //    //Action
        //    leilao.TerminaPregao();

        //    //Assert
        //    Assert.Equal(1455, leilao.Ganhador.Valor);
        //    Assert.Equal(joaquim, leilao.Ganhador.Cliente);
        //}

        //[Fact]
        //public void LeilaoComLancesOrdenadosPorValor()
        //{
        //    //Arrange
        //    var leilao = new Leilao("Van Gogh");
        //    var jose = new Interessada("José", leilao);
        //    var maria = new Interessada("Maria", leilao);

        //    leilao.RecebeLance(jose, 850);
        //    leilao.RecebeLance(maria, 950);
        //    leilao.RecebeLance(maria, 985);
        //    leilao.RecebeLance(jose, 1055);


        //    //Action
        //    leilao.TerminaPregao();

        //    //Assert
        //    Assert.Equal(1055, leilao.Ganhador.Valor);
        //}

        //[Fact]
        //public void LeilaoComVariosLances()
        //{
        //    //Arrange
        //    var leilao = new Leilao("Van Gogh");
        //    var jose = new Interessada("José", leilao);
        //    var maria = new Interessada("Maria", leilao);

        //    leilao.RecebeLance(jose, 850);
        //    leilao.RecebeLance(maria, 950);
        //    leilao.RecebeLance(jose, 1055);
        //    leilao.RecebeLance(maria, 985);


        //    //Action
        //    leilao.TerminaPregao();

        //    //Assert
        //    Assert.Equal(1055, leilao.Ganhador.Valor);
        //}

        //[Fact]
        //public void LeilaoComApenasUmLance()
        //{
        //    //Arrange
        //    var leilao = new Leilao("Van Gogh");
        //    var jose = new Interessada("José", leilao);


        //    leilao.RecebeLance(jose, 850);            

        //    //Action
        //    leilao.TerminaPregao();

        //    //Assert
        //    Assert.Equal(850, leilao.Ganhador.Valor);
        //}
    }
}
