using MediatR;
using MediManage.Application.ViewModels;
using MediManage.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Queries.GetAllServicoQuery
{
    public class GetAllServicosQueryHandler : IRequestHandler<GetAllServicosQuery, List<ServicoViewModel>>
    {
        private readonly MediManageContext _context;

        public GetAllServicosQueryHandler(MediManageContext context)
        {
            _context = context;
        }

        public async Task<List<ServicoViewModel>> Handle(GetAllServicosQuery request, CancellationToken cancellationToken)
        {
            var servico = _context.Servicos;
            var servicoViewModel = await servico
                .Select(s => new ServicoViewModel(s.Id, s.Nome, s.Descricao, s.Valor, s.ValorTotal, s.Duracao, s.Status)).ToListAsync();
            return servicoViewModel;
        }
    }
}
