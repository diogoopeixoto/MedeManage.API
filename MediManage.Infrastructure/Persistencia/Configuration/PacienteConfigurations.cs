using MediManage.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediManage.Infrastructure.Persistence.Configurations
{
    public class PacienteConfigurations : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(p => p.SobreNome)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(p => p.DataNascimento)
                .IsRequired();

            builder
                .Property(p => p.Telefone)
                .HasMaxLength(15);

            builder
                .Property(p => p.Email)
                .HasMaxLength(100);

            builder
                .Property(p => p.CPF)
                .IsRequired()
                .HasMaxLength(11);

            builder
                .Property(p => p.TipoSanguineo)
                .HasMaxLength(3);

            builder
                .Property(p => p.Altura)
                .IsRequired();

            builder
                .Property(p => p.Peso)
                .IsRequired();           

            builder
                .HasMany(p => p.Atendimentos)
                .WithOne(a => a.Paciente)
                .HasForeignKey(a => a.IdPaciente);
        }
    }
}
