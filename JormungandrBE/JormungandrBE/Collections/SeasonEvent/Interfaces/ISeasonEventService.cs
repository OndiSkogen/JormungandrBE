using System.Reflection;

namespace JormungandrBE.Collections.SeasonEvent.Interfaces
{
    public interface ISeasonEventService
    {
        Models.SeasonEvent GetSeasonEvent(string name);
        List<Models.SeasonEvent> GetSeasonEvents();
        Models.SeasonEvent CreateSeasonEvent(Models.SeasonEvent seasonEvent);
        bool DeleteSeasonEvent(string name);
        bool UpdateSeasonEvent(string name, Models.SeasonEvent seasonEventIn);
        List<Models.SeasonEvent> GetSeasonEventsForSeason(string seasonId);
    }
}
