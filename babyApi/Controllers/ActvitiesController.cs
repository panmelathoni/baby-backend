using babyApi.domain;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<ActionResult<List<Activity>>> Get()
        {
            return Ok(await _context.Activities.ToListAsync());

        }

        [HttpGet("{id}")]

        public async Task<ActionResult<List<Activity>>> Get(int id)
        {
            var activity = _context.Activities.FindAsync(id);
            if (activity == null)
            
                return BadRequest("Activity not Found.");
            

                return Ok(activity);
        }


        [HttpPost]

        public async Task<ActionResult<List<Activity>>> AddActivity(Activity activity)
        {
           await _context.Activities.AddAsync(activity);

            await _context.SaveChangesAsync();
           
            var activities = await _context.Activities.ToListAsync();
            return Ok(activities);
        }

        [HttpPut]

        public async Task<ActionResult<List<Activity>>> UpdateActivity(Activity request)
        {
            var dbactivity = await _context.Activities.FindAsync(request.Id);
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

        public async Task<ActionResult<List<Activity>>> Delete(int id)
        {
            var dbactivity = await _context.Activities.FindAsync(id);
            if (dbactivity == null)
            
                return BadRequest("Activity not Found.");

            _context.Activities.Remove(dbactivity);
            await _context.SaveChangesAsync();
            return Ok(await _context.Activities.ToListAsync());

        }

    }
}

