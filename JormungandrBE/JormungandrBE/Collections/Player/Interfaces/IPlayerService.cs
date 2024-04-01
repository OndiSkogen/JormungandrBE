using System.Reflection;

namespace JormungandrBE.Collections.Player.Interfaces
{
    public interface IPlayerService
    {
        Models.Player GetPlayer(string name);
        List<Models.Player> GetPlayers();
        Models.Player CreatePlayer(Models.Player player);
        bool DeletePlayer(string name);
        bool UpdatePlayer(string name, Models.Player playerIn);
    }
}
