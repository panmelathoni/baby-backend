using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using babyApi.domain;
using Microsoft.EntityFrameworkCore;


namespace babyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BabyActivitiesController : ControllerBase
    {

        private readonly DataContext _context;

        public BabyActivitiesController(DataContext context)
        {
            _context = context;
        }

      

        [HttpGet]

        public async Task<ActionResult<List<BabyActivity>>> Get()
        {
            return Ok(await _context.BabiesActivities.ToListAsync());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<List<BabyActivity>>> Get(int id)
        {
            var activity = _context.BabiesActivities.FindAsync(id);
            if (activity == null)
            {
                return BadRequest("Baby Activity not Found.");
            }

            return Ok(activity);
        }


        [HttpPost]

        public async Task<ActionResult<List<BabyActivity>>> AddBabyActivity(BabyActivity activity)
        {
          await _context.BabiesActivities.AddAsync(activity);


            await _context.SaveChangesAsync();
            return Ok(await _context.BabiesActivities.ToListAsync());
        }

        [HttpPut]

        public async Task<ActionResult<List<BabyActivity>>> UpdateBabyActivity(BabyActivity request)
        {
            var dbactivity = await _context.BabiesActivities.FindAsync( request.Id);
            if (dbactivity == null)
            
                return BadRequest("Baby Activity not Found.");

            
            dbactivity.Id = request.Id;
            dbactivity.BabyProfileId = request.BabyProfileId;
            dbactivity.ActivityId = request.ActivityId;
            dbactivity.InitialTime = request.InitialTime;
            dbactivity.EndTime = request.EndTime;
            dbactivity.Description = request.Description;

            await _context.SaveChangesAsync();
            return Ok(await _context.BabiesActivities.ToListAsync());
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<List<BabyActivity>>> Delete(int id)
        {
            var dbactivity = await _context.BabiesActivities.FindAsync(id);
            if (dbactivity == null)
            
                return BadRequest("Baby Activity not Found.");

            _context.BabiesActivities.Remove(dbactivity);
            await _context.SaveChangesAsync();
            return Ok(await _context.BabiesActivities.ToListAsync());

        }

    }


}

