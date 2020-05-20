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
        IRequestHandler<CadastrarDistribuicaoPorProdutoCommand, bool>,
        IRequestHandler<AlterarDistribuicaoPorProdutoCommand, bool>,
        IRequestHandler<RecalcularDistribuicaoPorProdutoCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<DistribuicaoPorProduto> _distribuicaoRepositorio;
        private readonly IAporteRepository _aporteRepository;
        private readonly IHandlerBase _handlerBase;

        public DistribuicaoPorProdutoHandler(IMapper mapper,
            IRepositoryBase<DistribuicaoPorProduto> distribuicaoPorProdutoRepository,
            IAporteRepository aporteRepository,
            IHandlerBase handlerBase)
        {
            _mapper = mapper;
            _distribuicaoRepositorio = distribuicaoPorProdutoRepository;
            _aporteRepository = aporteRepository;
            _handlerBase = handlerBase;
        }

        public async Task<bool> Handle(CadastrarDistribuicaoPorProdutoCommand request, CancellationToken cancellationToken)
        {
            if (!_handlerBase.ValidateCommand(request))
                return false;

            if (PercentualObjetivoAcumuladoUltrapasa100PorCento(request.ProdutoId, request.PercentualObjetivo))
            {
                _handlerBase.PublishNotification("O Percentual objetivo informado somado ao percentual objetivo acumulado ultrapassa 100%");
                return false;
            }

            if (ProdutoJaCadastrado(request.ProdutoId))
            {
                _handlerBase.PublishNotification("Este tipo de investimento já possuí um percentual de distribuição definido");
            }

            _distribuicaoRepositorio.Insert(_mapper.Map<DistribuicaoPorProduto>(request));
            return await _distribuicaoRepositorio.UnitOfWork.Commit();
        }


        public async Task<bool> Handle(AlterarDistribuicaoPorProdutoCommand request, CancellationToken cancellationToken)
        {
            if (!_handlerBase.ValidateCommand(request))
                return false;

            if (ProdutoJaCadastrado(request.ProdutoId, request.Id))
            {
                _handlerBase.PublishNotification("O novo produto selecionado já possuí um percentual de distribuição definido");
                return false;
            }

            if (PercentualObjetivoAcumuladoUltrapasa100PorCento(request.ProdutoId, request.PercentualObjetivo))
            {
                _handlerBase.PublishNotification("O Percentual objetivo informado somado ao percentual objetivo acumulado ultrapassa 100%");
                return false;
            }

            return await Update(_mapper.Map<DistribuicaoPorProduto>(request)); ;
        }

        public async Task<bool> Handle(RecalcularDistribuicaoPorProdutoCommand request, CancellationToken cancellationToken)
        {
            List<DistribuicaoPorProduto> distribuicoes = _distribuicaoRepositorio.GetManyBy(d => d.UsuarioId == request.UsuarioId).Result.ToList();
            var valor_total = _aporteRepository.ObterTotalAplicado(request.UsuarioId).Result;

            foreach (var item in distribuicoes)
            {
                var valorTotalPorProduto = _aporteRepository.ObterTotalAplicadoPorProduto(item.ProdutoId, request.UsuarioId).Result;
                item.Valores.OrquestrarAtualizacaoDeValoresEPercentuais(valorTotalPorProduto, valor_total);
                item.AtualizarOrientacao();
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

    }
}