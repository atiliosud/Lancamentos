using Lancamentos.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lancamentos.Business.Contracts.Services
{
    public interface ICaixaService
    {
        CaixaDiario PegarCaixaPorDia(DateTimeOffset hoje, string user);
        CaixaDiario PegarFluxoCaixaPorDia(DateTimeOffset dia, string user);
        void InserirLancamento(Lancamento lancamentoDomain, string user);
    }
}
