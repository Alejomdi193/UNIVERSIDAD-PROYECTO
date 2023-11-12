using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Persistencia;

namespace Aplicacion.Repository
{
    public class AsignaturaRepository : GenericRepository<Asignatura>,IAsignatura
    {
        private readonly UniversidadEvaluacionContext context;
        public AsignaturaRepository(UniversidadEvaluacionContext context) : base(context)
        {
            this.context = context;
        }

        //Consulta 6Devuelve un listado con los datos de todas las **alumnas** que se han matriculado alguna vez en el `Grado en Ingeniería Informática (Plan 2015)`.

        public async Task<IEnumerable<Asignatura>> AsignaturasPrimerCuatrimestreTercerCursoGrado7()
        {
            var asignaturas = await context.Asignaturas
                .Where(a => a.Cuatrimestre == 1 && a.Cursos == 3 && a.IdGradoFk == 7)
                .ToListAsync();

            return asignaturas;
        }
        //  Consulta 7 Devuelve un listado con todas las asignaturas ofertadas en el `Grado en Ingeniería Informática (Plan 2015)`.

        public async Task<IEnumerable<Asignatura>> ObtenerAsignaturasEnIngenieriaInformatica()
        {
            var asignaturas = await context.Asignaturas
                .Where(a => a.Grado.Nombre == "Grado en Ingeniería Informática (Plan 2015)")
                .ToListAsync();

            return asignaturas;
        }
    }
}