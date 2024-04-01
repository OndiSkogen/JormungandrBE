using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace JormungandrBE.Collections.MetaGame.Models
{
    public class MetaGame
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public SeasonEvent.Models.SeasonEvent SeasonEvent { get; set; } = new SeasonEvent.Models.SeasonEvent();
        public List<Deck.Models.Deck> Decks { get; set; } = new List<Deck.Models.Deck>();
    }
}
