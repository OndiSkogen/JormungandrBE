using System.Reflection;

namespace JormungandrBE.Collections.League.Interfaces
{
    public interface ILeagueService
    {
        Models.League GetLeague(string name);
        List<Models.League> GetLeagues();
        Models.League CreateLeague(Models.League league);
        bool DeleteLeague(string name);
        bool UpdateLeague(string name, Models.League leagueIn);
    }
}
