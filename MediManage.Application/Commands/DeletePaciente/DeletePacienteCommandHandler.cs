using MediatR;
using MediManage.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Commands.DeletePaciente
{
    public class DeletePacienteCommandHandler : IRequestHandler<DeletePacienteCommand, Unit>
    {
        private readonly MediManageContext _context;
        public DeletePacienteCommandHandler(MediManageContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePacienteCommand request, CancellationToken cancellationToken)
        {
            var paciente = _context.Pacientes.SingleOrDefault(p => p.Id == request.Id);

            paciente.Cancel();

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
