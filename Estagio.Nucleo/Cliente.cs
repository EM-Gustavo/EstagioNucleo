namespace Estagio.Nucleo
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public CPFCNPJ CPFCNPJ { get; set; } //olhar esse get e set

        public override string ToString()
        {
            return Nome;
        }

    }
}