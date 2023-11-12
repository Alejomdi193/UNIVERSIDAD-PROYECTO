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

    public class CursoEscolarController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CursoEscolarController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<CursoEscolarDto>>> Get()
        {
            var cursoEscolar = await unitOfWork.CursoEscolares.GetAllAsync();
            return mapper.Map<List<CursoEscolarDto>>(cursoEscolar);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<CursoEscolarDto>> GetByIdAsync(int id)
        {
            var cursoEscolar = await unitOfWork.CursoEscolares.GetByIdAsync(id);
            if (cursoEscolar == null)
            {
                return NotFound();
            }
            return mapper.Map<CursoEscolarDto>(cursoEscolar);
        } 





        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<CursoEscolarDto>> Put(int id, [FromBody]CursoEscolarDto cursoEscolarDto)
        {
            if (cursoEscolarDto == null)
            {
                return BadRequest();
            }
            var cursoEscolar = mapper.Map<CursoEscolar>(cursoEscolarDto);
            unitOfWork.CursoEscolares.Update(cursoEscolar);
            await unitOfWork.SaveAsync();
            return cursoEscolarDto;
        } 

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<CursoEscolar>> Post(CursoEscolarDto CursoEscolarDto)
        {
            var cursoEscolar = mapper.Map<CursoEscolar>(CursoEscolarDto);
            unitOfWork.CursoEscolares.Add(cursoEscolar);
            await unitOfWork.SaveAsync();
            if (cursoEscolar== null)
            {
                return BadRequest();
            }

            cursoEscolar.Id = cursoEscolar.Id;
            return CreatedAtAction(nameof(Post), new { id = cursoEscolar.Id }, CursoEscolarDto);
        } 

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var cursoEscolar = await unitOfWork.CursoEscolares.GetByIdAsync(id);
            if (cursoEscolar== null)
            {
                return NotFound();
            }

            unitOfWork.CursoEscolares.Remove(cursoEscolar);
            await unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
    