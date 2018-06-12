using Estagio.Nucleo.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estagio.WinForm
{
    public partial class frmBaseAterrisagem : frmBase
    {
        public frmBaseAterrisagem(IContainer components, PictureBox pictureBox1, StatusStrip ssBarraDeStatus, ToolStripStatusLabel toolStripStatusLabel1, Panel panel1) : base(components, pictureBox1, ssBarraDeStatus, toolStripStatusLabel1, panel1)
        {
            InitializeComponent();

            dgvGeral.AutoGenerateColumns = false;
            dgvGeral.AllowUserToAddRows = false;
            dgvGeral.AllowUserToDeleteRows = false;
            dgvGeral.AllowUserToResizeColumns = false;

            var colunaId = new DataGridViewTextBoxColumn();
            colunaId.HeaderText = "Id";
            colunaId.DataPropertyName = "Id";
            colunaId.Width = 90;
            colunaId.ReadOnly = true;
            dgvGeral.Columns.Add(colunaId);

            var colunaDescricao = new DataGridViewTextBoxColumn();
            colunaDescricao.HeaderText = "Descrição";
            colunaDescricao.DataPropertyName = "Descricao";
            colunaDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colunaDescricao.ReadOnly = true;
            dgvGeral.Columns.Add(colunaDescricao);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            var frm = CrieFormularioNovo();
            var resultado = frm.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                MessageBox.Show(ObtenhaMensagemBotaoOk());
            }
            bsGeral.DataSource = ObtenhaListaDeDados();
            bsGeral.ResetBindings(false);
        }

        protected virtual IEnumerable<object> ObtenhaListaDeDados()
        {
            return RepositorioDeProduto.Instancia.GetAll();
        }

        protected virtual string ObtenhaMensagemBotaoOk()
        {
            return "Clicou em Ok!";
        }

        protected virtual Form CrieFormularioEdicao()
        {
            throw new NotImplementedException();
        }

        protected virtual Form CrieFormularioNovo()
        {
            throw new NotImplementedException();
        }

        protected object ObtenhaItemSelecionado()
        {
            return bsGeral.Current;
        }


        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var itemSelecioando = ObtenhaItemSelecionado();
            if (itemSelecioando == null)
            {
                ExibaMensagemDeNaoSelecionado();
                return;
            }
            var resultado = MessageBox.Show("Deseja excluir o produto?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                RemovaItemDaLista(itemSelecioando);
                bsGeral.DataSource = ObtenhaListaDeDados();
                bsGeral.ResetBindings(false);
            }

        }
        protected virtual void RemovaItemDaLista(object itemSelecioando)
        {
            throw new NotImplementedException();
        }

        protected virtual DialogResult ExibaMensagemDeNaoSelecionado()
        {
            return MessageBox.Show("Selecione");
        }

        protected virtual object ObtenhaObjSelecionado()
        {
            return bsGeral.Current;
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            var itemSelecioando = ObtenhaItemSelecionado();
            if (itemSelecioando == null)
            {
                ExibaMensagemDeNaoSelecionado();
                return;
            }
            var frm = CrieFormularioEdicao();

            EnviaItem(itemSelecioando);

            var resultado = frm.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                MessageBox.Show(ObtenhaMensagemBotaoOk());
            }
        }

        protected virtual void EnviaItem(object itemSelecionado)
        {
            throw new NotImplementedException();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
