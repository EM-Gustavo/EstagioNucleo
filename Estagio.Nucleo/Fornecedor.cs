namespace Estagio.Nucleo
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public CPFCNPJ CPFCNPJ { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}