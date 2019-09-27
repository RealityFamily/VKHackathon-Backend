using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace VKHackathon.WebApp.Controllers
{
    [Route("test")]
    public class RegistrationController : Controller
    {
        private readonly AppDbContext dbContext;

        public RegistrationController(AppDbContext dbContext )
        {
            this.dbContext = dbContext;
            
            



        }
    }
}