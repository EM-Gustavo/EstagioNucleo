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
        public MovimentacaoDeEstoqueAbstrato MovimentacaoDeEstoqueAbstrato { get; set; }
        public frmMovimentacaoEntrada()
        {
            InitializeComponent();
            MonteColunas();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            AtualizeDataGrid();
        }

        private void MonteColunas()
        {
            dgvGeral.CrieColunaFill("Descrição", nameof(Produto.Descricao));
            dgvGeral.CrieColuna("Preço Unit.", nameof(Produto.PrecoUnitario), 100);
            dgvGeral.CrieColuna("Qtd. Mínima de Estoque", nameof(Produto.QuantidadeMinimaEstoque), 160);

        }

        private void AtualizeDataGrid()
        {
            bsGeral.DataSource = RepositorioDeProduto.Instancia.GetAll();
            bsGeral.ResetBindings(false);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            InsereValores();

        }

        private void InsereValores()
        {
            var FornecedorSelecionado = ucPesquisaFornecedor1.Fornecedor;
            var ProdutoSelecionado = bsGeral.Current;
            
            MovimentacaoDeEstoqueAbstrato.ItemMovimentacao.Quantidade = Convert.ToInt32(txtQuantidade.Text);
            MovimentacaoDeEstoqueAbstrato.ItemMovimentacao.ValorUnitario = Convert.ToDecimal(txtQuantidade.Text);
            MovimentacaoDeEstoqueAbstrato.ItemMovimentacao.Produto.Id = ProdutoSelecionado.
        }
    }
}
