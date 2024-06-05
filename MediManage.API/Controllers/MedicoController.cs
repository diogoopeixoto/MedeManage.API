using MediManage.Application.ImputModels;
using MediManage.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediManage.API.Controllers
{
        [Route("api/medico")]
        public class MedicoController : Controller
        {
            private readonly IMedicoServices _medicoServices;

        public MedicoController(IMedicoServices medicoServices)
        {
            _medicoServices = medicoServices;
        }

        // api/medico?query=net core
        [HttpGet]
            public IActionResult Get(string query)
            {
                var medico = _medicoServices.GetAll(query);

                return Ok(medico);
            }

            // api/medico/2
            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                var medico = _medicoServices.GetById(id);

                if (medico == null)
                {
                    return NotFound();
                }

                return Ok(medico);
            }

            // api/medico/
            [HttpGet("{cpf}/cpf")]
            public IActionResult GetByCPF(string cpf)
            {
                var medico = _medicoServices.GetByCPF(cpf);

                if (medico == null)
                {
                    return NotFound();
                }

                return Ok(medico);
            }

            [HttpPost]
            public IActionResult Post([FromBody] NewMedicoImputModel inputModel)
            {
                if (inputModel.Nome.Length > 150)
                {
                    return BadRequest();
                }

                var id = _medicoServices.Create(inputModel);

                return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
            }

            // api/medico/2
            [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody] UpdateMedicoImputModel inputModel)
            {
                if (inputModel.Nome.Length > 200)
                {
                    return BadRequest();
                }

                _medicoServices.Update(inputModel);

                return NoContent();
            }

            // api/medico/3 DELETE
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                _medicoServices.Delete(id);

                return NoContent();
            }

        }
    }
