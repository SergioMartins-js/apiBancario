namespace apiBancario.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public decimal Saldo { get; set; }
        // Outros campos relacionados aos clientes

        // Construtor padrão (opcional)
        public Cliente()
        {
        }

        // Construtor com parâmetros
        public Cliente(string nome, string endereco, string telefone, string email, decimal saldo)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            Saldo = saldo;
        }
    }
}
