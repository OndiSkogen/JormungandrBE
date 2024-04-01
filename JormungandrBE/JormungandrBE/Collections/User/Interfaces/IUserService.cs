using System.Reflection;

namespace JormungandrBE.Collections.User.Interfaces
{
    public interface IUserService
    {
        string Authenticate(string email, string password);
        Models.User CreateUser(Models.User user);
        List<Models.User> GetUsers();
        Models.User GetUser(string id);
    }
}
