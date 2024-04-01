using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JormungandrBE.Collections.Deck.Models
{
    public class Deck
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SuperArchType { get; set; } = string.Empty;
        public string ColorAffiliation { get; set; } = string.Empty;
        public MetaGame.Models.MetaGame MetaGame { get; set; } = new MetaGame.Models.MetaGame();
    }
}
