namespace ApartmentsAPI.Services.Abstract
{
    using ApartmentsAPI.Models.Interfaces;
    using ApartmentsAPI.Settings.Interfaces;
    using MongoDB.Driver;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class DbRepository<TEntity> : IRepository<TEntity> where TEntity: class, IId
    {
        private readonly IMongoCollection<TEntity> _entities;
        private const string s = "s";
        public DbRepository(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            string collectionName = typeof(TEntity).Name + s;
            _entities = database.GetCollection<TEntity>(collectionName);
        }

        public List<TEntity> Get() =>
            _entities.Find(entity => true).ToList();

        public TEntity Get(string id) =>
            _entities.Find<TEntity>(entity => entity.Id == id).FirstOrDefault();

        public TEntity Create(TEntity entity)
        {
            _entities.InsertOne(entity);
            return entity;
        }

        public void Update(string id, TEntity entityIn) =>
            _entities.ReplaceOne(entity => entity.Id == id, entityIn);

        public void Remove(TEntity entityIn) =>
            _entities.DeleteOne(entity => entity.Id == entityIn.Id);

        public void Remove(string id) =>
            _entities.DeleteOne(entity => entity.Id == id);
    }
}

