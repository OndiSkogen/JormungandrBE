using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace JormungandrBE.Collections.EventResult.Models
{
    public class EventResult
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string EventId { get; set; } = string.Empty;
        public string PlayerId { get; set; } = string.Empty;
        public int Points { get; set; }
        public decimal OMW { get; set; }
        public decimal GW { get; set; }
        public decimal OGW { get; set; }
        public int Placement { get; set; }
        public string PlayerName { get; set; } = string.Empty;
    }
}
