using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interface;
using Persistencia;

namespace Aplicacion.Repository
{
    public class GradoRepository : GenericRepository<Grado>,IGrado
    {
        private readonly UniversidadEvaluacionContext context;
        public GradoRepository(UniversidadEvaluacionContext context) : base(context)
        {
            this.context = context;
        }
    }
}