using MediatR;
using MediManage.Application.Commands.CriarAtendimento;
using MediManage.Application.Commands.CriarMedico;
using Microsoft.AspNetCore.Mvc;

namespace MediManage.API.Controllers
{
    [Route("api/atendimento")]
    public class AtendimentoController : Controller
    {
        private readonly IMediator _mediator;

        public AtendimentoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarAtendimentoCommand command)
        {
            if (command.TipoAtendimento == null)
            {
                return BadRequest();
            }

            var id = await _mediator.Send(command);

            //return CreatedAtAction(nameof(GetById), new { id = id }, command);
            return Ok(id);
        }
    }
}
