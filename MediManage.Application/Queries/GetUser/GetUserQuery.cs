using MediatR;
using MediManage.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Queries.GetUser
{   
    public class GetUserQuery : IRequest<UserViewModel>
    {
        public GetUserQuery(int id, string tenantid)
        {
            Id = id;            
            TenantId = tenantid; 
        }       

        public int Id { get; private set; }

        public string TenantId { get; private set; }
    }
}

