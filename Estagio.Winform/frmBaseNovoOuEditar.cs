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
    public partial class frmBaseNovoOuEditar : frmBase
    {
        public frmBaseNovoOuEditar()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {
            if (!PodeConfirmar())
            {
                return;
            }
            GraveElemento();
            DialogResult = DialogResult.OK;
            Close();
        }

        protected virtual bool PodeConfirmar()
        {
            throw new NotImplementedException();
        }

        protected virtual void GraveElemento()
        {
            throw new NotImplementedException();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
