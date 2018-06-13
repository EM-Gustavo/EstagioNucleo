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
        public Produto _produto { get; set; }

        public frmEditarProduto(Produto Produto)
        {
            InitializeComponent();
            txtDescricao.Text = Produto.Descricao;
            txtPrecoUnitario.Text = Produto?.PrecoUnitario.ToString() ?? string.Empty;
            txtQuantidade.Text = Produto?.QuantidadeMinimaEstoque.ToString() ?? string.Empty;
            _produto = Produto;
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


            _produto.Descricao = txtDescricao.Text;
            _produto.PrecoUnitario = Convert.ToDecimal(txtPrecoUnitario.Text);
            _produto.QuantidadeMinimaEstoque = Convert.ToInt32(txtQuantidade.Text);
            RepositorioDeProduto.Instancia.UpDate(_produto);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
