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
    public partial class frmNovoCadastro : Form
    {
        public frmNovoCadastro()
        {
            InitializeComponent();
        }

        private void frmNovoCadastro_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            var novoProduto = new Produto();
            novoProduto.Id = Convert.ToInt32(txtId.Text);
            novoProduto.Descricao = txtNomeDoProduto.Text;
            novoProduto.PrecoUnitario = Convert.ToDecima(txtPrecoUnitario.Text);
            novoProduto.QuantidadeMinimaEstoque = Convert.ToInt32(txtQuantidade.Text);

            try
            {
                RepositorioDeProduto.Instancia.Add(novoProduto);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            MessageBox.Show("Sucesso" , "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
