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

        protected override void MonteColunas(DataGridView dgvGeral)
        {
            dgvGeral.CrieColuna("Id", nameof(Produto.Id), 90);
            dgvGeral.CrieColunaFill("Descrição", nameof(Produto.Descricao));
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

        protected override void AtualizeDataGrid()
        {
            bsGeral.DataSource = RepositorioDeProduto.Instancia.GetAll();
            bsGeral.ResetBindings(false);
        }

        protected override void ExibaItemPesquisado(string textoPesquisado)
        {
            bsGeral.DataSource = RepositorioDeProduto.Instancia.GetAll().Where(p => p.Descricao.ToUpper().Contains(textoPesquisado)).ToList();
            bsGeral.ResetBindings(false);
        }

        protected override string ObtenhaMensagemDeExlusao()
        {
            return "Produto excluído!";
        }

    }
}
