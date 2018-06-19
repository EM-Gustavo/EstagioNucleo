using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estagio.WinForm
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbraFormulario(new frmCadastroDeCliente());
        }

        private void AbraFormulario(Form frm)
        {
            frm.Icon = Icon;
            frm.MdiParent = this;
            frm.Show();
        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbraFormulario(new frmCadastroDeFornecedor());
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbraFormulario(new frmCadastroDeProduto());
        }

        private void entradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbraFormulario(new frmMovimentacaoEntrada());
        }

        private void saídaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbraFormulario(new frmMovimentacaoSaida());
        }
    }
}
