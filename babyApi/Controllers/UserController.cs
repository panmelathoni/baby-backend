using babyApi.domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace babyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }
       

        [HttpGet]

        public async Task<ActionResult<List<User>>> Get()
        {


            return Ok(await _context.Users.ToListAsync());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<List<User>>> Get(int id)
        {
            var user = _context.Users.FindAsync(id);
            if (user == null)
            
            return BadRequest("User not Found.");
            

            return Ok(user);
        }

        [HttpPost]

        public async Task<ActionResult<List<User>>> AddUser(User user)
        {

            await _context.Users.AddAsync(user);

        

            await _context.SaveChangesAsync();
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpPut]

        public async Task<ActionResult<List<User>>> UpdateUser(User request)
        {
            var dbuser = await  _context.Users.FindAsync(request.Id);
            if (dbuser == null)
            
                return BadRequest("User not Found.");
                
                dbuser.Name = request.Name;
                dbuser.Email = request.Email;
                dbuser.Password = request.Password;
     
                await _context.SaveChangesAsync();
                return Ok(await _context.Users.ToListAsync());
        }



        [HttpDelete("{id}")]

        public async Task<ActionResult<List<User>>> Delete(int Id)
        {
            var dbuser = await _context.Users.FindAsync(Id);
            if (dbuser == null)
            
                return BadRequest("User not Found.");

               _context.Users.Remove(dbuser);
                await _context.SaveChangesAsync();
                return Ok(await _context.Users.ToListAsync());
        }

    }



}
