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
    public partial class ucPesquisaCliente : ucBasePesquisa
    {
        public ucPesquisaCliente()
        {
            InitializeComponent();
        }

        protected override DialogResult AbraFormularioDePesquisa(out object objeto)
        {           
            var resultado = frmPesquisa.AbraPesquisaCliente(out var cliente);
            objeto = cliente;
            return resultado;
        }
    }
}
