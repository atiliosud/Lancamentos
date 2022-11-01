using Lancamentos.Business.Models;

namespace Lancamentos.MVC.Models
{
    public class HomeVM
    {
        public Decimal SaldoAtual { get; set; }
        public DateTimeOffset Dia { get; set; }

        internal static HomeVM MapperToVM(CaixaDiario caixa)
        {
            return new HomeVM()
            {
                SaldoAtual = caixa.Saldo,
                Dia = caixa.Dia
            };
        }
    }
}