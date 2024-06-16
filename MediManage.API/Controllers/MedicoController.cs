using MediatR;
using MediManage.Application.Commands.CriarMedico;
using MediManage.Application.Commands.DeleteMedico;
using MediManage.Application.Commands.UpdateMedico;
using MediManage.Application.ImputModels;
using MediManage.Application.Queries.GetAllMedicosQuery;
using MediManage.Application.Queries.GetByCPFMedicosQuery;
using MediManage.Application.Queries.GetByIdMedicosQuery;
using MediManage.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediManage.API.Controllers
{
        [Route("api/medico")]
        public class MedicoController : Controller
        {
            private readonly IMediator _mediator;

        public MedicoController(IMediator mediator)
        {           
            _mediator = mediator;
        }

        // api/medico?query=net core
        [HttpGet]
        //[Authorize(Roles = "medico")]
            public async Task<IActionResult> Get(string query)
            {
            var getAllMedicoQuery = new GetAllMedicosQuery(query);

            var medicos = await _mediator.Send(getAllMedicoQuery);

                return Ok(medicos);
            }

            // api/medico/2
            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var query = new GetByIdMedicosQuery(id);

                var medico = await _mediator.Send(query);

                if (medico == null)
                {
                    return NotFound();
                }

                return Ok(medico);
            }

            // api/medico/
            [HttpGet("{cpf}/cpf")]
            public async Task<IActionResult> GetByCPF(string cpf)
            {
                var query = new GetByCPFMedicosQuery(cpf);

                var medico = await _mediator.Send(query);

                if (medico == null)
                {
                    return NotFound();
                }

                return Ok(medico);
            }

            [HttpPost]
            public async Task<IActionResult> Post([FromBody] CriarMedicoCommand command)
            {
                if (command.Nome.Length > 150)
                {
                    return BadRequest();
                }

                var id = await _mediator.Send(command);

                return CreatedAtAction(nameof(GetById), new { id = id }, command);
            }

            // api/medico/2
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

            // api/medico/3 DELETE
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
            var command = new DeleteMedicoCommand(id);
            await _mediator.Send(command);

                return NoContent();
            }

        }
    }
