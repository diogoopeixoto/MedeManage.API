using MediatR;
using MediManage.Application.ViewModels;
using MediManage.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Queries.GetByIdServicoQuery
{
    public class GetByIdServicoQuery : IRequest<ServicoDetalhesViewModel>
    {
        public GetByIdServicoQuery(int id)
        {
            Id = id;
        }

        public GetByIdServicoQuery(int id, string nome, string descricao, decimal valor, decimal? valorTotal, int duracao, ServicoStatusEnum status)
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

