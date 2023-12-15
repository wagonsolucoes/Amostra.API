using Amostra.API.Data.Amostra;
using Amostra.API.Models.Amostra;
using Amostra.API.ViewModel.Amostra;
using AutoMapper;
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

        public ClienteLst Filtrar(int IniciaEm, int QtdLinhas, string TermoBusca = "", string ColunaOrdenar = "Nome", string Direcao = "ASC")
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
            if (ColunaOrdenar == "Nome" || string.IsNullOrEmpty(ColunaOrdenar))
            {
                if (Direcao == "" || Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.CpfCnpj);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.CpfCnpj);
                }
            }
            if (ColunaOrdenar == "Numero" || string.IsNullOrEmpty(ColunaOrdenar))
            {
                if (Direcao == "" || Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Numero);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Numero);
                }
            }
            if (ColunaOrdenar == "Bairro" || string.IsNullOrEmpty(ColunaOrdenar))
            {
                if (Direcao == "" || Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Bairro);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Bairro);
                }
            }
            if (ColunaOrdenar == "Bairro" || string.IsNullOrEmpty(ColunaOrdenar))
            {
                if (Direcao == "" || Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Bairro);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Bairro);
                }
            }
            if (ColunaOrdenar == "Cep" || string.IsNullOrEmpty(ColunaOrdenar))
            {
                if (Direcao == "" || Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Cep);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Cep);
                }
            }
            if (ColunaOrdenar == "Email" || string.IsNullOrEmpty(ColunaOrdenar))
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
    }
}
