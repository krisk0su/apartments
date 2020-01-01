using Apartments_Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apartments_API.Services.Abstract
{
    public abstract class MainService<T> where T: class
    {
        //private readonly IMongoCollection<T> _entity;

        //public MainService(IBookstoreDatabaseSettings settings)
        //{
        //    var client = new MongoClient(settings.ConnectionString);
        //    var database = client.GetDatabase(settings.DatabaseName);

        //    _entity = database.GetCollection<T>("dsaasd");
        //}

        //public List<Book> Get() =>
        //    _entity.Find(book => true).ToList();

        //public Book Get(string id) =>
        //    _entity.Find<Book>(book => book.Id == id).FirstOrDefault();

        //public Book Create(Book book)
        //{
        //    _entity.InsertOne(book);
        //    return book;
        //}

        //public void Update(string id, Book bookIn) =>
        //    _entity.ReplaceOne(book => book.Id == id, bookIn);

        //public void Remove(Book bookIn) =>
        //    _entity.DeleteOne(book => book.Id == bookIn.Id);

        //public void Remove(string id) =>
        //    _entity.DeleteOne(book => book.Id == id);
    }
}
