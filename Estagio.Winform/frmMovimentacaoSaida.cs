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
    public partial class frmMovimentacaoSaida : frmBase
    {

        public frmMovimentacaoSaida()
        {
            InitializeComponent();

            if (DesignMode) return;

            dgvGeral.AutoGenerateColumns = false;
            dgvGeral.AllowUserToAddRows = false;
            dgvGeral.AllowUserToDeleteRows = false;
            dgvGeral.AllowUserToResizeColumns = false;
            dgvGeral.ReadOnly = true;

            MonteColunas(dgvGeral);
        }

        private void MonteColunas(DataGridView dgvGeral)
        {
            //dgvGeral.CrieColuna("Id", nameof(Produto.Id), 90);
            //dgvGeral.CrieColuna("Descrição", nameof(Produto.Descricao));
            //dgvGeral.CrieColuna("Quantidade Mínima", nameof(Produto.QuantidadeMinimaEstoque));
            //dgvGeral.CrieColuna("Preço Unitário", nameof(Produto.PrecoUnitario));
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            AtualizeDataGrid();
        }

        protected void AtualizeDataGrid()
        {
            bsGeral.DataSource = RepositorioDeProduto.Instancia.GetAll();
            bsGeral.ResetBindings(false);
        }

    }
}
