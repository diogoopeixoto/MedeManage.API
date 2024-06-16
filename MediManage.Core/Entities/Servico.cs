using MediManage.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Core.Entities
{
    public class Servico : BaseEntity
    {
        public Servico(string nome, string descricao, decimal valor, decimal? valorTotal, int duracao, ServicoStatusEnum status)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            ValorTotal = valorTotal;
            Duracao = duracao;
            Status = status;
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public decimal? ValorTotal { get; set; }
        public int Duracao { get; set; }
        public ServicoStatusEnum Status { get; set; }
        public List<Atendimento>? Atendimentos { get; set; }

        public void Cancel()
        {
            if(Status == ServicoStatusEnum.Ativo)
            {
                Status = ServicoStatusEnum.Inativo;
            }
        }
    }
}
