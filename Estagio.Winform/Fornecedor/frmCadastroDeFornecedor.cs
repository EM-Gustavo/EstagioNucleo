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
    public partial class frmCadastroDeFornecedor : frmBaseAterrisagem
    { 
        public frmCadastroDeFornecedor()
        {
            InitializeComponent();
        }

        private void frmCadastroDeProduto_Load(object sender, EventArgs e)
        {
            var fornecedor1 = new Fornecedor();
            fornecedor1.Id = 1;
            fornecedor1.Nome = "Carlos";
            RepositorioDeFornecedor.Instancia.Add(fornecedor1);

        }

        protected override DataGridViewTextBoxColumn InformeDadosDaPrimeiraColuna()
        {
            var primeiraColuna = new DataGridViewTextBoxColumn();
            primeiraColuna.HeaderText = "Id";
            primeiraColuna.DataPropertyName = "Id";
            primeiraColuna.Width = 90;
            primeiraColuna.ReadOnly = true;
            return (primeiraColuna);
        }

        protected override DataGridViewTextBoxColumn InformeDadosDaSegundaColuna()
        {
            var segundaColuna = new DataGridViewTextBoxColumn();
            segundaColuna.HeaderText = "Nome";
            segundaColuna.DataPropertyName = "Nome";
            segundaColuna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            segundaColuna.ReadOnly = true;
            return (segundaColuna);
        }

        protected override void RemovaItemDaLista(object itemSelecioando)
        {
            RepositorioDeFornecedor.Instancia.Delete((Fornecedor)itemSelecioando);
        }

        protected override Form CrieFormularioNovoOuEdicao(object fornecedor)
        {
            var frmComFornecedor = new frmEditarOuCadastrarForncedor();
            frmComFornecedor.Fornecedor = (Fornecedor)fornecedor;
            return frmComFornecedor;
        }


        protected override string ObtenhaMensagemDeCadastradoConcluido()
        {
            return "Cadastro de fornecedor realizado";
        }

        protected override string ObtenhaMensagemDeEdicaoConcluida()
        {
            return "Edição de fornecedor realizado";
        }

        protected override DialogResult ExibaMensagemDeNaoSelecionado()
        {
            return MessageBox.Show("Selecione Fornecedor", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        protected override IEnumerable<object> ObtenhaListaDeDados()
        {
            return RepositorioDeProduto.Instancia.GetAll();
        }

        protected override string ObtenhaMensagemDeExlusao()
        {
            return "Fornecedor excluído!";
        }
    }
}
