﻿using AutoMapper;
using IHolder.Application.ViewModels;
using IHolder.Domain.DomainObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using IHolder.Domain.Entities;
using System;
using System.Threading;
using IHolder.Data.Services;
using IHolder.Data.Services.Models;

namespace IHolder.Application.Queries
{
    public class AtivoQueries : IAtivoQueries
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<Ativo> _repository;
        private readonly IConsultaCotacaoService _service;

        public AtivoQueries(IMapper mapper, IRepositoryBase<Ativo> repository, IConsultaCotacaoService service)
        {
            _mapper = mapper;
            _repository = repository;
            _service = service;
        }

        public async Task<IEnumerable<AtivoViewModel>> ObterAtivosPorUsuario(Guid usuarioId)
        {
            var ativos = _mapper.Map<IEnumerable<AtivoViewModel>>(await _repository.GetManyBy(where: d => d.UsuarioId == usuarioId, d => d.Produto.TipoInvestimento, d => d.Produto));
            return ativos;
        }

        public async Task<Cotacao> ObterCotacaoPorTicker(ConsultaCotacaoArgs args)
        {
            Cotacao cotacao = await _service.ConsultarCotacao(args, CancellationToken.None);
            return cotacao;
        }
    }
}
