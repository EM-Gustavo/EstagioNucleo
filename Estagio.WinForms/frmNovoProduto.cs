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
    public partial class frmNovoProduto : Form
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

            var produtoNovo = new Produto();
            produtoNovo.Id = RepositorioDeProduto.Instancia.Produtos.Count() + 1;
            produtoNovo.Descricao = txtDescricao.Text;
            produtoNovo.PrecoUnitario = Convert.ToDecimal(txtPrecoUnitario.Text);
            produtoNovo.QuantidadeMinimaEstoque = Convert.ToInt32(txtQuantidade.Text);

            //if (Produto.Equals(produtoNovo))
            //{
            //    RepositorioDeProduto.Instancia.Add(produtoNovo);
            //    DialogResult = DialogResult.OK;
            //}
            Close();
        }

        private void txtPrecoUnitario_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPrecoUnitario.Text = Convert.ToDecimal(txtPrecoUnitario.Text).ToString("0.00");
                txtPrecoUnitario.MaxLength = 20;
            }
            catch
            {

            }
        }

        private void frmNovoCadastro_Load(object sender, EventArgs e)
        {

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

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            txtQuantidade.MaxLength = 20;
        }

        private void txtPrecoUnitario_TextChanged(object sender, EventArgs e)
        {
            txtPrecoUnitario.MaxLength = 20;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
            
        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {
            txtDescricao.MaxLength = 30;
        }
    }
}
