﻿using babyApi.data.Repositories;
using babyApi.domain;
using Microsoft.AspNetCore.Mvc;


namespace babyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
     private readonly IGenericRepository<User> _userRepo;
       
        public UserController( IGenericRepository<User> userRepo)
        {
           
            _userRepo = userRepo;
        }

     

        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(_userRepo.GetAll());
        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
          
            if(_userRepo.GetById(id) == null) 
                return BadRequest("User Not Found");  

            return Ok(_userRepo.GetById(id));   
           
        }

       

        [HttpPost]

        public IActionResult AddUser(User user) 
        {
           return Ok(_userRepo.Add(user));
        }

      

        [HttpPut]

        public IActionResult UpdateUser(User user)
        {
            if (user == null)
                return BadRequest("User Not Found");

                    return Ok(_userRepo.Update(user));
        }


        [HttpDelete("{id}")]

        public IActionResult DeleteUser(User user)
        {
            if (user == null)
                return BadRequest("User Not Found");

            return Ok(_userRepo.Delete(user));

        }
    }
      

    }




