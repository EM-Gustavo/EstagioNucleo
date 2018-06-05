using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estagio.Nucleo.Repositorio;

namespace Estagio.Nucleo
{
    class Program
    {

        static void Main(string[] args)
        {
            
            var produto = new Produto();
            
            produto.Id = 1;
            produto.Descricao = "refrigerante";

            var cliente = new Cliente();
            var CpfCnpj = new CPFCNPJ("");
            var valor = CpfCnpj.ObtenhaCPFCNPJFormatado();
            

            


        }
    }
}
