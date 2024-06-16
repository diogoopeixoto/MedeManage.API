using MediatR;
using MediManage.Application.ViewModels;
using MediManage.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Queries.GetByIdMedicosQuery
{
    public class GetByIdMedicosQueryHandler : IRequestHandler<GetByIdMedicosQuery, MedicoDetalhesViewModel>
    {
        private readonly MediManageContext _context;

        public GetByIdMedicosQueryHandler(MediManageContext context)
        {
            _context = context;
        }
        public async Task<MedicoDetalhesViewModel> Handle(GetByIdMedicosQuery request, CancellationToken cancellationToken)
        {
            var medico = await _context.Medicos.SingleOrDefaultAsync(m => m.Id == request.Id);

            if (medico == null) return null;

            var medicoDetalheViewModel = new MedicoDetalhesViewModel(

                medico.Id,
                medico.Nome,
                medico.SobreNome,
                medico.DataNascimento,
                medico.Telefone,
                medico.Email,
                medico.CPF,
                medico.TipoSanguineo,
                medico.Especialidade,
                medico.CRM,
                medico.Cep,
                medico.Logradouro,
                medico.Bairro,
                medico.Localidade,
                medico.Uf,
                medico.Numero
                );
            return medicoDetalheViewModel;
        }
    }
}
