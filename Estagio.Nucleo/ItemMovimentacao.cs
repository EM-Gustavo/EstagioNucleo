using System.Collections.Generic;

namespace Estagio.Nucleo
{
    public class ItemMovimentacao
    {
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
        public Produto Produto { get; set; }
        public decimal ValorMovimentacao { get
            {
                return Quantidade * ValorUnitario;
            }
        }

        public void RecebeProduto(Produto produto)
        {
            Produto = produto;
        }


    }
}