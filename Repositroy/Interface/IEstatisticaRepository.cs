using netgs.Models;
using System.Threading.Tasks;

namespace netgs.Repository.Interfaces
{
    public interface IEstatisticaRepository : IMongoRepository<Estatistica>
    {
        Task<Estatistica> ObterEstatisticasGeraisAsync();
    }
}
