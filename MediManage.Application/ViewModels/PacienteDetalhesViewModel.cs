using MediManage.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.ViewModels
{
    public class PacienteDetalhesViewModel
    {
        public PacienteDetalhesViewModel( int id, string nome, string sobreNome, DateTime dataNascimento, string telefone, string email, 
            string cPF, string tipoSanguineo, double altura, double peso, PacienteStatusEnum status)
        {
            Id = id;
            Nome = nome;
            SobreNome = sobreNome;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
            CPF = cPF;
            TipoSanguineo = tipoSanguineo;
            Altura = altura;
            Peso = peso;
            
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string TipoSanguineo { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public string Endereco { get; set; }
        public PacienteStatusEnum StatusEnum { get; set; }
    }
}
