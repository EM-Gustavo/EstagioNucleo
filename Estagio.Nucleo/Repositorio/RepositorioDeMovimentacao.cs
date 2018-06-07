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

        private List<MovimentacaoDeEstoqueAbstrato> _movimentacaoDeEstoqueAbstratos = new List<MovimentacaoDeEstoqueAbstrato>();

        public void Add(MovimentacaoDeEstoqueAbstrato item)
        {
            _movimentacaoDeEstoqueAbstratos.Add(item);
        }

        public void Delete(MovimentacaoDeEstoqueAbstrato item)
        {
            _movimentacaoDeEstoqueAbstratos.Remove(item);
        }

        public IEnumerable<MovimentacaoDeEstoqueAbstrato> GetAll()
        {
            return _movimentacaoDeEstoqueAbstratos;
        }

        public MovimentacaoDeEstoqueAbstrato GetById(int id)
        {
            return _movimentacaoDeEstoqueAbstratos.Find(x => x.Id == id);
        }

        public void UpDate(MovimentacaoDeEstoqueAbstrato item)
        {
            _movimentacaoDeEstoqueAbstratos.Remove(GetById(item.Id));
            _movimentacaoDeEstoqueAbstratos.Add(item);
        }
    }
}
