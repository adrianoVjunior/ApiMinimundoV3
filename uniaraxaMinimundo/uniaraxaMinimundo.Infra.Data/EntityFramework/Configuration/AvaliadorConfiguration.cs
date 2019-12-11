using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using uniaraxaMinimundo.Dominio.Entidades;

namespace uniaraxaMinimundo.Infra.Data.EntityFramework.Configuration
{
    public class AvaliadorConfiguration : IEntityTypeConfiguration<Avaliador>
    {
        public void Configure(EntityTypeBuilder<Avaliador> builder)
        {
            builder.ToTable("AVALIADOR_037073");
            builder.HasKey(f => f.AvaliadorID);
            builder.Property(f => f.AvaliadorID)
                .UseSqlServerIdentityColumn();
            builder.Property(f => f.UsuarioID);
        }
    }
}
