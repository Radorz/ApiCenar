using Database.Models;
using DTO;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Repository.Repository
{
    public class MesaRepo : RepositoryBase<Ingredientes, ApiCenarContext>
    {
        private readonly IMapper _mapper;

        public MesaRepo(ApiCenarContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;

        }

        public async Task<List<MesasDTO>> GetAlldto()
        {
            var mesas = await _context.Mesas.ToListAsync();
            var Listdto = new List<MesasDTO>();
            if (mesas == null)
            {
                return null;
            }
            foreach (var item in mesas)
            {
              var dto = _mapper.Map<MesasDTO>(item);

                dto.Descripcion = dto.Descripcion.Trim();
                var estado = await _context.TiposEstados.FindAsync(item.Estado);
                dto.Estado = estado.EstadoDesc.Trim();


                Listdto.Add(dto);
            }
            return Listdto;

        }
        public async Task<bool> Adddto(MesasDtoCU entity)
        {
            var item = _mapper.Map<Mesas>(entity);
            item.Descripcion = item.Descripcion.Trim();
            item.Estado = 1;
            
            _context.Set<Mesas>().Add(item);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<MesasDTO> GetbyIddto(int id)
        {
            var mesas = await _context.Mesas.FindAsync(id);
            if (mesas == null)
            {
                return null;
            }
            var dto = _mapper.Map<MesasDTO>(mesas);
                dto.Descripcion = dto.Descripcion.Trim();
                var estado = await _context.TiposEstados.FindAsync(mesas.Estado);
                dto.Estado = estado.EstadoDesc.Trim();

            return dto;
        }


        public async Task<MesasDtoCU> Updatedto(int id, MesasDtoCU dto)
        {
            var item = await _context.Set<Mesas>().FindAsync(id);
            if (item == null)
            {

                return null;
            }
            item.Personas = dto.Personas;
            item.Descripcion = dto.Descripcion.Trim();
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return dto;
        }
        public async Task<bool> ChangeStatusdto(int id, MesasStatusDTO dto)
        {
            var item = await _context.Set<Mesas>().FindAsync(id);
            var status = await _context.Set<TiposEstados>().FindAsync(dto.Estado);

            if (item == null)
            {

                return false;
            }
            if (status == null)
            {

                return false;
            }
            item.Estado = dto.Estado;
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
       

    }
}


