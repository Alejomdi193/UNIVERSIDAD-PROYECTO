using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class GradoConfiguration : IEntityTypeConfiguration<Grado>
    {
        public void Configure(EntityTypeBuilder<Grado> builder)
        {
            builder.ToTable("Grado");

            builder.Property(p => p.Nombre)
            .HasColumnName("Nombre")
            .HasColumnType("varchar")
            .HasMaxLength(100);

            


        }
    }
}