using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using uniaraxaMinimundo.Dominio.Entidades;

namespace uniaraxaMinimundo.Infra.Data.EntityFramework.Configuration
{
    class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("EMPRESA_037073");
            builder.HasKey(f => f.EmpresaID);
            builder.Property(f => f.EmpresaID)
                .UseSqlServerIdentityColumn();
            builder.Property(f => f.NomeFantasia);
            builder.Property(f => f.RazaoSocial);
            builder.Property(f => f.CNPJ);
            builder.Property(f => f.IE);
        }
    }
}
