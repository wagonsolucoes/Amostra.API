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

        public EmprestadoLst Filtrar(int IniciaEm, int QtdLinhas, string IdCliente, Guid IdLivro, string ColunaOrdenar = "Nome", string Direcao = "ASC")
        {
            #region DECLARES
            EmprestadoLst retorno = new EmprestadoLst();
            List<Emprestado> lst = new List<Emprestado>();
            #endregion

            #region IQUERYABLE
            IQueryable<Emprestado> qry = _ctx.Emprestados.Include(x => x.IdLivro).Include(y => y.IdCliente);
            IQueryable<Emprestado> qryTotalizador = _ctx.Emprestados.Include(x => x.IdLivro).Include(y => y.IdCliente);
            #endregion

            #region WHERE
            if (!string.IsNullOrEmpty(IdCliente))
            {
                qry = qry.Where(x => x.IdCliente == IdCliente);
            }
            if (IdLivro != Guid.Empty)
            {
                qry = qry.Where(x => x.IdLivro == IdLivro);
            }
            qryTotalizador = qry; 
            #endregion

            #region PAGINADOR
            qry = qry.Skip(IniciaEm).Take(QtdLinhas);
            #endregion

            #region ORDER BY
            if (Direcao == "" || Direcao == "ASC")
            {
                qry = qry.OrderBy(p => p.Dh);
            }
            else
            {
                qry = qry.OrderByDescending(p => p.Dh);
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
