using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estagio.Nucleo
{
    public abstract class MovimentacaoDeEstoqueAbstrato
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public List<ItemMovimentacao> Itens { get; set; }
        public decimal ValorTotal
        {
            get
            {
                var total = Itens.Sum(i => i.ValorMovimentacao);
                return total;
            }
        }     

    }
}
