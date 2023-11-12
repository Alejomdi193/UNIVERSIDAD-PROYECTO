using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Repository;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore.Metadata;
using Persistencia;

namespace Aplicacion.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly UniversidadEvaluacionContext context;
        public UnitOfWork(UniversidadEvaluacionContext _context)
        {
            context = _context;
        }

        private IAsignatura _asignaturas;
        private ICursoEscolar _cursoEscolares;
        private IDepartamento _departamentos;
        private IGrado _grados;
        private IPersona _personas;
        private IProfesor _profesores;


        public IAsignatura Asignaturas
        {
            get{
                if(_asignaturas == null)
                {
                    _asignaturas = new AsignaturaRepository(context);
                }
                return _asignaturas;
            }
        }
        public ICursoEscolar CursoEscolares
        {
            get{
                if(_cursoEscolares == null)
                {
                    _cursoEscolares = new CursoEscolarRepository(context);
                }
                return _cursoEscolares;
            }
        }

        public IDepartamento Departamentos
        {
            get{
                if(_profesores== null)
                {
                    _departamentos = new DepartamentoRepository(context);
                }
                return _departamentos;
            }
        }

        public IGrado Grados
        {
            get{
                if(_grados == null)
                {
                    _grados = new GradoRepository(context);
                }
                return _grados;
            }
        }

        public IPersona Personas
        {
            get{
                if(_personas == null)
                {
                    _personas = new PersonaRepository(context);
                }
                return _personas;
            }
        }

        public IProfesor Profesores
        {
            get{
                if(_profesores== null)
                {
                    _profesores= new ProfesorRepository(context);
                }
                return _profesores;
            }
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
        
        public void Dispose()
        {
            context.Dispose();
        }
    }
}