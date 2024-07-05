using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Services.Interfaces
{
    public interface IWhatsAppService
    {
        void SendWhatsAppMessage(string to, string message);
    }
}
