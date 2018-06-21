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

namespace Estagio.WinForm
{
    public partial class frmMovimentacaoEntrada : frmBase 
    {
        public MovimentacaoDeEntrada MovimentacaoDeEntrada { get; set; }
        public Produto ProdutoSelecionado { get; set; }

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
            MovimentacaoDeEntrada = new MovimentacaoDeEntrada();
            MovimentacaoDeEntrada.Itens = new List<ItemMovimentacao>();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            AtualizeDataGrid();
            AtuazaDataGridItens();
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

        private void dgvProdutos_DoubleClick(object sender, EventArgs e)
        {
            ProdutoSelecionado = new Produto();
            ProdutoSelecionado = (Produto)bsProdutos.Current;

            if (!EhProduto())
            {
                IsereItens();
                AtuazaDataGridItens();
            }
        }

        private bool EhProduto()
        {
            foreach (var item in MovimentacaoDeEntrada.Itens)
            {
                if (item.Produto.Id == ProdutoSelecionado.Id)
                {
                    item.Quantidade++;
                    Refresh();
                    return true;
                }
            }
            return false;
        }

        private void IsereItens()
        {
            MovimentacaoDeEntrada.Itens.Add(AdicioneUmNovoItemDeMovimentacao());
        }

        private void AtualizeDataGrid()
        {
            bsProdutos.DataSource = RepositorioDeProduto.Instancia.GetAll();
            bsProdutos.ResetBindings(false);
        }

        private void AtuazaDataGridItens()
        {
            bsProdutosSelecionados.DataSource = MovimentacaoDeEntrada.Itens;
            bsProdutosSelecionados.ResetBindings(false);
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            MovimentacaoDeEntrada.Fornecedor = ucPesquisaFornecedor1.Fornecedor;
            MovimentacaoDeEntrada.Data = dtpEntrada.Value.Date;
            RepositorioDeMovimentacao.Instancia.Add(MovimentacaoDeEntrada);
        }

        private ItemMovimentacao AdicioneUmNovoItemDeMovimentacao()
        {
            var quantidade = 1;
            var novoItemMovimentacao = new ItemMovimentacao();
            novoItemMovimentacao.Quantidade = quantidade;
            novoItemMovimentacao.ValorUnitario = ProdutoSelecionado.PrecoUnitario;
            novoItemMovimentacao.Produto = ProdutoSelecionado;
            return novoItemMovimentacao;
        }


    }
}
