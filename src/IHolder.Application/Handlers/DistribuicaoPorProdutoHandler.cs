using AutoMapper;
using IHolder.Application.Base;
using IHolder.Application.Commands;
using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using IHolder.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IHolder.Application.Handlers
{
    public class DistribuicaoPorProdutoHandler :
        IRequestHandler<AlterarDistribuicaoPorProdutoCommand, bool>,
        IRequestHandler<RecalcularDistribuicaoPorProdutoCommand, bool>,
        IRequestHandler<DividirDistribuicaoPorProdutoCommand, bool>
    {
        private const int PERCENTUAL_MAXIMO = 100;
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<DistribuicaoPorProduto> _distribuicaoRepositorio;
        private readonly IAtivoEmCarteiraRepository _AtivoEmCarteiraRepository;
        private readonly IHandlerBase _handlerBase;

        public DistribuicaoPorProdutoHandler(IMapper mapper,
            IRepositoryBase<DistribuicaoPorProduto> distribuicaoPorProdutoRepository,
            IAtivoEmCarteiraRepository AtivoEmCarteiraRepository,
            IHandlerBase handlerBase)
        {
            _mapper = mapper;
            _distribuicaoRepositorio = distribuicaoPorProdutoRepository;
            _AtivoEmCarteiraRepository = AtivoEmCarteiraRepository;
            _handlerBase = handlerBase;
        }

        public async Task<bool> Handle(AlterarDistribuicaoPorProdutoCommand request, CancellationToken cancellationToken)
        {
            if (ProdutoJaCadastrado(request.TipoDistribuicaoId, request.Id))
            {
                _handlerBase.PublishNotification("O novo produto selecionado já possuí um percentual de distribuição definido");
                return false;
            }

            if (PercentualObjetivoAcumuladoUltrapasa100PorCento(request.TipoDistribuicaoId, request.PercentualObjetivo))
            {
                _handlerBase.PublishNotification("O Percentual objetivo informado somado ao percentual objetivo acumulado ultrapassa 100%");
                return false;
            }

            return await Update(_mapper.Map<DistribuicaoPorProduto>(request)); ;
        }

        public async Task<bool> Handle(RecalcularDistribuicaoPorProdutoCommand request, CancellationToken cancellationToken)
        {
            List<DistribuicaoPorProduto> distribuicoes = _distribuicaoRepositorio.GetManyBy(d => d.UsuarioId == request.UsuarioId).Result.ToList();
            var valor_total = _AtivoEmCarteiraRepository.ObterTotalAplicado(request.UsuarioId).Result;

            foreach (var item in distribuicoes)
            {
                var valorTotalPorProduto = _AtivoEmCarteiraRepository.ObterTotalAplicadoPorProduto(item.ProdutoId, request.UsuarioId).Result;
                item.Valores.OrquestrarAtualizacaoDeValoresEPercentuais(valorTotalPorProduto, valor_total);
                item.AtualizarOrientacao(valorTotalPorProduto, valor_total);
                await Update(item);
            }

            return true;
        }


        private async Task<bool> Update(DistribuicaoPorProduto entity)
        {
            _distribuicaoRepositorio.Update(entity);
            return await _distribuicaoRepositorio.UnitOfWork.Commit();
        }

        private bool PercentualObjetivoAcumuladoUltrapasa100PorCento(Guid ProdutoId, decimal percentualObjetivo, Nullable<Guid> distribuicaoId = null)
        {
            decimal percentualAcumulado = _distribuicaoRepositorio.GetManyBy(d => d.ProdutoId != ProdutoId && d.Id != distribuicaoId).Result.Sum(d => d.Valores.PercentualObjetivo);
            return percentualAcumulado + percentualObjetivo > 100;
        }

        private bool ProdutoJaCadastrado(Guid ProdutoId, Nullable<Guid> distribuicaoId = null)
        {
            return _distribuicaoRepositorio.GetBy(d => d.ProdutoId == ProdutoId && d.Id != distribuicaoId).Result != null;
        }

        public async Task<bool> Handle(DividirDistribuicaoPorProdutoCommand request, CancellationToken cancellationToken)
        {
            List<DistribuicaoPorProduto> distribuicoes = ObterDistribuicoesProdutosCadastrados(request.UsuarioId);

            if (request.SomenteItensEmCarteira)
                await AlterarDistribuicoesProdutosEmCarteira(request, distribuicoes);
            else
                await AlterarDistribuicoesProdutosCadastrados(distribuicoes);

            return await _distribuicaoRepositorio.UnitOfWork.Commit();
        }

        private async Task AlterarDistribuicoesProdutosCadastrados(List<DistribuicaoPorProduto> distribuicoes)
        {
            int percentualDivisao = PERCENTUAL_MAXIMO / distribuicoes.Count();

            foreach (var distribuicao in distribuicoes)
            {
                distribuicao.Valores.AtualizarPercentualObjetivo(percentualDivisao);
                await Update(distribuicao);
            }
        }
        private async Task AlterarDistribuicoesProdutosEmCarteira(DividirDistribuicaoPorProdutoCommand request, List<DistribuicaoPorProduto> distribuicoes)
        {
            List<DistribuicaoPorProduto> distribuicoesCarteira = ObterDistribuicoesProdutosEmCarteira(request.UsuarioId);
            int percentualDivisao = PERCENTUAL_MAXIMO / distribuicoesCarteira.Count();

            foreach (var distribuicao in distribuicoes)
            {
                if (distribuicoesCarteira.Where(x => x.ProdutoId == distribuicao.ProdutoId).Any())
                    distribuicao.Valores.AtualizarPercentualObjetivo(percentualDivisao);
                else
                    distribuicao.Valores.AtualizarPercentualObjetivo(0);
                await Update(distribuicao);
            }
        }

        private List<DistribuicaoPorProduto> ObterDistribuicoesProdutosEmCarteira(Guid usuarioId)
        {
            IEnumerable<Guid> ProdutosEmCarteira = _AtivoEmCarteiraRepository.GetManyBy(where: a => a.UsuarioId == usuarioId,a => a.Ativo, a => a.Ativo.Produto).Result.Distinct(new ProdutoAtivoEmCarteiraComparer()).Select(a => a.Ativo.ProdutoId);
            List<DistribuicaoPorProduto> distribuicoes =
            _distribuicaoRepositorio.GetManyBy(d => d.UsuarioId == usuarioId && ProdutosEmCarteira.Contains(d.ProdutoId)).Result.ToList();

            return distribuicoes;
        }

        private List<DistribuicaoPorProduto> ObterDistribuicoesProdutosCadastrados(Guid usuarioId)
        {
            return _distribuicaoRepositorio.GetManyBy(d => d.UsuarioId == usuarioId).Result.ToList();
        }

    }
}