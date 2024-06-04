using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.ViewModels
{
    public class ServicoDetalhesViewModel
    {
        public ServicoDetalhesViewModel(string nome, string descricao, decimal valor, decimal? valorTotal, int duracao)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            ValorTotal = valorTotal;
            Duracao = duracao;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public decimal? ValorTotal { get; private set; }
        public int Duracao { get; private set; }
    }
}
