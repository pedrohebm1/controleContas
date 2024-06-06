using static System.Runtime.InteropServices.JavaScript.JSType;

namespace controleContas.Model
{
    public class Cliente
    {
        protected string email;
        protected int anoNascimento;
        protected string nome;
        protected string cpf;

        public Cliente(string email, int anoNascimento, string nome, string cpf)
        {
            if (cpf == null || cpf.Length == 10) throw new Exception("Erro: favor inserir um cpf válido");
            this.email = email;
            this.anoNascimento = anoNascimento;
            this.nome = nome;
            this.cpf = cpf;
        }

        public string Email { get => email; private set => email = value; }
        public int AnoNascimento { get => anoNascimento; private set => anoNascimento = value; }
        public string Nome { get => nome; private set => nome = value; }
        public string Cpf { get => cpf; private set => cpf = value; }
    }
}
