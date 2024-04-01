using System.Reflection;

namespace JormungandrBE.Collections.Season.Interfaces
{
    public interface ISeasonService
    {
        Models.Season GetSeason(string name);
        List<Models.Season> GetSeasons();
        Models.Season CreateSeason(Models.Season season);
        bool DeleteSeason(string name);
        bool UpdateSeason(string name, Models.Season seasonIn);
        List<Models.Season> GetSeasonsForLeague(string leagueId);
    }
}
