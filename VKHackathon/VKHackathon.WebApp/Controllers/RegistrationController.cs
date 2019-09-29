using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Requests;

namespace VKHackathon.WebApp.Controllers
{
    [Route("reg")]
    public class RegistrationController : Controller
    {
        private readonly AppDbContext dbContext;

        public RegistrationController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("adduser")]
        public async Task<IActionResult> PostUser([FromBody] RegistrUser user)
        {
            Client client = new Client()
            {
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
            };

            await dbContext.Clients.AddAsync(client);
            await dbContext.SaveChangesAsync();

            return Ok(client.Id);


        }
    }
}