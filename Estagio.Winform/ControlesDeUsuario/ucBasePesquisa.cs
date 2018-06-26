using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estagio.WinForm.ControlesDeUsuario
{
    public partial class ucBasePesquisa : UserControl
    {
        public ucBasePesquisa()
        {
            InitializeComponent();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            var retorno = AbraFormularioDePesquisa(out var objetoRetornado);
            if (retorno == DialogResult.OK)
            {
                txtPesquisa.Text = objetoRetornado?.ToString() ?? string.Empty;
            }
            else
            {
                txtPesquisa.Text = string.Empty;
            }
        }

        protected virtual DialogResult AbraFormularioDePesquisa(out object objeto)
        {
            throw new NotImplementedException();
        }

        public void limpeTextBox()
        {
            txtPesquisa.Text = String.Empty;
        }
    }
}
