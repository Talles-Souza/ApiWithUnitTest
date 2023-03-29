using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult> FindAll()
        {
            var result = await _personService.FindAll();
            if (result.Code == 200) return Ok(result);
            return BadRequest(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> FindById(int id)
        {
            var result = await _personService.FindById(id);
            if (result.Code == 406) return Problem(
                      statusCode: 406, title: "Unacceptable character");
            else if (result.Code == 404) return NotFound(result);
            return Ok(result.Data);
            
        }
        [HttpPost("register")]
        public async Task<ActionResult> Create([FromBody] PersonDTO personDTO)
        {
            var result = await _personService.Create(personDTO);
            if (result.Code == 400) return BadRequest(result);
            return Ok(result.Data);
            
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _personService.Delete(id);
            if (result.Code == 406) return Problem(
                        statusCode: 406, title: "Unacceptable character");
            else if (result.Code == 404) return NotFound(result);
            return Ok(result.Message);
        }
    }
}
