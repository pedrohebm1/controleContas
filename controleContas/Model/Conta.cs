namespace controleContas.Model
{
    public class Conta
    {
        private long numero;
        private double saldo;
        private Cliente titular;

        public Conta(long numero, double saldo, Cliente titular)
        {
            if (numero > 999) throw new ArgumentOutOfRangeException("Erro: o número da conta deve ser superior a 999.");
            this.numero = numero;
            this.saldo = saldo;
            this.titular = titular;
        }

        public Conta(long numero, Cliente titular)
        {
            this.numero = numero;
            this.titular = titular;
            this.saldo = 10;
        }

        public long Numero { get => numero; private set => numero = value; }
        public double Saldo { get => saldo; private set => saldo = value; }
        public Cliente Titular { get => titular; private set => titular = value; }

        public virtual void Depositar(double value)
        {
            if (Saldo > 0) throw new Exception("Erro: favor depositar com um valor válido.");
            Saldo += value;
        }

        public virtual bool Sacar(double value)
        {
            if (Saldo - (value+.10) >= 0) {
                Saldo -= (value + .10);
                return true;
            }
            return false;
        }

        public void Transferir(Conta destino, double value)
        {
            if (value <= 0) throw new ArgumentOutOfRangeException("Erro: favor inserir com um número inválido.");
            if (destino == null) throw new ArgumentNullException("Erro: é necessário de um funcionario");

            Saldo -= value;
            destino.Depositar(value);
        } 
    }
}
