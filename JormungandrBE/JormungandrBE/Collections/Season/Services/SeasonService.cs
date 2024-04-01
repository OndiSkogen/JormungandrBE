using JormungandrBE.Collections.Season.Interfaces;
using JormungandrBE.Database;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace JormungandrBE.Collections.Season.Services
{
    public class SeasonService : ISeasonService
    {
        private readonly IMongoCollection<Models.Season> _seasons;

        public SeasonService(IOptions<DatabaseSettings> databaseSettings)
        {
            var client = new MongoClient(databaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);
            _seasons = database.GetCollection<Models.Season>(databaseSettings.Value.LeaguesCollectionName);
        }

        public Models.Season GetSeason(string name) => _seasons.Find(league => league.Name == name).FirstOrDefault();
        public List<Models.Season> GetSeasons() => _seasons.Find(league => true).ToList();

        public Models.Season CreateSeason(Models.Season season)
        {
            _seasons.InsertOne(season);
            return season;
        }

        public bool DeleteSeason(string name)
        {
            var result = _seasons.DeleteOne(league => league.Name == name);
            return result.DeletedCount > 0;
        }

        public bool UpdateSeason(string name, Models.Season leagueIn)
        {
            var result = _seasons.ReplaceOne(league => league.Name == name, leagueIn);
            return result.ModifiedCount > 0;
        }

        public List<Models.Season> GetSeasonsForLeague(string leagueId)
        {
            return _seasons.Find(season => season.LeagueId == leagueId).ToList();
        }
    }
}
