using System;
using System.Collections.Generic;
using System.Text;

namespace FAK.LeilaoOnline.Core
{
    public class Lance
    {
        private Interessada Cliente { get; }
        private decimal Valor { get; }

        public Lance(Interessada cliente, decimal valor)
        {
            Cliente = cliente;
            Valor = valor;
        }
    }
}
