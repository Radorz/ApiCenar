using Database.Models;
using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
   public class IngredientesRepo : RepositoryBase<Ingredientes, ApiCenarContext>
    {
        public IngredientesRepo(ApiCenarContext context) : base(context)
        {

        }

        public async Task<List<IngredientesDto>> GetAlldto()
        {
            var ingredientes = await _context.Ingredientes.ToListAsync();
            var Listdto = new List< IngredientesDto>();

            foreach (var item in ingredientes)
            {
                var dto = new IngredientesDto();

                dto.id = item.Id;
                dto.Nombre = item.Nombre.Trim();
                Listdto.Add(dto);
            }
            return Listdto;

        }
        public async Task<IngredientesDto> Adddto(IngredientesDto entity)
        {
            var item = new Ingredientes();
            item.Nombre = entity.Nombre;
            _context.Set<Ingredientes>().Add(item);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<IngredientesDto> GetbyIddto(int id)
        {
           var item =await _context.Set<Ingredientes>().FindAsync(id);
            if (item == null)
            {

                return null;
            }
            var dto = new IngredientesDto();

            dto.id = item.Id;
            dto.Nombre = item.Nombre.Trim();
            return dto;
        }
    

        public async Task<IngredientesDto> Updatedto(int id, IngredientesDto dto)
        {
            var item = await _context.Set<Ingredientes>().FindAsync(id);
            if(item== null)
            {

                return null;
            }
            item.Nombre = dto.Nombre.Trim();
            
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return dto;
        }
      
    }
}
