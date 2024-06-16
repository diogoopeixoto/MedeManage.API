using MediatR;
using MediManage.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Commands.CriarServico
{
    public class CriarServicoCommand : IRequest<Unit>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public decimal? ValorTotal { get; set; }
        public int Duracao { get; set; }
        public ServicoStatusEnum Status { get; set; }
    }
}
