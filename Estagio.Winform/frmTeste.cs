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
    public partial class frmTeste : frmBase
    {
        public frmTeste()
        {
            InitializeComponent();
            MonteColuna();
            
        }

        private void MonteColuna()
        {
            dgvProdutos.CrieColuna("Id", nameof(Produto.Id), 90);
            dgvProdutos.CrieColuna("Descrição", nameof(Produto.Descricao));
            dgvProdutos.CrieColuna("Quantidade Mínima", nameof(Produto.QuantidadeMinimaEstoque));
            dgvProdutos.CrieColuna("Preço Unitário", nameof(Produto.PrecoUnitario));
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            AtualizeDataGrid();
        }

        protected void AtualizeDataGrid()
        {
            bsProdutos.DataSource = RepositorioDeProduto.Instancia.GetAll();
            bsProdutos.ResetBindings(false);
        }

        private void txtFornecedorCliente_MouseClick(object sender, MouseEventArgs e)
        {
            var frm = new frmTesteFornecedor();
            var resultado = frm.ShowDialog();
        }
    }
}
