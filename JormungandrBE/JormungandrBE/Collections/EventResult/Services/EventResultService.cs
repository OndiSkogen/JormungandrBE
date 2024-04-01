using JormungandrBE.Collections.EventResult.Interfaces;
using JormungandrBE.Database;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace JormungandrBE.Collections.EventResult.Services
{
    public class EventResultService : IEventResultService
    {
        private readonly IMongoCollection<Models.EventResult> _eventResults;
        public EventResultService(IOptions<DatabaseSettings> databaseSettings)
        {
            var client = new MongoClient(databaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);
            _eventResults = database.GetCollection<Models.EventResult>(databaseSettings.Value.EventResultsCollectionName);
        }
        public Models.EventResult GetEventResult(string id) => _eventResults.Find(eventResult => eventResult.Id == id).FirstOrDefault();
        public List<Models.EventResult> GetEventResults() => _eventResults.Find(eventResult => true).ToList();
        public Models.EventResult CreateEventResult(Models.EventResult eventResult)
        {
            _eventResults.InsertOne(eventResult);
            return eventResult;
        }
        public bool DeleteEventResult(string id)
        {
            var result = _eventResults.DeleteOne(eventResult => eventResult.Id == id);
            return result.DeletedCount > 0;
        }
        public bool UpdateEventResult(string id, Models.EventResult eventResultIn)
        {
            var result = _eventResults.ReplaceOne(eventResult => eventResult.Id == id, eventResultIn);
            return result.ModifiedCount > 0;
        }

        public List<Models.EventResult> GetEventResultsForEvent(string eventId)
        {
            var model = new List<Models.EventResult>();
            foreach (var eventResult in _eventResults.Find(eventResult => eventResult.EventId == eventId).ToList())
            {
                model.Add(eventResult);
            }
            return model;
        }
    }
}
