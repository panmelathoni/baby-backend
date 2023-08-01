
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
     
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;


        public UserController( IPasswordService passwordService, IMapper mapper, IUserService userService )
        {

           
            _passwordService = passwordService;
            _mapper = mapper;
            _userService = userService;
        }



        [HttpGet, Authorize]

        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }


        [HttpGet("{id}"), Authorize]

        public IActionResult GetById(int id)
        {

            if (_userService.GetById(id) == null)
                return BadRequest("User Not Found");

            return Ok(_userService.GetById(id));

        }



        //register God
        [HttpPost]

        public IActionResult AddUser(UserDto userDto)
        {
            (byte[] passwordHash, byte[] passwordSalt) = _passwordService.CreatePasswordHash(userDto.Password);


            var user = _mapper.Map<User>(userDto);

           
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return Ok(_userService.Add(user));


        }


        [HttpPut, Authorize]

        public IActionResult UpdateUser(UserDto userDto)
        {
            if (userDto == null)
                return BadRequest("User Not Found");
            var userUp = _mapper.Map<User>(userDto);
            return Ok(_userService.Update(userUp));
        }


        [HttpDelete("{id}"), Authorize]

        public IActionResult DeleteUser(UserDto userDto)
        {
            if (userDto == null)
                return BadRequest("User Not Found");
            var userDel = _mapper.Map<User>(userDto);
            return Ok(_userService.Delete(userDel));

        }

   
    }
}
      

    




