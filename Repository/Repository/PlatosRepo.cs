using Database.Models;
using DTO;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace Repository.Repository
{
    public class PlatosRepo : RepositoryBase<Platos, ApiCenarContext>
    {
        private readonly IMapper _mapper;

        public PlatosRepo(ApiCenarContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;

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
                var ingredientesid = await _context.IngredientesPlato.Where(a => a.IdPlato == item.Id).ToListAsync();
                var Listingredientes = new List<IngredientesDto>();

                var dto = _mapper.Map<PlatosDto>(item);
                dto.Nombre = dto.Nombre.Trim();
                foreach (var ingredientes in ingredientesid)
                {
                    var ingrediente = await _context.Ingredientes.FirstOrDefaultAsync(a => a.Id == ingredientes.IdIngrediente);
                    var Listdtoingredientes = new IngredientesDto();

                    Listdtoingredientes.id = ingrediente.Id;
                    Listdtoingredientes.Nombre = ingrediente.Nombre.Trim();
                    Listingredientes.Add(Listdtoingredientes);

                }
                dto.Ingredientes = Listingredientes;
                dto.Categoria = dto.Categoria.Trim();



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
                var ingredientesid = await _context.IngredientesPlato.Where(a => a.IdPlato == platos.Id).ToListAsync();
                var Listingredientes = new List<IngredientesDto>();
            var dto = _mapper.Map<PlatosDto>(platos);
                dto.Nombre = platos.Nombre.Trim();
               
                foreach (var ingredientes in ingredientesid)
                {
                    var ingrediente = await _context.Ingredientes.FirstOrDefaultAsync(a => a.Id == ingredientes.IdIngrediente);
                    var Listdtoingredientes = new IngredientesDto();

                    Listdtoingredientes.id = ingrediente.Id;
                    Listdtoingredientes.Nombre = ingrediente.Nombre.Trim();
                    Listingredientes.Add(Listdtoingredientes);

                }
                dto.Ingredientes = Listingredientes;
                dto.Categoria = dto.Categoria.Trim();

            return dto;

        }
        public async Task<bool> Adddto(PlatosDtoCU entity)
        {
            var item = _mapper.Map<Platos>(entity);

            _context.Set<Platos>().Add(item);
            await _context.SaveChangesAsync();

                foreach(var id in entity.Ingredientes)
            {
                if (await _context.Ingredientes.FindAsync(id) != null)
                {
                    var ingplato = new IngredientesPlato();
                    ingplato.IdIngrediente = id;
                    ingplato.IdPlato = item.Id;
                   await _context.IngredientesPlato.AddAsync(ingplato);
                    await _context.SaveChangesAsync();


                }


            }

            
            return true;
        }

        public async Task<PlatosDtoCU> Updatedto(int id, PlatosDtoCU dto)
        {
            var item = await _context.Set<Platos>().FindAsync(id);
            if (item == null)
            {

                return null;
            }
             item = _mapper.Map<Platos>(dto);

            
            var ingredientes = await _context.IngredientesPlato.Where(a => a.IdPlato == id).ToListAsync();

            foreach(var ing in ingredientes){

                 _context.IngredientesPlato.Remove(ing);
                await _context.SaveChangesAsync();

            }

            foreach (var ids in dto.Ingredientes)
            {
                if (await _context.Ingredientes.FindAsync(ids) != null)
                {
                    var ingplato = new IngredientesPlato();
                    ingplato.IdIngrediente = ids;
                    ingplato.IdPlato = item.Id;
                    await _context.IngredientesPlato.AddAsync(ingplato);
                    await _context.SaveChangesAsync();


                }


                _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            }
            return dto;
        }

        public async Task<List<PlatosDto>> GetAlldtoForOrders(List<int> platosOrdenes)
        {
            
            var Listdto = new List<PlatosDto>();

            foreach (var item in platosOrdenes)
            {

                var platos = await _context.Platos.FirstOrDefaultAsync(a => a.Id == item);
                if (platos == null)
                {
                    return null;
                }
                var ingredientesid = await _context.IngredientesPlato.Where(a => a.IdPlato == platos.Id).ToListAsync();
                var Listingredientes = new List<IngredientesDto>();
                var dto = _mapper.Map<PlatosDto>(platos);

                dto.Nombre = platos.Nombre.Trim();

                foreach (var ingredientes in ingredientesid)
                {
                    var ingrediente = await _context.Ingredientes.FirstOrDefaultAsync(a => a.Id == ingredientes.IdIngrediente);
                    var Listdtoingredientes = new IngredientesDto();

                    Listdtoingredientes.id = ingrediente.Id;
                    Listdtoingredientes.Nombre = ingrediente.Nombre.Trim();
                    Listingredientes.Add(Listdtoingredientes);

                }
                dto.Ingredientes = Listingredientes;
                dto.Categoria = dto.Categoria.Trim();



                Listdto.Add(dto);
            }
            return Listdto;

        }
    }
}


