using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using uniaraxaMinimundo.Dominio.Entidades;

namespace uniaraxaMinimundo.Infra.Data.EntityFramework.Configuration
{
    public class CampanhaConfiguration : IEntityTypeConfiguration<Campanha>
    {
        public void Configure(EntityTypeBuilder<Campanha> builder)
        {
            builder.ToTable("CAMPANHA_037073");
            builder.HasKey(f => f.CampanhaID);
            builder.Property(f => f.CampanhaID)
                .UseSqlServerIdentityColumn();

            builder.Property(f => f.AvaliadorID);
            builder.Property(f => f.EmpresaID);
            builder.Property(f => f.CampanhaNome);
            builder.Property(f => f.Descricao);
            builder.Property(f => f.DataInicio);
            builder.Property(f => f.DataFim);
            builder.Property(f => f.ValorPremio);
        }
    }
}
