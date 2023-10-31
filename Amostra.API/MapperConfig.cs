//using AutoMapper;
//using Wagon.Entity.Models.CNPJ;
//using Wagon.ViewModel.CNPJ.Dto;
//using Wagon.ViewModel.CNPJ.VM;

//namespace Wagon.API
//{
//    public class MapperConfig
//    {
//        public static Mapper InitializeAutomapper()
//        {
//            var config = new MapperConfiguration(cfg =>
//            {
//                cfg.CreateMap<Bairro, DtoBairro>();
//                cfg.CreateMap<Cnae, DtoCnae>();
//                cfg.CreateMap<Empresa, DtoEmpresa>();
//                cfg.CreateMap<Estado, DtoEstado>();
//                cfg.CreateMap<Motivo, DtoMotivo>();
//                cfg.CreateMap<Municipio, DtoMunicipio>();
//                cfg.CreateMap<NaturezaJuridica, DtoNaturezaJuridica>();
//                cfg.CreateMap<Pai, DtoPais>();
//                cfg.CreateMap<Porte, DtoPorte>();
//                cfg.CreateMap<QualificacaoResponsavel, DtoQualificacaoResponsavel>();
//                cfg.CreateMap<SituacaoCadastral, DtoSituacaoCadastral>();

//                cfg.CreateMap<VMBairro, Bairro>();
//                cfg.CreateMap<VMCnae, Cnae>();
//                cfg.CreateMap<VMEmpresa, Empresa>();
//                cfg.CreateMap<VMEstado, Estado>();
//                cfg.CreateMap<VMMotivo, Motivo>();
//                cfg.CreateMap<VMMunicipio, Municipio>();
//                cfg.CreateMap<VMNaturezaJuridica, NaturezaJuridica>();
//                cfg.CreateMap<VMPais, Pai>();
//                cfg.CreateMap<VMPorte, Porte>();
//                cfg.CreateMap<VMQualificacaoResponsavel, QualificacaoResponsavel>();
//                cfg.CreateMap<VMSituacaoCadastral, SituacaoCadastral>();
//            });
//            var mapper = new Mapper(config);
//            return mapper;
//        }
//    }
//}
