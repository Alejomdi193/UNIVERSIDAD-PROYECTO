using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace Dominio.Interface
{
    public interface IAsignatura : IGeneric<Asignatura>
    {
        Task<IEnumerable<Asignatura>> AsignaturasPrimerCuatrimestreTercerCursoGrado7();
        Task<IEnumerable<Asignatura>> ObtenerAsignaturasEnIngenieriaInformatica();
        Task<IEnumerable<object>> ObtenerAsignaturasSinProfesor();
    }
}