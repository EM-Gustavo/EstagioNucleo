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
    public partial class frmEditarOuCadastrarProduto : frmBaseNovoOuEditar
    {
        public Produto Produto { get; set; }

        public frmEditarOuCadastrarProduto()
        {
            InitializeComponent();
            txtDescricao.FormatoTexto();
            txtPrecoUnitario.FormatoMonetario();
            txtQuantidade.FormatoInteiro();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (Produto != null)
            {
                txtDescricao.Text = Produto.Descricao;
                txtPrecoUnitario.Text = Produto?.PrecoUnitario.ToString() ?? string.Empty;
                txtQuantidade.Text = Produto?.QuantidadeMinimaEstoque.ToString() ?? string.Empty;
            }
        }

        protected override void GraveElemento()
        {
            InsereValores();

            if (EhNovoProduto())
            {
                RepositorioDeProduto.Instancia.Add(Produto);
            }
            else
            {
                RepositorioDeProduto.Instancia.UpDate(Produto);
            }
        }

        private bool EhNovoProduto()
        {
            return Produto == null || Produto.Id == 0;
        }

        private void InsereValores()
        {
            Produto = Produto ?? new Produto();
            Produto.Descricao = txtDescricao.Text;
            Produto.PrecoUnitario = Convert.ToDecimal(txtPrecoUnitario.Text);
            Produto.QuantidadeMinimaEstoque = int.Parse(txtQuantidade.Text);
        }

        protected override bool PodeConfirmar()
        {
            if (!FoiInformadoOCampo(txtDescricao, "Informe a descrição")) return false;
            if (!FoiInformadoOCampo(txtQuantidade, "Informe a quantidade unitária")) return false;
            if (!FoiInformadoOCampo(txtPrecoUnitario, "Informe preço unitário")) return false;
            return true;
        }
    }
}
