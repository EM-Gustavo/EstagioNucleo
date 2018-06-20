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
        public List<ItemMovimentacao> Itens { get; set; }

        public MovimentacaoDeEstoqueAbstrato MovimentacaoDeEstoqueAbstrato { get; set; }
        public MovimentacaoDeEntrada MovimentacaoDeEntrada { get; set; }
        public ItemMovimentacao ItemMovimentacao { get; set; }
        public Produto Produto { get; set; }

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
            MovimentacaoDeEntrada = new MovimentacaoDeEntrada();
            MovimentacaoDeEntrada.Data = Convert.ToDateTime(dtpEntrada.Text);
            MovimentacaoDeEntrada.Fornecedor = ucPesquisaFornecedor1.Fornecedor;

            ItemMovimentacao = new ItemMovimentacao();
            ItemMovimentacao.Quantidade = Convert.ToInt32(txtQuantidade.Text);
            ItemMovimentacao.ValorUnitario = Convert.ToDecimal(txtValor.Text);
            ItemMovimentacao.Produto = (Produto)bsGeral.Current;
            
            MovimentacaoDeEntrada.Itens.Add(ItemMovimentacao);
            //movimentacaoE.vinculeFornecedor(movimentacaoE);



        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            //Itens.Add(i => i.Produto)
        }
    }
}
