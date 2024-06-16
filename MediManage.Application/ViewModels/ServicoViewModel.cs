using MediManage.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.ViewModels
{
    public class ServicoViewModel
    {
   
        
        public ServicoViewModel(int id, string nome, string descricao, decimal valor, decimal? valorTotal, int duracao, ServicoStatusEnum status)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            ValorTotal = valorTotal;
            Duracao = duracao;
            Status = status;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public decimal? ValorTotal { get; private set; }
        public int Duracao { get; private set; }
        public ServicoStatusEnum Status { get; set; }
    }
}
