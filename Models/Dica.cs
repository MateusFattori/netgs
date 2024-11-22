using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace netgs.Models
{
    public class Dica
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string Titulo { get; set; } = string.Empty;

        public string CategoriaId { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }
}
