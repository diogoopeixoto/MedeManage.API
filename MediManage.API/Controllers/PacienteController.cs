using MediatR;
using MediManage.Application.Commands.CriarMedico;
using MediManage.Application.Commands.CriarPaciente;
using MediManage.Application.Commands.DeletePaciente;
using MediManage.Application.Commands.UpdateMedico;
using MediManage.Application.ImputModels;
using MediManage.Application.Queries.GetALLPacientesQuery;
using MediManage.Application.Queries.GetByCPFMedicosQuery;
using MediManage.Application.Queries.GetByCPFPacienteQuery;
using MediManage.Application.Services.Interfaces;
using MediManage.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MediManage.API.Controllers
{
    [Route("api/paciente")]
    public class PacienteController : Controller
    {
        private readonly IMediator _mediator;
        public PacienteController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // api/paciente?query=net core
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllPaciente = new GetAllPacientesQuery(query);

            var paciente = await _mediator.Send(getAllPaciente);

            return Ok(paciente);
        }

        // api/paciente/2
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var query = new GetByIdPacientreQuery(id);

            var paciente = _mediator.Send(query);

            if (paciente == null)
            {
                return NotFound();
            }

            return Ok(paciente);
        }

        // api/paciente/
        [HttpGet("{cpf}/cpf")]
        public async Task<IActionResult> GetByCPF(string cpf)
        {
            var query = new GetByCPFMedicosQuery(cpf);

            var paciente = await _mediator.Send(query);


            if (paciente == null)
            {
                return NotFound();
            }

            return Ok(paciente);
        }

    [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarPacienteCommand command)
        {
            if (command.Nome.Length > 150)
            {
                return BadRequest();
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        // api/paciente/2
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateMedicoCommand command)
         {
            if (command.Nome.Length > 200)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }

        // api/paciente/3 DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePacienteCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
       
    }
}
