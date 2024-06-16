using MediatR;
using MediManage.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Commands.UpDatePaciente
{
    public class UpdatePacienteCommandHandler : IRequestHandler<UpDatePacienteCommand, Unit>
    {
        private readonly MediManageContext _context;
        public UpdatePacienteCommandHandler(MediManageContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpDatePacienteCommand request, CancellationToken cancellationToken)
        {
            var paciente =  _context.Pacientes.SingleOrDefault(p => p.Id == request.Id);
            if (paciente == null)
            {
                throw new KeyNotFoundException("Paciente não encontrado");
            }

            paciente.Nome = request.Nome;
            paciente.SobreNome = request.SobreNome;
            paciente.DataNascimento = request.DataNascimento;
            paciente.Telefone = request.Telefone;
            paciente.Email = request.Email;
            paciente.CPF = request.CPF;
            paciente.TipoSanguineo = request.TipoSanguineo;
            paciente.Altura = request.Altura;
            paciente.Peso = request.Peso;
            paciente.Status = request.Status;

           await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
