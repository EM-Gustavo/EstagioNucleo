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

        protected override void RemovaItemDaLista(object itemSelecioando)
        {
            RepositorioDeProduto.Instancia.Delete((Produto)itemSelecioando);
        }

        //protected override void EnviaItem(object itemSelecionado)
        //{
        //    var frm = new frmEditarProduto();
        //    frm.Produto = (Produto)itemSelecionado;
        //}

        //protected override Form CrieFormularioNovo()
        //{
        //    return new frmNovoProduto();
        //}

        //protected override Form CrieFormularioEdicao()
        //{
        //    return new frmEditarProduto();
        //}

        protected override string ObtenhaMensagemBotaoOk()
        {
            return "Cadastrou Produto";
        }

        protected override DialogResult ExibaMensagemDeNaoSelecionado()
        {
            return MessageBox.Show("Selecione Produto", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        protected override IEnumerable<object> ObtenhaListaDeDados()
        {
            return RepositorioDeProduto.Instancia.GetAll();
        }
    }
}