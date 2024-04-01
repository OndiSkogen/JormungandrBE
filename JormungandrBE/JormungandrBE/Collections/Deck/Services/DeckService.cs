using JormungandrBE.Collections.Deck.Interfaces;
using JormungandrBE.Database;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace JormungandrBE.Collections.Deck.Services
{
    public class DeckService : IDeckService
    {
        private readonly IMongoCollection<Models.Deck> _decks;

        public DeckService(IOptions<DatabaseSettings> databaseSettings)
        {
            var client = new MongoClient(databaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);
            _decks = database.GetCollection<Models.Deck>(databaseSettings.Value.DecksCollectionName);
        }

        public Models.Deck GetDeck(string name) => _decks.Find(deck => deck.Name == name).FirstOrDefault();
        public List<Models.Deck> GetDecks() => _decks.Find(deck => true).ToList();

        public Models.Deck CreateDeck(Models.Deck deck)
        {
            _decks.InsertOne(deck);
            return deck;
        }

        public bool DeleteDeck(string name)
        {
            var result = _decks.DeleteOne(deck => deck.Name == name);
            return result.DeletedCount > 0;
        }

        public bool UpdateDeck(string name, Models.Deck deckIn)
        {
            var result = _decks.ReplaceOne(deck => deck.Name == name, deckIn);
            return result.ModifiedCount > 0;
        }
    }
}
