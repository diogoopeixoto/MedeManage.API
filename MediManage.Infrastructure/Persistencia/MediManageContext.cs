using MediManage.Core.Entities;
using MediManage.Infrastructure.Persistence.Configurations;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PacienteConfigurations());
            modelBuilder.ApplyConfiguration(new AtendimentoConfigurations());
            modelBuilder.ApplyConfiguration(new MedicoConfigurations());
            modelBuilder.ApplyConfiguration(new ServicoConfigurations());
            // Outras configurações, se houver
        }
    }
}
