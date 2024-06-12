using MediManage.Application.ImputModels;
using MediManage.Application.Services.Interfaces;
using MediManage.Application.ViewModels;
using MediManage.Core.Entities;
using MediManage.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Services.Implementation
{
    public class MedicoServices : IMedicoServices
    {
        private readonly MediManageContext _context;

        public MedicoServices(MediManageContext context)
        {
            _context = context;
        }

        public List<MedicoViewModel> GetAll(string tenantId, string query)
        {
            var medico = _context.Medicos.Where(m => m.TenantId == tenantId);
            var medicoViewModel = medico.Select(m => new MedicoViewModel (
                m.Id, m.Nome, m.SobreNome, m.DataNascimento, m.Telefone, m.Email, m.CPF,
                m.TipoSanguineo, m.Especialidade, m.CRM, m.Cep, m.Logradouro, m.Bairro,
                m.Localidade, m.Uf, m.Numero, m.TenantId)).ToList();
            return medicoViewModel;
        }             
        public MedicoDetalhesViewModel GetById(int id)
        {
            var medico = _context.Medicos.SingleOrDefault(m => m.Id == id);

            if (medico == null) return null;

            var medicoDetalheViewModel = new MedicoDetalhesViewModel(

                medico.Id,
                medico.Nome,
                medico.SobreNome,
                medico.DataNascimento,
                medico.Telefone,
                medico.Email,
                medico.CPF,
                medico.TipoSanguineo,
                medico.Especialidade,
                medico.CRM,
                medico.Cep,
                medico.Logradouro,
                medico.Bairro,
                medico.Localidade,
                medico.Uf,
                medico.Numero
                );
            return medicoDetalheViewModel;
        }
        public MedicoDetalhesViewModel GetByCPF(string cpf)
        {
            var medico = _context.Medicos.SingleOrDefault(m => m.CPF == cpf);

            if (medico == null) return null;

            var medicoDetalheViewModel = new MedicoDetalhesViewModel(

                medico.Id,
                medico.Nome,
                medico.SobreNome,
                medico.DataNascimento,
                medico.Telefone,
                medico.Email,
                medico.CPF,
                medico.TipoSanguineo,
                medico.Especialidade,
                medico.CRM,
                medico.Cep,
                medico.Logradouro,
                medico.Bairro,
                medico.Localidade,
                medico.Uf,
                medico.Numero
                );
            return medicoDetalheViewModel;
        }
        public int Create(NewMedicoImputModel inputModel)
        {
            var medico = new Medico(
               inputModel.Nome,
               inputModel.SobreNome,
               inputModel.DataNascimento,
               inputModel.Telefone,
               inputModel.Email,
               inputModel.CPF,
               inputModel.TipoSanguineo,
               inputModel.Especialidade,
               inputModel.CRM,  
               inputModel.Status,
               inputModel.Cep,
               inputModel.Logradouro,
               inputModel.Bairro,
               inputModel.Localidade,
               inputModel.Uf,
               inputModel.Numero,
               inputModel.TanantId);
            _context.Medicos.Add( medico );
            _context.SaveChanges();

            return medico.Id;
               
        }

        public void Delete(int id)
        {
            var medico = _context.Medicos.SingleOrDefault( m => m.Id == id );
            medico.Cancel();
            _context.SaveChanges();
        }
               
        public void Update(UpdateMedicoImputModel inputModel)
        {
           var medico = _context.Medicos.SingleOrDefault(m => m.Id == inputModel.Id);
            if(medico == null)
            {
                throw new Exception("Medico não encontrado");
            }

            medico.Nome = inputModel.Nome;
            medico.SobreNome = inputModel.SobreNome;
            medico.DataNascimento = inputModel.DataNascimento;
            medico.Telefone = inputModel.Telefone;
            medico.Email = inputModel.Email;
            medico.CPF = inputModel.CPF;
            medico.TipoSanguineo = inputModel.TipoSanguineo;
            medico.Especialidade = inputModel.Especialidade;
            medico.CRM = inputModel.CRM;
            medico.Cep = inputModel.Cep;
            medico.Logradouro = inputModel.Logradouro;
            medico.Bairro = inputModel.Bairro;
            medico.Localidade = inputModel.Localidade;
            medico.Uf = inputModel.Uf;
            medico.Numero = inputModel.Numero;

            _context.SaveChanges();
        }
    }
}
