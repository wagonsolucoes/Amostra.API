using Amostra.API.Data.Amostra;
using Amostra.API.Models.Amostra;
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

        public LivroLst Filtrar(int IniciaEm, int QtdLinhas, string TermoBusca = "", string ColunaOrdenar = "Nome", string Direcao = "ASC")
        {
            #region DECLARES
            LivroLst retorno = new LivroLst();
            List<Livro> lst = new List<Livro>();
            #endregion

            #region IQUERYABLE
            IQueryable<Livro> qry = _ctx.Livros;
            IQueryable<Livro> qryTotalizador = _ctx.Livros;
            #endregion

            #region WHERE
            if (!string.IsNullOrEmpty(TermoBusca))
            {
                qry = qry.Where(x => x.Titulo.Contains(TermoBusca) || x.Prefacio.Contains(TermoBusca) || x.Autor.Contains(TermoBusca) || x.Editora.Contains(TermoBusca));
            }
            qryTotalizador = qry; 
            #endregion

            #region PAGINADOR
            qry = qry.Skip(IniciaEm).Take(QtdLinhas);
            #endregion

            #region ORDER BY
            if (ColunaOrdenar == "DhCompra" || string.IsNullOrEmpty(ColunaOrdenar))
            {
                if (Direcao == "" || Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.DhCompra);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.DhCompra);
                }
            }
            if (ColunaOrdenar == "Titulo" || string.IsNullOrEmpty(ColunaOrdenar))
            {
                if (Direcao == "" || Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Titulo);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Titulo);
                }
            }
            if (ColunaOrdenar == "Prefacio" || string.IsNullOrEmpty(ColunaOrdenar))
            {
                if (Direcao == "" || Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Prefacio);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Prefacio);
                }
            }
            if (ColunaOrdenar == "Autor" || string.IsNullOrEmpty(ColunaOrdenar))
            {
                if (Direcao == "" || Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Autor);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Autor);
                }
            }
            if (ColunaOrdenar == "Editora" || string.IsNullOrEmpty(ColunaOrdenar))
            {
                if (Direcao == "" || Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Editora);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Editora);
                }
            }
            if (ColunaOrdenar == "DhExtravio" || string.IsNullOrEmpty(ColunaOrdenar))
            {
                if (Direcao == "" || Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.DhExtravio);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.DhExtravio);
                }
            }
            if (ColunaOrdenar == "Extraviado" || string.IsNullOrEmpty(ColunaOrdenar))
            {
                if (Direcao == "" || Direcao == "ASC")
                {
                    qry = qry.OrderBy(p => p.Extraviado);
                }
                else
                {
                    qry = qry.OrderByDescending(p => p.Extraviado);
                }
            }
            if (ColunaOrdenar == "Ativo" || string.IsNullOrEmpty(ColunaOrdenar))
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
                retorno.lst = _mapper.Map<List<LivroDto>>(lst);
            }
            #endregion

            return retorno;
        }
    }
}
