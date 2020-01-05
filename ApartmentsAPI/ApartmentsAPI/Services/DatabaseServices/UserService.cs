namespace ApartmentsAPI.Services.DatabaseServices
{
    using ApartmentsAPI.Models;
    using ApartmentsAPI.Services.AuthServices.Contracts;
    using ApartmentsAPI.Settings.Interfaces;
    using MongoDB.Driver;
    using System.Collections.Generic;
    using System.Linq;
    public class UserService
    {
        private readonly IMongoCollection<User> _books;
        private readonly IPasswordHasher _passwordService;

        public UserService(IBookstoreDatabaseSettings settings,  IPasswordHasher passwordService)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<User>(settings.UsersCollectionName);
            _passwordService = passwordService;
        }

        public List<User> Get() =>
            _books
            .Find(book => true)
            .ToList();

        public User Get(string id) =>
            _books.Find(user => user.Id == id).FirstOrDefault();

        public User Create(User user)
        {
            var password = this._passwordService.HashPassword(user.Password);
            user.Password = password;
            _books.InsertOne(user);
            return user;
        }
        public void Update(string id, User bookIn) =>
            _books.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(User bookIn) =>
            _books.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
            _books.DeleteOne(book => book.Id == id);
    }
}
