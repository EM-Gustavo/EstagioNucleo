﻿using Estagio.Nucleo.Repositorio;
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
        public frmBaseAterrisagem()
        {
            InitializeComponent();

            dgvGeral.AutoGenerateColumns = false;
            dgvGeral.AllowUserToAddRows = false;
            dgvGeral.AllowUserToDeleteRows = false;
            dgvGeral.AllowUserToResizeColumns = false;

            var primeiraColuna = new DataGridViewTextBoxColumn();
            primeiraColuna = InformeDadosDaPrimeiraColuna();
            dgvGeral.Columns.Add(primeiraColuna);

            var segundaColuna = new DataGridViewTextBoxColumn();
            segundaColuna = InformeDadosDaSegundaColuna();
            dgvGeral.Columns.Add(segundaColuna);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            AtualizeDataGrid();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            var frm = CrieFormularioNovoOuEdicao(null);
            var resultado = frm.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                MessageBox.Show(ObtenhaMensagemDeCadastradoConcluido(), "Aviso" , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            AtualizeDataGrid();
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            var itemSelecioando = ObtenhaItemSelecionado();
            if (itemSelecioando == null)
            {
                ExibaMensagemDeNaoSelecionado();
                return;
            }
            var frm = CrieFormularioNovoOuEdicao(itemSelecioando);
            var resultado = frm.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                MessageBox.Show(ObtenhaMensagemDeEdicaoConcluida(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            AtualizeDataGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var itemSelecioando = ObtenhaItemSelecionado();
            if (itemSelecioando == null)
            {
                ExibaMensagemDeNaoSelecionado();
                return;
            }
            var resultado = MessageBox.Show("Deseja excluir o item?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                RemovaItemDaLista(itemSelecioando);
                AtualizeDataGrid();

                MessageBox.Show(ObtenhaMensagemDeExlusao(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnFechar_Click_1(object sender, EventArgs e)
        {
            Close();
        }



        private void AtualizeDataGrid()
        {
            bsGeral.DataSource = ObtenhaListaDeDados();
            bsGeral.ResetBindings(false);
        }

        protected virtual IEnumerable<object> ObtenhaListaDeDados()
        {
            throw new NotImplementedException();
        }

        protected virtual DataGridViewTextBoxColumn InformeDadosDaPrimeiraColuna()
        {
            throw new NotImplementedException();
        }

        protected virtual DataGridViewTextBoxColumn InformeDadosDaSegundaColuna()
        {
            throw new NotImplementedException();
        }

        protected virtual string ObtenhaMensagemDeCadastradoConcluido()
        {
            return "Clicou em Ok!";
        }

        protected virtual Form CrieFormularioNovoOuEdicao(object itemSelecionado)
        {
            throw new NotImplementedException();
        }

        protected object ObtenhaItemSelecionado()
        {
            return bsGeral.Current;
        }
     
        protected virtual void RemovaItemDaLista(object itemSelecioando)
        {
            throw new NotImplementedException();
        }

        protected virtual DialogResult ExibaMensagemDeNaoSelecionado()
        {
            return MessageBox.Show("Selecione item");
        }
       
        protected virtual string ObtenhaMensagemDeEdicaoConcluida()
        {
            return "Clicou em Ok!";
        }

        protected virtual string ObtenhaMensagemDeExlusao()
        {
            return "Item excluído!";
        }

    }
}
