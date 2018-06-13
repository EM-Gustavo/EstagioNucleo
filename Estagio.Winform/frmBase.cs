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
    public partial class frmBase : Form
    {
        public frmBase()
        {
            InitializeComponent();
        }

        protected bool FoiInformadoOCampo(TextBox textBox, string mensagemDeInconsistencia)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show(mensagemDeInconsistencia, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox.Focus();
                return false;
            }
            return true;
        }
    }
}
