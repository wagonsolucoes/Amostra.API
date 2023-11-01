using AutoMapper;
using Amostra.API.Models.Amostra;
using Amostra.API.ViewModel;
using Amostra.API.ViewModel.Amostra;

namespace Wagon.API
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cliente, DtoCliente>();
                cfg.CreateMap<DtoCliente, Cliente>();
            });
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
