using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.ViewModels
{
    public class DiaDeAtendimentoDto
    {
        public DateTime Dia { get; set; }
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fim { get; set; }
        public TimeSpan Intervalo { get; set; }
    }
}
