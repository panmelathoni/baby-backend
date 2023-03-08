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

        public async Task<ActionResult<List<BabyActivities>>> Get()
        {
            return Ok(await _context.BabyActivities.ToListAsync());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<List<BabyActivities>>> Get(int id)
        {
            var activity = _context.BabyActivities.FindAsync();
            if (activity == null)
            {
                return BadRequest("Baby Activity not Found.");
            }

            return Ok(activity);
        }


        [HttpPost]

        public async Task<ActionResult<List<BabyActivities>>> AddBabyActivity(BabyActivities activity)
        {
           _context.BabyActivities.Add(activity);



            return Ok(await _context.BabyActivities.ToListAsync());
        }

        [HttpPut]

        public async Task<ActionResult<List<BabyActivities>>> UpdateBabyActivity(BabyActivities request)
        {
            var dbactivity = await _context.BabyActivities.FindAsync( request.Id);
            if (dbactivity == null)
            
                return BadRequest("Baby Activity not Found.");

            
            dbactivity.Id = request.Id;
            dbactivity.BabyId = request.BabyId;
            dbactivity.ActivityId = request.ActivityId;
            dbactivity.InitialTime = request.InitialTime;
            dbactivity.EndTime = request.EndTime;
            dbactivity.Description = request.Description;

            await _context.SaveChangesAsync();
            return Ok(await _context.BabyActivities.ToListAsync());
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<List<BabyActivities>>> Delete(int id)
        {
            var dbactivity = await _context.BabyActivities.FindAsync(Id);
            if (dbactivity == null)
            
                return BadRequest("Baby Activity not Found.");

            _context.BabyActivities.Remove(dbactivity);
            await _context.SaveChangesAsync();
            return Ok(await _context.BabyActivities.ToListAsync());

        }

    }


}

