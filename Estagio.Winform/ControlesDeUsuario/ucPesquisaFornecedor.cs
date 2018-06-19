using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Estagio.Nucleo;
using Estagio.Nucleo.Repositorio;

namespace Estagio.WinForm.ControlesDeUsuario
{
    public partial class ucPesquisaFornecedor : ucBasePesquisa
    {
        public Fornecedor Fornecedor { get; set; }

        public ucPesquisaFornecedor()
        {
            InitializeComponent();
        }
       
        protected override DialogResult AbraFormularioDePesquisa(out object objeto)
        {
            var resultado = frmPesquisa.AbraPesquisaFornecedor(out var fornecedor);
            objeto = fornecedor;
            Fornecedor = fornecedor;
            return resultado;
        }
    }
}
