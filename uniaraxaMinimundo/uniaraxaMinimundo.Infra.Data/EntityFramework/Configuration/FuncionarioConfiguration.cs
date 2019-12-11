using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using uniaraxaMinimundo.Dominio.Entidades;

namespace uniaraxaMinimundo.Infra.Data.EntityFramework.Configuration
{
    class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("FUNCIONARIO_037073");
            builder.HasKey(f => f.FuncionarioID);
            builder.Property(f => f.FuncionarioID)
                .UseSqlServerIdentityColumn();
            builder.Property(f => f.DataCriacao);
            builder.Property(f => f.UsuarioID);
            builder.Property(f => f.EmpresaID);
        }

    }
}
