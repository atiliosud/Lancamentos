using Lancamentos.Business.Contracts.Repositories;
using Lancamentos.Business.Models;
using Lancamentos.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lancamentos.Repository.Repositories
{
    public class CaixaDiarioRepository : ICaixaDiarioRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CaixaDiarioRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public CaixaDiario? PegarCaixaPorDia(DateTimeOffset dia, string user)
        {
            return _dbContext.CaixaDiarios.FirstOrDefault(
                x =>
                x.Dia.Year == dia.Year &&
                x.Dia.Month == dia.Month &&
                x.Dia.Day == dia.Day &&
                x.ColaboradorId == user
            );
        }

        public CaixaDiario? PegarFluxoCaixaPorDia(DateTimeOffset dia, string user)
        {
            return _dbContext.CaixaDiarios.Include(x=>x.Lancamentos).FirstOrDefault(
                x =>
                x.Dia.Year == dia.Year &&
                x.Dia.Month == dia.Month &&
                x.Dia.Day == dia.Day &&
                x.ColaboradorId == user
            );
        }

        public void UpsertCaixa(CaixaDiario caixa)
        {
            if(caixa.Id == 0)
            {
                _dbContext.Add(caixa);
            }
            else
            {
                _dbContext.Update(caixa);
            }

            _dbContext.SaveChanges();
        }
    }
}
