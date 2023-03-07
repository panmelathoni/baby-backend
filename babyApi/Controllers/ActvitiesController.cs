using Microsoft.AspNetCore.Http;
using babyApi.domain;
using Microsoft.AspNetCore.Mvc;

namespace babyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActvitiesController : ControllerBase
    {
        private static List<Activities> activitiesType = new List<Activities>

        {
                new Activities {
                    Id = 1,
                    NameActivity = "Breastfeeding",
                    CodeActivity = "Not",
                    Icon = "Bottle",
                   


               },
                 new Activities {
                    Id = 2,
                    NameActivity = "Breastfeeding",
                    CodeActivity = "yes",
                    Icon = "Bottle",


               },


            };
        private readonly DataContext dataContext;

        public ActvitiesController(DataContext context) {
           
        }

        [HttpGet]

        public async Task<ActionResult<List<Activities>>> Get()
        {
            return Ok(activitiesType);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<List<Activities>>> Get(int id)
        {
            var activity = activitiesType.Find(x => x.Id == id);
            if (activity == null)
            {
                return BadRequest("Activity not Found.");
            }

            return Ok(activity);
        }


        [HttpPost]

        public async Task<ActionResult<List<Activities>>> AddActivity(Activities activity)
        {
            activitiesType.Add(activity);

            return Ok(activity);
        }

        [HttpPut]

        public async Task<ActionResult<List<Activities>>> UpdateActivity(Activities request)
        {
            var activity = activitiesType.Find(x => x.Id == request.Id);
            if (activity == null)
            {
                return BadRequest("Baby not Found.");


              
            }
                activity.Id = request.Id;
                activity.NameActivity = request.NameActivity;
                activity.CodeActivity = request.CodeActivity;
                activity.Icon = request.Icon;
            return Ok(activity);
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Activities>>> Delete(int id)
        {
            var activity = activitiesType.Find(x => x.Id == id);
            if (activity == null)
            {
                return BadRequest("Baby not Found.");


            }

            activitiesType.Remove(activity);
            return Ok(activitiesType);
        }

    }
}

