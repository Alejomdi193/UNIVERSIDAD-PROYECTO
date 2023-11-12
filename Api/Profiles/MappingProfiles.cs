using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace Api.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Departamento,DepartamentoDto>().ReverseMap();
            CreateMap<Asignatura,AsignaturaDto>().ReverseMap();
            CreateMap<CursoEscolar,CursoEscolarDto>().ReverseMap();
            CreateMap<Grado,GradoDto>().ReverseMap();
            CreateMap<Persona,PersonaDto>().ReverseMap();
            CreateMap<Profesor,ProfesorDto>().ReverseMap();

        }
    }
}