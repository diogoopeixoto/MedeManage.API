using MediManage.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Core.Entities
{
    public class Atendimento : BaseEntity
    {
        public int IdPaciente { get; set; }
        public Paciente Paciente { get; set; }
        public int IdServico { get; set; }
        public Servico Servico { get; set; }
        public int IdMedico { get; set; }
        public Medico Medico { get; set; }
        public string Convenio { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public TipoAtendimentoEnum TipoAtendimento { get; set; }
    }
}
