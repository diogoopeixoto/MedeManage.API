using MediatR;
using MediManage.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Commands.UpdateServico
{   
    public class UpDateServicoCommandHandler : IRequestHandler<UpdateServicoCommand, Unit>
    {
        private readonly MediManageContext _context;

        public UpDateServicoCommandHandler(MediManageContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateServicoCommand request, CancellationToken cancellationToken)
        {
            var servico = _context.Servicos.SingleOrDefault(s => s.Id == request.Id);

            if (servico == null)
            {
                throw new Exception("Serviço não encontrado!");
            }

            servico.Nome = request.Nome;
            servico.Descricao = request.Descricao;
            servico.Valor = request.Valor;
            servico.ValorTotal = request.ValorTotal;
            servico.Duracao = request.Duracao;
            servico.Status = request.Status;

           await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
