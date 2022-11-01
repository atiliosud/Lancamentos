using Lancamentos.Business.Contracts.Repositories;
using Lancamentos.Business.Models;
using Lancamentos.Repository.Data;

namespace Lancamentos.Repository.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public LancamentoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InserirLancamento(Lancamento lancamentoDomain)
        {
            _dbContext.Add(lancamentoDomain);

            _dbContext.SaveChanges();
        }
    }
}
