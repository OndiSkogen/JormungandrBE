using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace JormungandrBE.Collections.Player.Models
{
    public class Player
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string PlayerName { get; set; } = string.Empty;
        public int Events { get; set; } = 0;
        public int Points { get; set; } = 0;
        public int Wins { get; set; } = 0;
        public int Losses { get; set; } = 0;
        public int Ties { get; set; } = 0;
    }
}
