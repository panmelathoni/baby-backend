using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using babyApi.domain;
using Microsoft.EntityFrameworkCore;

namespace babyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BabyProfileController : ControllerBase
    {
        private readonly DataContext _context;

        public BabyProfileController(DataContext context)
        {
            _context = context;
        }

   

        [HttpGet] 

        public async Task<ActionResult<List<BabyProfile>>> Get()
        {
            return Ok(await _context.Babies.ToListAsync());

        }

        [HttpGet("{id}")]

        public async Task<ActionResult<List<BabyProfile>>> Get(int id)
        {
            var baby = _context.Babies.FindAsync(id);
            if (baby == null)

                return BadRequest("Baby Profile not Found.");


            return Ok(baby);
        }


        [HttpPost]

        public async Task<ActionResult<List<BabyProfile>>> AddBabyProfile(BabyProfile Babies)
        {
            _context.Babies.Add(Babies);

            return Ok(await _context.Babies.ToListAsync());
        }

        [HttpPut]

        public async Task<ActionResult<List<BabyProfile>>> UpdateBaby(BabyProfile request)
        {
            var dbbaby = await _context.Babies.FindAsync(request.Id);
            if (dbbaby == null)
            
                return BadRequest("Baby Profile not Found.");

                dbbaby.Name = request.Name;
                dbbaby.Birth = request.Birth;
                dbbaby.InicialWeight = request.InicialWeight;
                dbbaby.ActualWeight = request.ActualWeight;
                dbbaby.Size = request.Size;

            await _context.SaveChangesAsync();
            return Ok(await _context.Babies.ToListAsync());
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<List<BabyProfile>>> Delete(int id)
        {
            var dbbaby =await _context.Babies.FindAsync(id);
            if (dbbaby == null)
            
                return BadRequest("Baby Profile not Found.");

            _context.Babies.Remove(dbbaby);
            await _context.SaveChangesAsync();
            return Ok(await _context.Babies.ToListAsync());

        }

    }
}
