using MediatR;
using MediManage.Application.ViewModels;
using MediManage.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Queries.GetALLPacientesQuery
{
    public class GetAllPacientesQueryHandler : IRequestHandler<GetAllPacientesQuery, List<PacienteViewModel>>
    {
        private readonly MediManageContext _context;
        public GetAllPacientesQueryHandler(MediManageContext context)
        {
            _context = context;
        }
        public async Task<List<PacienteViewModel>> Handle(GetAllPacientesQuery request, CancellationToken cancellationToken)
        {
            var pacientes = _context.Pacientes;
            var pacienteViewModel = pacientes
                .Select(p => new PacienteViewModel(p.Id, p.Nome, p.SobreNome, p.DataNascimento, p.Telefone,
                p.Email, p.CPF, p.TipoSanguineo, p.Altura, p.Peso, p.Status,
                p.Cep, p.Logradouro, p.Bairro, p.Localidade, p.Uf, p.Numero)).ToList();
            return pacienteViewModel;
        }
    }
}
