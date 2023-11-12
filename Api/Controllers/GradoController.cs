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

    public class GradoController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GradoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<GradoDto>>> Get()
        {
            var grado = await unitOfWork.Grados.GetAllAsync();
            return mapper.Map<List<GradoDto>>(grado);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<GradoDto>> GetByIdAsync(int id)
        {
            var grado = await unitOfWork.Grados.GetByIdAsync(id);
            if (grado == null)
            {
                return NotFound();
            }
            return mapper.Map<GradoDto>(grado);
        } 


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<GradoDto>> Put(int id, [FromBody]GradoDto gradoDto)
        {
            if (gradoDto == null)
            {
                return BadRequest();
            }
            var grado = mapper.Map<Grado>(gradoDto);
            unitOfWork.Grados.Update(grado);
            await unitOfWork.SaveAsync();
            return gradoDto;
        } 

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Grado>> Post(GradoDto gradoDto)
        {
            var grado = mapper.Map<Grado>(gradoDto);
            unitOfWork.Grados.Add(grado);
            await unitOfWork.SaveAsync();
            if (grado== null)
            {
                return BadRequest();
            }

            grado.Id = grado.Id;
            return CreatedAtAction(nameof(Post), new { id = grado.Id }, gradoDto);
        } 

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var grado = await unitOfWork.Grados.GetByIdAsync(id);
            if (grado== null)
            {
                return NotFound();
            }

            unitOfWork.Grados.Remove(grado);
            await unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}