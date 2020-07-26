using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Models;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository;

namespace ApiCenar.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlatosController : ControllerBase
    {
        private readonly PlatosRepo _PlatosRepo;

        public PlatosController(PlatosRepo PlatosRepo)
        {
            _PlatosRepo = PlatosRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<PlatosDto>>> List()
        {
            try
            {
                var lists = await _PlatosRepo.GetAlldto();

                if (lists == null)
                {


                    return NotFound();

                }
                else
                {
                    return lists;

                }
            }
            catch(Exception e)
            {
                return StatusCode(500);

            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlatosDto>> GetById(int id)
        {
            try
            {
                var dto = await _PlatosRepo.GetByIddto(id);
                if (dto == null)
                {
                    return NotFound();

                }

                return dto;
            }
            catch
            {
                return StatusCode(500);

            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(PlatosDtoCU dto)
        {
            if (ModelState.IsValid)
            {
                await _PlatosRepo.Adddto(dto);
                return NoContent();
            }
            return StatusCode(500);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PlatosDtoCU dto)
        {
            if (ModelState.IsValid)
            {
                if (await _PlatosRepo.Updatedto(id, dto) == null)
                {
                    return StatusCode(500);

                }
                else
                {
                    return NoContent();
                }
            }
            return StatusCode(500);

        }



    }
}
