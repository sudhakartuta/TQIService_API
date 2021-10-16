using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TQIService.API.Entites;

namespace TQIService.API.Data
{
    public interface ITQIServiceAPIContext
    {
        IMongoCollection<users> users { get; }
        IMongoCollection<entryData> entryData { get; }
    }
}
