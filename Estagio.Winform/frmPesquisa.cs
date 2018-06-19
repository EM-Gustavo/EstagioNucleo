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
    public partial class frmPesquisa : frmBase
    {
        private delegate object ObtenhaObjetosFiltradosDelegate(string textoASerPesquisado);
        private ObtenhaObjetosFiltradosDelegate ObtenhaObjetosFiltrados { get; set; }

        private object ObjetoSelecionado { get; set; }

        public frmPesquisa()
        {
            InitializeComponent();
            dgvGeral.AllowUserToOrderColumns = false;
            dgvGeral.AllowUserToResizeColumns = false;
            dgvGeral.AllowUserToAddRows = false;

            dgvGeral.ReadOnly = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }

        public static DialogResult AbraPesquisaFornecedor(out Fornecedor fornecedor)
        {
            var frm = new frmPesquisa();
            frm.dgvGeral.CrieColunaFill("Nome", nameof(Fornecedor.Nome));
            frm.dgvGeral.CrieColuna("CPF/CNPJ", nameof(Fornecedor.CPFCNPJ), 120);

            frm.bsGeral.DataSource = RepositorioDeFornecedor.Instancia.GetAll();
            frm.bsGeral.ResetBindings(false);

            //object funcaoFiltraFornecedores(string texto)
            //{
            //    return RepositorioDeFornecedor.Instancia.GetAll().Where(f => f.Nome.Contains(texto));
            //}

            //frm.ObtenhaObjetosFiltrados = funcaoFiltraFornecedores;

            frm.ObtenhaObjetosFiltrados = (texto) =>
            {
                return RepositorioDeFornecedor.Instancia.GetAll().Where(f => f.Nome.Contains(texto));
            };

            var resultado = frm.ShowDialog();
            fornecedor = (Fornecedor)frm.ObjetoSelecionado;
            return resultado;
        }

        public static DialogResult AbraPesquisaCliente(out Cliente cliente)
        {
            var frm = new frmPesquisa();
            frm.dgvGeral.CrieColunaFill("Nome", nameof(Cliente.Nome));
            frm.dgvGeral.CrieColuna("CPF/CNPJ", nameof(Cliente.CPFCNPJ), 120);

            frm.bsGeral.DataSource = RepositorioDeCliente.Instancia.GetAll();
            frm.bsGeral.ResetBindings(false);


            frm.ObtenhaObjetosFiltrados = (texto) =>
            {
                return RepositorioDeCliente.Instancia.GetAll().Where(f => f.Nome.Contains(texto));
            };

            var resultado = frm.ShowDialog();
            cliente = (Cliente)frm.ObjetoSelecionado;
            return resultado;
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            //Eu não sei fazer a pesqusia
            //Então peço para alguém fazer
            //Quem???
            var textoASerPesquisado = txtPesquisa.Text.ToUpper();
            bsGeral.DataSource = ObtenhaObjetosFiltrados(textoASerPesquisado) ;
            bsGeral.ResetBindings(false);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            ObjetoSelecionado = bsGeral.Current;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
