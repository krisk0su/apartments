namespace ApartmentsAPI.Models.Housing
{
    using ApartmentsAPI.Models.Interfaces;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public abstract class BaseModel : IId, IPrice
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set ; }
        public double Price { get ; set ; }
    }
}
