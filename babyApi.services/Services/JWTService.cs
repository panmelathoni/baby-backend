using babyApi.data.Repositories;
using babyApi.domain;
using babyApi.domain.Dto;
using babyApi.services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace babyApi.services.Services
{

    public class JWTService : IJWTService
    {


        public readonly IConfiguration _configuration;
        private readonly IGenericRepository<User> _userRepo;
        private readonly IPasswordService _passwordService;

        public static User user = new User();
        public JWTService(IGenericRepository<User> userRepo, IConfiguration configuration, IPasswordService passwordService)
        {
            _userRepo = userRepo;
            _configuration = configuration;
            _passwordService = passwordService;
        }
        public UserDto UserLogin(UserDto userDto)
        {
            var userLogged = _userRepo.GetBy(x => x.Name.Equals(userDto.Name)).FirstOrDefault();
            if (userLogged == null)
                return new UserDto();

            var checkPassword = _passwordService.VerifyPassword(userDto.Password, userLogged.PasswordHash, userLogged.PasswordSalt);
            if (!checkPassword )
                return new UserDto();


            var userDtoLogged = new UserDto
            {
                Name = userLogged.Name,
                Email = userLogged.Email,
                Id = userLogged.Id,
                Token = CreateToken(userLogged.Name)
            };
            return userDtoLogged;
            
        }


       public string CreateToken(string username)
        {
            List<Claim> claims = new List<Claim>
           {
               new Claim(ClaimTypes.Name, username),

           };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;

        }

     
    }
}
