using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HealthCatalystTest.Contracts;
using HealthCatalystTest.Models;


namespace HealthCatalystTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _service;

        public PeopleController(IPeopleService service)
        {
            _service = service;
        }

        // GET api/People
        [HttpGet]
        [Route("/api/people")]
        public ActionResult<IEnumerable<Person>> Get(string q="")
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (q == "")
            {
                var items = _service.GetAllPeople();
                return Ok(items);
            }
            else
            {
                var items = _service.GetAllMatchingPeople(q);
                return Ok(items);
            }
           
        }

        // GET api/People/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = _service.GetPersonById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }     
    }
}
