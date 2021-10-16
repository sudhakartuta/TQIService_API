using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TQIService.API.Entites
{
    public class entryData
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string formnumber { get; set; }
        public string details { get; set; }
        public string userid { get; set; }
        public string username { get; set; }
        public DateTime? entrydate { get; set; }
        public string pay_mode { get; set; }
        public string pay_sent { get; set; }
        public string pay_approvedby { get; set; }
        public DateTime? approved_date { get; set; }
        public string status { get; set; }
    }
}
