using Lancamentos.Business.Contracts.Repositories;
using Lancamentos.Business.Contracts.Services;
using Lancamentos.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lancamentos.Business.Services
{
    public class CaixaService : ICaixaService
    {
        private readonly ICaixaDiarioRepository _caixaDiarioRepository;
        private readonly ILancamentoRepository _lancamentoRepository;
        public CaixaService(
            ICaixaDiarioRepository caixaDiarioRepository,
            ILancamentoRepository lancamentoRepository
            )
        {
            _caixaDiarioRepository = caixaDiarioRepository;
            _lancamentoRepository = lancamentoRepository;
        }
        public void InserirLancamento(Lancamento lancamentoDomain, string user)
        {
            var caixa = _caixaDiarioRepository.PegarCaixaPorDia(lancamentoDomain.Instante, user);
            if(caixa == null)
            {
                caixa = CaixaDiario.FactoryVazio(lancamentoDomain.Instante, user);
            }
            caixa.Saldo = caixa.Saldo + lancamentoDomain.Valor;
            //TODO:  abri transaction no banco para evitar concorrencia
            _caixaDiarioRepository.UpsertCaixa(caixa);
            lancamentoDomain.CaixaDiarioId = caixa.Id;
            _lancamentoRepository.InserirLancamento(lancamentoDomain);

        }

        public CaixaDiario PegarCaixaPorDia(DateTimeOffset dia, string user)
        {
            var caixa = _caixaDiarioRepository.PegarCaixaPorDia(dia, user);
            if(caixa == null)
            {
                return CaixaDiario.FactoryVazio(dia, user);
            }

            return caixa;

        }

        public CaixaDiario PegarFluxoCaixaPorDia(DateTimeOffset dia, string user)
        {
            var caixa = _caixaDiarioRepository.PegarFluxoCaixaPorDia(dia, user);
            if (caixa == null)
            {
                return CaixaDiario.FactoryVazio(dia, user);
            }

            return caixa;
        }
    }
}
