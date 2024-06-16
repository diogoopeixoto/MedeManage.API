using MediatR;
using MediManage.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Commands.UpdateMedico
{
    public class UpdateMedicoCommandHandler : IRequestHandler<UpdateMedicoCommand, Unit>
    {

        private readonly MediManageContext _context;

        public UpdateMedicoCommandHandler(MediManageContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateMedicoCommand request, CancellationToken cancellationToken)
        {
            var medico = _context.Medicos.SingleOrDefault(m => m.Id == request.Id);
            if (medico == null)
            {
                throw new Exception("Medico não encontrado");
            }

            medico.Nome = request.Nome;
            medico.SobreNome = request.SobreNome;
            medico.DataNascimento = request.DataNascimento;
            medico.Telefone = request.Telefone;
            medico.Email = request.Email;
            medico.CPF = request.CPF;
            medico.TipoSanguineo = request.TipoSanguineo;
            medico.Especialidade = request.Especialidade;
            medico.CRM = request.CRM;
            medico.Cep = request.Cep;
            medico.Logradouro = request.Logradouro;
            medico.Bairro = request.Bairro;
            medico.Localidade = request.Localidade;
            medico.Uf = request.Uf;
            medico.Numero = request.Numero;

           await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
