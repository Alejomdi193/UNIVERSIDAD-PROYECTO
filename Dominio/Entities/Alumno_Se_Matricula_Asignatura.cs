using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Alumno_Se_Matricula_Asignatura
    {
        public int IdAlumnoFk {get; set;}
        public Persona Alumno {get; set;}
        public int IdAsignaturaFk {get; set;}
        public Asignatura Asignatura {get; set;}
        public int IdCursoEscolarFk {get; set;}
        public CursoEscolar CursoEscolar {get; set;}
        
    }
}