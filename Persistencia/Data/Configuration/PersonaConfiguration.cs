
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("Persona");

            builder.Property(p => p.Nif)
            .HasColumnName("Nif")
            .HasColumnType("varchar")
            .HasMaxLength(9);

            builder.Property(p => p.Nombre)
            .HasColumnName("Nombre")
            .HasColumnType("varchar")
            .HasMaxLength(25);

            builder.Property(p => p.Apellido1)
            .HasColumnName("Apellido1")
            .HasColumnType("varchar")
            .HasMaxLength(50);


            builder.Property(p => p.Apellido2)
            .HasColumnName("Apellido2")
            .HasColumnType("varchar")
            .HasMaxLength(50);

            builder.Property(p => p.Ciudad)
            .HasColumnName("Ciudad")
            .HasColumnType("varchar")
            .HasMaxLength(25);

            builder.Property(p => p.Direccion)
            .HasColumnName("Direccion")
            .HasColumnType("varchar")
            .HasMaxLength(50);

            builder.Property(p => p.Telefono)
            .HasColumnName("Telefono")
            .HasColumnType("varchar")
            .HasMaxLength(9);


            builder.Property(p => p.Fecha_Nacimiento)
            .HasColumnName("Fecha_Nacimiento")
            .HasColumnType("Date");

            builder.Property(p => p.Genero)
            .HasColumnName("Genero")
            .HasColumnType("varchar")  
            .HasMaxLength(1)
            .HasConversion<string>();

            builder.Property(p => p.TipoPersona)
            .HasColumnName("TipoPersona")
            .HasColumnType("varchar") 
            .HasMaxLength(8)
            .HasConversion<string>();
        }
    }
}