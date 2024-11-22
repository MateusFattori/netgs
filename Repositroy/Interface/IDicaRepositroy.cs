using netgs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace netgs.Repository.Interfaces
{
    public interface IDicaRepository : IMongoRepository<Dica>
    {
        Task<IEnumerable<Dica>> BuscarPorCategoria(string categoriaId);
    }
}
