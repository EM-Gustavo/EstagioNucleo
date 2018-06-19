using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estagio.Nucleo.Repositorio
{
    public class RepositorioDeMovimentacao : IRepositorio<MovimentacaoDeEstoqueAbstrato>
    {
        public static readonly RepositorioDeMovimentacao Instancia = new RepositorioDeMovimentacao();
        
        private RepositorioDeMovimentacao()
        {
        }

        public void Add(MovimentacaoDeEstoqueAbstrato item)
        {
            item.Id = DBHelper.Instancia.ObtenhaProximoId("KEYMVEID", "TBMOVENTRADA");

            var sql = @"INSERT INTO TBMOVENTRADA (KEYMVEID, MVEQUANTIDADE, MVEVALOR, MVETOTAL, MVEDATA, MVEPRODID, MVEFORNID) VALUES ( @KEYMVEID, @MVEQUANTIDADE, @MVEVALOR, @MVETOTAL, @MVEDATA,  @MVEPRODID, @MVEFORNID)";
            using (var cmd = DBHelper.Instancia.CrieComando(sql))
            {
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@KEYMVEID", item.Id));
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@MVEQUANTIDADE", item.ItemMovimentacao.Quantidade));
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@MVEVALOR", item.ItemMovimentacao.ValorUnitario));
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@MVETOTAL", item.ItemMovimentacao.ValorMovimentacao));
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@MVEDATA", item.Data));
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@MVEPRODID", item.ItemMovimentacao.Produto.Id));
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@MVEFORNID", 2));
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(MovimentacaoDeEstoqueAbstrato item)
        {
            
        }

        public IEnumerable<MovimentacaoDeEstoqueAbstrato> GetAll()
        {
            return null;
        }

        public MovimentacaoDeEstoqueAbstrato GetById(int id)
        {
            return null;
        }

        public void UpDate(MovimentacaoDeEstoqueAbstrato item)
        {

        }
    }
}
