using JormungandrBE.Collections.League.Interfaces;
using JormungandrBE.Database;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace JormungandrBE.Collections.League.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly IMongoCollection<Models.League> _leagues;

        public LeagueService(IOptions<DatabaseSettings> databaseSettings)
        {
            var client = new MongoClient(databaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);
            _leagues = database.GetCollection<Models.League>(databaseSettings.Value.LeaguesCollectionName);
        }

        public Models.League GetLeague(string name) => _leagues.Find(league => league.Name == name).FirstOrDefault();
        public List<Models.League> GetLeagues() => _leagues.Find(league => true).ToList();

        public Models.League CreateLeague(Models.League league)
        {
            _leagues.InsertOne(league);
            return league;
        }

        public bool DeleteLeague(string name)
        {
            var result = _leagues.DeleteOne(league => league.Name == name);
            return result.DeletedCount > 0;
        }

        public bool UpdateLeague(string name, Models.League leagueIn)
        {
            var result = _leagues.ReplaceOne(league => league.Name == name, leagueIn);
            return result.ModifiedCount > 0;
        }
    }
}
