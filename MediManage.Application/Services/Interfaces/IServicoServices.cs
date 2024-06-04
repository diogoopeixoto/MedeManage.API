using MediManage.Application.ImputModels;
using MediManage.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Services.Interfaces
{
    public interface IServicoServices
    {
        List<ServicoViewModel> GetAll(string query);
        ServicoDetalhesViewModel GetById(int id);
        int Create(NewServicoImputModel inputModel);
        void Update(UpdateServicoImputModel inputModel);
        void Delete(int id);
    }
}
