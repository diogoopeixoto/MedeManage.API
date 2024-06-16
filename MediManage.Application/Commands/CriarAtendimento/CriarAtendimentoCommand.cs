using MediatR;
using MediManage.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Commands.CriarAtendimento
{
    public class CriarAtendimentoCommand : IRequest<Unit>
    {
        public int IdPaciente { get; set; }
        public int IdServico { get; set; }
        public int IdMedico { get; set; }
        public string Convenio { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public TipoAtendimentoEnum TipoAtendimento { get; set; }
    }
}
