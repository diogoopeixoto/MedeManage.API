using MediatR;
using MediManage.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Queries.GetALLPacientesQuery
{
    public class GetAllPacientesQuery : IRequest<List<PacienteViewModel>>
    {
        public GetAllPacientesQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
