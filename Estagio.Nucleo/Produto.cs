using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estagio.Nucleo
{
    public class Produto : ICloneable
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeMinimaEstoque { get; set; }
        public decimal PrecoUnitario { get; set; }

        public object Clone()
        {
            return new Produto
            {
                Id = this.Id,
                Descricao = this.Descricao,
                QuantidadeMinimaEstoque = this.QuantidadeMinimaEstoque,
                PrecoUnitario = this.PrecoUnitario
            };
        }

        public override bool Equals(object obj)
        {
            return obj is Produto produto && produto.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override string ToString()
        {
            return Descricao;
        }

    }


}
