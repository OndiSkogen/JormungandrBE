using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace JormungandrBE.Collections.User.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("Password")]
        public string Password { get; set; } = string.Empty;
    }
}
