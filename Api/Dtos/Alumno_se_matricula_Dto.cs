using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace Api.Dtos
{
    public class Alumno_se_matricula_Dto
    {
        public PersonaDto Alumno {get; set;}
        public AsignaturaDto Asignatura {get; set;}
        public CursoEscolarDto CursoEscolar {get; set;}
    }
}