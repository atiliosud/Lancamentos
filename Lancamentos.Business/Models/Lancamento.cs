using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lancamentos.Business.Models
{
    public class Lancamento
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public string Descricao { get; set; } = String.Empty;
        public DateTimeOffset Instante { get; set; }
        public int CaixaDiarioId { get; set; }
        public CaixaDiario? CaixaDiario { get; set; }

    }
}
