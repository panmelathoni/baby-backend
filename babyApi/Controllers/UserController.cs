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
        private readonly IGenericRepository<User> _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;

        public UserController(IGenericRepository<User> userRepository, IPasswordService passwordService, IMapper mapper )
        {

            _userRepository = userRepository;
            _passwordService = passwordService;
            _mapper = mapper;
        }



        [HttpGet, Authorize]

        public IActionResult GetAll()
        {
            return Ok(_userRepository.GetAll());
        }


        [HttpGet("{id}"), Authorize]

        public IActionResult GetById(int id)
        {

            if (_userRepository.GetById(id) == null)
                return BadRequest("User Not Found");

            return Ok(_userRepository.GetById(id));

        }



        //register God
        [HttpPost]

        public IActionResult AddUser(UserDto userDto)
        {
            (byte[] passwordHash, byte[] passwordSalt) = _passwordService.CreatePasswordHash(userDto.Password);


            var user = _mapper.Map<User>(userDto);

           
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return Ok(_userRepository.Add(user));


        }


        [HttpPut, Authorize]

        public IActionResult UpdateUser(UserDto userDto)
        {
            if (userDto == null)
                return BadRequest("User Not Found");
            var userUp = _mapper.Map<User>(userDto);
            return Ok(_userRepository.Update(userUp));
        }


        [HttpDelete("{id}"), Authorize]

        public IActionResult DeleteUser(UserDto userDto)
        {
            if (userDto == null)
                return BadRequest("User Not Found");
            var userDel = _mapper.Map<User>(userDto);
            return Ok(_userRepository.Delete(userDel));

        }

   
    }
}
      

    




