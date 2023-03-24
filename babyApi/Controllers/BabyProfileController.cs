
using Microsoft.AspNetCore.Mvc;
using babyApi.domain;
using babyApi.data.Repositories;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using babyApi.domain.Dto;

namespace babyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BabyProfileController : ControllerBase
    {
        private readonly IGenericRepository<BabyProfile> _babyProfileRepo;
        private readonly IMapper _mapper;


        public BabyProfileController(IGenericRepository<BabyProfile> babyProfileRepo, IMapper mapper)
        {

            _babyProfileRepo = babyProfileRepo;
            _mapper = mapper;
        }


        [HttpGet]

        public IActionResult GetAll()
        {
            var bpAll = _mapper.Map<List<BabyProfileDto>>(_babyProfileRepo.GetAll());
            return Ok(bpAll);
        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            if (_babyProfileRepo.GetById(id) == null)
                return BadRequest("Baby Profile Not Found");

            var bpById = _mapper.Map<BabyProfileDto>(_babyProfileRepo.GetById(id));

            return Ok(bpById);

        }


        [HttpPost]

        public IActionResult AddBabyProfile(BabyProfileDto babyProfileDto)
        {
            var bpAdd = _mapper.Map<BabyProfile>(babyProfileDto);
            return Ok(_babyProfileRepo.Add(bpAdd));
        }

        [HttpPut]

        public IActionResult UpdateBabyProfile(BabyProfileDto babyProfileDto)
        {
            if (babyProfileDto == null)
                return BadRequest("Baby Profile Not Found");

            var bpUp = _mapper.Map<BabyProfile>(babyProfileDto);

            return Ok(_babyProfileRepo.Update(bpUp));
        }


        [HttpDelete("{id}")]

        public IActionResult DeleteBabyProfile(BabyProfileDto babyProfileDto)
        {
            if (babyProfileDto == null)
                return BadRequest("Baby Profile Not Found");

            var bpDel = _mapper.Map<BabyProfile>(babyProfileDto);

            return Ok(_babyProfileRepo.Delete(bpDel));

        }

    }
}
