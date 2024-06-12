using MediManage.Application.ImputModels;
using MediManage.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Services.Interfaces
{
    public interface IMedicoServices
    {
        List<MedicoViewModel> GetAll(string tenantId, string query);
        MedicoDetalhesViewModel GetById(int id);
        MedicoDetalhesViewModel GetByCPF(string cpf);
        int Create(NewMedicoImputModel inputModel);
        void Update(UpdateMedicoImputModel inputModel);
        void Delete(int id);
    }
}
