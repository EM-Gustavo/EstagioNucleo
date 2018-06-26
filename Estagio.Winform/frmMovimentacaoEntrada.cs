using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Estagio.Nucleo;
using Estagio.Nucleo.Repositorio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Estagio.WinForm
{
    public partial class frmMovimentacaoEntrada : frmBase 
    {

        private List<ItemMovimentacaoMV> _itensSelecioandos = new List<ItemMovimentacaoMV>();

        public frmMovimentacaoEntrada()
        {
            InitializeComponent();

            if (DesignMode) return;

            dgvProdutos.AutoGenerateColumns = false;
            dgvProdutos.AllowUserToAddRows = false;
            dgvProdutos.AllowUserToDeleteRows = false;
            dgvProdutos.AllowUserToResizeColumns = false;
            dgvProdutos.AllowUserToResizeRows = false;
            dgvProdutos.ReadOnly = true;

            MonteColunas();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            AtualizeDataGridProdutos();
        }

        private class ItemMovimentacaoMV : INotifyPropertyChanged
        {
            private ItemMovimentacao _itemMovimentacao;

            public ItemMovimentacaoMV(ItemMovimentacao itemMovimentacao)
            {
                _itemMovimentacao = itemMovimentacao;
            }

            public Produto Produto { get => _itemMovimentacao.Produto; }
            public decimal PrecoUnitario { get => _itemMovimentacao.Produto.PrecoUnitario; }

            public int Quantidade
            {
                get => _itemMovimentacao.Quantidade;
                set
                {
                    if (value != _itemMovimentacao.Quantidade)
                    {
                        _itemMovimentacao.Quantidade = value;
                        OnPropertyChanged("Quantidade");
                     }
                }
            }

            public decimal ValorUnitario
            {
                get => _itemMovimentacao.ValorUnitario;
                set
                {
                    if (value != _itemMovimentacao.ValorUnitario)
                    {
                        _itemMovimentacao.ValorUnitario = value;
                        OnPropertyChanged("Valor Unitario");
                    }
                }
            }

            public decimal ValorMovimentacao { get => _itemMovimentacao.ValorMovimentacao;  }

            public event PropertyChangedEventHandler PropertyChanged;

            private void OnPropertyChanged(string prop)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
                this.PropertyChanged -= this.PropertyChanged;
            }
        }

        private void MonteColunas()
        {
            dgvProdutos.CrieColunaFill("Produtos", nameof(Produto.Descricao));
            dgvProdutos.CrieColuna("Vlr. Unitário", nameof(Produto.PrecoUnitario), 80);

            dgvItensSelecionados.CrieColunaFill("Produto", nameof(ItemMovimentacao.Produto));
            dgvItensSelecionados.CrieColuna("Vlr. Unitário", nameof(ItemMovimentacao.ValorUnitario), 80);
            dgvItensSelecionados.CrieColuna("Quantidade", nameof(ItemMovimentacao.Quantidade), 80);
            dgvItensSelecionados.CrieColuna("Subtotal", nameof(ItemMovimentacao.ValorMovimentacao), 80);
        }
        private void AtualizeDataGridProdutos()
        {
            bsProdutos.DataSource = RepositorioDeProduto.Instancia.GetAll();
            bsProdutos.ResetBindings(false);
        }

        private void AtuazaDataGridItens()
        {
            bsProdutosSelecionados.DataSource = _itensSelecioandos;
            bsProdutosSelecionados.ResetBindings(false);
        }

        private void dgvProdutos_DoubleClick(object sender, EventArgs e)
        {
            if (EhPermitidoInserir())
            {
                IsereItens();
            }
            AtuazaDataGridItens();
            AtualizeValorTotal();
        }

        private Produto SelecioneProduto()
        {
            var ProdutoSelecionado = new Produto();
            return (Produto)bsProdutos.Current;
        }

        private bool EhPermitidoInserir()
        {
            foreach (var item in _itensSelecioandos)
            {
                if (item.Produto.Id == SelecioneProduto().Id)
                {
                    item.PropertyChanged += Item_PropertyChanged;
                    item.Quantidade++;
                    return false;
                }
            }
            return true;
        }

        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            MessageBox.Show($"{e.PropertyName} foi alterada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void IsereItens()
        {
            _itensSelecioandos.Add(AdicioneUmNovoItemDeMovimentacao());
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            MovimentacaoDeEntrada _itemDeEntrada = new MovimentacaoDeEntrada();
            _itemDeEntrada.Fornecedor = ucPesquisaFornecedor1.Fornecedor;
            _itemDeEntrada.Data = dtpEntrada.Value.Date;

            _itemDeEntrada.Itens = ObtenhaItensDeEntrada();

            RepositorioDeMovimentacao.Instancia.Add(_itemDeEntrada);

            MessageBox.Show("Movimentação realizada com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimparFormulario();
        }

        private void LimparFormulario()
        {
            _itensSelecioandos.Clear();
            ucPesquisaFornecedor1.limpeTextBox();
            bsProdutosSelecionados.ResetBindings(false);
            AtualizeValorTotal();
        }

        private List<ItemMovimentacao> ObtenhaItensDeEntrada()
        {
            List<ItemMovimentacao> _novosItensDeEntrada = new List<ItemMovimentacao>();
            foreach (var item in _itensSelecioandos)
            {
                ItemMovimentacao _itensAdcionados = new ItemMovimentacao();
                _itensAdcionados.Quantidade = item.Quantidade;
                _itensAdcionados.ValorUnitario = item.ValorUnitario;
                _itensAdcionados.Produto = item.Produto;
                _novosItensDeEntrada.Add(_itensAdcionados);
            }
            return _novosItensDeEntrada;
        }

        private ItemMovimentacaoMV AdicioneUmNovoItemDeMovimentacao()
        {
            var quantidade = 1;
            var novoItemMovimentacao = new ItemMovimentacao();
            novoItemMovimentacao.Quantidade = quantidade;
            novoItemMovimentacao.ValorUnitario = SelecioneProduto().PrecoUnitario;
            novoItemMovimentacao.Produto = SelecioneProduto();

            return new ItemMovimentacaoMV(novoItemMovimentacao);
        }

        private void dgvItensSelecionados_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var itemSelecionado = (ItemMovimentacaoMV)bsProdutosSelecionados.Current;
            var cellAtual = dgvItensSelecionados.CurrentCell;
            foreach (var item in _itensSelecioandos)
            {
                if (item.Equals(itemSelecionado))
                {
                    item.PropertyChanged += Item_PropertyChanged;

                    if (cellAtual.ColumnIndex == 1)
                    {
                        //Formula para que a messageBox do evento dispare corretamente
                        item.Quantidade = (decimal)(item.Quantidade += cellAtual.Value) / 2;
                    }
                    if (cellAtual.ColumnIndex == 2) 
                    {
                        item.Quantidade = (int)(item.Quantidade += cellAtual.Value) / 2;
                        item.Quantidade = (int)cellAtual.Value;
                    }
                }
            }
            AtualizeValorTotal();
        }

        private void AtualizeValorTotal()
        {
            var valorTotal = _itensSelecioandos.Sum(t => t.ValorMovimentacao);
            txtTotal.Text = valorTotal.ToString();
        }



    }
}
