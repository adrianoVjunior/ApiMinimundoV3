using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using uniaraxaMinimundo.Dominio.Entidades;

namespace uniaraxaMinimundo.Infra.Data.EntityFramework.Configuration
{
    public class AvaliacaoSugestaoConfiguration : IEntityTypeConfiguration<AvaliacaoSugestao>
    {
        public void Configure(EntityTypeBuilder<AvaliacaoSugestao> builder)
        {
            builder.ToTable("AVALIACAOSUGESTAO_037073");
            builder.HasKey(f => f.AvaliacaoID);
            builder.Property(f => f.AvaliacaoID)
                .UseSqlServerIdentityColumn();
            builder.Property(f => f.SugestaoID);
            builder.Property(f => f.Criatividade);
            builder.Property(f => f.Investimento);
            builder.Property(f => f.Tempo);
        }
    }
}
