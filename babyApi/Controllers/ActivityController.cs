using AutoMapper;
using babyApi.data.Repositories;
using babyApi.domain;
using babyApi.domain.Dto;
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
        private readonly IMapper _mapper;




        public ActivityController(IGenericRepository<Activity> activityRepo, IMapper mapper)
        {

            _activityRepo = activityRepo;
            _mapper = mapper;
        }

        

        [HttpGet]

        public IActionResult GetAll()
        {
            var actAll = _mapper.Map<List<ActivityDto>>(_activityRepo.GetAll());
            return Ok(actAll);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            if (_activityRepo.GetById(id) == null)
                return BadRequest("Activity not Found");

            var actById = _mapper.Map<ActivityDto>(_activityRepo.GetById(id));
            return Ok(actById);

        }


        [HttpPost]

        public IActionResult AddActivity(ActivityDto activityDto)
        {
            var act = _mapper.Map<Activity>(activityDto);
            return Ok(_activityRepo.Add(act));
        }


        [HttpPut]

        public IActionResult UpdateActivity(ActivityDto activityDto)
        {

            if (activityDto == null)
                return BadRequest("Activity Not Found");

            var act = _mapper.Map<Activity>(activityDto);

            return Ok(_activityRepo.Update(act));
        }


        [HttpDelete("{id}")]


        public IActionResult DeleteActivity(ActivityDto activityDto)
        {
            if (activityDto == null)
                return BadRequest("Activity not Found");

            var act = _mapper.Map<Activity>(activityDto);


            return Ok(_activityRepo.Delete(act));

        }

    }
}

