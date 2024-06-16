using MediatR;
using MediManage.Application.Commands.CriarMedico;
using MediManage.Application.Commands.CriarServico;
using MediManage.Application.Commands.DeletePaciente;
using MediManage.Application.Commands.DeleteServico;
using MediManage.Application.Commands.UpdateMedico;
using MediManage.Application.Commands.UpdateServico;
using MediManage.Application.Queries.GetALLPacientesQuery;
using MediManage.Application.Queries.GetAllServicoQuery;
using MediManage.Application.Queries.GetByCPFMedicosQuery;
using MediManage.Application.Queries.GetByCPFPacienteQuery;
using MediManage.Application.Queries.GetByIdServicoQuery;
using Microsoft.AspNetCore.Mvc;

namespace MediManage.API.Controllers
{
    [Route("api/servico")]
    public class ServicoController : Controller
    {
        private readonly IMediator _mediator;
        public ServicoController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // api/servico?query=net core
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllServico = new GetAllServicosQuery(query);

            var servico = await _mediator.Send(getAllServico);

            return Ok(servico);
        }

        // api/servico/2
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdServicoQuery(id);

            var servico = await _mediator.Send(query);

            if (servico == null)
            {
                return NotFound();
            }

            return Ok(servico);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarServicoCommand command)
        {
            if (command.Nome.Length > 150)
            {
                return BadRequest();
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        // api/servico/2
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateServicoCommand command)
        {
            if (command.Nome.Length > 200)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }

        // api/servico/3 DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteSertvicoCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
