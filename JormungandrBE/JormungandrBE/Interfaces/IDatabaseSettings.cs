namespace JormungandrBE.Interfaces
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string DecksCollectionName { get; set; }
        string EventResultsCollectionName { get; set; }
        string SeasonEventsCollectionName { get; set; }
        string LeaguesCollectionName { get; set; }
        string MetaGamesCollectionName { get; set; }
        string PlayersCollectionName { get; set; }
        string UsersCollectionName { get; set; }
    }
}
