using MediManage.Application.ImputModels;
using MediManage.Application.Services.Interfaces;
using MediManage.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Services.Implementation
{
    public class ServicoServices : IServicoServices
    {
        public List<ServicoViewModel> GetAll(string query)
        {
            throw new NotImplementedException();
        }

        public ServicoDetalhesViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Create(NewServicoImputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        
        public void Update(UpdateServicoImputModel inputModel)
        {
            throw new NotImplementedException();
        }
    }
}
