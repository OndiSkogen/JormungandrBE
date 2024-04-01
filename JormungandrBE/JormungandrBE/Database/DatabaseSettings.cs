using JormungandrBE.Interfaces;

namespace JormungandrBE.Database
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string DecksCollectionName { get; set; } = null!;
        public string EventResultsCollectionName { get; set; } = null!;
        public string SeasonEventsCollectionName { get; set; } = null!;
        public string LeaguesCollectionName { get; set; } = null!;
        public string MetaGamesCollectionName { get; set; } = null!;
        public string PlayersCollectionName { get; set; } = null!;
        public string UsersCollectionName { get; set; } = null!;
    }
}
