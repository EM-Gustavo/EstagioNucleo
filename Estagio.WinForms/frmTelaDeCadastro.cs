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

namespace Estagio.WinForms
{
    public partial class Form1 : Form
    {
        private BindingSource bindingSource1 = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            dgvProdutos.AutoGenerateColumns = false;
            dgvProdutos.AutoSize = false;
            dgvProdutos.DataSource = bindingSource1;

            DataGridViewColumn coluna = new DataGridViewTextBoxColumn();
            coluna.DataPropertyName = "ID";
            coluna.Name = "ID";

            dgvProdutos.Columns.Add(coluna);

            coluna = new DataGridViewTextBoxColumn();
            coluna.DataPropertyName = "Descrição";
            coluna.Name = "Descrição";
            dgvProdutos.Columns.Add(coluna);


            bindingSource1.DataSource = RepositorioDeProduto.Instancia.GetAll();


            //dataGridViewProd.Columns.Add(dgvProdutos.AdicionaColuna("ID", nameof(Produto.Id), 30));
            //dataGridViewProd.Columns.Add(DgvHelper.AdicionaColuna("Descricao", nameof(Produto.Descricao), 30));

            //dataGridViewProd.Columns.Add(new DataGridViewTextBoxColumn
            //{
            //    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
            //    Width = 100,
            //    DataPropertyName = nameof(Produto.Id),
            //    HeaderText = "Id Teste",
            //    Name = nameof(Produto.Id)
            //});


        }

        private void txtInfoParaPesquisa_TextChanged(object sender, EventArgs e)
        {
            if(txtInfoParaPesquisa.Text == string.Empty)
            {
                
            }
        }

        private void grdBuscaDeProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //grdBuscaDeProdutos.AutoGenerateColumns = false;

            //var selecionado = RepositorioDeProduto.Instancia.Produtos.ToArray();

            //grdBuscaDeProdutos.Columns.AddRange(RepositorioDeProduto.Instancia.Produtos.ToArray());
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            var frmNovoCadastro = new frmNovoCadastro();

            frmNovoCadastro.ShowDialog();
            //adcionar na grid
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var frmCadastroEditado = new frmEditarProduto();

            frmCadastroEditado.ShowDialog();
            //adcionar na grid
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //var selecionado = (Produto)grdBuscaDeProdutos ;
            //RepositorioDeProduto.Instancia.Delete(selecionado);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
