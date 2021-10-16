using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TQIService.API.Entites
{
    public class users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("username")]

        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public bool exist { get; set; }
        public DateTime? activedate { get; set; }
        public string access_level { get; set; }
        public string payment_mode { get; set; }
        public string lockedby { get; set; }
        public DateTime? lockeddate { get; set; }
        public string status { get; set; }

    }
}
