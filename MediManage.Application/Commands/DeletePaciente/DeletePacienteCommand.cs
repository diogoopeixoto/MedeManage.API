using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Commands.DeletePaciente
{
    public class DeletePacienteCommand : IRequest<Unit>
    {
        public DeletePacienteCommand(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
