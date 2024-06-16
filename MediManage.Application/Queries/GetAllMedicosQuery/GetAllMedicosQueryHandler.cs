using MediatR;
using MediManage.Application.ViewModels;
using MediManage.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Queries.GetAllMedicosQuery
{
    public class GetAllMedicosQueryHandler : IRequestHandler<GetAllMedicosQuery, List<MedicoViewModel>>
    {
        private readonly MediManageContext _context;

        public GetAllMedicosQueryHandler(MediManageContext context)
        {
            _context = context;
        }
        public async Task<List<MedicoViewModel>> Handle(GetAllMedicosQuery request, CancellationToken cancellationToken)
        {           
            var medico = _context.Medicos.Where(m => m.TenantId == m.TenantId);
            var medicoViewModel = await medico.Select(m => new MedicoViewModel(
                m.Id, m.Nome, m.SobreNome, m.DataNascimento, m.Telefone, m.Email, m.CPF,
                m.TipoSanguineo, m.Especialidade, m.CRM, m.Cep, m.Logradouro, m.Bairro,
                m.Localidade, m.Uf, m.Numero, m.TenantId)).ToListAsync();
            return medicoViewModel;
        }
    }
}
