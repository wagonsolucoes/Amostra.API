using Amostra.API.Data.Amostra;
using Amostra.API.Models.Amostra;
using Amostra.API.ViewModel;
using Amostra.API.ViewModel.Amostra;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Amostra.API.Repository
{
    public class ClientesRepository : GenericRepository<Cliente>, IClienteRepository
    {
        private readonly AmostraContext _ctx;
        private readonly IMapper _mapper;

        public ClientesRepository(AmostraContext ctx, IMapper mapper) : base(ctx)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<ClienteLst?> Filtrar(int IniciaEm, int QtdLinhas, string TermoBusca = "", string ColunaOrdenar = "Nome", string Direcao = "ASC")
        {
            #region DECLARES
            ClienteLst retorno = new ClienteLst();
            List<Cliente> lst = new List<Cliente>();
            #endregion

            #region IQUERYABLE
            IQueryable<Cliente> qry = _ctx.Clientes;
            IQueryable<Cliente> qryTotalizador = _ctx.Clientes;
            #endregion

            #region WHERE
            if (!string.IsNullOrEmpty(TermoBusca))
            {
                qry = qry.Where(x => x.CpfCnpj.Contains(TermoBusca) || x.Nome.Contains(TermoBusca));
            }
            qryTotalizador = qry; 
            #endregion

            #region PAGINADOR
            qry = qry.Skip(IniciaEm).Take(QtdLinhas);
            #endregion

            #region ORDER BY
            if (ColunaOrdenar == "Documento")
            {
                if (Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.CpfCnpj);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.CpfCnpj);
                }
            }
            if (ColunaOrdenar == "Nome")
            {
                if (Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Nome);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Nome);
                }
            }
            if (ColunaOrdenar == "Bairro")
            {
                if (Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Bairro);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Bairro);
                }
            }
            if (ColunaOrdenar == "Municipio")
            {
                if (Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Localidade);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Localidade);
                }
            }
            if (ColunaOrdenar == "Uf")
            {
                if (Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Uf);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Uf);
                }
            }
            if (ColunaOrdenar == "Email")
            {
                if (Direcao == "" || Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Email);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Email);
                }
            }
            if (ColunaOrdenar == "Telefone")
            {
                if (Direcao == "" || Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Telefone);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Telefone);
                }
            }
            if (ColunaOrdenar == "Ativo")
            {
                if (Direcao == "" || Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Ativo);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Ativo);
                }
            }
            #endregion

            #region RETORNO
            retorno.ttRows = qryTotalizador.ToList().Count();
            lst = qry.ToList();
            if (lst != null && lst.Count > 0)
            {
                retorno.lst = _mapper.Map<List<ClienteDto>>(lst);
            }
            #endregion

            return retorno;
        }

        public async Task<int> FiltrarCount(string TermoBusca = "")
        {
            #region IQUERYABLE
            IQueryable<Cliente> qry = _ctx.Clientes;
            IQueryable<Cliente> qryTotalizador = _ctx.Clientes;
            #endregion

            #region WHERE
            if (!string.IsNullOrEmpty(TermoBusca))
            {
                qryTotalizador = qryTotalizador.Where(x => x.CpfCnpj.Contains(TermoBusca) || x.Nome.Contains(TermoBusca));
            }
            #endregion

            return qryTotalizador.ToList().Count();
        }

        public async Task<List<Cliente>> FiltrarLista(int IniciaEm, int QtdLinhas, string TermoBusca = "", string ColunaOrdenar = "Nome", string Direcao = "ASC")
        {
            #region DECLARES
            List<Cliente> lst = new List<Cliente>();
            #endregion

            #region IQUERYABLE
            IQueryable<Cliente> qry = _ctx.Clientes;
            IQueryable<Cliente> qryTotalizador = _ctx.Clientes;
            #endregion

            #region WHERE
            if (!string.IsNullOrEmpty(TermoBusca))
            {
                qry = qry.Where(x => x.CpfCnpj.Contains(TermoBusca) || x.Nome.Contains(TermoBusca));
            }
            #endregion

            #region PAGINADOR
            qry = qry.Skip(IniciaEm).Take(QtdLinhas);
            #endregion

            #region ORDER BY
            if (ColunaOrdenar == "Documento")
            {
                if (Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.CpfCnpj);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.CpfCnpj);
                }
            }
            if (ColunaOrdenar == "Nome")
            {
                if (Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Nome);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Nome);
                }
            }
            if (ColunaOrdenar == "Bairro")
            {
                if (Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Bairro);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Bairro);
                }
            }
            if (ColunaOrdenar == "Municipio")
            {
                if (Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Localidade);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Localidade);
                }
            }
            if (ColunaOrdenar == "Uf")
            {
                if (Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Uf);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Uf);
                }
            }
            if (ColunaOrdenar == "Email")
            {
                if (Direcao == "" || Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Email);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Email);
                }
            }
            if (ColunaOrdenar == "Telefone")
            {
                if (Direcao == "" || Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Telefone);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Telefone);
                }
            }
            if (ColunaOrdenar == "Ativo")
            {
                if (Direcao == "" || Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Ativo);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Ativo);
                }
            }
            #endregion

            return qry.ToList();
        }

        public async Task<List<SelectDto>> GetDdlCliente()
        {
            List<SelectDto> sel = new List<SelectDto>();
            sel = (from o in _ctx.Clientes orderby o.Nome select new SelectDto { val = o.CpfCnpj, txt = o.Nome }).ToList();
            return sel;
        }
    }
}
