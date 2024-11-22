using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace netgs.Models
{
    public class Historico
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string DicaId { get; set; } = string.Empty;

        public DateTime DataAcesso { get; set; } = DateTime.UtcNow;
    }
}
