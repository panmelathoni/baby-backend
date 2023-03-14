using babyApi.data.Repositories;
using babyApi.domain;
using babyApi.domain.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Security.Claims;
using babyApi.services.Interfaces;

namespace babyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGenericRepository<User> _userRepo;
        private readonly IPasswordService _passwordService;

        public UserController(IGenericRepository<User> userRepo, IPasswordService passwordService)
        {

            _userRepo = userRepo;
            _passwordService = passwordService;
        }



        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(_userRepo.GetAll());
        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            if (_userRepo.GetById(id) == null)
                return BadRequest("User Not Found");

            return Ok(_userRepo.GetById(id));

        }



        [HttpPost]

        public IActionResult AddUser(UserDto userDto)
        {
           ( byte[] passwordHash, byte[] passwordSalt) = _passwordService.CreatePasswordHash(userDto.Password);

       
            User user = new User();
            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return Ok(_userRepo.Add(user));
        }



        [HttpPut]

        public IActionResult UpdateUser(User user)
        {
            if (user == null)
                return BadRequest("User Not Found");

            return Ok(_userRepo.Update(user));
        }


        [HttpDelete("{id}")]

        public IActionResult DeleteUser(User user)
        {
            if (user == null)
                return BadRequest("User Not Found");

            return Ok(_userRepo.Delete(user));

        }
 
    }
}
      

    




