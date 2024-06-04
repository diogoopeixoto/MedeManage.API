using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Core.Entities
{
    public class Medico : BaseEntity
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string TipoSanguineo { get; set; }       
        public string Endereco { get; set; }
        public string Especialidade { get; set; }
        public string CRM { get; set; }
        public List<Atendimento>? Atendimentos { get; set;}
    }
}
