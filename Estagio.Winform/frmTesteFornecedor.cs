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
    public partial class frmTesteFornecedor : frmBase
    {
        public frmTesteFornecedor()
        {
            InitializeComponent();
            MonteColuna();

        }

        private void MonteColuna()
        {
            dgvGeral.CrieColuna("Id", nameof(Fornecedor.Id), 90);
            dgvGeral.CrieColuna("Nome", nameof(Fornecedor.Nome));
            dgvGeral.CrieColuna("CPF/CNPJ", nameof(Fornecedor.CPFCNPJ));
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            AtualizeDataGrid();
        }

        protected void AtualizeDataGrid()
        {
            bsFornecedor.DataSource = RepositorioDeFornecedor.Instancia.GetAll();
            bsFornecedor.ResetBindings(false);
        }

    }
}
