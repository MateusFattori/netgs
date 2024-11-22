using MongoDB.Driver;
using netgs.Models;
using netgs.Repository;
using netgs.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netgs.Repository
{
    public class CategoriaRepository : MongoRepository<Categoria>, ICategoriaRepository
    {
        private readonly IMongoCollection<Dica> _dicasCollection;

        public CategoriaRepository(IMongoDatabase database)
            : base(database, "Categorias")
        {
            _dicasCollection = database.GetCollection<Dica>("Dicas");
        }

        public async Task<Categoria?> BuscarPorNomeAsync(string nome)
        {
            return await _collection.Find(c => c.Nome.ToLower() == nome.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<bool> ExisteCategoriaAsync(string nome)
        {
            var categoria = await BuscarPorNomeAsync(nome);
            return categoria != null;
        }

        public async Task<IEnumerable<(Categoria Categoria, int ContagemDicas)>> ListarCategoriasComContagemDicasAsync()
        {
            var categorias = await _collection.Find(_ => true).ToListAsync();

            var resultado = new List<(Categoria Categoria, int ContagemDicas)>();
            foreach (var categoria in categorias)
            {
                var contagemDicas = await _dicasCollection.CountDocumentsAsync(d => d.CategoriaId == categoria.Id);
                resultado.Add((categoria, (int)contagemDicas));
            }

            return resultado;
        }
    }
}
