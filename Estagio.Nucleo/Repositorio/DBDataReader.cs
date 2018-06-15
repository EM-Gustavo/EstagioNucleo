using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estagio.Nucleo.Repositorio
{
    public class DBDataReader : IDisposable
    {
        private readonly DbConnection _conexao;
        private readonly DbDataReader _dataReader;
        private readonly int _maxRows;
        private int _rowsRead;

        public DBDataReader(DbConnection conexao, DbDataReader dataReader, int maxRows)
        {
            _conexao = conexao;
            _dataReader = dataReader;

            _maxRows = maxRows;
            _rowsRead = 0;
        }

        public int FieldCount => _dataReader.FieldCount;

        #region IDisposable Members

        public void Dispose()
        {
            if (!_dataReader.IsClosed) _dataReader.Close();
            if (_conexao != null && _conexao.State != ConnectionState.Closed) _conexao.Close();
        }

        #endregion

        ~DBDataReader()
        {
            try
            {
                Dispose();
            }
            catch
            {
            }
        }

        public int GetInteger(string name)
        {
            var value = GetValue(name);
            if (value == null || value is DBNull)
                return 0;

            return Convert.ToInt32(value);
        }

        public long GetInteger64(string name)
        {
            var value = GetValue(name);
            if (value == null || value is DBNull)
                return 0;

            return Convert.ToInt64(value);
        }

        public decimal GetDecimal(string name)
        {
            var value = GetValue(name);
            if (value == null || value is DBNull)
                return 0;
            return Convert.ToDecimal(value);
        }


        public string GetString(string name)
        {
            var value = GetValue(name);
            if (value == null || value is DBNull)
                return string.Empty;

            return Convert.ToString(value);
        }

        //public bool GetCharToBoolean(string name)
        //{
        //    var value = GetValue(name);
        //    if (value == null || value is DBNull)
        //        return false;

        //    return Convert.ToString(value) == "S";
        //}

        //public DateTime GetDateTime(string name)
        //{
        //    var value = GetValue(name);
        //    var DataNula = new DateTime();

        //    if (value == null || value is DBNull)
        //        return DataNula;

        //    if (value is DateTime)
        //        return (DateTime)value;

        //    if (value is TimeSpan)
        //        return new DateTime(((TimeSpan)value).Ticks);

        //    if (value is int)
        //        return GetIntegerToDate(name);

        //    return DataNula;
        //}

        public string GetName(int ordinal)
        {
            return _dataReader.GetName(ordinal);
        }

        public object GetValue(int ordinal)
        {
            return _dataReader.GetValue(ordinal);
        }

        public object GetValue(string name)
        {
            try
            {
                return _dataReader.GetValue(_dataReader.GetOrdinal(name));
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException("Não foi possível encontrar o campo " + name + " - " + ex.Message);
            }
        }

        public bool ContainsField(string name)
        {
            for (var i = 0; i < _dataReader.FieldCount; i++)
            {
                if (string.Equals(_dataReader.GetName(i), name, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        public Type GetFieldType(string name)
        {
            return _dataReader.GetFieldType(_dataReader.GetOrdinal(name));
        }

        public bool IsNull(string name)
        {
            return _dataReader.IsDBNull(_dataReader.GetOrdinal(name));
        }

        public bool Read()
        {
            var leuRegistro = DoRead();

            if (!leuRegistro)
            {
                _conexao?.Close();
            }

            return leuRegistro;
        }

        private bool DoRead()
        {
            if (_dataReader.IsClosed)
                return false;

            if (_maxRows > 0 && (_rowsRead++ == _maxRows))
                return false;

            return _dataReader.Read();
        }


        public decimal? GetDecimalNullable(string name)
        {
            var value = GetValue(name);
            if (value == null || value is DBNull)
                return null;
            return Convert.ToDecimal(value);
        }

        public int? GetIntegerNullable(string name)
        {
            var value = GetValue(name);
            if (value == null || value is DBNull)
                return null;
            return Convert.ToInt32(value);
        }

        public long? GetInteger64Nullable(string name)
        {
            var value = GetValue(name);
            if (value == null || value is DBNull)
                return null;
            return Convert.ToInt64(value);
        }

        public byte[] GetBytes(string name)
        {
            var ordinal = _dataReader.GetOrdinal(name);
            if (_dataReader.IsDBNull(ordinal))
                return null;
            return (byte[])_dataReader[ordinal];
        }

        public static implicit operator DBDataReader(DbDataReader dataReader)
        {
            return new DBDataReader(null, dataReader, 0);
        }
    }
}
