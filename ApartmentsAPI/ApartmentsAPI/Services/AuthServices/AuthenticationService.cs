namespace ApartmentsAPI.Services.AuthServices
{
    using ApartmentsAPI.Enums;
    using ApartmentsAPI.Models;
    using ApartmentsAPI.Services.AuthServices.Contracts;
    using ApartmentsAPI.Settings;
    using ApartmentsAPI.Settings.Interfaces;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using MongoDB.Driver;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;

    public interface IAuthenticationService
    {
        User Authenticate(string username, string password);
    }

    public class AuthenticationService : IAuthenticationService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private readonly IMongoCollection<User> _users;
        private readonly IPasswordHasher _passwordService;
        private readonly AppSettings _appSettings;

        public AuthenticationService(IBookstoreDatabaseSettings settings, 
            IOptions<AppSettings> appSettings,
            IPasswordHasher passwordService)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _appSettings = appSettings.Value;

            _users = database.GetCollection<User>(settings.UsersCollectionName);
            _passwordService = passwordService;
        }

        public User Authenticate(string username, string password)
        {
            var user = _users.Find(user => user.Username == username).FirstOrDefault();

            // return null if user not found
            if (user == null)
                return null;

            var result = this._passwordService.VerifyHashedPassword(user.Password, password);

            if (result == PasswordVerificationResult.Failed) 
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }
    }
}
