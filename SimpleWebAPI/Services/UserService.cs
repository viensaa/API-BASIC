using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SampleWebAPI.Data;
using SampleWebAPI.Helpers;
using SampleWebAPI.Models;
using SimpleWebAPI.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
//using User = SampleWebAPI.Domain.User;



namespace SampleWebAPI.Services
{
    public interface IUserService
    {
       // AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        AuthenticateResponse Login(AuthenticateRequest model);
    }
    public class UserService : IUserService
    {
        private List<User> _users = new List<User>
        {
            
            new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
        };

        private readonly AppSettings _appSettings;
        private readonly SamuraiContext _context;

        public UserService(IOptions<AppSettings> appSettings,SamuraiContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        //public AuthenticateResponse Authenticate(AuthenticateRequest model)
        //{
        //    var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

        //    // return null if user not found
        //    if (user == null) return null;

        //    // authentication successful so generate jwt token
        //    var token = generateJwtToken(user);

        //    return new AuthenticateResponse(user, token);
        //}

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        private string generateJwtToken(Domain.User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public AuthenticateResponse Login(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == model.Username && u.Password == model.Password);
            if(user == null) return null;

            var token = generateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }

        
    }
}