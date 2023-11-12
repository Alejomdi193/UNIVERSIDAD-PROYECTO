
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class AsignaturaConfiration : IEntityTypeConfiguration<Asignatura>
    {
        public void Configure(EntityTypeBuilder<Asignatura> builder)
        {
            builder.ToTable("Asignatura");

            builder.Property(p => p.Nombre)
            .HasColumnName("Nombre")
            .HasColumnType("varchar")
            .HasMaxLength(100);


            builder.Property(p => p.Creditos)
            .HasColumnName("Creditos")
            .HasColumnType("int")
            .HasMaxLength(100);
            
            builder.Property(p => p.Tipo)
            .HasColumnName("Tipo")
            .HasColumnType("varchar")
            .HasMaxLength(50);

            builder.Property(p => p.Cursos)
            .HasColumnName("Cursos")
            .HasColumnType("int")
            .HasMaxLength(100);


            builder.Property(p => p.Cuatrimestre)
            .HasColumnName("Cuatrimestre")
            .HasColumnType("int")
            .HasMaxLength(100);

            builder.HasOne(p => p.Profesor)
            .WithMany(p => p.Asignaturas)
            .HasForeignKey(p => p.IdProfesorFk);

            builder.HasOne(p => p.Grado)
            .WithMany(p => p.Asignaturas)
            .HasForeignKey(p => p.IdGradoFk);


            builder.HasMany(p => p.Personas)
                .WithMany(p => p.Asignaturas)
                .UsingEntity<Alumno_Se_Matricula_Asignatura>(
                    j =>
                    {
                        j.HasOne(p => p.Asignatura)
                        .WithMany(p => p.Alumno_se_Matricula_asignaturas)
                        .HasForeignKey(p => p.IdAsignaturaFk);

                        j.HasOne(p => p.Alumno)
                        .WithMany(p => p.Alumno_se_Matricula_asignatura)
                        .HasForeignKey(p => p.IdAlumnoFk);

                        j.HasOne(p => p.CursoEscolar)
                        .WithMany(p => p.Alumno_se_Matricula_asignaturas)
                        .HasForeignKey(p => p.IdCursoEscolarFk);


                        j.ToTable("Alumno_Se_Matricula_Asignatura");
                        j.HasKey(t => new{t.IdAsignaturaFk, t.IdAlumnoFk, t.IdCursoEscolarFk});
                    }
                );
        }
    }
}