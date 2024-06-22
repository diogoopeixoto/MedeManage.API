using MediManage.Core.Entities;
using MediManage.Infrastructure.Persistence.Configurations;
using MediManage.Infrastructure.Persistencia.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MediManage.Infrastructure.Persistence
{
    public class MediManageContext : DbContext
    {
        public MediManageContext(DbContextOptions<MediManageContext> options)
            : base(options)
        {
        }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DiaDeAtendimento> DiasDeAtendimento { get; set; }
        public DbSet<HorarioDisponivel> HorariosDisponiveis { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PacienteConfigurations());
            modelBuilder.ApplyConfiguration(new AtendimentoConfigurations());
            modelBuilder.ApplyConfiguration(new MedicoConfigurations());
            modelBuilder.ApplyConfiguration(new ServicoConfigurations());
            modelBuilder.ApplyConfiguration(new DiaDeAtendimentoConfigurations());

            // Outras configurações, se houver
        }
    }
}
