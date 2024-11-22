using MongoDB.Driver;
using netgs.Models;
using netgs.Repository.Interfaces;
using System.Threading.Tasks;

namespace netgs.Repository
{
    public class EstatisticaRepository : MongoRepository<Estatistica>, IEstatisticaRepository
    {
        private readonly IMongoCollection<Usuario> _usuarios;
        private readonly IMongoCollection<Dica> _dicas;
        private readonly IMongoCollection<Categoria> _categorias;
        private readonly IMongoCollection<Avaliacao> _avaliacoes;

        public EstatisticaRepository(IMongoDatabase database)
            : base(database, "Estatisticas")
        {
            _usuarios = database.GetCollection<Usuario>("Usuarios");
            _dicas = database.GetCollection<Dica>("Dicas");
            _categorias = database.GetCollection<Categoria>("Categorias");
            _avaliacoes = database.GetCollection<Avaliacao>("Avaliacoes");
        }

        public async Task<Estatistica> ObterEstatisticasGeraisAsync()
        {
            var totalUsuarios = await _usuarios.CountDocumentsAsync(_ => true);
            var totalDicas = await _dicas.CountDocumentsAsync(_ => true);
            var totalCategorias = await _categorias.CountDocumentsAsync(_ => true);
            var totalAvaliacoes = await _avaliacoes.CountDocumentsAsync(_ => true);

            return new Estatistica
            {
                TotalUsuarios = (int)totalUsuarios,
                TotalDicas = (int)totalDicas,
                TotalCategorias = (int)totalCategorias,
                TotalAvaliacoes = (int)totalAvaliacoes,
                UltimaAtualizacao = DateTime.UtcNow
            };
        }
    }
}
