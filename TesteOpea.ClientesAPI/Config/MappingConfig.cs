using AutoMapper;
using TesteOpea.ClientesAPI.DTO;
using TesteOpea.ClientesAPI.Model;

namespace TesteOpea.ClientesAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapping =  new MapperConfiguration(config => {
                config.CreateMap<ClienteDTO, Cliente>().ReverseMap();
                
            });

            return mapping;
        }
    }
}
