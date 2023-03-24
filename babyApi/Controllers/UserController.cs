using babyApi.data.Repositories;
using babyApi.domain;
using babyApi.domain.Dto;
using Microsoft.AspNetCore.Mvc;
using babyApi.services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
namespace babyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGenericRepository<User> _userRepo;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;

        public UserController(IGenericRepository<User> userRepo, IPasswordService passwordService, IMapper mapper )
        {

            _userRepo = userRepo;
            _passwordService = passwordService;
            _mapper = mapper;
        }



        [HttpGet, Authorize]

        public IActionResult GetAll()
        {
            return Ok(_userRepo.GetAll());
        }


        [HttpGet("{id}"), Authorize]

        public IActionResult GetById(int id)
        {

            if (_userRepo.GetById(id) == null)
                return BadRequest("User Not Found");

            return Ok(_userRepo.GetById(id));

        }



        //register God
        [HttpPost]

        public IActionResult AddUser(UserDto userDto)
        {
            (byte[] passwordHash, byte[] passwordSalt) = _passwordService.CreatePasswordHash(userDto.Password);


            var user = _mapper.Map<User>(userDto);

           
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return Ok(_userRepo.Add(user));


        }


        [HttpPut, Authorize]

        public IActionResult UpdateUser(User user)
        {
            if (user == null)
                return BadRequest("User Not Found");

            return Ok(_userRepo.Update(user));
        }


        [HttpDelete("{id}"), Authorize]

        public IActionResult DeleteUser(User user)
        {
            if (user == null)
                return BadRequest("User Not Found");

            return Ok(_userRepo.Delete(user));

        }

   
    }
}
      

    




