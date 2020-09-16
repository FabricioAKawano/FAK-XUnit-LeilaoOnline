using FAK.LeilaoOnline.Core;
using System;
using Xunit;

namespace FAK.LeilaoOnline.Tests
{
    public class LanceConstrutor
    {
        [Fact]
        public void RetornaExceptionDadoUmaValorNegativoNaCriacaoDoLance()
        {
            //Arrange            

            //Assert
            var excecaoObtida = Assert.Throws<InvalidOperationException>(
                //Action
                () => new Lance(null, -100)
                );
            Assert.Equal("Lance inválido.", excecaoObtida.Message);
        }
    }
}
