﻿using System;
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

namespace Estagio.WinForms
{
    public partial class frmCadastro : Form
    {
        //Encapsula a fonte de dados de um formulário

        public frmCadastro()
        {
            InitializeComponent();
            dgvProdutos.AutoGenerateColumns = false;
            dgvProdutos.AllowUserToAddRows = false;
            dgvProdutos.AllowUserToDeleteRows = false;
            dgvProdutos.AllowUserToResizeColumns = false;

            var colunaId = new DataGridViewTextBoxColumn();
            colunaId.HeaderText = "Id";
            colunaId.DataPropertyName = "Id";
            colunaId.Width = 90;
            colunaId.ReadOnly = true;
            dgvProdutos.Columns.Add(colunaId);

            var colunaDescricao = new DataGridViewTextBoxColumn();
            colunaDescricao.HeaderText = "Descrição";
            colunaDescricao.DataPropertyName = "Descricao";
            colunaDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colunaDescricao.ReadOnly = true;
            dgvProdutos.Columns.Add(colunaDescricao);
        }

        private void frmCadastro_Load(object sender, EventArgs e)
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

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            bsProdutos.DataSource = RepositorioDeProduto.Instancia.GetAll();
            bsProdutos.ResetBindings(false);
        }


        private void btnNovo_Click(object sender, EventArgs e)
        {
            var produtoSelecionado = (Produto)bsProdutos.Current;
            if(produtoSelecionado == null)
            {
                MessageBox.Show("Selecione um produto");
                return;
            }
            var frmEditar = new frmNovoProduto();
            var resultado = frmEditar.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                MessageBox.Show("Produto Cadastrado");
            }
            bsProdutos.DataSource = RepositorioDeProduto.Instancia.GetAll();
            bsProdutos.ResetBindings(false);

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var produtoSelecioando = (Produto)bsProdutos.Current;
            if (produtoSelecioando == null)
            {
                MessageBox.Show("Selecione um produto");
                return;
            }
            var frmEditar = new frmEditarProduto();
            frmEditar.Produto = produtoSelecioando;
            var resultado = frmEditar.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                MessageBox.Show("Produto Editado");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //var selecionado = (Produto)grdBuscaDeProdutos ;
            //RepositorioDeProduto.Instancia.Delete(selecionado);
            var produto = (Produto)bsProdutos.Current;
            bsProdutos.RemoveCurrent();

            RepositorioDeProduto.Instancia.Delete(produto);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

 
    }
}
