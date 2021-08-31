using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp4
{
    public class Lancamento
    {
        Conta Conta { get; set; }
        public decimal Valor { get; set; }

        public decimal MyProperty { get; set; }
    }


    public interface ILancamentoRepositorio
    {
        decimal ObterSaldo(Conta conta);
       
    }

    public class LancamentoRepositorio : ILancamentoRepositorio
    {
        public decimal ObterSaldo(Conta conta)
        {
            throw new NotImplementedException();
        }
    }

    public class Conta
    {

    }
}
