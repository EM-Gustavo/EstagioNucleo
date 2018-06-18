using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estagio.Nucleo.Repositorio
{
    public class RepositorioDeCliente : IRepositorio<Cliente>
    {
        public static readonly RepositorioDeCliente Instancia = new RepositorioDeCliente();

        private RepositorioDeCliente()
        {

        }

        public void Add(Cliente item)
        {
            item.Id = DBHelper.Instancia.ObtenhaProximoId("CLIEID", "TBCLIENTES");

            var sql = "INSERT INTO TBCLIENTES (CLIEID, CLIENOME, CLIECPFCNPJ) VALUES (@CLIEID, @CLIENOME, @CLIECPFCNPJ)";
            using (var cmd = DBHelper.Instancia.CrieComando(sql))
            {
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@CLIEID", item.Id));
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@CLIENOME", item.Nome));
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@CLIECPFCNPJ", item.CPFCNPJ.Numero));
                cmd.ExecuteNonQuery();
            }
        }



        public void Delete(Cliente item)
        {
            var sql = "DELETE FROM TBCLIENTES WHERE CLIEID = @CLIEID";
            using (var cmd = DBHelper.Instancia.CrieComando(sql))
            {
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@CLIEID", item.Id));
                cmd.ExecuteNonQuery();
            }
        }

        public Cliente GetById(int Id)
        {
            var cliente = new Cliente();

            var sql = "SELECT CLIEID, CLIENOME, CLIECPFCNPJ FROM TBCLIENTES WHERE CLIEID = @CLIEID";
            using (var cmd = DBHelper.Instancia.CrieComando(sql))
            {
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@CLIEID", Id));
                using (DBDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        cliente.Id = dr.GetInteger("CLIEID");
                        cliente.Nome = dr.GetString("CLIENOME");
                        cliente.CPFCNPJ = new CPFCNPJ(dr.GetString("CLIECPFCNPJ"));
                    }
                }
            }
            return cliente;
        }

        public void UpDate(Cliente item)
        {
            var sql = "UPDATE TBCLIENTES SET CLIENOME = @CLIENOME, CLIECPFCNPJ = @CLIECPFCNPJ WHERE CLIEID = @CLIEID";
            using (var cmd = DBHelper.Instancia.CrieComando(sql))
            {
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@CLIEID", item.Id));
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@CLIENOME", item.Nome));
                cmd.Parameters.Add(DBHelper.Instancia.CrieParametro("@CLIECPFCNPJ", item.CPFCNPJ.Numero));
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Cliente> GetAll()
        {
            var clientes = new List<Cliente>();

            var sql = "SELECT CLIEID, CLIENOME, CLIECPFCNPJ FROM TBCLIENTES";
            using (var cmd = DBHelper.Instancia.CrieComando(sql))
            {
                using (DBDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var cliente = new Cliente();
                        cliente.Id = dr.GetInteger("CLIEID");
                        cliente.Nome = dr.GetString("CLIENOME");
                        cliente.CPFCNPJ = new CPFCNPJ(dr.GetString("CLIECPFCNPJ"));
                        clientes.Add(cliente);
                    }
                }
            }
            return clientes;
        }
    }
}
