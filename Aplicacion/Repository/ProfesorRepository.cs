using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using static Dominio.Entities.Persona;

namespace Aplicacion.Repository
{
    public class ProfesorRepository : GenericRepository<Profesor>, IProfesor
    {
        private readonly UniversidadEvaluacionContext context;
        public ProfesorRepository(UniversidadEvaluacionContext context) : base(context)
        {
            this.context = context;
        }

        //



    }
}


