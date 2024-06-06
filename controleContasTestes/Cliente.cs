using controleContas.Model;

namespace controleContasTestes
{
    [TestClass]
    public class ClienteTest
    {
        [TestMethod]
        public void ClienteCriar()
        {
            Cliente cliente = new ("pdpsadpdsa@gmail.com", 2002, "Gon�alves", "19294839284");
            Assert.IsNotNull(cliente);
        }

        [TestMethod]
        public void ClienteCpfInvalido()
        {
            Assert.ThrowsException<Exception>(() => new Cliente("pdpsadpdsa@gmail.com", 2002, "Gon�alves", "1929483928"));
        }
    }
}