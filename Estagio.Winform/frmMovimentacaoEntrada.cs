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
            AtualizeDataGrid();
            AtuazaDataGridItens();
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
        private void AtualizeDataGrid()
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
            MessageBox.Show($"{e.PropertyName} foi alterada");
        }

        private void IsereItens()
        {
            _itensSelecioandos.Add(AdicioneUmNovoItemDeMovimentacao());
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            MovimentacaoDeEntrada itemDeEntrada = new MovimentacaoDeEntrada();
            itemDeEntrada.Fornecedor = ucPesquisaFornecedor1.Fornecedor;
            itemDeEntrada.Data = dtpEntrada.Value.Date;

            RepositorioDeMovimentacao.Instancia.Add(itemDeEntrada);
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
            var item = (ItemMovimentacaoMV)bsProdutosSelecionados.Current;
            item.PropertyChanged += Item_PropertyChanged;
            //aqui vai modificar
        }
    }
}
