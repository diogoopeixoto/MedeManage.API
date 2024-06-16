using MediatR;
using MediManage.Core.Entities;
using MediManage.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Commands.CriarPaciente
{
    public class CriarPacienteCommandHandler : IRequestHandler<CriarPacienteCommand, Unit>
    {
        private readonly MediManageContext _context;
        public CriarPacienteCommandHandler(MediManageContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CriarPacienteCommand request, CancellationToken cancellationToken)
        {
            var paciente = new Paciente(request.Nome, request.SobreNome, request.DataNascimento, request.Telefone,
               request.Email, request.CPF, request.TipoSanguineo, request.Altura, request.Peso, request.Status,
               request.Cep, request.Logradouro, request.Bairro, request.Localidade, request.Uf, request.Numero);

           await _context.Pacientes.AddAsync(paciente);
           await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
