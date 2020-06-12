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
            ativosEmCarteiraViewModel.ForEach(i => CalcularValorAtualESaldo(i));
            return ativosEmCarteiraViewModel;
        }

        private void CalcularValorAtualESaldo(AtivoEmCarteiraViewModel item)
        {
            decimal cotacao = _consultaCotacaoService.ConsultarCotacao(new ConsultaCotacaoArgs(ticker: item.AtivoTicker, produtoDescricao: item.ProdutoDescricao), CancellationToken.None).Result.Preco;
            item.ValorAtual = (item.Quantidade * cotacao);
            item.Saldo = item.ValorAtual - item.ValorAplicado;
        }
    }
}
