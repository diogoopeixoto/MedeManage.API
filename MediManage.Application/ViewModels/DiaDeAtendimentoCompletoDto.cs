using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.ViewModels
{
    public class DiaDeAtendimentoCompletoDto
    {
        public DateTime Dia { get; set; }
        public List<string> HorariosDisponiveis { get; set; }
    }
}