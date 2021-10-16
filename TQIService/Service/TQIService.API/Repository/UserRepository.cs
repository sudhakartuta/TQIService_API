using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TQIService.API.Data;
using TQIService.API.Entites;

namespace TQIService.API.Repository
{
    public class UserRepository : IUsersRepository
    {
        private readonly ITQIServiceAPIContext _context;

        public UserRepository(ITQIServiceAPIContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<IEnumerable<users>> GetUsers()
        {
            return await _context.users.Find(r => true).ToListAsync();
        }

        public async Task<users> GetUser(string ID)
        {
            return await _context.users.Find(r => r.Id == ID).FirstOrDefaultAsync();       
        }      

        public async Task CreateUser(users user)
        {
            await _context.users.InsertOneAsync(user);
        }

        public async Task<bool> UpdateUser(users user)
        {
            var updateData = await _context.users.ReplaceOneAsync(filter: r => r.Id == user.Id, replacement: user);
            return updateData.IsAcknowledged && updateData.ModifiedCount > 0;
        }
        public async Task<bool> DeleteUser(string ID)
        {
            var deleteUser = await _context.entryData.DeleteOneAsync(r => r.Id == ID);
            return deleteUser.IsAcknowledged && deleteUser.DeletedCount > 0;
        }
    }
}
