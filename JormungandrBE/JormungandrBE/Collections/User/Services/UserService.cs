using JormungandrBE.Collections.User.Interfaces;
using JormungandrBE.Database;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JormungandrBE.Collections.User.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<Models.User> _users;
        private readonly IConfiguration _configuration;

        public UserService(IOptions<DatabaseSettings> databaseSettings, IConfiguration configuration)
        {
            var client = new MongoClient(databaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);
            _users = database.GetCollection<Models.User>(databaseSettings.Value.UsersCollectionName);
            _configuration = configuration;
        }

        public List<Models.User> GetUsers() => _users.Find(user => true).ToList();

        public Models.User GetUser(string id) => _users.Find(user => user.Id == id).FirstOrDefault();

        public Models.User CreateUser(Models.User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public string Authenticate(string email, string password)
        {
            var users = _users.Find(u => true).ToList();
            var user = _users.Find(u => u.Email == email && u.Password == password).FirstOrDefault();

            if (user == null)
            {
                return "User not found";
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = _configuration.GetValue<string>("JwtKey");
            var tokenKey = Encoding.ASCII.GetBytes(key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
