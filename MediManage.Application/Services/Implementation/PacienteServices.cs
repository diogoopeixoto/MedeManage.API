using MediManage.Application.ImputModels;
using MediManage.Application.Services.Interfaces;
using MediManage.Application.ViewModels;
using MediManage.Core.Entities;
using MediManage.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MediManage.Application.Services.Implementation
{
    public class PacienteServices : IPacienteServices
    {
        private readonly MediManageContext _dbContext;

        public PacienteServices(MediManageContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<PacienteViewModel> GetAll(string query)
        {
            var pacientes = _dbContext.Pacientes;
            var pacienteViewModel = pacientes
                .Select(p =>  new PacienteViewModel(p.Id, p.Nome, p.SobreNome, p.DataNascimento, p.Telefone,
                p.Email, p.CPF, p.TipoSanguineo, p.Altura, p.Peso, p.Status,
                p.Cep, p.Logradouro, p.Bairro, p.Localidade, p.Uf, p.Numero)).ToList();
            return pacienteViewModel;
        }

        public PacienteDetalhesViewModel GetById(int id)
        {
            // Busca o paciente pelo ID
            var paciente = _dbContext.Pacientes
                .SingleOrDefault(p => p.Id == id);

            if (paciente == null) return null;

            // Cria e retorna o ViewModel com os detalhes do paciente
            var pacienteDetalheViewModel = new PacienteDetalhesViewModel(
                paciente.Id,
                paciente.Nome,
                paciente.SobreNome,
                paciente.DataNascimento,
                paciente.Telefone,
                paciente.Email,
                paciente.CPF,
                paciente.TipoSanguineo,
                paciente.Altura,
                paciente.Peso,                
                paciente.Status            );

            return pacienteDetalheViewModel;
        }

        public PacienteDetalhesViewModel GetByCPF(string cpf)
        {
            // Busca o paciente pelo ID
            var paciente = _dbContext.Pacientes
                .SingleOrDefault(p => p.CPF == cpf);

            if (paciente == null) return null;

            // Cria e retorna o ViewModel com os detalhes do paciente
            var pacienteDetalheViewModel = new PacienteDetalhesViewModel(
                paciente.Id,
                paciente.Nome,
                paciente.SobreNome,
                paciente.DataNascimento,
                paciente.Telefone,
                paciente.Email,
                paciente.CPF,
                paciente.TipoSanguineo,
                paciente.Altura,
                paciente.Peso,
                paciente.Status);

            return pacienteDetalheViewModel;
        }

        public int Create(NewPacienteImputModel inputModel)
        {
            var paciente = new Paciente(inputModel.Nome, inputModel.SobreNome, inputModel.DataNascimento, inputModel.Telefone,
                inputModel.Email, inputModel.CPF, inputModel.TipoSanguineo, inputModel.Altura, inputModel.Peso, inputModel.Status,
                inputModel.Cep, inputModel.Logradouro, inputModel.Bairro, inputModel.Localidade, inputModel.Uf, inputModel.Numero);

            _dbContext.Pacientes.Add( paciente );
            _dbContext.SaveChanges();

            return paciente.Id;
    }

        public void Delete(int id)
        {
            var paciente = _dbContext.Pacientes.SingleOrDefault( p => p.Id == id );
            paciente.Cancel();
            _dbContext.SaveChanges();
        }
        
        public void Update(UpdatePacienteImputModel inputModel)
        {
            var paciente = _dbContext.Pacientes.SingleOrDefault(p => p.Id == inputModel.Id);
            if (paciente == null)
            {
                throw new KeyNotFoundException("Paciente não encontrado");
            }

            paciente.Nome = inputModel.Nome;
            paciente.SobreNome = inputModel.SobreNome;
            paciente.DataNascimento = inputModel.DataNascimento;
            paciente.Telefone = inputModel.Telefone;
            paciente.Email = inputModel.Email;
            paciente.CPF = inputModel.CPF;
            paciente.TipoSanguineo = inputModel.TipoSanguineo;
            paciente.Altura = inputModel.Altura;
            paciente.Peso = inputModel.Peso;            
            paciente.Status = inputModel.Status;

            _dbContext.SaveChanges();
        }
    }
}
