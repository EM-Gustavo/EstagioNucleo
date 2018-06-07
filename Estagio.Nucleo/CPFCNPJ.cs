using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estagio.Nucleo
{
    public class CPFCNPJ
    {
        private string _numero;

        private const int TamanhoDoCNPJ = 14;
        private const int TamanhoDoCPF = 11;

        public CPFCNPJ(string numero)
        {
            _numero = numero ?? throw new ArgumentNullException(nameof(numero));

            RemovaCarecteresNaoNumericos();

            if (!(EhCPFValido() || EhCPNJValido()))
            {
                throw new ApplicationException("CPF/CNPJ inválido");
            }
        }

        public string Numero { get => _numero; }

        private bool EhDoTamanhoCorretoDeCNPJ()
        {
            return _numero.Length == TamanhoDoCNPJ;
        }

        private bool EhDoTamanhoCorretoDoCPF()
        {
            return _numero.Length == TamanhoDoCPF;
        }

        private void RemovaCarecteresNaoNumericos()
        {
            _numero = new string(_numero.Where(c => char.IsNumber(c)).ToArray());
        }

        private bool EhCPFValido()
        {
            if (!EhDoTamanhoCorretoDoCPF())
            {
                return false;
            }

            var numeros = _numero.Select(c => int.Parse(c.ToString())).ToArray();

            var soma = 0;
            for (var i = 0; i < 9; i++)
            {
                soma += (10 - i) * numeros[i];
            }

            var resto = soma % 11;

            if (resto < 2)
            {
                if (numeros[9] != 0) return false;
            }
            else
            {
                if (numeros[9] != 11 - resto) return false;
            }

            soma = 0;
            for (var i = 0; i < 10; i++)
            {
                soma += (11 - i) * numeros[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                if (numeros[10] != 0) return false;
            }
            else
            {
                if (numeros[10] != 11 - resto) return false;
            }


            return true;
        }

        private bool EhCPNJValido()
        {
            if (!EhDoTamanhoCorretoDeCNPJ())
            {
                return false;
            }

            var numeros = _numero.Select(c => int.Parse(c.ToString())).ToArray();

            var multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            var soma = 0;

            for (var i = 0; i < 12; i++)
            {
                soma +=  numeros[i] * multiplicador1[i];
            }

            var resto = soma % 11;

            if (resto < 2)
            {
                if (numeros[12] != 0) return false;
            }
            else
            {
                if (numeros[12] != 11 - resto) return false;
            }

            soma = 0;
            for (var i = 0; i < 13; i++)
            {
                soma += numeros[i] * multiplicador2[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                if (numeros[13] != 0) return false;
            }
            else
            {
                if (numeros[13] != 11 - resto) return false;
            }

            return true;
        }

        public string ObtenhaCPFCNPJFormatado()
        {
            if (EhDoTamanhoCorretoDoCPF())
            {
                var cpfFormatado = Convert.ToUInt64(_numero).ToString(@"000\.000\.000\-00");
                return cpfFormatado;
            }
            else
            {
                var cnpjFormatado = Convert.ToUInt64(_numero).ToString(@"00\.000\.000\/0000\-00");
                return cnpjFormatado;
            }
            
        }

        public override string ToString()
        {
            return ObtenhaCPFCNPJFormatado();
        }

        public override bool Equals(object obj)
        {
            return (obj is CPFCNPJ cPFCNPJ) && cPFCNPJ._numero == _numero;
        }


    }
} 