using MediatR;
using MediManage.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Commands.DeleteMedico
{
    public class DeletMedicoCommandHandler : IRequestHandler<DeleteMedicoCommand, Unit>
    {
        private readonly MediManageContext _context;

        public DeletMedicoCommandHandler(MediManageContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteMedicoCommand request, CancellationToken cancellationToken)
        {
            var medico = _context.Medicos.SingleOrDefault(m => m.Id == request.Id);
            medico.Cancel();

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
