using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Dominio.Entities
{
    public class CursoEscolar : BaseEntity
    {
        public int Anyo_Inicio {get; set;}
        public int Anyo_Fin {get; set;}

        public ICollection<Alumno_Se_Matricula_Asignatura> Alumno_se_Matricula_asignaturas {get; set;}
    }
}