using JormungandrBE.Collections.SeasonEvent.Interfaces;
using JormungandrBE.Database;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace JormungandrBE.Collections.SeasonEvent.Services
{
    public class SeasonEventService : ISeasonEventService
    {
        private readonly IMongoCollection<Models.SeasonEvent> _seasonEvents;
        public SeasonEventService(IOptions<DatabaseSettings> databaseSettings)
        {
            var client = new MongoClient(databaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);
            _seasonEvents = database.GetCollection<Models.SeasonEvent>(databaseSettings.Value.SeasonEventsCollectionName);
        }
        public Models.SeasonEvent GetSeasonEvent(string id) => _seasonEvents.Find(seasonEvent => seasonEvent.Id == id).FirstOrDefault();
        public List<Models.SeasonEvent> GetSeasonEvents() => _seasonEvents.Find(seasonEvent => true).ToList();
        public Models.SeasonEvent CreateSeasonEvent(Models.SeasonEvent seasonEvent)
        {
            _seasonEvents.InsertOne(seasonEvent);
            return seasonEvent;
        }
        public bool DeleteSeasonEvent(string id)
        {
            var result = _seasonEvents.DeleteOne(seasonEvent => seasonEvent.Id == id);
            return result.DeletedCount > 0;
        }
        public bool UpdateSeasonEvent(string id, Models.SeasonEvent seasonEventIn)
        {
            var result = _seasonEvents.ReplaceOne(seasonEvent => seasonEvent.Id == id, seasonEventIn);
            return result.ModifiedCount > 0;
        }

        public List<Models.SeasonEvent> GetSeasonEventsForSeason(string seasonId)
        {
            var model = new List<Models.SeasonEvent>();

            foreach (var seasonEvent in _seasonEvents.Find(seasonEvent => seasonEvent.SeasonId == seasonId).ToList())
            {
                model.Add(seasonEvent);
            }

            return model;
        }
    }
}
