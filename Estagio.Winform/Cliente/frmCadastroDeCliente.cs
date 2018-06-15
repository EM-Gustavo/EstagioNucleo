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
    public partial class frmCadastroDeCliente : frmBaseAterrisagem
    {
        public frmCadastroDeCliente()
        {
            InitializeComponent();
        }

        private void frmCadastroDeCliente_Load(object sender, EventArgs e)
        {
            var cliente1 = new Cliente();
            cliente1.Id = 1;
            cliente1.Nome = "André";
            var CPF = new CPFCNPJ("874.948.052-90");
            cliente1.CPFCNPJ = CPF;

            RepositorioDeCliente.Instancia.Add(cliente1);
        }

        protected override void MonteColunas(DataGridView dgvGeral)
        {
            MetodosDeExtenssaoCrieColunas.CrieColuna(dgvGeral, "Id", "Id", 90);
            MetodosDeExtenssaoCrieColunas.CrieColuna(dgvGeral, "Nome", "Nome");
        }

        protected override void RemovaItemDaLista(object itemSelecioando)
        {
            RepositorioDeCliente.Instancia.Delete((Cliente)itemSelecioando);
        }

        protected override Form CrieFormularioNovoOuEdicao(object cliente)
        {
            var frmComCliente = new frmEditarOuCadastrarCliente();
            frmComCliente.Cliente = (Cliente)cliente;
            return frmComCliente;
        }


        protected override string ObtenhaMensagemDeCadastradoConcluido()
        {
            return "Cadastro de cliente realizado";
        }

        protected override string ObtenhaMensagemDeEdicaoConcluida()
        {
            return "Edição de cliente realizado";
        }

        protected override DialogResult ExibaMensagemDeNaoSelecionado()
        {
            return MessageBox.Show("Selecione cliente", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        protected override void AtualizeDataGrid()
        {
            bsGeral.DataSource = RepositorioDeCliente.Instancia.GetAll();
            bsGeral.ResetBindings(false);
        }

        protected override void ExibaItemPesquisado(string textoPesquisado)
        {
            bsProdutos.DataSource = RepositorioDeCliente.Instancia.GetAll().Where(p => p.Nome.ToUpper().Contains(textoPesquisado)).ToList();
            bsProdutos.ResetBindings(false);
        }

        protected override string ObtenhaMensagemDeExlusao()
        {
            return "Cliente excluído!";
        }
    }
}
