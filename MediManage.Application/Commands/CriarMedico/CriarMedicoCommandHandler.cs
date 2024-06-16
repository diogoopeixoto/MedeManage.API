using MediatR;
using MediManage.Core.Entities;
using MediManage.Infrastructure.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace MediManage.Application.Commands.CriarMedico
{
    public class CriarMedicoCommandHandler : IRequestHandler<CriarMedicoCommand, Unit>
    {
        private readonly MediManageContext _context;

        public CriarMedicoCommandHandler(MediManageContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CriarMedicoCommand request, CancellationToken cancellationToken)
        {
            var medico = new Medico(
                request.Nome,
                request.SobreNome,
                request.DataNascimento,
                request.Telefone,
                request.Email,
                request.CPF,
                request.TipoSanguineo,
                request.Especialidade,
                request.CRM,
                request.Status,
                request.Cep,
                request.Logradouro,
                request.Bairro,
                request.Localidade,
                request.Uf,
                request.Numero,
                request.TenantId
            );

            await _context.Medicos.AddAsync(medico, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
