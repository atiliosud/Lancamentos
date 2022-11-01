using Lancamentos.Business.Models;

namespace Lancamentos.MVC.Models
{
    public class LancamentoNovoVM
    {
        public decimal Valor { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public string Descricao { get; set; } = String.Empty;

        internal Lancamento MapperToModel()
        {
            return new Lancamento()
            {
                Valor = this.Valor,
                TipoPagamento = this.TipoPagamento,
                Descricao = this.Descricao
            };
        }
    }
}