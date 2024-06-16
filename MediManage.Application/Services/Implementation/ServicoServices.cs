using MediManage.Application.ImputModels;
using MediManage.Application.Services.Interfaces;
using MediManage.Application.ViewModels;
using MediManage.Core.Entities;
using MediManage.Infrastructure.Persistence;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MediManage.Application.Services.Implementation
//{
//    public class ServicoServices : IServicoServices
//    {
//        private readonly MediManageContext _context;

//        public ServicoServices(MediManageContext context)
//        {
//            _context = context;
//        }

        //public List<ServicoViewModel> GetAll(string query)
        //{
        //    var servico = _context.Servicos;
        //    var servicoViewModel = servico
        //        .Select(p => new ServicoViewModel(p.Id, p.Nome, p.Descricao, p.Valor, p.ValorTotal, p.Duracao )).ToList();
        //    return servicoViewModel;
        //}

        //public ServicoDetalhesViewModel GetById(int id)
        //{
        //    var servico = _context.Servicos.SingleOrDefault(p => p.Id == id);

        //    if (servico == null) return null;

        //    var servicoDetalhesViewModel = new ServicoDetalhesViewModel(servico.Id, servico.Nome, servico.Descricao, servico.Valor, servico.ValorTotal, servico.Duracao);
        //    return servicoDetalhesViewModel;
        //}

        //public int Create(NewServicoImputModel inputModel)
        //{
        //    var servico = new Servico(
        //        inputModel.Nome,
        //        inputModel.Descricao,
        //        inputModel.Valor,
        //        inputModel.ValorTotal,
        //        inputModel.Duracao,
        //        inputModel.Status
                
        //        );
        //    _context.Add( servico );
        //    _context.SaveChanges();

        //    return servico.Id;
        //}

        //public void Update(UpdateServicoImputModel inputModel)
        //{
        //    var servico = _context.Servicos.SingleOrDefault(s => s.Id == inputModel.Id);

        //    if (servico == null)
        //    {
        //        throw new Exception("Serviço não encontrado!");
        //    }

        //    servico.Nome = inputModel.Nome;
        //    servico.Descricao = inputModel.Descricao;
        //    servico.Valor = inputModel.Valor;
        //    servico.ValorTotal = inputModel.ValorTotal;
        //    servico.Duracao = inputModel.Duracao;

        //    _context.SaveChanges();
        //}

        //public void Delete(int id)
        //{
        //    var servico = _context.Servicos.SingleOrDefault(s => s.Id == id);
        //    servico.Cancel();
        //    _context.SaveChanges();
        //}
        
//    }
//}
