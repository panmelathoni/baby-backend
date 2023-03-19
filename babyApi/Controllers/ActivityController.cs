using babyApi.data.Repositories;
using babyApi.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace babyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ActivityController : ControllerBase
    {
        private readonly IGenericRepository<Activity> _activityRepo;



        public ActivityController(IGenericRepository<Activity> activityRepo)
        {

            _activityRepo = activityRepo;
        }



        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(_activityRepo.GetAll());
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            if (_activityRepo.GetById(id) == null)
                return BadRequest("User not Found");

            return Ok(_activityRepo.GetById(id));

        }


        [HttpPost]

        public IActionResult AddActivity(Activity activity)
        {
            return Ok(_activityRepo.Add(activity));
        }


        [HttpPut]

        public IActionResult UpdateActivity(Activity activity)
        {
            if (activity == null)
                return BadRequest("User Not Found");

            return Ok(_activityRepo.Update(activity));
        }


        [HttpDelete("{id}")]


        public IActionResult DeleteActivity(Activity activity)
        {
            if (activity == null)
                return BadRequest("User not Found");

            return Ok(_activityRepo.Delete(activity));

        }

    }
}

