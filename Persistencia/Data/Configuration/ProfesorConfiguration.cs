using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class ProfesorConfiguration : IEntityTypeConfiguration<Profesor>
    {
        public void Configure(EntityTypeBuilder<Profesor> builder)
        {
            builder.ToTable("Profesor");


            builder.HasOne(p => p.Departamento)
            .WithMany(p => p.Profesores)
            .HasForeignKey(p => p.IdDepartamentoFk);



            builder.HasOne(p => p.Persona)
            .WithMany(p => p.Profesores)
            .HasForeignKey(p => p.IdProfesorFk);
        }
    }
}