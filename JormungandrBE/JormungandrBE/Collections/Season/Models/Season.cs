using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace JormungandrBE.Collections.Season.Models
{
    public class Season
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Winner { get; set; } = string.Empty;
        public string GroupStageWinner { get; set; } = string.Empty;
        public int NumberOfEvents { get; set; }
        public int NumberOfEventsToCount { get; set; }
        public string LeagueId { get; set; } = string.Empty;
    }
}
