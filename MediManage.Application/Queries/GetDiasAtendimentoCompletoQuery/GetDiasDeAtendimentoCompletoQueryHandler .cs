using MediatR;
using MediManage.Application.ViewModels;
using MediManage.Core.Entities;
using MediManage.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Queries.GetDiasAtendimentoCompletoQuery
{
    public class GetDiasDeAtendimentoCompletoQueryHandler : IRequestHandler<GetDiasDeAtendimentoCompletoQuery, List<DiaDeAtendimentoCompletoDto>>
    {
        private readonly MediManageContext _context;

        public GetDiasDeAtendimentoCompletoQueryHandler(MediManageContext context)
        {
            _context = context;
        }

        public async Task<List<DiaDeAtendimentoCompletoDto>> Handle(GetDiasDeAtendimentoCompletoQuery request, CancellationToken cancellationToken)
        {
            var medico = await _context.Medicos
                .Include(m => m.DiasDeAtendimento)
                .FirstOrDefaultAsync(m => m.Id == request.MedicoId, cancellationToken);

            if (medico == null)
            {
                throw new Exception("Médico não encontrado");
            }

            // Calcular os horários disponíveis para cada dia de atendimento
            var diasDeAtendimentoCompletoDto = medico.DiasDeAtendimento.Select(d => new DiaDeAtendimentoCompletoDto
            {
                Dia = d.Dia,
                HorariosDisponiveis = ObterHorariosDisponiveisParaDia(d)
            }).ToList();

            return diasDeAtendimentoCompletoDto;
        }

        private List<string> ObterHorariosDisponiveisParaDia(DiaDeAtendimento diaDeAtendimento)
        {
            var horariosDisponiveis = new List<string>();

            TimeSpan current = diaDeAtendimento.Inicio;
            while (current.Add(diaDeAtendimento.Intervalo) <= diaDeAtendimento.Fim)
            {
                horariosDisponiveis.Add(current.ToString(@"hh\:mm"));
                current = current.Add(diaDeAtendimento.Intervalo);
            }

            return horariosDisponiveis;
        }
    }
}
