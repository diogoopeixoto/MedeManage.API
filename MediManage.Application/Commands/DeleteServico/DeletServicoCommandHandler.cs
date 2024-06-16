using MediatR;
using MediManage.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Commands.DeleteServico
{
    public class DeletServicoCommandHandler : IRequestHandler<DeleteSertvicoCommand, Unit>
    {
        private readonly MediManageContext _context;

        public DeletServicoCommandHandler(MediManageContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSertvicoCommand request, CancellationToken cancellationToken)
        {
            var servico = _context.Servicos.SingleOrDefault(s => s.Id == request.Id);
            servico.Cancel();
            await _context.SaveChangesAsync();

            return Unit.Value;

        }
    }
}
