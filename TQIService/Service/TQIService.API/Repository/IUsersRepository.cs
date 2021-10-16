using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TQIService.API.Entites;

namespace TQIService.API.Repository
{
    public interface IUsersRepository
    {
        public Task<IEnumerable<users>> GetUsers();
        public Task<users> GetUser(string ID);
        public Task CreateUser(users user);
        public Task<bool> UpdateUser(users user);
        public Task<bool> DeleteUser(string ID);

    }
}
