using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using uniaraxaMinimundo.Dominio.Entidades;

namespace uniaraxaMinimundo.Infra.Data.EntityFramework.Configuration
{
    public class LoginConfiguration : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.ToTable("USERTOKEN_037073");
            builder.HasKey(f => f.userToken_ID);
            builder.Property(f => f.usuario);
            builder.Property(f => f.senha);
        }
    }
}
