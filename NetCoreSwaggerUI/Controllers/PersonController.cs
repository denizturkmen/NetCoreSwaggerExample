using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreSwaggerUI.Business.Abstract;
using NetCoreSwaggerUI.Entities;

namespace NetCoreSwaggerUI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var personList = _personService.GetAll();
            return Ok(personList);
        }

       [HttpGet("{id}",Name = "GetById")]
        public IActionResult GetById(int id)
        {
            var person = _personService.GetById(id);
            if (person == null)
            {
                return BadRequest("Erorrr");
            }

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest("Person is Null!!!!");
            }

            _personService.Create(person);

            return CreatedAtRoute("GetById",
                new { Id = person.Id }, person);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest("erorr");
            }

            Person entity = _personService.GetById(id);
            if (entity == null)
            {
                return BadRequest("erorr");
            }

            entity.Adi = person.Adi;
            entity.Soyadi = person.Soyadi;

            _personService.Update(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Person person = _personService.GetById(id);

            if (person == null)
            {
                return NotFound("The Person record could not be found");
            }

            _personService.Delete(person);
            return NoContent();

        }
    }
}