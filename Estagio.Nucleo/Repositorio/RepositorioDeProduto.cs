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

            var sql = @"INSERT INTO TBPRODUTOS (PRODID, PRODDESCRICAO, PRODPRCUNITARIO, PRODQTDMINIMA) VALUES(@PRODID,@PRODDESCRICAO,@PRODPRCUNITARIO,@PRODQTDMINIMA)";
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
            var produto = new Produto();

            var sql = "SELECT PRODID, PRODDESCRICAO, PRODPRCUNITARIO, PRODQTDMINIMA FROM TBPRODUTOS WHERE PRODID = @PRODID";
            using (var cmd = DBHelper.Instancia.CrieComando(sql))
            {
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@PRODID", Id));
                using (DBDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        produto.Id = dr.GetInteger("PRODID");
                        produto.Descricao = dr.GetString("PRODDESCRICAO");
                        produto.PrecoUnitario = dr.GetDecimal("PRODPRCUNITARIO");
                        produto.QuantidadeMinimaEstoque = dr.GetInteger("PRODQTDMINIMA");
                    }
                }
            }
            return produto;
        }

        public void UpDate(Produto item)
        {
            var sql = "UPDATE TBPRODUTOS SET PRODDESCRICAO = @PRODDESCRICAO, PRODPRCUNITARIO = @PRODPRCUNITARIO, PRODQTDMINIMA = @PRODQTDMINIMA WHERE PRODID = @PRODID";
            using (var cmd = DBHelper.Instancia.CrieComando(sql))
            {
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@PRODID", item.Id));
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@PRODDESCRICAO", item.Descricao));
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@PRODPRCUNITARIO", item.PrecoUnitario));
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@PRODQTDMINIMA", item.QuantidadeMinimaEstoque));
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Produto> GetAll()
        {
            var produtos = new List<Produto>();

            var sql = "SELECT PRODID, PRODDESCRICAO, PRODPRCUNITARIO, PRODQTDMINIMA FROM TBPRODUTOS";
            using (var cmd = DBHelper.Instancia.CrieComando(sql))
            {
                using (DBDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var produto = new Produto();
                        produto.Id = dr.GetInteger("PRODID");
                        produto.Descricao = dr.GetString("PRODDESCRICAO");
                        produto.PrecoUnitario = dr.GetDecimal("PRODPRCUNITARIO");
                        produto.QuantidadeMinimaEstoque = dr.GetInteger("PRODQTDMINIMA");
                        produtos.Add(produto);
                    }
                }
            }
            return produtos;
        }
    }
}
