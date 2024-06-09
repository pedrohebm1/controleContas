namespace controleContas.Model
{
    public class ContaCaixinha : Conta
    {
        private const double taxaSaque = 5.00;
        private const double bonusDeposito = 1;

        public ContaCaixinha(long numero, double saldo, Cliente titular) : base(numero, saldo, titular) { }
        public ContaCaixinha(long numero, Cliente titular) : base(numero, titular) {
            base.saldo = 10;
        }

        public override void Depositar(double value)
        {
            if (value < 1) throw new ArgumentOutOfRangeException("Erro: favor depositar com um valor válido.");
            base.Saldo += value+bonusDeposito;
        }

        public override bool Sacar(double value)
        {
            if (Saldo - (value + 5) >= 0)
            {
                Saldo-=value+(taxaSaque);
                return true;
            }
            return false;
        }
    }
}
