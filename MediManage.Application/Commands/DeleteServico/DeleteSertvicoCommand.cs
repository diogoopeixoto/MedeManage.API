using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Commands.DeleteServico
{
    public class DeleteSertvicoCommand : IRequest<Unit>
    {
        public DeleteSertvicoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
