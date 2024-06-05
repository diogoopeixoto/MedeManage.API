using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.ViewModels
{
    public class MedicoDetalhesViewModel
    {
      
        public MedicoDetalhesViewModel(int id, string nome, string sobreNome, DateTime dataNascimento, string telefone, string email, string cPF, string tipoSanguineo, string especialidade, string cRM, string cep, string logradouro, string bairro, string localidade, string uf, string numero)
        {
            Id = id;
            Nome = nome;
            SobreNome = sobreNome;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
            CPF = cPF;
            TipoSanguineo = tipoSanguineo;
            Especialidade = especialidade;
            CRM = cRM;
            Cep = cep;
            Logradouro = logradouro;
            Bairro = bairro;
            Localidade = localidade;
            Uf = uf;
            Numero = numero;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string TipoSanguineo { get; set; }
        public string Especialidade { get; set; }
        public string CRM { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Numero { get; set; }
    }
}
