using netgs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace netgs.Repository.Interfaces
{
    public interface IHistoricoRepository : IMongoRepository<Historico>
    {
        Task<IEnumerable<Historico>> ObterPorDicaAsync(string dicaId);
    }
}
