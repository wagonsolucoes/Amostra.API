using Amostra.API.Data.Amostra;
using Amostra.API.Models.Amostra;
using Amostra.API.ViewModel.Amostra;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Amostra.API.Repository
{
    public class EmprestadoRepository : GenericRepository<Emprestado>, IEmprestadoRepository
    {
        private readonly AmostraContext _ctx;
        private readonly IMapper _mapper;

        public EmprestadoRepository(AmostraContext ctx, IMapper mapper) : base(ctx)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public EmprestadoLst Filtrar(int IniciaEm, int QtdLinhas, string IdCliente, Guid? IdLivro, string ColunaOrdenar = "Cliente", string Direcao = "ASC")
        {
            #region DECLARES
            EmprestadoLst retorno = new EmprestadoLst();
            List<Emprestado> lst = new List<Emprestado>();
            #endregion

            #region IQUERYABLE
            IQueryable<Emprestado> qry = _ctx.Emprestados.Include(y => y.IdClienteNavigation).Include(x => x.IdLivroNavigation);
            IQueryable<Emprestado> qryTotalizador = _ctx.Emprestados;
            #endregion

            #region WHERE
            if (!string.IsNullOrEmpty(IdCliente))
            {
                qry = qry.Where(x => x.IdCliente == IdCliente);
                qryTotalizador = qryTotalizador.Where(x => x.IdCliente == IdCliente);
            }
            if (IdLivro != Guid.Empty)
            {
                qry = qry.Where(x => x.IdLivro == IdLivro);
                qryTotalizador = qryTotalizador.Where(x => x.IdLivro == IdLivro);
            }
            #endregion

            #region PAGINADOR
            qry = qry.Skip(IniciaEm).Take(QtdLinhas);
            #endregion

            #region ORDER BY
            if (Direcao == "Cliente" || Direcao == "ASC")
            {
                qry = qry.OrderBy(p => p.IdClienteNavigation.Nome);
            }
            else
            {
                qry = qry.OrderByDescending(p => p.IdClienteNavigation.Nome);
            }
            if (Direcao == "Livro" || Direcao == "ASC")
            {
                qry = qry.OrderBy(p => p.IdLivroNavigation.Titulo);
            }
            else
            {
                qry = qry.OrderByDescending(p => p.IdLivroNavigation.Titulo);
            }
            if (Direcao == "Dh" || Direcao == "ASC")
            {
                qry = qry.OrderBy(p => p.Dh);
            }
            else
            {
                qry = qry.OrderByDescending(p => p.Dh);
            }
            if (Direcao == "DhDevolucao" || Direcao == "ASC")
            {
                qry = qry.OrderBy(p => p.DhDevolucao);
            }
            else
            {
                qry = qry.OrderByDescending(p => p.DhDevolucao);
            }
            if (Direcao == "Ativo" || Direcao == "ASC")
            {
                qry = qry.OrderBy(p => p.Ativo);
            }
            else
            {
                qry = qry.OrderByDescending(p => p.Ativo);
            }
            #endregion

            #region RETORNO
            retorno.ttRows = qryTotalizador.ToList().Count();
            lst = qry.ToList();
            if (lst != null && lst.Count > 0)
            {
                retorno.lst = _mapper.Map<List<EmprestadoDto>>(lst);
            }
            #endregion

            return retorno;
        }
    }
}
