using AutoMapper;
using Amostra.API.Models.Amostra;
using Amostra.API.ViewModel;
using Amostra.API.ViewModel.Amostra;

namespace Wagon.API
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            #region Cliente, DtoCliente
            CreateMap<Cliente, DtoCliente>()
                .ForMember(
                    dest => dest.CpfCnpj,
                    opt => opt.MapFrom(src => $"{src.CpfCnpj}")
                )
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome}")
                )
                .ForMember(
                    dest => dest.Cep,
                    opt => opt.MapFrom(src => $"{src.Cep}")
                )
                .ForMember(
                    dest => dest.Logradouro,
                    opt => opt.MapFrom(src => $"{src.Logradouro}")
                )
                .ForMember(
                    dest => dest.Numero,
                    opt => opt.MapFrom(src => $"{src.Numero}")
                )
                .ForMember(
                    dest => dest.Complemento,
                    opt => opt.MapFrom(src => $"{src.Complemento}")
                )
                .ForMember(
                    dest => dest.Bairro,
                    opt => opt.MapFrom(src => $"{src.Bairro}")
                )
                .ForMember(
                    dest => dest.Localidade,
                    opt => opt.MapFrom(src => $"{src.Localidade}")
                )
                .ForMember(
                    dest => dest.Uf,
                    opt => opt.MapFrom(src => $"{src.Uf}")
                )
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => $"{src.Email}")
                )
                .ForMember(
                    dest => dest.Telefone,
                    opt => opt.MapFrom(src => $"{src.Telefone}")
                )
                .ForMember(
                    dest => dest.Ativo,
                    opt => opt.MapFrom(src => $"{src.Ativo}")
                )
                .ForMember(
                    dest => dest.Deleted,
                    opt => opt.MapFrom(src => $"{src.Deleted}")
                )
                .ReverseMap();
            #endregion

            #region Cliente, VMCliente
            CreateMap<Cliente, VMCliente>()
                .ForMember(
                    dest => dest.CpfCnpj,
                    opt => opt.MapFrom(src => $"{src.CpfCnpj}")
                )
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome}")
                )
                .ForMember(
                    dest => dest.Cep,
                    opt => opt.MapFrom(src => $"{src.Cep}")
                )
                .ForMember(
                    dest => dest.Logradouro,
                    opt => opt.MapFrom(src => $"{src.Logradouro}")
                )
                .ForMember(
                    dest => dest.Numero,
                    opt => opt.MapFrom(src => $"{src.Numero}")
                )
                .ForMember(
                    dest => dest.Complemento,
                    opt => opt.MapFrom(src => $"{src.Complemento}")
                )
                .ForMember(
                    dest => dest.Bairro,
                    opt => opt.MapFrom(src => $"{src.Bairro}")
                )
                .ForMember(
                    dest => dest.Localidade,
                    opt => opt.MapFrom(src => $"{src.Localidade}")
                )
                .ForMember(
                    dest => dest.Uf,
                    opt => opt.MapFrom(src => $"{src.Uf}")
                )
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => $"{src.Email}")
                )
                .ForMember(
                    dest => dest.Telefone,
                    opt => opt.MapFrom(src => $"{src.Telefone}")
                )
                .ForMember(
                    dest => dest.Ativo,
                    opt => opt.MapFrom(src => $"{src.Ativo}")
                )
                .ForMember(
                    dest => dest.Deleted,
                    opt => opt.MapFrom(src => $"{src.Deleted}")
                )
                .ReverseMap();
            #endregion

            #region VMCliente, Cliente
            CreateMap<VMCliente, Cliente>()
                .ForMember(
                    dest => dest.CpfCnpj,
                    opt => opt.MapFrom(src => $"{src.CpfCnpj}")
                )
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome}")
                )
                .ForMember(
                    dest => dest.Cep,
                    opt => opt.MapFrom(src => $"{src.Cep}")
                )
                .ForMember(
                    dest => dest.Logradouro,
                    opt => opt.MapFrom(src => $"{src.Logradouro}")
                )
                .ForMember(
                    dest => dest.Numero,
                    opt => opt.MapFrom(src => $"{src.Numero}")
                )
                .ForMember(
                    dest => dest.Complemento,
                    opt => opt.MapFrom(src => $"{src.Complemento}")
                )
                .ForMember(
                    dest => dest.Bairro,
                    opt => opt.MapFrom(src => $"{src.Bairro}")
                )
                .ForMember(
                    dest => dest.Localidade,
                    opt => opt.MapFrom(src => $"{src.Localidade}")
                )
                .ForMember(
                    dest => dest.Uf,
                    opt => opt.MapFrom(src => $"{src.Uf}")
                )
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => $"{src.Email}")
                )
                .ForMember(
                    dest => dest.Telefone,
                    opt => opt.MapFrom(src => $"{src.Telefone}")
                )
                .ForMember(
                    dest => dest.Ativo,
                    opt => opt.MapFrom(src => $"{src.Ativo}")
                )
                .ForMember(
                    dest => dest.Deleted,
                    opt => opt.MapFrom(src => $"{src.Deleted}")
                )
                .ReverseMap();
            #endregion

            #region DtoCliente, Cliente
            CreateMap<DtoCliente, Cliente>()
                .ForMember(
                    dest => dest.CpfCnpj,
                    opt => opt.MapFrom(src => $"{src.CpfCnpj}")
                )
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome}")
                )
                .ForMember(
                    dest => dest.Cep,
                    opt => opt.MapFrom(src => $"{src.Cep}")
                )
                .ForMember(
                    dest => dest.Logradouro,
                    opt => opt.MapFrom(src => $"{src.Logradouro}")
                )
                .ForMember(
                    dest => dest.Numero,
                    opt => opt.MapFrom(src => $"{src.Numero}")
                )
                .ForMember(
                    dest => dest.Complemento,
                    opt => opt.MapFrom(src => $"{src.Complemento}")
                )
                .ForMember(
                    dest => dest.Bairro,
                    opt => opt.MapFrom(src => $"{src.Bairro}")
                )
                .ForMember(
                    dest => dest.Localidade,
                    opt => opt.MapFrom(src => $"{src.Localidade}")
                )
                .ForMember(
                    dest => dest.Uf,
                    opt => opt.MapFrom(src => $"{src.Uf}")
                )
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => $"{src.Email}")
                )
                .ForMember(
                    dest => dest.Telefone,
                    opt => opt.MapFrom(src => $"{src.Telefone}")
                )
                .ForMember(
                    dest => dest.Ativo,
                    opt => opt.MapFrom(src => $"{src.Ativo}")
                )
                .ForMember(
                    dest => dest.Deleted,
                    opt => opt.MapFrom(src => $"{src.Deleted}")
                )
                .ReverseMap();
            #endregion

            //CreateMap<List<Cliente>, List<DtoCliente>>().ReverseMap();
            //CreateMap<List<Cliente>, List<VMCliente>>().ReverseMap();
            //CreateMap<List<DtoCliente>, List<Cliente>>().ReverseMap();
            //CreateMap<List<VMCliente>, List<Cliente>>().ReverseMap();
        }
    }
}