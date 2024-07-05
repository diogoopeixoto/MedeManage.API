using MediManage.Application.Services.Interfaces;
using MediManage.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MediManage.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WhatsAppController : ControllerBase
    {
        private readonly IWhatsAppService _whatsAppService;

        public WhatsAppController(IWhatsAppService whatsAppService)
        {
            _whatsAppService = whatsAppService;
        }

        [HttpPost("send")]
        public IActionResult SendWhatsAppMessage([FromBody] WhatsAppRequest request)
        {
            _whatsAppService.SendWhatsAppMessage(request.To, request.Message);
            return Ok("Mensagem enviada com sucesso!");
        }
    }
}
