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
    }
}
