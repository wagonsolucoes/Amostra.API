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
            #region CLIENTE
            #region Cliente, DtoCliente
            CreateMap<Cliente, ClienteDto>()
                .ForMember(
                    dest => dest.Documento,
                    opt => opt.MapFrom(src => src.CpfCnpj)
                )
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => src.Nome)
                )
                .ForMember(
                    dest => dest.Cep,
                    opt => opt.MapFrom(src => src.Cep)
                )
                .ForMember(
                    dest => dest.Endereco,
                    opt => opt.MapFrom(src => src.Logradouro)
                )
                .ForMember(
                    dest => dest.Numero,
                    opt => opt.MapFrom(src => src.Numero)
                )
                .ForMember(
                    dest => dest.Complemento,
                    opt => opt.MapFrom(src => src.Complemento)
                )
                .ForMember(
                    dest => dest.Bairro,
                    opt => opt.MapFrom(src => src.Bairro)
                )
                .ForMember(
                    dest => dest.Municipio,
                    opt => opt.MapFrom(src => src.Localidade)
                )
                .ForMember(
                    dest => dest.Uf,
                    opt => opt.MapFrom(src => src.Uf)
                )
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => src.Email)
                )
                .ForMember(
                    dest => dest.Telefone,
                    opt => opt.MapFrom(src => src.Telefone)
                )
                .ForMember(
                    dest => dest.Nascimento,
                    opt => opt.MapFrom(src => src.Nascimento)
                )
                .ForMember(
                    dest => dest.Idade,
                    opt => opt.MapFrom(src => src.Idade)
                )
                .ForMember(
                    dest => dest.Ativo,
                    opt => opt.MapFrom(src => src.Ativo)
                );
            #endregion

            #region Cliente, VMCliente
            CreateMap<Cliente, ClienteVm>()
                .ForMember(
                    dest => dest.Documento,
                    opt => opt.MapFrom(src => src.CpfCnpj)
                )
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => src.Nome)
                )
                .ForMember(
                    dest => dest.Cep,
                    opt => opt.MapFrom(src => src.Cep)
                )
                .ForMember(
                    dest => dest.Endereco,
                    opt => opt.MapFrom(src => src.Logradouro)
                )
                .ForMember(
                    dest => dest.Numero,
                    opt => opt.MapFrom(src => src.Numero)
                )
                .ForMember(
                    dest => dest.Complemento,
                    opt => opt.MapFrom(src => src.Complemento)
                )
                .ForMember(
                    dest => dest.Bairro,
                    opt => opt.MapFrom(src => src.Bairro)
                )
                .ForMember(
                    dest => dest.Municipio,
                    opt => opt.MapFrom(src => src.Localidade)
                )
                .ForMember(
                    dest => dest.Uf,
                    opt => opt.MapFrom(src => src.Uf)
                )
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => src.Email)
                )
                .ForMember(
                    dest => dest.Telefone,
                    opt => opt.MapFrom(src => src.Telefone)
                )
                .ForMember(
                    dest => dest.Nascimento,
                    opt => opt.MapFrom(src => src.Nascimento)
                )
                .ForMember(
                    dest => dest.Idade,
                    opt => opt.MapFrom(src => src.Idade)
                )
                .ForMember(
                    dest => dest.Ativo,
                    opt => opt.MapFrom(src => src.Ativo)
                );
            #endregion

            #region VMCliente, Cliente
            CreateMap<ClienteVm, Cliente>()
                .ForMember(
                    dest => dest.CpfCnpj,
                    opt => opt.MapFrom(src => src.Documento)
                )
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => src.Nome)
                )
                .ForMember(
                    dest => dest.Cep,
                    opt => opt.MapFrom(src => src.Cep)
                )
                .ForMember(
                    dest => dest.Logradouro,
                    opt => opt.MapFrom(src => src.Endereco)
                )
                .ForMember(
                    dest => dest.Numero,
                    opt => opt.MapFrom(src => src.Numero)
                )
                .ForMember(
                    dest => dest.Complemento,
                    opt => opt.MapFrom(src => src.Complemento)
                )
                .ForMember(
                    dest => dest.Bairro,
                    opt => opt.MapFrom(src => src.Bairro)
                )
                .ForMember(
                    dest => dest.Localidade,
                    opt => opt.MapFrom(src => src.Municipio)
                )
                .ForMember(
                    dest => dest.Uf,
                    opt => opt.MapFrom(src => src.Uf)
                )
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => src.Email)
                )
                .ForMember(
                    dest => dest.Telefone,
                    opt => opt.MapFrom(src => src.Telefone)
                )
                .ForMember(
                    dest => dest.Nascimento,
                    opt => opt.MapFrom(src => src.Nascimento)
                )
                .ForMember(
                    dest => dest.Idade,
                    opt => opt.MapFrom(src => src.Idade)
                )
                .ForMember(
                    dest => dest.Ativo,
                    opt => opt.MapFrom(src => src.Ativo)
                );
            #endregion

            #region DtoCliente, Cliente
            CreateMap<ClienteDto, Cliente>()
                .ForMember(
                    dest => dest.CpfCnpj,
                    opt => opt.MapFrom(src => src.Documento)
                )
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => src.Nome)
                )
                .ForMember(
                    dest => dest.Cep,
                    opt => opt.MapFrom(src => src.Cep)
                )
                .ForMember(
                    dest => dest.Logradouro,
                    opt => opt.MapFrom(src => src.Endereco)
                )
                .ForMember(
                    dest => dest.Numero,
                    opt => opt.MapFrom(src => src.Numero)
                )
                .ForMember(
                    dest => dest.Complemento,
                    opt => opt.MapFrom(src => src.Complemento)
                )
                .ForMember(
                    dest => dest.Bairro,
                    opt => opt.MapFrom(src => src.Bairro)
                )
                .ForMember(
                    dest => dest.Localidade,
                    opt => opt.MapFrom(src => src.Municipio)
                )
                .ForMember(
                    dest => dest.Uf,
                    opt => opt.MapFrom(src => src.Uf)
                )
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => src.Email)
                )
                .ForMember(
                    dest => dest.Telefone,
                    opt => opt.MapFrom(src => src.Telefone)
                )
                .ForMember(
                    dest => dest.Nascimento,
                    opt => opt.MapFrom(src => src.Nascimento)
                )
                .ForMember(
                    dest => dest.Idade,
                    opt => opt.MapFrom(src => src.Idade)
                )
                .ForMember(
                    dest => dest.Ativo,
                    opt => opt.MapFrom(src => src.Ativo)
                );
            #endregion
            #endregion

            #region EMPRESTADO
            #region Emprestado, EmprestadoDto
            CreateMap<Emprestado, EmprestadoDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.IdCliente,
                    opt => opt.MapFrom(src => src.IdCliente)
                )
                .ForMember(
                    dest => dest.IdLivro,
                    opt => opt.MapFrom(src => src.IdLivro)
                )
                .ForMember(
                    dest => dest.Dh,
                    opt => opt.MapFrom(src => src.Dh)
                )
                .ForMember(
                    dest => dest.DhDevolucao,
                    opt => opt.MapFrom(src => src.DhDevolucao)
                )
                .ForMember(
                    dest => dest.DiasEmprestado,
                    opt => opt.MapFrom(src => src.DiasEmprestado)
                )
                .ForMember(
                    dest => dest.Ativo,
                    opt => opt.MapFrom(src => src.Ativo)
                )
                .ForMember(
                    dest => dest.Cliente,
                    opt => opt.MapFrom(src => src.IdClienteNavigation)
                )
                .ForMember(
                    dest => dest.Livro,
                    opt => opt.MapFrom(src => src.IdLivroNavigation)
                );
            #endregion

            #region Emprestado, EmprestadoVm
            CreateMap<Emprestado, EmprestadoVm>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.IdCliente,
                    opt => opt.MapFrom(src => src.IdCliente)
                )
                .ForMember(
                    dest => dest.IdLivro,
                    opt => opt.MapFrom(src => src.IdLivro)
                )
                .ForMember(
                    dest => dest.Dh,
                    opt => opt.MapFrom(src => src.Dh)
                )
                .ForMember(
                    dest => dest.DhDevolucao,
                    opt => opt.MapFrom(src => src.DhDevolucao)
                )
                .ForMember(
                    dest => dest.DiasEmprestado,
                    opt => opt.MapFrom(src => src.DiasEmprestado)
                )
                .ForMember(
                    dest => dest.Ativo,
                    opt => opt.MapFrom(src => src.Ativo)
                );
            #endregion

            #region EmprestadoVm, Emprestado
            CreateMap<EmprestadoVm, Emprestado>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.IdCliente,
                    opt => opt.MapFrom(src => src.IdCliente)
                )
                .ForMember(
                    dest => dest.IdLivro,
                    opt => opt.MapFrom(src => src.IdLivro)
                )
                .ForMember(
                    dest => dest.Dh,
                    opt => opt.MapFrom(src => src.Dh)
                )
                .ForMember(
                    dest => dest.DhDevolucao,
                    opt => opt.MapFrom(src => src.DhDevolucao)
                )
                .ForMember(
                    dest => dest.DiasEmprestado,
                    opt => opt.MapFrom(src => src.DiasEmprestado)
                )
                .ForMember(
                    dest => dest.Ativo,
                    opt => opt.MapFrom(src => src.Ativo)
                );
            #endregion

            #region EmprestadoDto, Emprestado
            CreateMap<EmprestadoDto, Emprestado>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.IdCliente,
                    opt => opt.MapFrom(src => src.IdCliente)
                )
                .ForMember(
                    dest => dest.IdLivro,
                    opt => opt.MapFrom(src => src.IdLivro)
                )
                .ForMember(
                    dest => dest.Dh,
                    opt => opt.MapFrom(src => src.Dh)
                )
                .ForMember(
                    dest => dest.DhDevolucao,
                    opt => opt.MapFrom(src => src.DhDevolucao)
                )
                .ForMember(
                    dest => dest.DiasEmprestado,
                    opt => opt.MapFrom(src => src.DiasEmprestado)
                )
                .ForMember(
                    dest => dest.Ativo,
                    opt => opt.MapFrom(src => src.Ativo)
                )
                .ForMember(
                    dest => dest.IdClienteNavigation,
                    opt => opt.MapFrom(src => src.Cliente)
                )
                .ForMember(
                    dest => dest.IdLivroNavigation,
                    opt => opt.MapFrom(src => src.Livro)
                );
            #endregion
            #endregion

            #region LIVRO
            #region Livro, LivroDto
            CreateMap<Livro, LivroDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.DhCompra,
                    opt => opt.MapFrom(src => src.DhCompra)
                )
                .ForMember(
                    dest => dest.Titulo,
                    opt => opt.MapFrom(src => src.Titulo)
                )
                .ForMember(
                    dest => dest.Prefacio,
                    opt => opt.MapFrom(src => src.Prefacio)
                )
                .ForMember(
                    dest => dest.Autor,
                    opt => opt.MapFrom(src => src.Autor)
                )
                .ForMember(
                    dest => dest.Editora,
                    opt => opt.MapFrom(src => src.Editora)
                )
                .ForMember(
                    dest => dest.DhExtravio,
                    opt => opt.MapFrom(src => src.DhExtravio)
                )
                .ForMember(
                    dest => dest.Extraviado,
                    opt => opt.MapFrom(src => src.Extraviado)
                )
                .ForMember(
                    dest => dest.Emprestado,
                    opt => opt.MapFrom(src => src.Emprestado)
                )
                .ForMember(
                    dest => dest.Ativo,
                    opt => opt.MapFrom(src => src.Ativo)
                );
            #endregion

            #region Livro, VMLivro
            CreateMap<Livro, LivroVm>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.DhCompra,
                    opt => opt.MapFrom(src => src.DhCompra)
                )
                .ForMember(
                    dest => dest.Titulo,
                    opt => opt.MapFrom(src => src.Titulo)
                )
                .ForMember(
                    dest => dest.Prefacio,
                    opt => opt.MapFrom(src => src.Prefacio)
                )
                .ForMember(
                    dest => dest.Autor,
                    opt => opt.MapFrom(src => src.Autor)
                )
                .ForMember(
                    dest => dest.Editora,
                    opt => opt.MapFrom(src => src.Editora)
                )
                .ForMember(
                    dest => dest.DhExtravio,
                    opt => opt.MapFrom(src => src.DhExtravio)
                )
                .ForMember(
                    dest => dest.Extraviado,
                    opt => opt.MapFrom(src => src.Extraviado)
                )
                .ForMember(
                    dest => dest.Emprestado,
                    opt => opt.MapFrom(src => src.Emprestado)
                )
                .ForMember(
                    dest => dest.Ativo,
                    opt => opt.MapFrom(src => src.Ativo)
                );
            #endregion

            #region VMLivro, Livro
            CreateMap<LivroVm, Livro>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.DhCompra,
                    opt => opt.MapFrom(src => src.DhCompra)
                )
                .ForMember(
                    dest => dest.Titulo,
                    opt => opt.MapFrom(src => src.Titulo)
                )
                .ForMember(
                    dest => dest.Prefacio,
                    opt => opt.MapFrom(src => src.Prefacio)
                )
                .ForMember(
                    dest => dest.Autor,
                    opt => opt.MapFrom(src => src.Autor)
                )
                .ForMember(
                    dest => dest.Editora,
                    opt => opt.MapFrom(src => src.Editora)
                )
                .ForMember(
                    dest => dest.DhExtravio,
                    opt => opt.MapFrom(src => src.DhExtravio)
                )
                .ForMember(
                    dest => dest.Extraviado,
                    opt => opt.MapFrom(src => src.Extraviado)
                )
                .ForMember(
                    dest => dest.Emprestado,
                    opt => opt.MapFrom(src => src.Emprestado)
                )
                .ForMember(
                    dest => dest.Ativo,
                    opt => opt.MapFrom(src => src.Ativo)
                );
            #endregion

            #region LivroDto, Livro
            CreateMap<LivroDto, Livro>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.DhCompra,
                    opt => opt.MapFrom(src => src.DhCompra)
                )
                .ForMember(
                    dest => dest.Titulo,
                    opt => opt.MapFrom(src => src.Titulo)
                )
                .ForMember(
                    dest => dest.Prefacio,
                    opt => opt.MapFrom(src => src.Prefacio)
                )
                .ForMember(
                    dest => dest.Autor,
                    opt => opt.MapFrom(src => src.Autor)
                )
                .ForMember(
                    dest => dest.Editora,
                    opt => opt.MapFrom(src => src.Editora)
                )
                .ForMember(
                    dest => dest.DhExtravio,
                    opt => opt.MapFrom(src => src.DhExtravio)
                )
                .ForMember(
                    dest => dest.Extraviado,
                    opt => opt.MapFrom(src => src.Extraviado)
                )
                .ForMember(
                    dest => dest.Emprestado,
                    opt => opt.MapFrom(src => src.Emprestado)
                )
                .ForMember(
                    dest => dest.Ativo,
                    opt => opt.MapFrom(src => src.Ativo)
                );
            #endregion
            #endregion
        }
    }
}