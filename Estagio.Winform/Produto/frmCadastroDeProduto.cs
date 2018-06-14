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
    public partial class frmCadastroDeProduto : frmBaseAterrisagem
    {
        public frmCadastroDeProduto() 
        {
            InitializeComponent();
        }

        private void frmCadastroDeProduto_Load(object sender, EventArgs e)
        {
            var produto = new Produto();
            produto.Id = 1;
            produto.Descricao = "refrigerante";
            produto.PrecoUnitario = 4;
            RepositorioDeProduto.Instancia.Add(produto);

            var produto2 = new Produto();
            produto2.Id = 2;
            produto2.Descricao = "suco";
            produto2.PrecoUnitario = 3;
            RepositorioDeProduto.Instancia.Add(produto2);
        }

        protected override void MonteColunas(DataGridView dgvGeral)
        {
            MetodosDeExtenssaoCrieColunas.CrieColuna(dgvGeral, "Id", "Id" , Width = 90);
            MetodosDeExtenssaoCrieColunas.CrieColuna(dgvGeral, "Descrição", "Descricao", DataGridViewAutoSizeColumnMode.Fill);
        }

        protected override void RemovaItemDaLista(object itemSelecioando)
        {
            RepositorioDeProduto.Instancia.Delete((Produto)itemSelecioando);
        }

        protected override Form CrieFormularioNovoOuEdicao(object produto)
        {
            var frmComProduto = new frmEditarOuCadastrarProduto();
            frmComProduto.Produto = (Produto)produto;
            return frmComProduto;
        }

        protected override List<Nucleo.Produto> ObtenhaResultadoDaPesquisa()
        {
            return RepositorioDeProduto.Instancia.GetAll().Where(p => p.Descricao.ToUpper().Contains(txtInfoParaPesquisa.Text.ToUpper())).ToList();
        }

        protected override string ObtenhaMensagemDeCadastradoConcluido()
        {
            return "Cadastro de produto realizado";
        }

        protected override string ObtenhaMensagemDeEdicaoConcluida()
        {
            return "Edição de produto realizado";
        }

        protected override DialogResult ExibaMensagemDeNaoSelecionado()
        {
            return MessageBox.Show("Selecione Produto", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        protected override IEnumerable<object> ObtenhaListaDeDados()
        {
            return RepositorioDeProduto.Instancia.GetAll();
        }

        protected override string ObtenhaMensagemDeExlusao()
        {
            return "Produto excluído!";
        }
    }
}
