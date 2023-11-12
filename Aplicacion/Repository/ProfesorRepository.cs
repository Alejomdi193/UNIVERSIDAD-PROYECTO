using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using static Dominio.Entities.Persona;

namespace Aplicacion.Repository
{
    public class ProfesorRepository : GenericRepository<Profesor>, IProfesor
    {
        private readonly UniversidadEvaluacionContext context;
        public ProfesorRepository(UniversidadEvaluacionContext context) : base(context)
        {
            this.context = context;
        }

        //Consulta 13

        public async Task<IEnumerable<object>> ObtenerProfesoresYDepartamentosSinAsociacion()
        {
            var profesoresSinDepartamento = await (
                from profesor in context.Profesores
                where profesor.Departamento == null
                select new
                {
                    Tipo = "Profesor",
                    PrimerApellido = profesor.Persona.Apellido1,
                    SegundoApellido = profesor.Persona.Apellido2,
                    Nombre = profesor.Persona.Nombre
                }
            ).ToListAsync();

            var departamentosSinProfesores = await (
                from departamento in context.DepartamentoS
                where !context.Profesores.Any(profesor => profesor.IdDepartamentoFk == departamento.Id)
                select new
                {
                    Tipo = "Departamento",
                    Nombre = departamento.Nombre
                }
            ).ToListAsync();

            var resultado = new List<object>();
            resultado.AddRange(profesoresSinDepartamento);
            resultado.AddRange(departamentosSinProfesores);

            return resultado;
        }

        //Consulta 14

        public async Task<IEnumerable<object>> ObtenerProfesoresSinAsignaturas()
        {
            return await (
                from profesor in context.Profesores
                where !context.Asignaturas.Any(asignatura => asignatura.IdProfesorFk == profesor.IdProfesorFk)
                select new
                {
                    PrimerApellido = profesor.Persona.Apellido1,
                    SegundoApellido = profesor.Persona.Apellido2,
                    Nombre = profesor.Persona.Nombre
                }
            ).ToListAsync();
        }




    }
}


