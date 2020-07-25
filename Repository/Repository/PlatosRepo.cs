using Database.Models;
using DTO;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class PlatosRepo : RepositoryBase<Platos, ApiCenarContext>
    {
        public PlatosRepo(ApiCenarContext context) : base(context)
        {

        }

        public async Task<List<PlatosDto>> GetAlldto()
        {
            var platos = await _context.Platos.ToListAsync();
            var Listdto = new List<PlatosDto>();
            if (platos == null)
            {
                return null;
            }
            foreach (var item in platos)
            {
                var dto = new PlatosDto();
                var ingredientesid = await _context.IngredientesPlato.Where(a => a.IdPlato == item.Id).ToListAsync();
                var Listingredientes = new List<IngredientesDto>();


                dto.id = item.Id;
                dto.Nombre = item.Nombre.Trim();
                dto.Precio = item.Precio.GetValueOrDefault();
                dto.Personas = item.Personas.GetValueOrDefault();
                foreach (var ingredientes in ingredientesid)
                {
                    var ingrediente = await _context.Ingredientes.FirstOrDefaultAsync(a => a.Id == ingredientes.IdIngrediente);
                    var Listdtoingredientes = new IngredientesDto();

                    Listdtoingredientes.id = ingrediente.Id;
                    Listdtoingredientes.Nombre = ingrediente.Nombre.Trim();
                    Listingredientes.Add(Listdtoingredientes);

                }
                dto.Ingredientes = Listingredientes;
                dto.Categoria = item.Categoria.Trim();



                Listdto.Add(dto);
            }
            return Listdto;

        }

        public async Task<PlatosDto> GetByIddto(int id)
        {
            var platos = await _context.Platos.FindAsync(id);
            if (platos == null)
            {
                return null;
            }
            var dto = new PlatosDto();
                var ingredientesid = await _context.IngredientesPlato.Where(a => a.IdPlato == platos.Id).ToListAsync();
                var Listingredientes = new List<IngredientesDto>();


                dto.id = platos.Id;
                dto.Nombre = platos.Nombre.Trim();
                dto.Precio = platos.Precio.GetValueOrDefault();
                dto.Personas = platos.Personas.GetValueOrDefault();
                foreach (var ingredientes in ingredientesid)
                {
                    var ingrediente = await _context.Ingredientes.FirstOrDefaultAsync(a => a.Id == ingredientes.IdIngrediente);
                    var Listdtoingredientes = new IngredientesDto();

                    Listdtoingredientes.id = ingrediente.Id;
                    Listdtoingredientes.Nombre = ingrediente.Nombre.Trim();
                    Listingredientes.Add(Listdtoingredientes);

                }
                dto.Ingredientes = Listingredientes;
                dto.Categoria = platos.Categoria.Trim();

            return dto;

        }
        public async Task<PlatosDto> Adddto(PlatosDto entity)
        {
            var item = new Platos();
            item.Nombre = entity.Nombre;
            item.Precio = entity.Precio;
            item.Nombre = entity.Nombre;


            _context.Set<Ingredientes>().Add(item);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
