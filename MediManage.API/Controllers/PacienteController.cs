using MediManage.Application.ImputModels;
using MediManage.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediManage.API.Controllers
{
    [Route("api/paciente")]
    public class PacienteController : Controller
    {
        private readonly IPacienteServices _pacienteServices;

        public PacienteController(IPacienteServices pacienteServices)
        {
            _pacienteServices = pacienteServices;
        }


        // api/paciente?query=net core
        [HttpGet]
        public IActionResult Get(string query)
        {
            var paciente = _pacienteServices.GetAll(query);

            return Ok(paciente);
        }

        // api/paciente/2
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var paciente = _pacienteServices.GetById(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return Ok(paciente);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewPacienteImputModel inputModel)
        {
            if (inputModel.Nome.Length > 150)
            {
                return BadRequest();
            }

            var id = _pacienteServices.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        // api/paciente/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdatePacienteImputModel inputModel)
         {
            if (inputModel.Nome.Length > 200)
            {
                return BadRequest();
            }

            _pacienteServices.Update(inputModel);

            return NoContent();
        }

        // api/paciente/3 DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pacienteServices.Delete(id);

            return NoContent();
        }
       
    }
}
