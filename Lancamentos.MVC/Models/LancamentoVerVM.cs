using Lancamentos.Business.Models;

namespace Lancamentos.MVC.Models
{
    public class LancamentoVerVM
    {
        public decimal Valor { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public string Descricao { get; set; } = String.Empty;

        internal static IEnumerable<LancamentoVerVM> MapperToVM(IEnumerable<Lancamento> lancamentos)
        {
            return lancamentos.Select(x => MapperToVM(x));
        }

        private static LancamentoVerVM MapperToVM(Lancamento lancamento)
        {
            return new LancamentoVerVM()
            {
                Valor = lancamento.Valor,
                Descricao = lancamento.Descricao,
                TipoPagamento = lancamento.TipoPagamento
            };
        }
    }
}