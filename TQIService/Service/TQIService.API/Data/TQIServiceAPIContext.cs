using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TQIService.API.Entites;

namespace TQIService.API.Data
{
    public class TQIServiceAPIContext : ITQIServiceAPIContext
    {
        public TQIServiceAPIContext( IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            users = database.GetCollection<users>(configuration.GetValue<string>("DatabaseSettings:UserCollection"));
            entryData = database.GetCollection<entryData>(configuration.GetValue<string>("DatabaseSettings:EntryCollection"));

        }
        public IMongoCollection<users> users { get; }

        public IMongoCollection<entryData> entryData { get; }

    }
}
