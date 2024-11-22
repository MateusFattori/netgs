using MongoDB.Driver;
using netgs.Models;
using netgs.Repository;
using netgs.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace netgs.Repository
{
    public class DicaRepository : MongoRepository<Dica>, IDicaRepository
    {
        public DicaRepository(IMongoDatabase database)
            : base(database, "Dicas")
        {
        }

        public async Task<IEnumerable<Dica>> BuscarPorCategoria(string categoriaId)
        {
            return await _collection.Find(d => d.CategoriaId == categoriaId).ToListAsync();
        }
    }
}
