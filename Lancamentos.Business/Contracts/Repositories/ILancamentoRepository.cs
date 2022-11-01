using Lancamentos.Business.Models;

namespace Lancamentos.Business.Contracts.Repositories
{
    public interface ILancamentoRepository
    {
        void InserirLancamento(Lancamento lancamentoDomain);
    }
}
