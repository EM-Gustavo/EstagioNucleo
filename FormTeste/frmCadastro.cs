using Estagio.Nucleo;
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

namespace FormTeste
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
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
            cmoProduto.Items.AddRange(RepositorioDeProduto.Instancia.Produtos.ToArray());

            var cliente = new Cliente();
            var CpfCnpj = new CPFCNPJ("38.117.767/0001-78");
            cliente.Nome = "Jose da Costa";
            cliente.Id = 21;
            cliente.CPFCNPJ = CpfCnpj;
            RepositorioDeCliente.Instancia.Add(cliente);
        }

        private void cmoProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selecionado = (Produto)cmoProduto.SelectedItem;

            txtId.Text = selecionado.Id.ToString;
            txtPrecoUnitario.Text = selecionado.PrecoUnitario.ToString();
            txtQuantidade.Text = selecionado.QuantidadeMinimaEstoque.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frmNovoCadastro = new frmNovoCadastro();

            frmNovoCadastro.ShowDialog();
            cmoProduto.Items.Clear();
            cmoProduto.Items.AddRange(RepositorioDeProduto.Instancia.Produtos.ToArray());



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var frmCadastroEditado = new frmEditarProduto();

            frmCadastroEditado.ShowDialog();
            cmoProduto.Items.Clear();  
            cmoProduto.Items.AddRange(RepositorioDeProduto.Instancia.Produtos.ToArray());
        }
    }
}
