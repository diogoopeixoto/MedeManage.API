using MediatR;
using MediManage.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Queries.GetByIdHorariosAtendimentoQuery
{
    public class GetDiasDeAtendimentoQuery : IRequest<List<DiaDeAtendimentoDto>>
    {
        public int MedicoId { get; set; }

        public GetDiasDeAtendimentoQuery(int medicoId)
        {
            MedicoId = medicoId;
        }
    }
}
