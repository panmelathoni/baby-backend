using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using babyApi.domain;
using Microsoft.EntityFrameworkCore;

using babyApi.data.Repositories;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using babyApi.domain.Dto;

namespace babyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BabyActivityController : ControllerBase
    {
        private readonly IGenericRepository<BabyActivity> _babyActivityRepo;
        private readonly IMapper _mapper;



        public BabyActivityController(IGenericRepository<BabyActivity> babyActivityRepo, IMapper mapper)
        {

            _babyActivityRepo = babyActivityRepo;
            _mapper = mapper;
        }



        [HttpGet]

        public IActionResult GetAll()
        {
            var bAcAll = _mapper.Map<List<BabyActivityDto>>(_babyActivityRepo.GetAll());
            return Ok(bAcAll);
        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            if (_babyActivityRepo.GetById(id) == null)
                return BadRequest("Baby Activity Not Found");

            var bAcById = _mapper.Map<BabyActivityDto>(_babyActivityRepo.GetById(id));

            return Ok(bAcById);

        }


        [HttpPost]

        public IActionResult AddBabyActivity(BabyActivityDto babyActivityDto)
        {
            var bAcAdd = _mapper.Map<BabyActivity>(babyActivityDto);
            return Ok(_babyActivityRepo.Add(bAcAdd));
        }

        [HttpPut]

        public IActionResult UpdateBabyActivity(BabyActivityDto babyActivityDto)
        {
            if (babyActivityDto == null)
                return BadRequest("Baby Activity Not Found");

            var bActUp = _mapper.Map<BabyActivity>(babyActivityDto);

            return Ok(_babyActivityRepo.Update(bActUp));
        }


        [HttpDelete("{id}")]

        public IActionResult DeleteBabyActivity(BabyActivityDto babyActivityDto)
        {
            if (babyActivityDto == null)
                return BadRequest("Baby Activity Not Found");

            var bAcDel = _mapper.Map<BabyActivity>(babyActivityDto);
            return Ok(_babyActivityRepo.Delete(bAcDel));

        }

    }


}

