using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estagio.Nucleo.Repositorio
{
    internal class DBHelper
    {
        public readonly static DBHelper Instancia = new DBHelper();

        private DBHelper()
        {
        }

        public DbConnection CrieConexao()
        {
            var sbConnection = new FbConnectionStringBuilder();
            sbConnection.Database = @"D:\WorkGustavo\BancoDeDados\BDESTAGIO.FDB";
            sbConnection.DataSource = "localhost";
            sbConnection.UserID = "sysdba";
            sbConnection.Password = "masterkey";
            var cn = new FbConnection(sbConnection.ToString());
            cn.Open();
            return cn;
        }

        public DbCommand CrieComando(string sql)
        {
            var cn = CrieConexao();
            var cmd = cn.CreateCommand();
            cmd.CommandText = sql;
            return cmd;
        }

        public DbParameter CrieParametro(string nome, object valor)
        {
            return new FbParameter(nome, valor);
        }


        public int ObtenhaProximoId(string campoId, string nomeTabela)
        {
            var sql = $"SELECT MAX({campoId}) FROM {nomeTabela}";
            using (var cmd = DBHelper.Instancia.CrieComando(sql))
            {
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return dr.GetInt32(0) + 1;
                    }
                }
            }
            return 1;
        }
    }
}
