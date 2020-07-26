using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCenar.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {

        private readonly OrdenesRepo _OrdenesRepo;

        public OrdenesController(OrdenesRepo OrdenesRepo)
        {
            _OrdenesRepo = OrdenesRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrdenesDto>>> List()
        {
            try
            {
                var lists = await _OrdenesRepo.GetAlldto();

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

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenesDto>> GetById(int id)
        {
            try
            {
                var dto = await _OrdenesRepo.GetbyIddto(id);
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
        public async Task<ActionResult> Create(OrdenesDtoCreate dto)
        {
            if (ModelState.IsValid)
            {
                try { 
                await _OrdenesRepo.Adddto(dto);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);

            }
        }
            return StatusCode(500);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, OrdenesDtoUpdate dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (await _OrdenesRepo.Updatedto(id, dto) )
                {
                    return NoContent();

                }
                else
                {
                    return StatusCode(500);
                    }
            }
            catch
            {
                return StatusCode(500);

            }
        }
            return StatusCode(500);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    if (await _OrdenesRepo.Deletedto(id))
                {
                    return NoContent();

                }
                else
                {
                    return StatusCode(500);
                }
                }
                catch
                {
                    return StatusCode(500);

                }
            }
            return StatusCode(500);

        }


    }
}
