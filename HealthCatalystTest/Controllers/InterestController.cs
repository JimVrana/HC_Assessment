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
    public class InterestController : ControllerBase
    {
        private readonly IPeopleService _service;

        public InterestController(IPeopleService service)
        {
            _service = service;
        }

        // GET api/Interest
        [HttpGet]
        public ActionResult<IEnumerable<Interest>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = _service.GetAllInterests();
            return Ok(items);
        }

        // GET api/Interest/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Interest>> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = _service.GetAllInterestsForPerson(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
    }
}
