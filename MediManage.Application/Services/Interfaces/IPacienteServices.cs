using MediManage.Application.ImputModels;
using MediManage.Application.ViewModels;


namespace MediManage.Application.Services.Interfaces
{
    public interface IPacienteServices
    {
        List<PacienteViewModel>GetAll(string query);
        PacienteDetalhesViewModel GetById(int id);
        PacienteDetalhesViewModel GetByCPF(string cpf);
        int Create(NewPacienteImputModel inputModel);
        void Update(UpdatePacienteImputModel inputModel);
        void Delete(int id);       
    }
}
