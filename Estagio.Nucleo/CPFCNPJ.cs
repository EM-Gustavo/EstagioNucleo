namespace Estagio.Nucleo
{
    public class CPFCNPJ
    {
        private string _Numero;
        public CPFCNPJ(string numero)
        {
            _Numero = numero;
        }

        public bool ValidaCpf(string numero)
        {
            var valor = numero.Replace(".", "");

            valor = valor.Replace("-", "");

            if (valor.Length == 11)
            {
                int[] numeros = new int[11];

                for (var i = 0; i < 11; i++)
                {
                    numeros[i] = int.Parse(valor[i].ToString());
                }

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

                if (resto >= 2)
                {
                    if (numeros[9] != 11 - resto) return false;
                }

                soma = 0;
                for (var i = 0; i < 11; i++)
                {
                    soma += (11 - i) * numeros[i];
                }

                resto = soma % 11;

                if (resto < 2)
                {
                    if (numeros[10] != 0) return false;
                }

                if (resto >= 2)
                {
                    if (numeros[10] != 11 - resto) return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        public bool ValidaCnpj(string numero)
        {
            numero = numero.Trim();
            numero = numero.Replace(".", "").Replace("-", "").Replace("/", "");

            var multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            if (numero.Length != 14)
            {
                return false;
            }

            var tempCnpj = numero.Substring(0, 12);

            var soma = 0;

            for (var i = 0; i < 12; i++) {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            }

            var resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            var digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
            {
                resto = 0;
            }
            else {
                resto = 11 - resto;
            }
            digito = digito + resto.ToString();
            return numero.EndsWith(digito);
                       
        {

        

        else
        {

        }
      
    }
}