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
    public class OrdenesRepo : RepositoryBase<Ordenes, ApiCenarContext>
    {
        private readonly PlatosRepo _PlatosRepo;
        private readonly IMapper _mapper;

        public OrdenesRepo(ApiCenarContext context, PlatosRepo platosRepo, IMapper mapper) : base(context)
        {
            _PlatosRepo = platosRepo;
            _mapper = mapper;

        }

        public async Task<List<OrdenesDto>> GetAlldto()
        {
            var Ordenes = await _context.Ordenes.ToListAsync();
            var Listdto = new List<OrdenesDto>();
           
            foreach (var item in Ordenes)
            {
                var dto = _mapper.Map<OrdenesDto>(item);

                
                dto.Estado = dto.Estado.Trim();
                dto.Subtotal = 0;
                var platosids = await _context.OrdenPlatos.Where(a => a.IdOrden == item.Id).Select(a => a.IdPlato.GetValueOrDefault()).ToListAsync();
                var platos = await _PlatosRepo.GetAlldtoForOrders(platosids);
                dto.OrdenPlatos = platos;

                foreach (var precio in platos)
                {
                    dto.Subtotal = dto.Subtotal + precio.Precio;
                }




                Listdto.Add(dto);
            }
            return Listdto;

        }
        public async Task<bool> Adddto(OrdenesDtoCreate entity)
        {
            var item = _mapper.Map<Ordenes>(entity);
            item.Estado = "Proceso";
            item.Subtotal = 0;
            _context.Set<Ordenes>().Add(item);
            await _context.SaveChangesAsync();

            foreach (var id in entity.OrdenPlatos)
            {
                if (await _context.Platos.FindAsync(id) != null)
                {
                    var plato = new OrdenPlatos();
                    plato.IdOrden = item.Id;
                    plato.IdPlato = id;
                    await _context.OrdenPlatos.AddAsync(plato);
                    await _context.SaveChangesAsync();


                }


            }
            
            return true;
        }
        public async Task<OrdenesDto> GetbyIddto(int id)
        {
            var item = await _context.Set<Ordenes>().FindAsync(id);
            if (item == null)
            {

                return null;
            }
            var dto = new OrdenesDto();

            dto.Id = item.Id;
            dto.IdMesa = item.IdMesa;
            dto.Estado = item.Estado.Trim();
            dto.Subtotal = 0;

            var platosids = await _context.OrdenPlatos.Where(a => a.IdOrden == item.Id).Select(a => a.IdPlato.GetValueOrDefault()).ToListAsync();
            var platos = await _PlatosRepo.GetAlldtoForOrders(platosids);
            dto.OrdenPlatos = platos;

            foreach (var precio in platos)
            {
                dto.Subtotal = dto.Subtotal + precio.Precio;
            }
            return dto;
        }


        public async Task<bool> Updatedto(int id, OrdenesDtoUpdate dto)
        {
            var item = await _context.Set<Ordenes>().FindAsync(id);
            if (item == null)
            {

                return false;
            }
            var platooRDEN = await _context.OrdenPlatos.Where(a => a.IdOrden == id).ToListAsync();

            foreach (var PLATO in platooRDEN)
            {

                _context.OrdenPlatos.Remove(PLATO);
                await _context.SaveChangesAsync();

            }
            foreach (var ids in dto.OrdenPlatos)
            {
                if (await _context.Platos.FindAsync(ids) != null)
                {
                    var plato = new OrdenPlatos();
                    plato.IdOrden = item.Id;
                    plato.IdPlato = ids;
                    await _context.OrdenPlatos.AddAsync(plato);
                    await _context.SaveChangesAsync();


                }


            }
            return true;
        }
        public async Task<bool> Deletedto(int id)
        {
            var orden = await _context.Set<Ordenes>().FindAsync(id);
            if (orden == null)
            {

                return false;
            }
            var platooRDEN = await _context.OrdenPlatos.Where(a => a.IdOrden == id).ToListAsync();

            foreach (var PLATO in platooRDEN)
            {

                _context.OrdenPlatos.Remove(PLATO);
                await _context.SaveChangesAsync();

            }
            await Delete(id);

            return true;
        }
        public async Task<List<OrdenesDto>> GetTableOrdenDto(int id)
        {
            if (await _context.Set<Mesas>().FindAsync(id)==null)
            {

                return null;
            }
            var Ordenes = await _context.Ordenes.Where(a => a.IdMesa == id).ToListAsync();

            if (Ordenes.Count() == 0)
            {

                return null;
            }
            var Listdto = new List<OrdenesDto>();

            foreach (var item in Ordenes)
            {
                var dto = _mapper.Map<OrdenesDto>(item);

                dto.Estado = dto.Estado.Trim();
                dto.Subtotal = 0;

                var platosids = await _context.OrdenPlatos.Where(a => a.IdOrden == item.Id).Select(a => a.IdPlato.GetValueOrDefault()).ToListAsync();
                var platos = await _PlatosRepo.GetAlldtoForOrders(platosids);
                dto.OrdenPlatos = platos;

                foreach (var precio in platos)
                {
                    dto.Subtotal = dto.Subtotal + precio.Precio;
                }

                Listdto.Add(dto);
            }

           

            return Listdto;
        }
        public async Task<bool> CompleteOrden(int id)
        {
            if (await _context.Set<Mesas>().FindAsync(id) == null)
            {

                return false;
            }
            var Ordenes = await _context.Ordenes.Where(a => a.IdMesa == id && a.Estado.Trim() == "Proceso").ToListAsync();

            if (Ordenes == null)
            {

                return false;
            }
            foreach(var orden in Ordenes)
            {
                orden.Subtotal = 0;
                var platosids = await _context.OrdenPlatos.Where(a => a.IdOrden == orden.Id).Select(a => a.IdPlato.GetValueOrDefault()).ToListAsync();
                var platos = await _PlatosRepo.GetAlldtoForOrders(platosids);

                foreach (var precio in platos)
                {
                    orden.Subtotal = orden.Subtotal + precio.Precio;
                }
                
                orden.Estado = "Completada";
                
                _context.Entry(orden).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

    
            return true;
        }
    }

    }
