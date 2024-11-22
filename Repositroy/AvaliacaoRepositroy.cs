using MongoDB.Driver;
using netgs.Models;
using netgs.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace netgs.Repository
{
    public class AvaliacaoRepository : MongoRepository<Avaliacao>, IAvaliacaoRepository
    {
        public AvaliacaoRepository(IMongoDatabase database)
            : base(database, "Avaliacoes")
        {
        }

        public async Task<double> ObterMediaPorDicaAsync(string dicaId)
        {
            var avaliacoes = await _collection.Find(a => a.DicaId == dicaId).ToListAsync();
            return avaliacoes.Any() ? avaliacoes.Average(a => a.Nota) : 0;
        }
    }
}
