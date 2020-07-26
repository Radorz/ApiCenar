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
            OrdenesConfiguration();
        }
        private void IngredientesConfiguration()
        {
            CreateMap<IngredientesDto, Ingredientes>().ReverseMap();

        }

        private void MesasConfiguration()
        {
            CreateMap<MesasDTO, Mesas>().ReverseMap().ForMember(dest => dest.Estado, opt => opt.Ignore());

        }

        private void OrdenesConfiguration()
        {
            CreateMap<OrdenesDto, Ordenes>().ReverseMap().ForMember(dest => dest.OrdenPlatos, opt => opt.Ignore());

        }


    }
}
