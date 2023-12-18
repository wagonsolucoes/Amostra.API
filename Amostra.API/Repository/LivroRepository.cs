using Amostra.API.Data.Amostra;
using Amostra.API.Models.Amostra;
using Amostra.API.ViewModel;
using Amostra.API.ViewModel.Amostra;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Amostra.API.Repository
{
    public class LivroRepository : GenericRepository<Livro>, ILivroRepository
    {
        private readonly AmostraContext _ctx;
        private readonly IMapper _mapper;

        public LivroRepository(AmostraContext ctx, IMapper mapper) : base(ctx)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<int> FiltrarCount(string TermoBusca = "")
        {
            #region IQUERYABLE
            IQueryable<Livro> qryTotalizador = _ctx.Livros;
            #endregion

            #region WHERE
            if (!string.IsNullOrEmpty(TermoBusca))
            {
                qryTotalizador = qryTotalizador.Where(x => x.Titulo.Contains(TermoBusca) || x.Prefacio.Contains(TermoBusca) || x.Autor.Contains(TermoBusca) || x.Editora.Contains(TermoBusca));
            }
            #endregion

            return qryTotalizador.ToList().Count();
        }

        public async Task<List<Livro>> FiltrarLista(int IniciaEm, int QtdLinhas, string TermoBusca = "", string ColunaOrdenar = "Titulo", string Direcao = "ASC")
        {
            #region IQUERYABLE
            IQueryable<Livro> qry = _ctx.Livros;
            #endregion

            #region WHERE
            if (!string.IsNullOrEmpty(TermoBusca))
            {
                qry = qry.Where(x => x.Titulo.Contains(TermoBusca) || x.Prefacio.Contains(TermoBusca) || x.Autor.Contains(TermoBusca) || x.Editora.Contains(TermoBusca));
            }
            #endregion

            #region PAGINADOR
            qry = qry.Skip(IniciaEm).Take(QtdLinhas);
            #endregion

            #region ORDER BY
            if (ColunaOrdenar == "Titulo")
            {
                if (Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Titulo);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Titulo);
                }
            }
            if (ColunaOrdenar == "Autor")
            {
                if (Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Autor);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Autor);
                }
            }
            if (ColunaOrdenar == "Editora")
            {
                if (Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Editora);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Editora);
                }
            }
            if (ColunaOrdenar == "Ativo")
            {
                if (Direcao == "ASC")
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

        public async Task<List<SelectDto>> GetDDL()
        {
            List<SelectDto> sel = new List<SelectDto>();
            sel = (from o in _ctx.Livros orderby o.Titulo select new SelectDto { id = o.Id, txt = o.Titulo }).ToList();
            return sel;
        }
    }
}
