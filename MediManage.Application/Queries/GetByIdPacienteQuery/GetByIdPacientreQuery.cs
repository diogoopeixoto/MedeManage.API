using MediatR;
using MediManage.Application.ViewModels;
using MediManage.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Queries.GetByCPFPacienteQuery
{
    public class GetByIdPacientreQuery : IRequest<PacienteDetalhesViewModel>
    {
        public GetByIdPacientreQuery(int id)
        {
            Id = id;
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
