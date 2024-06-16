using MediatR;
using MediManage.Application.ViewModels;
using MediManage.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Queries.GetAllServicoQuery
{
    public class GetAllServicosQuery : IRequest<List<ServicoViewModel>>
    {
        public GetAllServicosQuery(string query)
        {
            this.query = query;
        }

        public string query { get; set; }
    }
}
