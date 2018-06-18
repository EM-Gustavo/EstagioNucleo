using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estagio.Nucleo.Repositorio
{
    public class RepositorioDeFornecedor : IRepositorio<Fornecedor>
    {
        public static readonly RepositorioDeFornecedor Instancia = new RepositorioDeFornecedor();

        private RepositorioDeFornecedor()
        {

        }

        public void Add(Fornecedor item)
        {
            item.Id = DBHelper.Instancia.ObtenhaProximoId("FORNID", "TBFORNECEDORES");

            var sql = "INSERT INTO TBFORNECEDORES (FORNID, FORNNOME, FORNCPFCNPJ) VALUES (@FORNID, @FORNNOME, @FORNCPFCNPJ)";
            using (var cmd = DBHelper.Instancia.CrieComando(sql))
            {
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@FORNID", item.Id));
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@FORNNOME", item.Nome));
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@FORNCPFCNPJ", item.CPFCNPJ.Numero));
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(Fornecedor item)
        {
            var sql = "DELETE FROM TBFORNECEDORES WHERE FORNID = @FORNID";
            using (var cmd = DBHelper.Instancia.CrieComando(sql))
            {
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@FORNID", item.Id));
                cmd.ExecuteNonQuery();
            }
        }

        public Fornecedor GetById(int Id)
        {
            var fornecedor = new Fornecedor();

            var sql = "SELECT FORNID, FORNNOME, FORNCPFCNPJ FROM TBFORNECEDORES WHERE FORNID = @FORNID";
            using (var cmd = DBHelper.Instancia.CrieComando(sql))
            {
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@FORNID", Id));
                using (DBDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        fornecedor.Id = dr.GetInteger("FORNID");
                        fornecedor.Nome = dr.GetString("FORNNOME");
                        fornecedor.CPFCNPJ = new CPFCNPJ(dr.GetString("FORNCPFCNPJ"));
                    }
                }
            }
            return fornecedor;
        }

        public void UpDate(Fornecedor item)
        {
            var sql = "UPDATE TBFORNECEDORES SET FORNNOME = @FORNNOME, FORNCPFCNPJ = @FORNCPFCNPJ WHERE FORNID = @FORNID";
            using (var cmd = DBHelper.Instancia.CrieComando(sql))
            {
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@FORNID", item.Id));
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@FORNNOME", item.Nome));
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@FORNCPFCNPJ", item.CPFCNPJ.Numero));
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Fornecedor> GetAll()
        {
            var fornecedores = new List<Fornecedor>();

            var sql = "SELECT FORNID, FORNNOME, FORNCPFCNPJ FROM TBFORNECEDORES";
            using (var cmd = DBHelper.Instancia.CrieComando(sql))
            {
                using (DBDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var fornecedor = new Fornecedor();
                        fornecedor.Id = dr.GetInteger("FORNID");
                        fornecedor.Nome = dr.GetString("FORNNOME");
                        fornecedor.CPFCNPJ = new CPFCNPJ(dr.GetString("FORNCPFCNPJ"));
                        fornecedores.Add(fornecedor);
                    }
                }
            }
            return fornecedores;
        }
    }   
}
