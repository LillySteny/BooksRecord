using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BooksRecordWebAPI.Models
{
    public class Books
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }=String.Empty;
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
    }
}
