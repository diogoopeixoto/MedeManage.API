using MediManage.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediManage.Infrastructure.Persistencia.Configuration
{
    public class MedicoConfigurations : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.HasKey(m => m.Id);

            builder
                .Property(m => m.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder
                .Property(m => m.SobreNome)
                .IsRequired()
                .HasMaxLength(150);

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
                .Property(m => m.Especialidade)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(m => m.CRM)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .Property(m => m.Status)
                .IsRequired();

            builder
                .Property(m => m.Cep)
                .HasMaxLength(8);

            builder
                .Property(m => m.Logradouro)
                .HasMaxLength(150);

            builder
                .Property(m => m.Bairro)
                .HasMaxLength(100);

            builder
                .Property(m => m.Localidade)
                .HasMaxLength(100);

            builder
                .Property(m => m.Uf)
                .HasMaxLength(2);

            builder
                .Property(m => m.Numero)
                .HasMaxLength(10);

            builder
                .Property(m => m.TenantId)
                .HasMaxLength(50);

            
        }
    }
}
