using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estagio.Nucleo
{
    class MovimentacaoDeEntrada : MovimentacaoDeEstoqueAbstrato
    {
        public Fornecedor Fornecedor { get; set; }
    }
}
