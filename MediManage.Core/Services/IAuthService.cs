﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Core.Services
{
    public interface IAuthService 
    {
        string GenerateJwtToken(string email, string tenantId, string role);
        string ComputeSha256Hash(string password);
    }
}
