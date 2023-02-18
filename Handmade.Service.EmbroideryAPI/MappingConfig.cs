using Handmade.Service.EmbroideryAPI.Models;
using Handmade.Service.EmbroideryAPI.Models.Dto;
using AutoMapper;

namespace Handmade.Service.EmbroideryAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<MotoDto, Moto>();
                config.CreateMap<Moto, MotoDto>();
            }


                );

            return mappingConfig;
        }
    }
}
