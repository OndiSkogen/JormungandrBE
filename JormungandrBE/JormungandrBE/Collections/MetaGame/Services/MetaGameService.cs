using JormungandrBE.Collections.MetaGame.Interfaces;
using JormungandrBE.Database;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace JormungandrBE.Collections.MetaGame.Services
{
    public class MetaGameService : IMetaGameService
    {
        private readonly IMongoCollection<Models.MetaGame> _metaGames;

        public MetaGameService(IOptions<DatabaseSettings> databaseSettings)
        {
            var client = new MongoClient(databaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);
            _metaGames = database.GetCollection<Models.MetaGame>(databaseSettings.Value.MetaGamesCollectionName);
        }

        public Models.MetaGame GetMetaGame(string id) => _metaGames.Find(metaGame => metaGame.Id == id).FirstOrDefault();
        public List<Models.MetaGame> GetMetaGames() => _metaGames.Find(metaGame => true).ToList();

        public Models.MetaGame CreateMetaGame(Models.MetaGame metaGame)
        {
            _metaGames.InsertOne(metaGame);
            return metaGame;
        }

        public bool DeleteMetaGame(string id)
        {
            var result = _metaGames.DeleteOne(metaGame => metaGame.Id == id);
            return result.DeletedCount > 0;
        }

        public bool UpdateMetaGame(string id, Models.MetaGame metaGameIn)
        {
            var result = _metaGames.ReplaceOne(metaGame => metaGame.Id == id, metaGameIn);
            return result.ModifiedCount > 0;
        }

        public List<Models.MetaGame> GetMetaGamesForSeason(string seasonId)
        {
            var metaGames = _metaGames.Find(metaGame => metaGame.SeasonEvent.Id == seasonId).ToList();
            return metaGames;
        }
    }
}
