using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace APIMongoDB.Models
{
    public class Employees
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("salary")]
        public int Salary { get; set; }

        [BsonElement("address")]
        public string Address { get; set; } = string.Empty;

        [BsonElement("general")]
        public GeneralInfo General { get; set; } = null!;

        [BsonElement("social")]
        public string[] Social { get; set; } = null!;

        [BsonElement("department")]
        public string Department { get; set; } = null!;

    }

    public class GeneralInfo
    {
        [BsonElement("weight")]
        public Double Weight { get; set; } 
        [BsonElement("height")]
        public Double Height { get; set; }
        [BsonElement("gender")]
        public string Gender { get; set; } = null!;
    }
}
