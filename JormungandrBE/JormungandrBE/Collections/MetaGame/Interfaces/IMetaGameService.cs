using System.Reflection;

namespace JormungandrBE.Collections.MetaGame.Interfaces
{
    public interface IMetaGameService
    {
        List<Models.MetaGame> GetMetaGames();
        Models.MetaGame GetMetaGame(string id);
        Models.MetaGame CreateMetaGame(Models.MetaGame metaGame);
        bool UpdateMetaGame(string id, Models.MetaGame metaGameIn);
        bool DeleteMetaGame(string id);
        List<Models.MetaGame> GetMetaGamesForSeason(string seasonId);
    }
}
