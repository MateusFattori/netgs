using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace netgs.Models
{
    public class Estatistica
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public int TotalUsuarios { get; set; }

        public int TotalDicas { get; set; }

        public int TotalCategorias { get; set; }

        public int TotalAvaliacoes { get; set; }

        public DateTime UltimaAtualizacao { get; set; } = DateTime.UtcNow;
    }
}
