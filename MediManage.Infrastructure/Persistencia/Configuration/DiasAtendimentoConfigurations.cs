using MediManage.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediManage.Infrastructure.Persistencia.Configuration
{
    public class DiaDeAtendimentoConfigurations : IEntityTypeConfiguration<DiaDeAtendimento>
    {
        public void Configure(EntityTypeBuilder<DiaDeAtendimento> builder)
        {
            builder.HasKey(d => d.Id);

            builder
                .Property(d => d.Dia)
                .IsRequired();

            builder
                .Property(d => d.Inicio)
                .IsRequired();

            builder
                .Property(d => d.Fim)
                .IsRequired();

            builder
                .Property(d => d.Intervalo)
                .IsRequired();

           
        }
    }
}
