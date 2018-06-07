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

namespace FormTeste
{
    public partial class frmEditarProduto : Form
    {
        public frmEditarProduto()
        {
            InitializeComponent();
        }

        private void frmEditar_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            var produtoEditado = new Produto();
            produtoEditado.Descricao = txtNomeDoProduto.Text;
            produtoEditado.Id = Convert.ToInt32(txtId.Text);
            produtoEditado.PrecoUnitario = Convert.ToDecimal(txtPrecoUnitario.Text);
            produtoEditado.QuantidadeMinimaEstoque = Convert.ToInt32(txtQuantidade.Text);

            RepositorioDeProduto.Instancia.UpDate(produtoEditado);

            MessageBox.Show("Sucesso");
            this.Close();
        }

    }
}

