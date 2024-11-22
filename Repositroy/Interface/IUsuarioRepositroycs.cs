using netgs.Models;
using System.Threading.Tasks;

namespace netgs.Repository.Interfaces
{
    public interface IUsuarioRepository : IMongoRepository<Usuario>
    {
        Task<Usuario?> BuscarPorEmailAsync(string email);
    }
}
