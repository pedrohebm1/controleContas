using controleContas.Model;

namespace controleContasTestes
{
    [TestClass]
    public class ContaTest
    {
        Random random = new Random();

        public double randomDoubleRange(double min, double max)
        {
            return random.NextDouble() * (max - min) + min;
        }

        [TestMethod]
        public void ContaNumeroErrado()
        {
            Cliente titular = new Cliente("cliente@gmail.com", 2001, "cliente", "19584938405");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Conta(999, titular));
        }

        [TestMethod]
        public void ContaSemTitular()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Conta(random.Next(), null));
        }

        [TestMethod]
        public void Depositar()
        {
            double saldoInicial = randomDoubleRange(50.0, 100.0);
            double saldoDepositar = randomDoubleRange(200.0, 400.0);
            Cliente titular = new Cliente("cliente@gmail.com", 2001, "cliente", "19584938405");
            Conta conta = new Conta(1000, saldoInicial, titular);

            conta.Depositar(saldoDepositar);

            Assert.AreEqual(conta.Saldo, saldoInicial + saldoDepositar);
        }

        [TestMethod]
        public void DepositarValorInvalido()
        {
            Cliente titular = new Cliente("cliente@gmail.com", 2001, "cliente", "19584938405");
            Conta conta = new Conta(1000, titular);

            Assert.ThrowsException<Exception>(() => conta.Depositar(0));
        }

        [TestMethod]
        public void Sacar()
        {
            double saldoInicial = randomDoubleRange(50.0, 100.0);
            double saldoDepositar = randomDoubleRange(200.0, 400.0);
            double saldoSacar = saldoInicial-.10;                                                                                                                                                                                                                                                                                                                                                                                
            Cliente titular = new Cliente("cliente@gmail.com", 2001, "cliente", "19584938405");
            Conta conta = new Conta(1000, saldoInicial, titular);

            conta.Sacar(saldoSacar);

            Assert.AreEqual(conta.Saldo, saldoInicial-(saldoSacar+.1));
        }

        [TestMethod]
        public void SacarValorIndisponivel()
        {
            double saldoInicial = randomDoubleRange(50.0, 100.0);
            double saldoDepositar = randomDoubleRange(200.0, 400.0);
            double saldoSacar = saldoInicial;
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

        [TestMethod]
        public void Transferir()
        {
            double saldoInicial1 = randomDoubleRange(50.0, 100.0);
            double saldoInicial2 = randomDoubleRange(50.0, 100.0);
            double saldoTransferir = randomDoubleRange(10.0, 50.0);
            Cliente titular1 = new Cliente("cliente@gmail.com", 2001, "cliente", "19584938405");
            Cliente titular2 = new Cliente("cliente@gmail.com", 4201, "cliente", "19584938405");
            Conta conta1 = new Conta(1000, saldoInicial1, titular1);
            Conta conta2 = new Conta(1400, saldoInicial2, titular2);

            try
            {
                conta1.Transferir(conta2, saldoTransferir);
            } catch (Exception exception)
            {
                Assert.Fail($"Error: {exception}");
            }
        }

        [TestMethod]
        public void TransferirValorInvalido()
        {
            double saldoInicial1 = randomDoubleRange(50.0, 100.0);
            double saldoInicial2 = randomDoubleRange(50.0, 100.0);
            Cliente titular1 = new Cliente("cliente@gmail.com", 2001, "cliente", "19584938405");
            Cliente titular2 = new Cliente("cliente@gmail.com", 4201, "cliente", "19584938405");
            Conta conta1 = new Conta(1000, saldoInicial1, titular1);
            Conta conta2 = new Conta(1000, saldoInicial2, titular2);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => conta1.Transferir(conta2, 0));
        }

        [TestMethod]
        public void TransferirSemDestinario()
        {
            double saldoInicial1 = randomDoubleRange(50.0, 100.0);
            double saldoInicial2 = randomDoubleRange(50.0, 100.0);
            double saldoTransferir = randomDoubleRange(0.0, 50.0);
            Cliente titular1 = new Cliente("cliente@gmail.com", 2001, "cliente", "19584938405");
            Conta conta1 = new Conta(1000, saldoInicial1, titular1);

            Assert.ThrowsException<ArgumentNullException>(() => conta1.Transferir(null, saldoTransferir));
        }
    }
}
