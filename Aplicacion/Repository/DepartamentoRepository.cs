using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interface;
using Persistencia;

namespace Aplicacion.Repository
{
    public class DepartamentoRepository : GenericRepository<Departamento>,IDepartamento
    {
        private readonly UniversidadEvaluacionContext context;
        public DepartamentoRepository(UniversidadEvaluacionContext context) : base(context)
        {
            this.context = context;
        }
    }
}