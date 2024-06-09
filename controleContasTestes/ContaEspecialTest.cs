using controleContas.Model;

namespace controleContasTestes
{
    [TestClass]
    public class ContaEspecialTest
    {
        Random random = new Random();
        private const double taxa = .10;

        public double randomDoubleRange(double min, double max)
        {
            return random.NextDouble() * (max - min) + min;
        }

        [TestMethod]
        public void LimitePermitido()
        {
            double limite = randomDoubleRange(0, 1000);
            Cliente titular = new Cliente("cliente@gmail.com", 2001, "cliente", "19584938405");
        }

        [TestMethod]
        public void LimiteUltrapassado()
        {
            Cliente titular = new Cliente("cliente@gmail.com", 2001, "cliente", "19584938405");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new ContaEspecial(1001, 1000, 23, titular));
        }

        [TestMethod]
        public void Sacar()
        {
            double saldoInicial = randomDoubleRange(50.0, 100.0);
            double saldoSacar = randomDoubleRange(10.0, 50.0);
            double limite = randomDoubleRange(0, 1000);
            Cliente titular = new Cliente("cliente@gmail.com", 2001, "cliente", "19584938405");
            Conta conta = new ContaEspecial(limite, 1000, saldoInicial, titular);

            conta.Sacar(saldoSacar);

            Assert.AreEqual(conta.Saldo, saldoInicial - (saldoSacar + taxa));
        }

        [TestMethod]
        public void TransferirForaLimite()
        {
            double limite = randomDoubleRange(0, 1000);
            double saldoInicial1 = randomDoubleRange(50.0, 100.0);
            double saldoInicial2 = randomDoubleRange(50.0, 100.0);
            double saldoTransferir = (randomDoubleRange(10.0, saldoInicial1)+limite)+10.0;
            Cliente titular1 = new Cliente("cliente@gmail.com", 2001, "cliente", "19584938405");
            Cliente titular2 = new Cliente("cliente@gmail.com", 4201, "cliente", "19584938405");
            Conta conta1 = new ContaEspecial(999, 1000, saldoInicial1, titular1);
            Conta conta2 = new Conta(1400, saldoInicial2, titular2);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => conta1.Transferir(conta1, saldoTransferir));
        }

        [TestMethod]
        public void TransferirValorInvalido()
        {
            double saldoInicial1 = randomDoubleRange(50.0, 100.0);
            double saldoInicial2 = randomDoubleRange(50.0, 100.0);
            Cliente titular1 = new Cliente("cliente@gmail.com", 2001, "cliente", "19584938405");
            Cliente titular2 = new Cliente("cliente@gmail.com", 4201, "cliente", "19584938405");
            Conta conta1 = new ContaEspecial(999, 1000, saldoInicial1, titular1);
            Conta conta2 = new ContaEspecial(999, 1000, saldoInicial2, titular2);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => conta1.Transferir(conta2, 0));
        }

        [TestMethod]
        public void TransferirSemDestinario()
        {
            double saldoInicial1 = randomDoubleRange(50.0, 100.0);
            double saldoInicial2 = randomDoubleRange(50.0, 100.0);
            double saldoTransferir = randomDoubleRange(0.0, 50.0);
            Cliente titular1 = new Cliente("cliente@gmail.com", 2001, "cliente", "19584938405");
            Conta conta1 = new ContaEspecial(999, 1000, saldoInicial1, titular1);

            Assert.ThrowsException<ArgumentNullException>(() => conta1.Transferir(null, saldoTransferir));
        }
    }
}
