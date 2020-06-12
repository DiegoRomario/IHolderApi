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
    public class AporteQueries : IAporteQueries
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<Aporte> _repository;
        private readonly IConsultaCotacaoService _consultaCotacaoService;

        public AporteQueries(IMapper mapper, IRepositoryBase<Aporte> repository, IConsultaCotacaoService consultaCotacaoService)
        {
            _mapper = mapper;
            _repository = repository;
            _consultaCotacaoService = consultaCotacaoService;
        }

        public async Task<IEnumerable<AporteViewModel>> ObterAportesPorUsuario(Guid UsuarioId)
        {
            IEnumerable<Aporte> aportes = await _repository.GetManyBy(where: a => a.UsuarioId == UsuarioId, a => a.Ativo, a => a.Ativo.Produto);
            List<AporteViewModel> aportesViewModel = _mapper.Map<IEnumerable<AporteViewModel>>(aportes).ToList();
            aportesViewModel.ForEach(i => CalcularValorAtualESaldo(i));
            return aportesViewModel;
        }

        private void CalcularValorAtualESaldo(AporteViewModel item)
        {
            decimal cotacao = _consultaCotacaoService.ConsultarCotacao(new ConsultaCotacaoArgs(ticker: item.AtivoTicker, produtoDescricao: item.ProdutoDescricao), CancellationToken.None).Result.Preco;
            item.ValorAtual = (item.Quantidade * cotacao);
            item.Saldo = item.ValorAtual - item.ValorAplicado;
        }
    }
}
