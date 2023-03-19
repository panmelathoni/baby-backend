
using Microsoft.AspNetCore.Mvc;
using babyApi.domain;
using babyApi.data.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace babyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BabyProfileController : ControllerBase
    {
        private readonly IGenericRepository<BabyProfile> _babyProfileRepo;

        public BabyProfileController(IGenericRepository<BabyProfile> babyProfileRepo)
        {

            _babyProfileRepo = babyProfileRepo;
        }


        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(_babyProfileRepo.GetAll());
        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            if (_babyProfileRepo.GetById(id) == null)
                return BadRequest("Baby Profile Not Found");

            return Ok(_babyProfileRepo.GetById(id));

        }


        [HttpPost]

        public IActionResult AddBabyProfile(BabyProfile babyProfile)
        {
            return Ok(_babyProfileRepo.Add(babyProfile));
        }

        [HttpPut]

        public IActionResult UpdateBabyProfile(BabyProfile babyProfile)
        {
            if (babyProfile == null)
                return BadRequest("Baby Profile Not Found");

            return Ok(_babyProfileRepo.Update(babyProfile));
        }


        [HttpDelete("{id}")]

        public IActionResult DeleteBabyProfile(BabyProfile babyProfile)
        {
            if (babyProfile == null)
                return BadRequest("Baby Profile Not Found");

            return Ok(_babyProfileRepo.Delete(babyProfile));

        }

    }
}
