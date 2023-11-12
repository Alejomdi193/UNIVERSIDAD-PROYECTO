using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interface;
using Persistencia;

namespace Aplicacion.Repository
{
    public class CursoEscolarRepository : GenericRepository<CursoEscolar>,ICursoEscolar
    {
        private readonly UniversidadEvaluacionContext context;
        public CursoEscolarRepository(UniversidadEvaluacionContext context) : base(context)
        {
            this.context = context;
        }
    }
}