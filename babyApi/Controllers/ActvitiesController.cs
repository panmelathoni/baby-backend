using Microsoft.AspNetCore.Http;
using babyApi.domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace babyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActvitiesController : ControllerBase
    {

        private readonly DataContext _context;

        public ActvitiesController(DataContext context)
        {
            _context = context;
        }
       

        [HttpGet]

        public async Task<ActionResult<List<Activities>>> Get()
        {
            return Ok(await _context.Activities.ToListAsync());

        }

        [HttpGet("{id}")]

        public async Task<ActionResult<List<Activities>>> Get(int id)
        {
            var activity = _context.Activities.FindAsync(id);
            if (activity == null)
            
                return BadRequest("Activity not Found.");
            

                return Ok(activity);
        }


        [HttpPost]

        public async Task<ActionResult<List<Activities>>> AddActivity(Activities activity)
        {
           _context.Activities.Add(activity);

            return Ok(await _context.Activities.ToListAsync());

        }

        [HttpPut]

        public async Task<ActionResult<List<Activities>>> UpdateActivity(Activities request)
        {
            var dbactivity = await _context.Activities.FindAsync(request.Id)
            if (dbactivity == null)
            {
                return BadRequest("Activity not Found.");


              
            }
            dbactivity.Id = request.Id;
            dbactivity.NameActivity = request.NameActivity;
            dbactivity.CodeActivity = request.CodeActivity;
            dbactivity.Icon = request.Icon;

            await _context.SaveChangesAsync();
            return Ok(await _context.Activities.ToListAsync());

        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Activities>>> Delete(int id)
        {
            var dbactivity = await _context.Activities.FindAsync(Id);
            if (dbactivity == null)
            
                return BadRequest("Activity not Found.");

            _context.Activities.Remove(dbactivity);
            await _context.SaveChangesAsync();
            return Ok(await _context.Activities.ToListAsync());

        }

    }
}

