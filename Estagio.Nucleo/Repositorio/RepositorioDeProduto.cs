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

        private RepositorioDeProduto() {
               
        }

        private List<Produto> _produtos = new List<Produto>();

        public IEnumerable<Produto> Produtos => _produtos.AsReadOnly();



        public void Add(Produto item)
        {
            if (_produtos.Contains(item))
            {
                throw new ApplicationException("Produto já existente");
            }
            _produtos.Add(item);
        }

        public void Delete(Produto item)
        {
            _produtos.Remove(item);
        }

        public Produto GetById(int Id)
        {
            return _produtos.Find( x => x.Id == Id);
        }

        public void UpDate(Produto item)
        {
            _produtos.Remove(GetById(item.Id));
            _produtos.Add(item);
        }

        public IEnumerable<Produto> GetAll()
        {
            return _produtos;
        }


    }
}
