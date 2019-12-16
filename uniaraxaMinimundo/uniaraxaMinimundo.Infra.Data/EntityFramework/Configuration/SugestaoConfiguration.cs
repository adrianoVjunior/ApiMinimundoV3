using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using uniaraxaMinimundo.Dominio.Entidades;

namespace uniaraxaMinimundo.Infra.Data.EntityFramework.Configuration
{
    public class SugestaoConfiguration : IEntityTypeConfiguration<Sugestao>
    {
        public void Configure(EntityTypeBuilder<Sugestao> builder)
        {
            builder.ToTable("SUGESTAO_037073");
            builder.HasKey(f => f.SugestaoID);
            builder.Property(f => f.SugestaoID)
                .UseSqlServerIdentityColumn();
            builder.Property(f => f.CampanhaID);
            builder.Property(f => f.FuncionarioID);
            builder.Property(f => f.Descricao);
            builder.Property(f => f.Valor);
        }
    }
}
