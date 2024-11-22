using netgs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace netgs.Repository.Interfaces
{
    public interface ICategoriaRepository : IMongoRepository<Categoria>
    {
        Task<Categoria?> BuscarPorNomeAsync(string nome);

        Task<bool> ExisteCategoriaAsync(string nome);

        Task<IEnumerable<(Categoria Categoria, int ContagemDicas)>> ListarCategoriasComContagemDicasAsync();
    }
}
