using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.ViewModels
{
    public class LoginUserViewModel
    {
        public LoginUserViewModel(string email, string tenantId, string token)
        {
            Email = email;            
            TenantId = tenantId;
            Token = token;
        }

        public string Email { get; private set; }        
        public string TenantId { get; private set; }
        public string Token { get; private set; }
    }
}
