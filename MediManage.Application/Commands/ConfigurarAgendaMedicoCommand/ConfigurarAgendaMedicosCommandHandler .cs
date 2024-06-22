using MediatR;
using MediManage.Core.Entities;
using MediManage.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class ConfigurarAgendaMedicosCommandHandler : IRequestHandler<ConfigurarAgendaMedicosCommand, Unit>
{
    private readonly MediManageContext _context;

    public ConfigurarAgendaMedicosCommandHandler(MediManageContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(ConfigurarAgendaMedicosCommand request, CancellationToken cancellationToken)
    {
        var medico = await _context.Medicos
            .Include(m => m.HorariosDisponiveis)
            .FirstOrDefaultAsync(a => a.Id == request.MedicoId);

        if (medico == null)
        {
            throw new Exception("Médico não encontrado");
        }

        if (medico.DiasDeAtendimento == null)
        {
            medico.DiasDeAtendimento = new List<DiaDeAtendimento>();
        }

        if (medico.HorariosDisponiveis == null)
        {
            medico.HorariosDisponiveis = new List<HorarioDisponivel>();
        }

        medico.DiasDeAtendimento.Clear();
        medico.HorariosDisponiveis.Clear();

        foreach (var diaDeAtendimentoDto in request.DiasDeAtendimento)
        {
            var diaDeAtendimento = new DiaDeAtendimento
            {
                Dia = diaDeAtendimentoDto.Dia,
                Inicio = diaDeAtendimentoDto.Inicio,
                Fim = diaDeAtendimentoDto.Fim,
                Intervalo = diaDeAtendimentoDto.Intervalo,
                MedicoId = medico.Id
            };
            medico.DiasDeAtendimento.Add(diaDeAtendimento);

            var current = diaDeAtendimentoDto.Inicio;
            while (current + diaDeAtendimentoDto.Intervalo <= diaDeAtendimentoDto.Fim)
            {
                var inicio = diaDeAtendimentoDto.Dia.Date + current;
                var fim = inicio + diaDeAtendimentoDto.Intervalo;

                var horarioDisponivel = new HorarioDisponivel
                {
                    Inicio = inicio,
                    Fim = fim,
                    IdMedico = medico.Id,
                    EstaDisponivel = true // Indica que este horário está disponível para agendamento
                };
                medico.HorariosDisponiveis.Add(horarioDisponivel);

                current += diaDeAtendimentoDto.Intervalo;
            }
        }

        _context.Medicos.Update(medico);
        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}