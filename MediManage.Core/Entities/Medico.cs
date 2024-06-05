using MediManage.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Core.Entities
{
    public class Medico : BaseEntity
    {
        public Medico(string nome, string sobreNome, DateTime dataNascimento, string telefone, string email, string cPF, string tipoSanguineo, string especialidade, string cRM, StatusMedicoEnum status, string cep, string logradouro, string bairro, string localidade, string uf, string numero)
        {
            Nome = nome;
            SobreNome = sobreNome;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
            CPF = cPF;
            TipoSanguineo = tipoSanguineo;
            Especialidade = especialidade;
            CRM = cRM;
            Status = status;
            Cep = cep;
            Logradouro = logradouro;
            Bairro = bairro;
            Localidade = localidade;
            Uf = uf;
            Numero = numero;
        }

        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string TipoSanguineo { get; set; }            
        public string Especialidade { get; set; }
        public string CRM { get; set; }
        public StatusMedicoEnum Status { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Numero { get; set; }

        public List<Atendimento>? Atendimentos { get; set;}

        public void Cancel()
        {
            if (Status == StatusMedicoEnum.Ativo)
            {
                Status = StatusMedicoEnum.Inativo;
            }
        }
    }
}
