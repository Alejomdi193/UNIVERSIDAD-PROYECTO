using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class ProfesorDto
    {
        public int IdProfesor {get; set;}
        public int IdDepartamentoFk {get; set;}
        public DepartamentoDto Departamento {get; set;}
    }
}