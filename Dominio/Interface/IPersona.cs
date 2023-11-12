using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace Dominio.Interface
{
    public interface IPersona : IGeneric<Persona>
    {
        Task<IEnumerable<Persona>> ObtenerApellido();
        Task<IEnumerable<Persona>> ObtenerAlumnosSinTelefono();
        Task<IEnumerable<Persona>> ObtenerNacidosEn1999();

        Task<IEnumerable<Persona>> ProfesoresSinTelefonoYNifTerminaEnK();

        Task<IEnumerable<Persona>> ObtenerAlumnasMatriculadasEnIngenieriaInformatica();

        Task<IEnumerable<object>> ObtenerProfesoresConDepartamentoOrdenados();

        Task<IEnumerable<object>> ObtenerAsignaturasPorAlumno();

        Task<IEnumerable<string>> ObtenerDepartamentosConAsignaturasEnGrado();

        Task<IEnumerable<object>> ObtenerAlumnosMatriculadosEnCursoEscolar();

        Task<IEnumerable<object>> ObtenerProfesoresConDepartamentosOrdenados();

    }
}