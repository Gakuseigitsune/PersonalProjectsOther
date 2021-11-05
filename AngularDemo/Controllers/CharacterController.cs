using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularDemo.Models;

namespace AngularDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {

        [HttpGet]
        public List<Character> GetAll() => DAL.GetAll().ToList();


        [HttpPost]
        public void AddNew(Character c) => DAL.Add(c);

    }

}
