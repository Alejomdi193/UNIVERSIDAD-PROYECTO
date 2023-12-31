using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace Dominio.Interface
{
    public interface IProfesor :IGeneric<Profesor>
    {
        Task<IEnumerable<object>> ObtenerProfesoresYDepartamentosSinAsociacion();
        Task<IEnumerable<object>> ObtenerProfesoresSinAsignaturas();
    }
}