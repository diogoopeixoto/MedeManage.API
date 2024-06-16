using MediManage.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediManage.Infrastructure.Persistence.Configurations
{
    public class ServicoConfigurations : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .Property(s => s.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(s => s.Descricao)
                .IsRequired()
                .HasMaxLength(500);

            builder
                .Property(s => s.Valor)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder
                .Property(s => s.ValorTotal)
                .HasColumnType("decimal(18,2)");

            builder
                .Property(s => s.Duracao)
                .IsRequired();
            builder
                .
                Property(s => s.Status)
                .IsRequired();
            builder
                .HasMany(s => s.Atendimentos)
                .WithOne(a => a.Servico)
                .HasForeignKey(a => a.IdServico);
        }
    }
}
