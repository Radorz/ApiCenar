using AutoMapper;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Infraestructure
{
    public class AutoMapperConfigurationDTO : Profile
    {
        public AutoMapperConfigurationDTO()
        {

            IngredientesConfiguration();
            MesasConfiguration();
            Mesas2Configuration();

            OrdenesConfiguration();
            Ordenes2Configuration();
            Ordenes3Configuration();

            PlatosConfiguration();
            Platos2Configuration();
        }
        private void IngredientesConfiguration()
        {
            CreateMap<IngredientesDto, Ingredientes>().ReverseMap();

        }

        private void MesasConfiguration()
        {
            CreateMap<MesasDTO, Mesas>().ReverseMap().ForMember(dest => dest.Estado, opt => opt.Ignore());

        }
        private void Mesas2Configuration()
        {
            CreateMap<MesasDtoCU, Mesas>().ReverseMap();

        }
        private void OrdenesConfiguration()
        {
            CreateMap<OrdenesDto, Ordenes>().ReverseMap().ForMember(dest => dest.OrdenPlatos, opt => opt.Ignore());

        }
        private void Ordenes2Configuration()
        {
            CreateMap<OrdenesDtoCreate, Ordenes>().ReverseMap().ForMember(dest => dest.OrdenPlatos, opt => opt.Ignore());

        }
        private void Ordenes3Configuration()
        {
            CreateMap<OrdenesDtoUpdate, Ordenes>().ReverseMap().ForMember(dest => dest.OrdenPlatos, opt => opt.Ignore());

        }
        private void PlatosConfiguration()
        {
            CreateMap<PlatosDto, Platos>().ReverseMap().ForMember(dest => dest.Ingredientes, opt => opt.Ignore());

        }
        private void Platos2Configuration()
        {
            CreateMap<PlatosDtoCU, Platos>().ReverseMap().ForMember(dest => dest.Ingredientes, opt => opt.Ignore());

        }


    }
}
