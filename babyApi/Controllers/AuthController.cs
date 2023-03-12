
using babyApi.domain.Dto;
using babyApi.services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace babyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJWTService _jwtService;

        public AuthController(IJWTService jwtService)
        {

            _jwtService = jwtService;
        }
        [HttpPost]

        public IActionResult UserLogin(UserDto userDto) 
        {
            return Ok(_jwtService.UserLogin(userDto));
        }

    }
}
