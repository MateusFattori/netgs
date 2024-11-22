using MongoDB.Driver;
using netgs.Models;
using netgs.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace netgs.Repository
{
    public class HistoricoRepository : MongoRepository<Historico>, IHistoricoRepository
    {
        public HistoricoRepository(IMongoDatabase database)
            : base(database, "Historicos")
        {
        }

        public async Task<IEnumerable<Historico>> ObterPorDicaAsync(string dicaId)
        {
            return await _collection.Find(h => h.DicaId == dicaId).ToListAsync();
        }
    }
}
