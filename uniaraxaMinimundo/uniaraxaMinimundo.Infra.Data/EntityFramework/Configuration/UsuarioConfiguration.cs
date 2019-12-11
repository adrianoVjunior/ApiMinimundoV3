using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using uniaraxaMinimundo.Dominio.Entidades;

namespace uniaraxaMinimundo.Infra.Data.EntityFramework.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO_037073");
            builder.HasKey(f => f.UsuarioID);
            //builder.HasKey(f => f.login);
            builder.Property(f => f.UsuarioID)
                   .UseSqlServerIdentityColumn();
            builder.Property(f => f.DataNascimento);
            builder.Property(f => f.CPF);
            builder.Property(f => f.login);
            builder.Property(f => f.Senha);
            builder.Property(f => f.Email);
        }
    }
}
