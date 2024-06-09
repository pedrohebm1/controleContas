namespace controleContas.Model
{
    public class ContaEspecial : Conta
    {
        private double limite;

        public ContaEspecial(double limite, long numero, double saldo, Cliente titular)
            : base(numero, saldo, titular)
        {
            if (limite > 1000) throw new ArgumentOutOfRangeException("Erro: o limite é necessário ser menor que 1000");
            this.limite = limite;
        }

        public ContaEspecial(double limite, long numero, Cliente titular)
            : base(numero, titular)
        {
            if (limite > 1000) throw new ArgumentOutOfRangeException("Erro: o limite é necessário ser menor que 1000");
            this.limite = limite;
        }

        public double Limite { get => limite; private set => limite = value; }

        public override bool Sacar(double value)
        {
            if (Saldo + limite - (value + .10) >= 0)
            {
                Saldo -= (value + .10);
                return true;
            }
            return false;
        }

        public void Transferir(Conta destino, double value)
        {
            if (value <= 0) throw new ArgumentOutOfRangeException("Erro: favor inserir um valor válido.");
            if (destino == null) throw new ArgumentNullException("Erro: é necessário uma conta destino.");
            if (Saldo + limite - value < 0) throw new ArgumentOutOfRangeException("Erro: saldo insuficiente.");

            Saldo -= value;
            destino.Depositar(value);
        }
    }
}