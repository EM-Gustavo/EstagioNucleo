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

        public frmMovimentacaoEntrada()
        {
            InitializeComponent();            
            MonteColunas();
            MovimentacaoDeEntrada = new MovimentacaoDeEntrada();
            MovimentacaoDeEntrada.Itens = new List<ItemMovimentacao>();
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
            MovimentacaoDeEntrada.Fornecedor = ucPesquisaFornecedor1.Fornecedor;
            MovimentacaoDeEntrada.Data = dtpEntrada.Value.Date;
            RepositorioDeMovimentacao.Instancia.Add(MovimentacaoDeEntrada);
        }



        private void btnAdicionar_Click(object sender, EventArgs e)
        {

            MovimentacaoDeEntrada.Itens.Add(AdicioneUmNovoItemDeMovimentacao());

        }

        private ItemMovimentacao AdicioneUmNovoItemDeMovimentacao()
        {
            ItemMovimentacao novoItemMovimentacao = new ItemMovimentacao();
            novoItemMovimentacao.Quantidade = Convert.ToInt32(txtQuantidade.Text);
            novoItemMovimentacao.ValorUnitario = Convert.ToDecimal(txtValor.Text);
            novoItemMovimentacao.ObtenhaProduto((Produto)bsGeral.Current);
            return novoItemMovimentacao;
        }
    }
}
