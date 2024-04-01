using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using JormungandrBE.Elements;

namespace JormungandrBE.Collections.League.Models
{
    public class League
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Format { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Preamble { get; set; } = string.Empty;
        public Ulist Prizes { get; set; } = new Ulist();
        public Ulist TieBreakers { get; set; } = new Ulist();
        public StatBox PointLeaders { get; set; } = new StatBox();
        public MetaGame.Models.MetaGame MetaGame { get; set; } = new MetaGame.Models.MetaGame();
    }
}
