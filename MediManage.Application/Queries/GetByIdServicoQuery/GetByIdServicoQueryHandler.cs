using MediatR;
using MediManage.Application.ViewModels;
using MediManage.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Queries.GetByIdServicoQuery
{
    public class GetByIdServicoQueryHandler : IRequestHandler<GetByIdServicoQuery, ServicoDetalhesViewModel>
    {
        private readonly MediManageContext _context;

        public GetByIdServicoQueryHandler(MediManageContext context)
        {
            _context = context;
        }

        public async Task<ServicoDetalhesViewModel> Handle(GetByIdServicoQuery request, CancellationToken cancellationToken)
        {
            var servico = await _context.Servicos.AsNoTracking().SingleOrDefaultAsync(p => p.Id == request.Id);

            if (servico == null) return null;

            var servicoDetalhesViewModel = new ServicoDetalhesViewModel(servico.Id, servico.Nome, servico.Descricao, servico.Valor, servico.ValorTotal, servico.Duracao, servico.Status);
            return servicoDetalhesViewModel;
        }
    }
}
