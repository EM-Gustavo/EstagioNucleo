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

namespace Estagio.WinForms
{
    public partial class frmEditarProduto : Form
    {
        public frmEditarProduto()
        {
            InitializeComponent();
        }

        public Produto Produto { get; set; }

        private void frmEditarProduto_Load(object sender, EventArgs e)
        {
            txtDescricao.Text = Produto?.Descricao ?? string.Empty;
            txtPrecoUnitario.Text = Produto?.PrecoUnitario.ToString() ?? string.Empty;
            txtQuantidade.Text = Produto?.QuantidadeMinimaEstoque.ToString() ?? string.Empty;

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            var teclaBackSpace = 8;
            var teclaVirgula = 44;
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != teclaBackSpace && e.KeyChar != teclaVirgula)
            {
                e.Handled = true;
            }
        }

        private void txtPrecoUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            var teclaBackSpace = 8;
            var teclaVirgula = 44;
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != teclaBackSpace && e.KeyChar != teclaVirgula)
            {
                e.Handled = true;
            }
        }

        private void txtPrecoUnitario_Leave(object sender, EventArgs e)
        {
            txtPrecoUnitario.Text = Convert.ToDecimal(txtPrecoUnitario.Text).ToString("0.00");
        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            txtPrecoUnitario.Text = Convert.ToDecimal(txtPrecoUnitario.Text).ToString("0.00");
            txtQuantidade.MaxLength = 20;
        }

        private void txtPrecoUnitario_TextChanged(object sender, EventArgs e)
        {
            txtPrecoUnitario.MaxLength = 20;
        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {
            txtDescricao.MaxLength = 30;
        }
    }
}
