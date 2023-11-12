using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    public class ProfesorController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProfesorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<ProfesorDto>>> Get()
        {
            var profesor = await unitOfWork.Profesores.GetAllAsync();
            return mapper.Map<List<ProfesorDto>>(profesor);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ProfesorDto>> GetByIdAsync(int id)
        {
            var profesor = await unitOfWork.Profesores.GetByIdAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }
            return mapper.Map<ProfesorDto>(profesor);
        } 

        //Consulta 13

        [HttpGet("ObtenerProfesoresYDepartamentosSinAsociacion")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         [ProducesResponseType(StatusCodes.Status404NotFound)]

         public async Task<ActionResult<IEnumerable<object>>> Get13()
         {
             var profesor = await unitOfWork.Profesores.ObtenerProfesoresYDepartamentosSinAsociacion();

             if (profesor == null)
             {
                 return NotFound();
             }
             return mapper.Map<List<object>>(profesor);
         }

         //Consulta 14
        [HttpGet("ObtenerProfesoresSinAsignaturas")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         [ProducesResponseType(StatusCodes.Status404NotFound)]

         public async Task<ActionResult<IEnumerable<object>>> Get14()
         {
             var profesor = await unitOfWork.Profesores. ObtenerProfesoresSinAsignaturas();

             if (profesor == null)
             {
                 return NotFound();
             }
             return mapper.Map<List<object>>(profesor);
         }



        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ProfesorDto>> Put(int id, [FromBody]ProfesorDto ProfesorDto)
        {
            if (ProfesorDto == null)
            {
                return BadRequest();
            }
            var profesor = mapper.Map<Profesor>(ProfesorDto);
            unitOfWork.Profesores.Update(profesor);
            await unitOfWork.SaveAsync();
            return ProfesorDto;
        } 

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Profesor>> Post(ProfesorDto profesorDto)
        {
            var profesor = mapper.Map<Profesor>(profesorDto);
            unitOfWork.Profesores.Add(profesor);
            await unitOfWork.SaveAsync();
            if (profesor== null)
            {
                return BadRequest();
            }

            profesor.Id = profesor.Id;
            return CreatedAtAction(nameof(Post), new { id = profesor.Id }, profesorDto);
        } 

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var profesor = await unitOfWork.Profesores.GetByIdAsync(id);
            if (profesor== null)
            {
                return NotFound();
            }

            unitOfWork.Profesores.Remove(profesor);
            await unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}