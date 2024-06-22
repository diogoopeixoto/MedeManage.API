using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Core.Entities
{
    public class HorarioDisponivel : BaseEntity
    {        
        public int IdMedico { get; set; }
        public Medico Medico { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public bool EstaDisponivel { get; set; } = true; // True indica que o horário está disponível
    }
}
