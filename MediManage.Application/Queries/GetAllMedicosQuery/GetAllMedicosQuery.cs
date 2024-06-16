using MediatR;
using MediManage.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Queries.GetAllMedicosQuery
{
    public class GetAllMedicosQuery : IRequest<List<MedicoViewModel>>
    {
        public GetAllMedicosQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
