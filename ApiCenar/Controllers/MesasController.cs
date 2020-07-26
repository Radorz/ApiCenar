using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository;

namespace ApiCenar.Controllers
{
    [Route("[controller]/{action}")]
    [ApiController]
    public class MesasController : ControllerBase
    {
        private readonly MesaRepo _MesaRepo;
        private readonly OrdenesRepo _OrdenesRepo;

        public MesasController(MesaRepo MesaRepo, OrdenesRepo OrdenesRepo)
        {
            _MesaRepo = MesaRepo;
            _OrdenesRepo = OrdenesRepo;

        }
        [HttpGet]
        public async Task<ActionResult<List<MesasDTO>>> List()
        {
            try
            {
                var lists = await _MesaRepo.GetAlldto();

                if (lists == null)
                {


                    return NotFound();

                }
                else
                {
                    return lists;

                }
            }
            catch
            {
                return StatusCode(500);

            }
        }


        [HttpPost]
        public async Task<ActionResult> Create(MesasDtoCU dto)
        {
            if (ModelState.IsValid)
            {
                await _MesaRepo.Adddto(dto);
                return NoContent();
            }
            return StatusCode(500);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MesasDTO>> GetById(int id)
        {
            try
            {
                var dto = await _MesaRepo.GetbyIddto(id);
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

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, MesasDtoCU dto)
        {
            if (ModelState.IsValid)
            {
                if (await _MesaRepo.Updatedto(id, dto) == null)
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
        [HttpPatch("{id}")]
        public async Task<ActionResult> ChangeStatus(int id, MesasStatusDTO estado)
        {
            if (ModelState.IsValid)
            {
                if (await _MesaRepo.ChangeStatusdto(id, estado))
                {
                    return NoContent();
                    

                }
                else
                {
                    return StatusCode(500);
                }
            }
            return StatusCode(500);

        }
            [HttpGet("{id}")]
            public async Task<ActionResult<List<OrdenesDto>>> GetTableOrden(int id)
            {
                try
                {
                    var ordenes = await _OrdenesRepo.GetTableOrdenDto(id);

                    if (ordenes == null)
                    {


                        return NotFound();

                    }
                    else
                    {
                        return ordenes;

                    }
                }
                catch
                {
                    return StatusCode(500);

                }
           

            }
        [HttpPost("{id}")]
        public async Task<ActionResult<List<OrdenesDto>>> CompleteTable(int id)
        {
            try
            {
                var ordenes = await _OrdenesRepo.CompleteOrden(id);

                if (ordenes)
                {

                    return NoContent();

                }
                else
                {
                    return NotFound();

                }
            }
            catch
            {
                return StatusCode(500);

            }


        }

    }
}
