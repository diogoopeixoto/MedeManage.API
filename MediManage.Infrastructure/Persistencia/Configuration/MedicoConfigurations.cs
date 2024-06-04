using MediManage.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediManage.Infrastructure.Persistence.Configurations
{
    public class MedicoConfigurations : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(m => m.SobreNome)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(m => m.DataNascimento)
                .IsRequired();

            builder
                .Property(m => m.Telefone)
                .HasMaxLength(15);

            builder
                .Property(m => m.Email)
                .HasMaxLength(100);

            builder
                .Property(m => m.CPF)
                .IsRequired()
                .HasMaxLength(11);

            builder
                .Property(m => m.TipoSanguineo)
                .HasMaxLength(3);

            builder
                .Property(m => m.Endereco)
                .HasMaxLength(200);

            builder
                .Property(m => m.Especialidade)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(m => m.CRM)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .HasMany(m => m.Atendimentos)
                .WithOne(a => a.Medico)
                .HasForeignKey(a => a.IdMedico);
        }
    }
}
