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
    public class PersonaRepository : GenericRepository<Persona>, IPersona
    {
        private readonly UniversidadEvaluacionContext context;
        public PersonaRepository(UniversidadEvaluacionContext context) : base(context)
        {
            this.context = context;
        }

        //Consulta 1 Devuelve un listado con el primer apellido, segundo apellido y el nombre de todos los alumnos. El listado deberá estar ordenado alfabéticamente de menor a mayor por el primer apellido, segundo apellido y nombre.


        public async Task<IEnumerable<Persona>> ObtenerApellido()
        {
            var personas = await context.Personas
                .Where(p => p.TipoPersona == Tipo.Alumno)
                .OrderBy(p => p.Apellido1)
                .ThenBy(p => p.Apellido2)
                .ThenBy(p => p.Nombre)
                .Select(p => new Persona
                {
                    Nif = p.Nif,
                    Nombre = p.Nombre,
                    Apellido1 = p.Apellido1,
                    Apellido2 = p.Apellido2,
                    Ciudad = p.Ciudad,
                    Direccion = p.Direccion,
                    Telefono = p.Telefono,
                    Fecha_Nacimiento = p.Fecha_Nacimiento,
                    Genero = p.Genero,
                    TipoPersona = p.TipoPersona,
                    Alumno_se_Matricula_asignatura = p.Alumno_se_Matricula_asignatura,
                    Asignaturas = p.Asignaturas,
                    Profesores = p.Profesores
                })
                .ToListAsync();

            return personas;
        }


        //CONSULTA 2 Averigua el nombre y los dos apellidos de los alumnos que **no** han dado de alta su número de teléfono en la base de datos.

        public async Task<IEnumerable<Persona>> ObtenerAlumnosSinTelefono()
        {
            var alumnosSinTelefono = await context.Personas
                .Where(p => p.TipoPersona == Tipo.Alumno && string.IsNullOrEmpty(p.Telefono))
                .ToListAsync();

            return alumnosSinTelefono;
        }

        //Consulta 3  Devuelve el listado de los alumnos que nacieron en `1999`.


        public async Task<IEnumerable<Persona>> ObtenerNacidosEn1999()
        {
            var nacidosEn1999 = await context.Personas
                .Where(p => p.Fecha_Nacimiento.Year == 1999)
                .ToListAsync();

            return nacidosEn1999;
        }

        //Consulta 6 Devuelve un listado con los datos de todas las **alumnas** que se han matriculado alguna vez en el `Grado en Ingeniería Informática (Plan 2015)`.


        public async Task<IEnumerable<Persona>> ObtenerAlumnasMatriculadasEnIngenieriaInformatica()
        {
            var alumnas = await context.Personas
                .Where(p => p.TipoPersona == Tipo.Alumno)
                .Where(p => p.Asignaturas.Any(a => a.Grado.Nombre == "Grado en Ingeniería Informática (Plan 2015)"))
                .Where(p => p.Genero == Sexo.M)
                .ToListAsync();

            return alumnas;
        }

        //4. Devuelve el listado de `profesores` que **no** han dado de alta su número de teléfono en la base de datos y además su nif termina en `K`.


        public async Task<IEnumerable<Persona>> ProfesoresSinTelefonoYNifTerminaEnK()
        {
            var profesoresSinTelefonoYNifTerminaEnK = await context.Personas
                .Where(p => p.TipoPersona == Tipo.Profesor && string.IsNullOrEmpty(p.Telefono) && p.Nif.EndsWith("K"))
                .ToListAsync();

            return profesoresSinTelefonoYNifTerminaEnK;
        }

        //Consulta 8  Devuelve un listado de los `profesores` junto con el nombre del `departamento` al que están vinculados. El listado debe devolver cuatro columnas, `primer apellido, segundo apellido, nombre y nombre del departamento.` El resultado estará ordenado alfabéticamente de menor a mayor por los `apellidos y el nombre.`

        public async Task<IEnumerable<object>> ObtenerProfesoresConDepartamentoOrdenados()
        {
            return await
            (
                from p in context.Profesores
                join d in context.DepartamentoS on p.IdDepartamentoFk equals d.Id
                orderby p.Persona.Apellido1, p.Persona.Apellido2, p.Persona.Nombre
                select new
                {
                    PrimerApellido = p.Persona.Apellido1,
                    SegundoApellido = p.Persona.Apellido2,
                    Nombre = p.Persona.Nombre,
                    NombreDepartamento = d.Nombre
                }
            ).ToListAsync();
        }


        //Consulta 9 
        public async Task<IEnumerable<object>> ObtenerAsignaturasPorAlumno()
        {
            string nifAlumno = "26902806M";

            return await (
                from alumno in context.Personas
                where alumno.Nif == nifAlumno && alumno.TipoPersona == Tipo.Alumno
                from matricula in alumno.Alumno_se_Matricula_asignatura
                select new
                {
                    NombreAsignatura = matricula.Asignatura.Nombre,
                    AnioInicioCursoEscolar = matricula.CursoEscolar.Anyo_Inicio,
                    AnioFinCursoEscolar = matricula.CursoEscolar.Anyo_Fin
                }
            ).ToListAsync();
        }


        //Consulta 10

        public async Task<IEnumerable<string>> ObtenerDepartamentosConAsignaturasEnGrado()
        {
            return await (
                from profesor in context.Profesores
                where profesor.Asignaturas.Any(a => a.Grado.Nombre == "Grado en Ingeniería Informática (Plan 2015)")
                select profesor.Departamento.Nombre
            ).Distinct().ToListAsync();
        }

        //Consulta 11
        public async Task<IEnumerable<object>> ObtenerAlumnosMatriculadosEnCursoEscolar()
        {
            return await (
                from alumno in context.Personas
                where alumno.TipoPersona == Tipo.Alumno &&
                      alumno.Alumno_se_Matricula_asignatura.Any(matricula => matricula.CursoEscolar.Anyo_Inicio == 2018 && matricula.CursoEscolar.Anyo_Fin == 2019)
                select new
                {
                    Nif = alumno.Nif,
                    Nombre = $"{alumno.Nombre} {alumno.Apellido1} {alumno.Apellido2}"
                }
            ).ToListAsync();
        }
        //Consulta 12

        public async Task<IEnumerable<object>> ObtenerProfesoresConDepartamentosOrdenados()
        {
            return await (
                from profesor in context.Profesores
                join departamento in context.DepartamentoS on profesor.IdDepartamentoFk equals departamento.Id into departamentosGroup
                from dept in departamentosGroup.DefaultIfEmpty()
                orderby dept.Nombre, profesor.Persona.Apellido1, profesor.Persona.Apellido2, profesor.Persona.Nombre
                select new
                {
                    NombreDepartamento = dept != null ? dept.Nombre : "Sin Departamento",
                    PrimerApellido = profesor.Persona.Apellido1,
                    SegundoApellido = profesor.Persona.Apellido2,
                    NombreProfesor = profesor.Persona.Nombre
                }
            ).ToListAsync();
        }








    }
}