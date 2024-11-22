using netgs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace netgs.Repository.Interfaces
{
    public interface IAvaliacaoRepository : IMongoRepository<Avaliacao>
    {
        Task<double> ObterMediaPorDicaAsync(string dicaId);
    }
}
