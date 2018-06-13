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
    public partial class frmNovoProduto : frmBaseNovoOuEditar
    {
        public frmNovoProduto()
        {
            InitializeComponent();
        }

        public Produto Produto { get; set; }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            txtDescricao.Text = Produto?.Descricao ?? string.Empty;
        }

        protected override void btnConfirmar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MessageBox.Show("Informe o Descrição", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescricao.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrecoUnitario.Text))
            {
                MessageBox.Show("Informe o Preço Unitário", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecoUnitario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtQuantidade.Text))
            {
                MessageBox.Show("Informe a Quantidade", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtQuantidade.Focus();
                return;
            }

            var produtoNovo = new Produto();
            produtoNovo.Id = RepositorioDeProduto.Instancia.Produtos.Count() + 1;
            produtoNovo.Descricao = txtDescricao.Text;
            produtoNovo.PrecoUnitario = Convert.ToDecimal(txtPrecoUnitario.Text);
            produtoNovo.QuantidadeMinimaEstoque = Convert.ToInt32(txtQuantidade.Text);

            RepositorioDeProduto.Instancia.Add(produtoNovo);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
