using AutoMapper;
using IHolder.Application.ViewModels;
using IHolder.Data.Services;
using IHolder.Data.Services.Models;
using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IHolder.Application.Queries
{
    public class AtivoEmCarteiraQueries : IAtivoEmCarteiraQueries
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<AtivoEmCarteira> _repository;
        private readonly IConsultaCotacaoService _consultaCotacaoService;

        public AtivoEmCarteiraQueries(IMapper mapper, IRepositoryBase<AtivoEmCarteira> repository, IConsultaCotacaoService consultaCotacaoService)
        {
            _mapper = mapper;
            _repository = repository;
            _consultaCotacaoService = consultaCotacaoService;
        }

        public async Task<IEnumerable<AtivoEmCarteiraViewModel>> ObterAtivosEmCarteiraPorUsuario(Guid UsuarioId)
        {
            IEnumerable<AtivoEmCarteira> ativosEmCarteira = await _repository.GetManyBy(where: a => a.UsuarioId == UsuarioId, a => a.Ativo, a => a.Ativo.Produto);
            List<AtivoEmCarteiraViewModel> ativosEmCarteiraViewModel = _mapper.Map<IEnumerable<AtivoEmCarteiraViewModel>>(ativosEmCarteira).ToList();
            ativosEmCarteiraViewModel.ForEach(async i => await ObterDadosDaCotacao(i));
            return ativosEmCarteiraViewModel;
        }

        private Task ObterDadosDaCotacao(AtivoEmCarteiraViewModel item)
        {
            Cotacao cotacao = _consultaCotacaoService.ConsultarCotacao(new ConsultaCotacaoArgs(ticker: item.AtivoTicker, produtoDescricao: item.ProdutoDescricao), CancellationToken.None).Result;
            decimal ultimaCotacao = cotacao.Preco > 0 ? cotacao.Preco : item.AtivoCotacao;
            
            item.UltimaCotacao = ultimaCotacao;
            item.UltimaVariacao = cotacao.Variacao;
            item.UltimaVariacaoPercentual = cotacao.VariacaoPercentual;
            item.ValorAtual = (item.Quantidade * ultimaCotacao);
            item.Saldo = item.ValorAtual - item.ValorAplicado;
            item.Percentual = 100 - (100 * ((item.ValorAplicado / item.ValorAtual)));

            return Task.CompletedTask;
        }
    }
}
