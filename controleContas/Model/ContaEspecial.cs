using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controleContas.Model
{
    public class ContaEspecial : Conta
    {
        private double limite;

        public ContaEspecial(double limite, long numero, double saldo, Cliente titular) : base(numero, saldo, titular)
        {
            this.limite = limite;
        }

        public override bool Sacar(double value)
        {
            if (Saldo - (value + .10) > 0)
            {
                base.Sacar(value);
                return true;
            }
            return false;
        }

        public bool Transferir(Conta destino, double value)
        {
            if (value <= 0) throw new ArgumentOutOfRangeException("Erro: favor inserir com um número inválido.");
            if (destino == null) throw new ArgumentNullException("Erro: é necessário de um funcionario");

            base.Sacar(value-.10);
            destino.Depositar(value);
            return true;
        }
    }
}
