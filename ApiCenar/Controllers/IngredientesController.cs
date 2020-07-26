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
    public class IngredientesController : ControllerBase
    {
        private readonly IngredientesRepo _IngredientesRepo;

        public IngredientesController( IngredientesRepo IngredientesRepo)
        {
            _IngredientesRepo = IngredientesRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<IngredientesDto>>> List()
        {
            try { 
            var lists = await _IngredientesRepo.GetAlldto();

                if(lists==null){


                    return NotFound();

                }else { 
                return lists;

                }
            }
            catch
            {
                return StatusCode(500);

            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientesDto>> GetById(int id)
        {
            try
            {
                var dto = await _IngredientesRepo.GetbyIddto(id);
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
            public async Task<ActionResult> Create(IngredientesDto dto)
            {
                if (ModelState.IsValid)
                {
                try
                {
                    await _IngredientesRepo.Adddto(dto);
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
        public async Task<ActionResult> Update(int id, IngredientesDto dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (await _IngredientesRepo.Updatedto(id, dto) == null)
                    {
                        return StatusCode(500);

                    }
                    else
                    {
                        return NoContent();
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
}
