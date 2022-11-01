using Lancamentos.Business.Models;

namespace Lancamentos.MVC.Models
{
    public class FluxoCaixaVM
    {
        public DateTimeOffset Dia { get; set; }
        public Decimal Saldo { get; set; } = 0;
        public IEnumerable<LancamentoVerVM> Lancamentos { get; set; } = new List<LancamentoVerVM>();

        internal static FluxoCaixaVM MapperToVM(CaixaDiario caixa)
        {
            return new FluxoCaixaVM()
            {
                Dia = caixa.Dia,
                Saldo = caixa.Saldo,
                Lancamentos = LancamentoVerVM.MapperToVM(caixa.Lancamentos)
            };
        }
    }
}