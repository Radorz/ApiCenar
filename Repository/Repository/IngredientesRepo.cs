using AutoMapper;
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
        private readonly IMapper _mapper;

        public IngredientesRepo(ApiCenarContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;

        }

        public async Task<List<IngredientesDto>> GetAlldto()
        {
            var ingredientes = await _context.Ingredientes.ToListAsync();
            var Listdto = new List< IngredientesDto>();
             
            foreach (var item in ingredientes)
            {
                var dto =_mapper.Map<IngredientesDto>(item);
                dto.Nombre = dto.Nombre.Trim();
                Listdto.Add(dto);
            }
            return Listdto;

        }
        public async Task<IngredientesDto> Adddto(IngredientesDto entity)
        {
            var item = _mapper.Map<Ingredientes>(entity);
            item.Nombre = item.Nombre.Trim();
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
            var dto = _mapper.Map<IngredientesDto>(item);
            dto.Nombre = dto.Nombre.Trim();
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
