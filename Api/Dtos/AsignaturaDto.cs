using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class AsignaturaDto
    {
        public string Nombre {get; set;}
        public int Creditos {get; set;}

        public string Tipo {get; set;}

        public int Cursos {get; set;}
        public int Cuatrimestre {get; set;}
        public ProfesorDto Profesor {get; set;}
        public GradoDto Grado{get; set;}
    }
}