using Api.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistencia;

namespace Api.Controllers
{
    public class AsignaturaController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AsignaturaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<AsignaturaDto>>> Get()
        {
            var asignatura = await unitOfWork.Asignaturas.GetAllAsync();
            return mapper.Map<List<AsignaturaDto>>(asignatura);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<AsignaturaDto>> GetByIdAsync(int id)
        {
            var asignatura = await unitOfWork.Asignaturas.GetByIdAsync(id);
            if (asignatura == null)
            {
                return NotFound();
            }
            return mapper.Map<AsignaturaDto>(asignatura);
        } 
        //Colsulta 5 

        [HttpGet("AsignaturasPrimerCuatrimestreTercer")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         [ProducesResponseType(StatusCodes.Status404NotFound)]

         public async Task<ActionResult<IEnumerable<AsignaturaDto>>> Get5()
         {
             var asignaturas = await unitOfWork.Asignaturas.AsignaturasPrimerCuatrimestreTercerCursoGrado7();

             if (asignaturas == null)
             {
                 return NotFound();
             }
             return mapper.Map<List<AsignaturaDto>>(asignaturas);
         }

        //Consulta 7 

        [HttpGet("AsignaturasEnIngenieriaInformatica")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         [ProducesResponseType(StatusCodes.Status404NotFound)]

         public async Task<ActionResult<IEnumerable<AsignaturaDto>>> Get7()
         {
             var asignatura = await unitOfWork.Asignaturas.ObtenerAsignaturasEnIngenieriaInformatica();

             if (asignatura == null)
             {
                 return NotFound();
             }
             return mapper.Map<List<AsignaturaDto>>(asignatura);
         }





        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<AsignaturaDto>> Put(int id, [FromBody]AsignaturaDto asignaturaDto)
        {
            if (asignaturaDto == null)
            {
                return BadRequest();
            }
            var asignatura = mapper.Map<Asignatura>(asignaturaDto);
            unitOfWork.Asignaturas.Update(asignatura);
            await unitOfWork.SaveAsync();
            return asignaturaDto;
        } 

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Asignatura>> Post(AsignaturaDto asignaturaDto)
        {
            var asignatura = mapper.Map<Asignatura>(asignaturaDto);
            unitOfWork.Asignaturas.Add(asignatura);
            await unitOfWork.SaveAsync();
            if (asignatura== null)
            {
                return BadRequest();
            }

            asignatura.Id = asignatura.Id;
            return CreatedAtAction(nameof(Post), new { id = asignatura.Id }, asignaturaDto);
        } 

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var asignatura = await unitOfWork.Asignaturas.GetByIdAsync(id);
            if (asignatura== null)
            {
                return NotFound();
            }

            unitOfWork.Asignaturas.Remove(asignatura);
            await unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}