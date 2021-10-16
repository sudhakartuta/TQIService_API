using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TQIService.API.Entites;
using TQIService.API.Repository;

namespace TQIService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController:ControllerBase
    {
        private readonly IUsersRepository _repository;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUsersRepository repository, ILogger<UsersController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<users>),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<users>>> GetUsers() {
            var data = await _repository.GetUsers();
            return Ok(data);
        }

        [HttpGet("{id:length(24)}",Name ="GetUser")]
        [ProducesResponseType(typeof(users), (int)HttpStatusCode.OK)]

        public async Task<ActionResult<users>> GetUser(string ID)
        {
            var user = await _repository.GetUser(ID);

            if (user == null)
            {
                _logger.LogError($"Usre not found with the ID {ID}");
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(typeof(users), (int)HttpStatusCode.OK)]

        public async Task<ActionResult<users>> CreateUser(users user)
        {
            await _repository.CreateUser(user);

            return CreatedAtRoute("GetUser", new { ID = user.Id, user });
        }

        [HttpPut]
        [ProducesResponseType(typeof(users), (int)HttpStatusCode.OK)]

        public async Task<ActionResult<users>> UpdateUser(users user)
        {
            return Ok(await _repository.UpdateUser(user)); 
        }

        [HttpDelete]
        [ProducesResponseType(typeof(users), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteUser(string ID)
        {
            return Ok(await _repository.DeleteUser(ID));
        }

    }
}
