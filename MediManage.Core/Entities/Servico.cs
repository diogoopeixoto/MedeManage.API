using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Core.Entities
{
    public class Servico : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public decimal? ValorTotal { get; set; }
        public int Duracao { get; set; }
        public List<Atendimento>? Atendimentos { get; set; }
    }
}
