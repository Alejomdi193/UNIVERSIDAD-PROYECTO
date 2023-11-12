using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Grado : BaseEntity
    {

        public string Nombre {get; set;}

        public ICollection<Asignatura> Asignaturas {get; set;}
    }
}