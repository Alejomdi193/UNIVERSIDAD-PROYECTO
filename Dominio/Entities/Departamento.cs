using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Departamento : BaseEntity
    {
   
        public string Nombre {get; set;}
        public ICollection<Profesor> Profesores {get; set;}

    }
}