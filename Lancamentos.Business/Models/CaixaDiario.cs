using Microsoft.AspNetCore.Identity;

namespace Lancamentos.Business.Models
{
    public class CaixaDiario
    {
        public int Id { get; set; }
        public DateTimeOffset Dia { get; set; }
        public Decimal Saldo { get; set; } = 0;
        public string ColaboradorId { get; set; } = string.Empty;
        public IdentityUser? Colaborador { get; set; }
        public IEnumerable<Lancamento> Lancamentos { get; set; } = new List<Lancamento>();

        internal static CaixaDiario FactoryVazio(DateTimeOffset dia, string user)
        {
            return new CaixaDiario()
            {
                Dia = dia,
                ColaboradorId = user
            };
        }
    }
}
