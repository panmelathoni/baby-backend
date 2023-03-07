using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using babyApi.domain;


namespace babyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BabyActivitiesController : ControllerBase
    {
        private static List<BabyActivities> activities = new List<BabyActivities>

        {
                new BabyActivities {
                    Id = 1,
                    BabyId = 1,
                    ActivityId = 1,
                    InitialTime = new DateTime(),
                    EndTime = new DateTime(),
                    Description = ""



               },
                 new BabyActivities {
                    Id = 2,
                    BabyId = 1,
                    ActivityId = 1,
                    InitialTime = new DateTime(),
                    EndTime = new DateTime(),
                    Description = ""


               },


            };

        [HttpGet]

        public async Task<ActionResult<List<BabyActivities>>> Get()
        {
            return Ok(activities);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<List<BabyActivities>>> Get(int id)
        {
            var activity = activities.Find(x => x.Id == id);
            if (activity == null)
            {
                return BadRequest("Baby Activity not Found.");
            }

            return Ok(activity);
        }


        [HttpPost]

        public async Task<ActionResult<List<BabyActivities>>> AddBabyActivity(BabyActivities activity)
        {
            activities.Add(activity);

            return Ok(activity);
        }

        [HttpPut]

        public async Task<ActionResult<List<BabyActivities>>> UpdateBabyActivity(BabyActivities request)
        {
            var activity = activities.Find(x => x.Id == request.Id);
            if (activity == null)
            {
                return BadRequest("Baby Activity not Found.");



            }
            activity.Id = request.Id;
            activity.BabyId = request.BabyId;
            activity.ActivityId = request.ActivityId;   
            activity.InitialTime = request.InitialTime; 
            activity.EndTime = request.EndTime;
            activity.Description = request.Description; 
            return Ok(activity);
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<List<BabyActivities>>> Delete(int id)
        {
            var activity = activities.Find(x => x.Id == id);
            if (activity == null)
            {
                return BadRequest("Baby Activity not Found.");


            }

            activities.Remove(activity);
            return Ok(activities);
        }

    }


}

