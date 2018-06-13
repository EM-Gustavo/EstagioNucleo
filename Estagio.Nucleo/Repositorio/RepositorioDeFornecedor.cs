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

        private List<Fornecedor> _fornecedores = new List<Fornecedor>();

        public void Add(Fornecedor item)
        {
            _fornecedores.Add(item);
        }

        public void Delete(Fornecedor item)
        {
            _fornecedores.Remove(item);
        }

        public IEnumerable<Fornecedor> GetAll()
        {
            return _fornecedores;
        }

        public Fornecedor GetById(int Id)
        {
            return _fornecedores.Find(x => x.Id == Id);
        }

        public void UpDate(Fornecedor item)
        {
            _fornecedores.Remove(GetById(item.Id));
            _fornecedores.Add(item);
        }
    }
}
