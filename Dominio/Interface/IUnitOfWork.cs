using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interface
{
    public interface IUnitOfWork
    {
        IAsignatura Asignaturas{get;}
        ICursoEscolar CursoEscolares {get;}
        IDepartamento Departamentos {get;}
        IGrado Grados{get;}
        IPersona Personas{get;}
        IProfesor Profesores{get;}

        Task<int> SaveAsync();
    }
}