
using Microsoft.AspNetCore.Mvc;
using babyApi.domain;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using babyApi.domain.Dto;
using babyApi.services.Interfaces;

namespace babyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class BabyProfileController : ControllerBase
    {
       
        private readonly IMapper _mapper;
        private readonly IBabyProfileService _babyProfileService;



        public BabyProfileController(IBabyProfileService babyProfileService, IMapper mapper)
        {
            _mapper = mapper;
            _babyProfileService = babyProfileService;
        }


        [HttpGet]

        public IActionResult GetAll()
        {
            var bpAll = _mapper.Map<List<BabyProfileDto>>(_babyProfileService.GetAll());
            return Ok(bpAll);
        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            if (_babyProfileService.GetById(id) == null)
                return BadRequest("Baby Profile Not Found");

            var bpById = _mapper.Map<BabyProfileDto>(_babyProfileService.GetById(id));

            return Ok(bpById);

        }


        [HttpPost]

        public IActionResult AddBabyProfile(BabyProfileDto babyProfileDto)
        {
            var bpAdd = _mapper.Map<BabyProfile>(babyProfileDto);
            return Ok(_babyProfileService.Add(bpAdd));
        }

        [HttpPut]

        public IActionResult UpdateBabyProfile(BabyProfileDto babyProfileDto)
        {
            if (babyProfileDto == null)
                return BadRequest("Baby Profile Not Found");

            var bpUp = _mapper.Map<BabyProfile>(babyProfileDto);

            return Ok(_babyProfileService.Update(bpUp));
        }


        [HttpDelete("{id}")]

        public IActionResult DeleteBabyProfile(BabyProfileDto babyProfileDto)
        {
            if (babyProfileDto == null)
                return BadRequest("Baby Profile Not Found");

            var bpDel = _mapper.Map<BabyProfile>(babyProfileDto);

            return Ok(_babyProfileService.Delete(bpDel));

        }

    }

}
