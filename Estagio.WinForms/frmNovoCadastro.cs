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
    public partial class frmNovoCadastro : Form
    {
        public frmNovoCadastro()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            var novoProduto = new Produto();
            novoProduto.Descricao = txtNomeDoProduto.Text;
            novoProduto.PrecoUnitario = Convert.ToDecimal(txtPrecoUnitario.Text);
            novoProduto.QuantidadeMinimaEstoque = Convert.ToInt32(txtQuantidade.Text);

            try
            {
                RepositorioDeProduto.Instancia.Add(novoProduto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            MessageBox.Show("Sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void frmNovoCadastro_Load(object sender, EventArgs e)
        {

        }

    }
}
