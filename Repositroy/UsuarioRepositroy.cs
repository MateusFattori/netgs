using MongoDB.Driver;
using netgs.Models;
using netgs.Repository.Interfaces;
using System.Threading.Tasks;

namespace netgs.Repository
{
    public class UsuarioRepository : MongoRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IMongoDatabase database)
            : base(database, "Usuarios")
        {
        }

        public async Task<Usuario?> BuscarPorEmailAsync(string email)
        {
            return await _collection.Find(u => u.Email == email).FirstOrDefaultAsync();
        }
    }
}
