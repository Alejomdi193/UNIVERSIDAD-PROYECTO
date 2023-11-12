using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class UniversidadEvaluacionContext : DbContext
    {
        public UniversidadEvaluacionContext(DbContextOptions<UniversidadEvaluacionContext> options) : base(options)
        {

        }

        public DbSet<Asignatura> Asignaturas{get; set;}

        public DbSet<CursoEscolar> CursoEscolares {get; set;}
        public DbSet<Departamento> DepartamentoS {get; set;}

        public DbSet<Grado> Grados {get; set;}

        public DbSet<Persona> Personas {get; set;}

        public DbSet<Profesor> Profesores {get; set;}

        public DbSet<Alumno_Se_Matricula_Asignatura> Alumno_Se_Matricula_Asignaturas{get; set;}

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
        
    }
}