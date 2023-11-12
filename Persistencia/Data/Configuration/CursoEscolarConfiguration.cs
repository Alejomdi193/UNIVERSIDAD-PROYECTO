using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class CursoEscolarConfiguration : IEntityTypeConfiguration<CursoEscolar>
    {
        public void Configure(EntityTypeBuilder<CursoEscolar> builder)
        {
            builder.ToTable("CursoEscolar");

            builder.Property(p => p.Anyo_Inicio)
            .HasColumnName("AñoInicial")
            .HasColumnType("int");

            builder.Property(p => p.Anyo_Fin)
            .HasColumnName("AñoFinal")
            .HasColumnType("int"); 
        }
    }
}