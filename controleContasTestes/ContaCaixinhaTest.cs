using controleContas.Model;

namespace controleContasTestes
{
    [TestClass]
    public class ContaCaixinhaTest
    {
        Random random = new Random();

        public double randomDoubleRange(double min, double max)
        {
            return random.NextDouble() * (max - min) + min;
        }

        [TestMethod]
        public void Depositar()
        {
            double saldoInicial = randomDoubleRange(50.0, 100.0);
            double saldoDepositar = randomDoubleRange(200.0, 400.0);
            Cliente titular = new Cliente("cliente@gmail.com", 2001, "cliente", "19584938405");
            Conta conta = new ContaCaixinha(1000, saldoInicial, titular);

            conta.Depositar(saldoDepositar);
            Assert.AreEqual(conta.Saldo, saldoInicial+saldoDepositar+1.0);
        }

        [TestMethod]
        public void DepositarValorInvalido()
        {
            double saldoInicial = randomDoubleRange(50.0, 100.0);
            double saldoDepositar = randomDoubleRange(-50.0, 0);
            Cliente titular = new Cliente("cliente@gmail.com", 2001, "cliente", "19584938405");
            Conta conta = new ContaCaixinha(1000, saldoInicial, titular);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => conta.Depositar(saldoDepositar));

        }

        [TestMethod]
        public void Sacar()
        {
            double saldoInicial = randomDoubleRange(50.0, 100.0);
            double saldoSacar = randomDoubleRange(10.0, 50.0);
            Cliente titular = new Cliente("cliente@gmail.com", 2001, "cliente", "19584938405");
            Conta conta = new ContaCaixinha(1000, saldoInicial, titular);

            conta.Sacar(saldoSacar);

            Assert.AreEqual(conta.Saldo, saldoInicial-(saldoSacar+5.0));
        }

        [TestMethod]
        public void SacarValorIndisponivel()
        {
            double saldoInicial = randomDoubleRange(50.0, 100.0);
            double saldoDepositar = randomDoubleRange(200.0, 400.0);
            double saldoSacar = randomDoubleRange(0, saldoInicial+saldoDepositar);
            Cliente titular = new Cliente("cliente@gmail.com", 2001, "cliente", "19584938405");
            Conta conta = new Conta(1000, saldoInicial, titular);

            Assert.IsFalse(conta.Sacar(conta.Saldo));
        }

        [TestMethod]
        public void SacarValorInvalido()
        {
            double saldoInicial = randomDoubleRange(50.0, 100.0);
            double saldoDepositar = randomDoubleRange(200.0, 400.0);
            double saldoSacar = saldoInicial;
            Cliente titular = new Cliente("cliente@gmail.com", 2001, "cliente", "19584938405");
            Conta conta = new Conta(1000, saldoInicial, titular);

            Assert.IsFalse(conta.Sacar(0));
        }
    }
}
