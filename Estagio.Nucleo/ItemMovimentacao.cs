using System.Collections.Generic;

namespace Estagio.Nucleo
{
    public class ItemMovimentacao
    {
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
        public Produto Produto { get; private set; }
        public decimal ValorMovimentacao { get
            {
                return Quantidade * ValorUnitario;
            }
        }


    }
}