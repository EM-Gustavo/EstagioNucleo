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
            if (EhDoTipoEntrada(item))
            {
                var itemEntrada = (MovimentacaoDeEntrada)item;
                itemEntrada.Id = DBHelper.Instancia.ObtenhaProximoId("MVEID", "TBMOVENTRADAS");

                var sql = "INSERT INTO TBMOVENTRADAS(MVEID, MVEDATA, MVETOTGERAL, MVEFORNID) VALUES (@MVEID, @MVEDATA, @MVETOTGERAL, @MVEFORNID)";
                using (var cmd = DBHelper.Instancia.CrieComando(sql))
                {
                    cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@MVEID", itemEntrada.Id ));
                    cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@MVEDATA", Convert.ToInt32(formatarDataEmInt(item.Data))));
                    cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@MVETOTGERAL", itemEntrada.ValorTotal));
                    cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@MVEFORNID", itemEntrada.Fornecedor.Id));
                    cmd.ExecuteNonQuery();
                }

                sql = "INSERT INTO TBMOVENTRADAITENS(MVEITID, MVEITPRDOID, MVEITQUANT, MVEITVALOR, MVEITTOTAL) VALUES(@MVEITID, @MVEITPRDOID, @MVEITQUANT, @MVEITVALOR, @MVEITTOTAL)";
                foreach (var itens in itemEntrada.Itens)
                {
                        using (var cmd = DBHelper.Instancia.CrieComando(sql))
                        {
                        cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@MVEITID", itemEntrada.Id));
                        cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@MVEITPRDOID", itens.Produto.Id ));
                        cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@MVEITQUANT", itens.Quantidade));
                        cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@MVEITVALOR", itens.ValorUnitario));
                        cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@MVEITTOTAL", itens.ValorMovimentacao));
                        cmd.ExecuteNonQuery();
                    }
                }

            }
        }

        private bool EhDoTipoEntrada(MovimentacaoDeEstoqueAbstrato item)
        {
            var entrada = new MovimentacaoDeEntrada();
            return item.GetType() == entrada.GetType();
        }

        private bool EhDoTipoSaida(MovimentacaoDeEstoqueAbstrato item)
        {
            var saida = new MovimentacaoSaida();
            return item.GetType() == saida.GetType();
        }

        private int formatarDataEmInt(DateTime data)
        {
            var dataFormatada = data.Day.ToString();
            dataFormatada += data.Month.ToString();
            dataFormatada += data.Year.ToString();

            return Convert.ToInt32(dataFormatada);
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
