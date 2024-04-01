using JormungandrBE.Collections.Player.Interfaces;
using JormungandrBE.Database;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace JormungandrBE.Collections.Player.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IMongoCollection<Models.Player> _players;

        public PlayerService(IOptions<DatabaseSettings> databaseSettings)
        {
            var client = new MongoClient(databaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);
            _players = database.GetCollection<Models.Player>(databaseSettings.Value.PlayersCollectionName);
        }

        public Models.Player GetPlayer(string name) => _players.Find(player => player.PlayerName == name).FirstOrDefault();
        public List<Models.Player> GetPlayers() => _players.Find(player => true).ToList();

        public Models.Player CreatePlayer(Models.Player player)
        {
            _players.InsertOne(player);
            return player;
        }

        public bool DeletePlayer(string name)
        {
            var result = _players.DeleteOne(player => player.PlayerName == name);
            return result.DeletedCount > 0;
        }

        public bool UpdatePlayer(string name, Models.Player playerIn)
        {
            var result = _players.ReplaceOne(player => player.PlayerName == name, playerIn);
            return result.ModifiedCount > 0;
        }
    }
}
