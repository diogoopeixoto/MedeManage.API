using MediatR;
using MediManage.Core.Entities;
using MediManage.Infrastructure.Persistence;

namespace MediManage.Application.Commands.CriarServico
{
    public class CriarServicoCommandHandler : IRequestHandler<CriarServicoCommand, Unit>
    {
        private readonly MediManageContext _context;

        public CriarServicoCommandHandler(MediManageContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CriarServicoCommand request, CancellationToken cancellationToken)
        {
            var servico = new Servico(
                request.Nome,
                request.Descricao,
                request.Valor,
                request.ValorTotal,
                request.Duracao,
                request.Status

                );
           await _context.AddAsync(servico);
           await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
