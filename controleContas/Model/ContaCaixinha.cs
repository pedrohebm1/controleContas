namespace controleContas.Model
{
    public class ContaCaixinha : Conta
    {
        public ContaCaixinha(long numero, double saldo, Cliente titular) : base(numero, saldo, titular) { }

        public override void Depositar(double value)
        {
            if (Saldo >= 1) throw new Exception("Erro: favor depositar com um valor válido.");

            base.Depositar(value+1);
        }

        public override bool Sacar(double value)
        {
            if (Saldo - (value + 5) >= 0)
            {
                Sacar(value+4.90);
                return true;
            }
            return false;
        }
    }
}
