using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estagio.Nucleo.Repositorio
{
    public interface IRepositorio<T>
    {
        void Add(T item);
        void Delete(T item);
        void UpDate(T item);
        IEnumerable<T> GetAll();
        T GetById(int id);

    }
}
