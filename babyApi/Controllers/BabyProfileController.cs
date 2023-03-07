using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using babyApi.domain;

namespace babyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BabyProfileController : ControllerBase
    {
        private static List<BabyProfile> babies = new List<BabyProfile>

        {
                new BabyProfile {
                    Id = 1,
                    UserId = 1,
                    Name = "Matteo",
                    Birth = "23-09-2022",
                    InicialWeight = 1820,
                    ActualWeight = 5960


               },
                 new BabyProfile {
                    Id = 2,
                    UserId = 1,
                    Name = "Caio",
                    Birth = "10-12-2022",
                    InicialWeight = 1820,
                    ActualWeight = 5960

               },


            };

        [HttpGet] 

        public async Task<ActionResult<List<BabyProfile>>> Get()
        {
            return Ok(babies);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<List<BabyProfile>>> Get(int id)
        {
            var baby = babies.Find(x => x.Id == id);
            if (baby == null)
            {
                return BadRequest("Baby not Found.");
            }

            return Ok(baby);
        }


        [HttpPost]

        public async Task<ActionResult<List<BabyProfile>>> AddUser(BabyProfile baby)
        {
            babies.Add(baby);

            return Ok(babies);
        }

        [HttpPut]

        public async Task<ActionResult<List<BabyProfile>>> UpdateBaby(BabyProfile request)
        {
            var baby = babies.Find(x => x.Id == request.Id);
            if (baby == null)
            {
                return BadRequest("Baby not Found.");

               
                
                baby.Name = request.Name;   
                baby.Birth = request.Birth;
                baby.InicialWeight = request.InicialWeight;
                baby.ActualWeight = request.ActualWeight;
                baby.Size = request.Size;
            
            }

            return Ok(babies);
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<List<BabyProfile>>> Delete(int id)
        {
            var baby = babies.Find(x => x.Id == id);
            if (baby == null)
            {
                return BadRequest("Baby not Found.");


            }

            babies.Remove(baby);
            return Ok(babies);
        }

    }
}
