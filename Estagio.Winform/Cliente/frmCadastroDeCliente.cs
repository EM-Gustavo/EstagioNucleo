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

        protected override void MonteColunas(DataGridView dgvGeral)
        {
            MetodosDeExtenssaoCrieColunas.CrieColuna(dgvGeral, "Id", nameof(Cliente.Id), 90);
            MetodosDeExtenssaoCrieColunas.CrieColunaFill(dgvGeral, "Nome", nameof(Cliente.Nome));
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
            bsGeral.DataSource = RepositorioDeCliente.Instancia.GetAll().Where(p => p.Nome.ToUpper().Contains(textoPesquisado)).ToList();
            bsGeral.ResetBindings(false);
        }

        protected override string ObtenhaMensagemDeExlusao()
        {
            return "Cliente excluído!";
        }
    }
}
