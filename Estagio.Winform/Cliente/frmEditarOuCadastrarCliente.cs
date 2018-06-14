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

namespace Estagio.WinForm
{
    public partial class frmEditarOuCadastrarCliente : frmBaseNovoOuEditar
    {
        public Cliente Cliente { get; set; }

        public frmEditarOuCadastrarCliente()
        {
            InitializeComponent();
            txtNome.FormatoTexto();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (Cliente != null)
            {
                txtNome.Text = Cliente.Nome;
                txtCPF.Text = Cliente.CPFCNPJ.ToString();
            }
        }

        protected override void GraveElemento()
        {
            InsereValores();

            if (EhNovoCliente())
            {
                RepositorioDeCliente.Instancia.Add(Cliente);
            }
            else
            {
                RepositorioDeCliente.Instancia.UpDate(Cliente);
            }
        }


        private bool EhNovoCliente()
        {
            return Cliente == null || Cliente.Id == 0;
        }

        private void InsereValores()
        {
            Cliente = Cliente ?? new Cliente();
            Cliente.Nome = txtNome.Text;
            var CPF = new CPFCNPJ(txtCPF.Text);
            Cliente.CPFCNPJ = CPF;
        }

        protected override bool PodeConfirmar()
        {
            if (!FoiInformadoOCampo(txtNome, "Informe nome")) return false;
            if (!FoiInformadoOCampo(txtCPF, "Informe CNPJ")) return false;
            return true;
        }
    }
}
