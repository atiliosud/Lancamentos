using Lancamentos.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lancamentos.Business.Contracts.Repositories
{
    public interface ICaixaDiarioRepository
    {
        CaixaDiario? PegarCaixaPorDia(DateTimeOffset dia, string user);
        CaixaDiario? PegarFluxoCaixaPorDia(DateTimeOffset dia, string user);
        void UpsertCaixa(CaixaDiario caixa);
    }
}
