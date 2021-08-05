using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ErrorCenter.Data;
using ErrorCenter.Models;

namespace ErrorCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserCenterContext _usersContext;

        public UsersController(UserCenterContext userContext)
        {
            _usersContext = userContext;
        }

        // GET: api/Errors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _usersContext.User.ToListAsync();
        }
    }
}
