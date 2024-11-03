using Backend2024.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using sovelluksenbackend.Models;
using Backend2024.Services;
using Azure.Identity;
using Microsoft.AspNetCore.Authorization;


namespace sovelluksenbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService service)
        {
            _userService = service;
        }
        [HttpGet]
        [Authorize]

        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            return Ok(await _userService.GetUsersAsync());
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<UserDTO>> GetUser(string username)
        {
            UserDTO? user = await _userService.GetUserAsync(username);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        //uusi
        [HttpPut("{username}")]

        public async Task<ActionResult<UserDTO>> PutUser(string username, User user)
        {
            if(username != user.UserName)
            { 
                return BadRequest();
            }

            if (await _userService.UpdateUserAsync(user))
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUser(User user)
        {
            UserDTO? newUser = await _userService.NewUserAsync(user);
            if (newUser == null)
            {
                return Problem("Username not available");
            }

            return CreatedAtAction("GetUser", new { username = user.UserName }, user);
        }
        [HttpDelete("{username}")]
        

        public async Task<IActionResult> DeleteUser(string username)
        {
            if(await _userService.DeleteUserAsync(username))
            { return NoContent(); }
            return NotFound();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
