using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace netgs.Models
{
    public class Avaliacao
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string DicaId { get; set; } = string.Empty;

        public int Nota { get; set; }

        public string Comentario { get; set; } = string.Empty;

        public DateTime DataAvaliacao { get; set; } = DateTime.UtcNow;
    }
}
