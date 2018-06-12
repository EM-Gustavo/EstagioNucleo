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
    public partial class frmEditarProduto : frmBaseNovoOuEditar
    {
        public Produto Produto { get; set; }

        public frmEditarProduto()
        {
            InitializeComponent();

        }

        protected override void EnviaValor(Produto produto)
        {
            txtDescricao.Text = produto.Descricao;
            txtPrecoUnitario.Text = produto?.PrecoUnitario.ToString() ?? string.Empty;
            txtQuantidade.Text = produto?.QuantidadeMinimaEstoque.ToString() ?? string.Empty;

        }

        protected override void btnConfirmar_Click(object sender, EventArgs e)
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

            var produtoEditado = new Produto();
            Produto.PrecoUnitario = Convert.ToDecimal(txtPrecoUnitario.Text);
            Produto.QuantidadeMinimaEstoque = Convert.ToInt32(txtQuantidade.Text);
            RepositorioDeProduto.Instancia.UpDate(Produto);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
