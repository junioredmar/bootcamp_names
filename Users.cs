using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace bootcamp_names
{
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set;  }
        [BsonElement("lastName")]
        public string LastName { get; set;  }
        [BsonElement("nationality")]
        public string Nationality { get; set;  }
        [BsonElement("age")]
        public string Age { get; set;  }
    }
}