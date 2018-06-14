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
            var CNPJ = new CPFCNPJ("38.117.767/0001-78");
            fornecedor1.CPFCNPJ = CNPJ;

            RepositorioDeFornecedor.Instancia.Add(fornecedor1);
        }

        protected override void MonteColunas(DataGridView dgvGeral)
        {
            MetodosDeExtenssaoCrieColunas.CrieColuna(dgvGeral, "Id", "Id", 90);
            MetodosDeExtenssaoCrieColunas.CrieColuna(dgvGeral, "Nome", "Nome", DataGridViewAutoSizeColumnMode.Fill);
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
            return RepositorioDeFornecedor.Instancia.GetAll();
        }

        protected override string ObtenhaMensagemDeExlusao()
        {
            return "Fornecedor excluído!";
        }
    }
}
