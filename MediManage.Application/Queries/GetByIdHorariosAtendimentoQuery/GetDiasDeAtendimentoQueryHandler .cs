using MediatR;
using MediManage.Application.ViewModels;
using MediManage.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Queries.GetByIdHorariosAtendimentoQuery
{
    public class GetDiasDeAtendimentoQueryHandler : IRequestHandler<GetDiasDeAtendimentoQuery, List<DiaDeAtendimentoDto>>
    {
        private readonly MediManageContext _context;

        public GetDiasDeAtendimentoQueryHandler(MediManageContext context)
        {
            _context = context;
        }

        public async Task<List<DiaDeAtendimentoDto>> Handle(GetDiasDeAtendimentoQuery request, CancellationToken cancellationToken)
        {
            var medico = await _context.Medicos
                .Include(m => m.DiasDeAtendimento)
                .FirstOrDefaultAsync(m => m.Id == request.MedicoId, cancellationToken);

            if (medico == null)
            {
                // Handle the case when the medico does not exist
                throw new Exception("Médico não encontrado");
            }

            var diasDeAtendimento = medico.DiasDeAtendimento.Select(d => new DiaDeAtendimentoDto
            {
                Dia = d.Dia,
                Inicio = d.Inicio,
                Fim = d.Fim,
                Intervalo = d.Intervalo
            }).ToList();

            return diasDeAtendimento;
        }
    }
}
