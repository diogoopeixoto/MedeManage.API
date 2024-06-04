using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.ViewModels
{
    public class PacienteViewModel
    {
        public PacienteViewModel(int id, string nome, string sobreNome, string cPF)
        {
            Id = id;
            Nome = nome;
            SobreNome = sobreNome;          
            CPF = cPF;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }            
        public string CPF { get; set; }
    }
}
