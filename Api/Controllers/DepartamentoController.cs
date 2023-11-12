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

    public class DepartamentoController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DepartamentoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<DepartamentoDto>>> Get()
        {
            var departamento = await unitOfWork.Departamentos.GetAllAsync();
            return mapper.Map<List<DepartamentoDto>>(departamento);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<DepartamentoDto>> GetByIdAsync(int id)
        {
            var departamento = await unitOfWork.Departamentos.GetByIdAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return mapper.Map<DepartamentoDto>(departamento);
        } 





        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<DepartamentoDto>> Put(int id, [FromBody]DepartamentoDto departamentoDto)
        {
            if (departamentoDto == null)
            {
                return BadRequest();
            }
            var departamento = mapper.Map<Departamento>(departamentoDto);
            unitOfWork.Departamentos.Update(departamento);
            await unitOfWork.SaveAsync();
            return departamentoDto;
        } 

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Departamento>> Post(DepartamentoDto departamentoDto)
        {
            var departamento = mapper.Map<Departamento>(departamentoDto);
            unitOfWork.Departamentos.Add(departamento);
            await unitOfWork.SaveAsync();
            if (departamento== null)
            {
                return BadRequest();
            }

            departamento.Id = departamento.Id;
            return CreatedAtAction(nameof(Post), new { id = departamento.Id }, departamentoDto);
        } 

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var departamento = await unitOfWork.Departamentos.GetByIdAsync(id);
            if (departamento== null)
            {
                return NotFound();
            }

            unitOfWork.Departamentos.Remove(departamento);
            await unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}