using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Asignatura  : BaseEntity
    {

        public string Nombre {get; set;}
        public int Creditos {get; set;}

        public string Tipo {get; set;}

        public int Cursos {get; set;}
        public int Cuatrimestre {get; set;}
        public int? IdProfesorFk {get; set;}
        public Profesor Profesor {get; set;}
        public int IdGradoFk {get; set;}
        public Grado Grado{get; set;}

        public ICollection<Persona> Personas {get; set;}

        public ICollection<Alumno_Se_Matricula_Asignatura> Alumno_se_Matricula_asignaturas {get; set;}


    }
}