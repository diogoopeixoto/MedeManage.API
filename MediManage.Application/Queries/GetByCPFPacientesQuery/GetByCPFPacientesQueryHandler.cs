using MediatR;
using MediManage.Application.ViewModels;
using MediManage.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Queries.GetByCPFPacientesQuery
{
    public class GetByCPFPacientesQueryHandler : IRequestHandler<GetByCPFPacientesQuery, PacienteDetalhesViewModel>
    {
        private readonly MediManageContext _context;
        public GetByCPFPacientesQueryHandler(MediManageContext context)
        {
            _context = context;
        }
        public async Task<PacienteDetalhesViewModel> Handle(GetByCPFPacientesQuery request, CancellationToken cancellationToken)
        {

            // Busca o paciente pelo ID
            var paciente = _context.Pacientes
                .SingleOrDefault(p => p.CPF == request.CPF);

            if (paciente == null) return null;

            // Cria e retorna o ViewModel com os detalhes do paciente
            var pacienteDetalheViewModel = new PacienteDetalhesViewModel(
                paciente.Id,
                paciente.Nome,
                paciente.SobreNome,
                paciente.DataNascimento,
                paciente.Telefone,
                paciente.Email,
                paciente.CPF,
                paciente.TipoSanguineo,
                paciente.Altura,
                paciente.Peso,
                paciente.Status);

            return pacienteDetalheViewModel;
        }
    }
}
