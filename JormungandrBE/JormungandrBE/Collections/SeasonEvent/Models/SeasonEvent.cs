using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace JormungandrBE.Collections.SeasonEvent.Models
{
    public class SeasonEvent
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public DateTime Date { get; set; }
        public int EventNumber { get; set; }
        public string SeasonId { get; set; } = string.Empty;
    }
}
