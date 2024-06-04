using MediManage.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediManage.Infrastructure.Persistence.Configurations
{
    public class AtendimentoConfigurations : IEntityTypeConfiguration<Atendimento>
    {
        public void Configure(EntityTypeBuilder<Atendimento> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .HasOne(a => a.Paciente)
                .WithMany(p => p.Atendimentos)
                .HasForeignKey(a => a.IdPaciente);

            builder
                .HasOne(a => a.Servico)
                .WithMany(s => s.Atendimentos)
                .HasForeignKey(a => a.IdServico);

            builder
                .HasOne(a => a.Medico)
                .WithMany(m => m.Atendimentos)
                .HasForeignKey(a => a.IdMedico);
        }
    }
}
