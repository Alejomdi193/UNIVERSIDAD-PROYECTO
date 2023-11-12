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

    public class PersonaController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<PersonaDto>>> Get()
        {
            var persona = await unitOfWork.Personas.GetAllAsync();
            return mapper.Map<List<PersonaDto>>(persona);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PersonaDto>> GetByIdAsync(int id)
        {
            var persona = await unitOfWork.Personas.GetByIdAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            return mapper.Map<PersonaDto>(persona);
        }

        //Consulta 1

         [HttpGet("Apellidos")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         [ProducesResponseType(StatusCodes.Status404NotFound)]

         public async Task<ActionResult<IEnumerable<PersonaDto>>> Get1()
         {
             var persona = await unitOfWork.Personas.ObtenerApellido();

             if (persona == null)
             {
                 return NotFound();
             }
             return mapper.Map<List<PersonaDto>>(persona);
         }

         //Consulta 2

         [HttpGet("SinNumero")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         [ProducesResponseType(StatusCodes.Status404NotFound)]

         public async Task<ActionResult<IEnumerable<PersonaDto>>> Get2()
         {
             var persona = await unitOfWork.Personas.ObtenerAlumnosSinTelefono();

             if (persona == null)
             {
                 return NotFound();
             }
             return mapper.Map<List<PersonaDto>>(persona);
         }

         //Consulta 3 


        [HttpGet("NacidosEn1999")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         [ProducesResponseType(StatusCodes.Status404NotFound)]

         public async Task<ActionResult<IEnumerable<PersonaDto>>> Get3()
         {
             var persona = await unitOfWork.Personas.ObtenerNacidosEn1999();

             if (persona == null)
             {
                 return NotFound();
             }
             return mapper.Map<List<PersonaDto>>(persona);
         }

        //Consulta 4 

        [HttpGet("ProfesoresSinCelYNif")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         [ProducesResponseType(StatusCodes.Status404NotFound)]

         public async Task<ActionResult<IEnumerable<PersonaDto>>> Get4()
         {
             var persona = await unitOfWork.Personas.ProfesoresSinTelefonoYNifTerminaEnK();

             if (persona == null)
             {
                 return NotFound();
             }
             return mapper.Map<List<PersonaDto>>(persona);
         }

         //Consulta 6

        [HttpGet("AlumnasMatriculadasEnIngenieriaInformatica")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         [ProducesResponseType(StatusCodes.Status404NotFound)]

         public async Task<ActionResult<IEnumerable<PersonaDto>>> Get6()
         {
             var persona = await unitOfWork.Personas.ObtenerAlumnasMatriculadasEnIngenieriaInformatica();

             if (persona == null)
             {
                 return NotFound();
             }
             return mapper.Map<List<PersonaDto>>(persona);
         }
        

        //Consulta 8

        [HttpGet("AlumnasMatriculadasEnIngenieriaInformatica")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         [ProducesResponseType(StatusCodes.Status404NotFound)]

         public async Task<ActionResult<IEnumerable<Object>>> Get8()
         {
             var persona = await unitOfWork.Personas.ObtenerProfesoresConDepartamentoOrdenados();

             if (persona == null)
             {
                 return NotFound();
             }
             return mapper.Map<List<Object>>(persona);
         }



        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PersonaDto>> Put(int id, [FromBody] PersonaDto personaDto)
        {
            if (personaDto == null)
            {
                return BadRequest();
            }
            var Persona = mapper.Map<Persona>(personaDto);
            unitOfWork.Personas.Update(Persona);
            await unitOfWork.SaveAsync();
            return personaDto;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Persona>> Post(PersonaDto personaDto)
        {
            var persona = mapper.Map<Persona>(personaDto);
            unitOfWork.Personas.Add(persona);
            await unitOfWork.SaveAsync();
            if (persona == null)
            {
                return BadRequest();
            }

            persona.Id = persona.Id;
            return CreatedAtAction(nameof(Post), new { id = persona.Id }, personaDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var persona = await unitOfWork.Personas.GetByIdAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            unitOfWork.Personas.Remove(persona);
            await unitOfWork.SaveAsync();
            return NoContent();
        }

    }

}
