using MediatR;
using MediManage.Core.Entities;
using MediManage.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Commands.CriarAtendimento
{
    public class CriarAtendimentoCommandHandler : IRequestHandler<CriarAtendimentoCommand, Unit>
    {
        private readonly MediManageContext _context;

        public CriarAtendimentoCommandHandler(MediManageContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CriarAtendimentoCommand request, CancellationToken cancellationToken)
        {
            var paciente = await _context.Pacientes.FirstOrDefaultAsync(p => p.Id == request.IdPaciente, cancellationToken);
            if (paciente == null) throw new Exception("Paciente não encontrado");

            var servico = await _context.Servicos.FirstOrDefaultAsync(s => s.Id == request.IdServico, cancellationToken);
            if (servico == null) throw new Exception("Serviço não encontrado");

            var medico = await _context.Medicos.FirstOrDefaultAsync(m => m.Id == request.IdMedico, cancellationToken);
            if (medico == null) throw new Exception("Médico não encontrado");

            // Criação do objeto Atendimento
            var atendimento = new Atendimento
            {
                IdPaciente = request.IdPaciente,
                Paciente = paciente,
                IdServico = request.IdServico,
                Servico = servico,
                IdMedico = request.IdMedico,
                Medico = medico,
                Convenio = request.Convenio,
                Inicio = request.Inicio,
                Fim = request.Fim,
                TipoAtendimento = request.TipoAtendimento
            };

            // Persistência no banco de dados
            _context.Atendimentos.Add(atendimento);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
