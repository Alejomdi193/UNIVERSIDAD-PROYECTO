using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dominio.Entities.Persona;

namespace Api.Dtos
{
    public class PersonaDto
    {
        public string Nif {get; set;}
        public string Nombre {get; set;}
        public string Apellido1 {get; set;}
        public string Apellido2 {get; set;}
        public string Ciudad {get; set;}
        public string Direccion {get; set;}
        public string Telefono {get; set;}
        public DateTime Fecha_Nacimiento {get; set;}
        public Sexo Genero {get; set;}
        public Tipo TipoPersona {get; set;}
    }
}