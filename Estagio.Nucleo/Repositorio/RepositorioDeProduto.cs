using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estagio.Nucleo.Repositorio
{
    public class RepositorioDeProduto : IRepositorio<Produto>
    {
        public static readonly RepositorioDeProduto Instancia = new RepositorioDeProduto();

        private RepositorioDeProduto()
        {

        }

        public void Add(Produto item)
        {
            item.Id = DBHelper.Instancia.ObtenhaProximoId("PRODID", "TBPRODUTOS");

            var sql = @"INSERT INTO TBPRODUTOS (PRODID, PRODDESCRICAO, PRODPRCUNITARIO, PRODQTDMINIMA)
 VALUES(@PRODID,@PRODDESCRICAO,@PRODPRCUNITARIO,@PRODQTDMINIMA)";
            using (var cmd = DBHelper.Instancia.CrieComando(sql))
            {
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@PRODID", item.Id));
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@PRODDESCRICAO", item.Descricao));
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@PRODPRCUNITARIO", item.PrecoUnitario));
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@PRODQTDMINIMA", item.QuantidadeMinimaEstoque));
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(Produto item)
        {
            var sql = "DELETE FROM TBPRODUTOS WHERE PRODID = @PRODID";
            using (var cmd = DBHelper.Instancia.CrieComando(sql))
            {
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@PRODID", item.Id));
                cmd.ExecuteNonQuery();
            }
        }

        public Produto GetById(int Id)
        {
            return null;
        }

        public void UpDate(Produto item)
        {
        }

        public IEnumerable<Produto> GetAll()
        {
            return null;
        }


    }
}
