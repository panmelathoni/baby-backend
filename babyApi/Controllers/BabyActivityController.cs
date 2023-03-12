using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using babyApi.domain;
using Microsoft.EntityFrameworkCore;

using babyApi.data.Repositories;

namespace babyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BabyActivityController : ControllerBase
    {
        private readonly IGenericRepository<BabyActivity> _babyActivityRepo;


        public  BabyActivityController(IGenericRepository<BabyActivity> babyActivityRepo)
        {

            _babyActivityRepo = babyActivityRepo;
        }



        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(_babyActivityRepo.GetAll());
        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            if (_babyActivityRepo.GetById(id) == null)
                return BadRequest("Baby Activity Not Found");

            return Ok(_babyActivityRepo.GetById(id));

        }


        [HttpPost]

        public IActionResult AddBabyActivity(BabyActivity babyActivity)
        {
            return Ok(_babyActivityRepo.Add(babyActivity));
        }

        [HttpPut]

        public IActionResult UpdateBabyActivity(BabyActivity babyActivity)
        {
            if (babyActivity == null)
                return BadRequest("Baby Activity Not Found");

            return Ok(_babyActivityRepo.Update(babyActivity));
        }


        [HttpDelete("{id}")]

        public IActionResult DeleteBabyActivity(BabyActivity babyActivity)
        {
            if (babyActivity == null)
                return BadRequest("Baby Activity Not Found");

            return Ok(_babyActivityRepo.Delete(babyActivity));

        }

    }


}

