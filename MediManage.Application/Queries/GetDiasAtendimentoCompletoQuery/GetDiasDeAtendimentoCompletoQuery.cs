using MediatR;
using MediManage.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Queries.GetDiasAtendimentoCompletoQuery
{
    public class GetDiasDeAtendimentoCompletoQuery : IRequest<List<DiaDeAtendimentoCompletoDto>>
    {
        public int MedicoId { get; set; }
    }

}
