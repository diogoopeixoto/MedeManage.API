using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.ViewModels
{
    public class ConfigurarAgendaMedicosDto
    {
        public int MedicoId { get; set; }
        public List<DiaDeAtendimentoDto> DiasDeAtendimento { get; set; }
    }
}
