using AutoMapper;
using IHolder.Application.ViewModels;
using IHolder.Domain.DomainObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using IHolder.Domain.Entities;
using System;

namespace IHolder.Application.Queries
{
    public class AtivoQueries : IAtivoQueries
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<Ativo> _repository;

        public AtivoQueries(IMapper mapper, IRepositoryBase<Ativo> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<AtivoViewModel>> ObterAtivosPorUsuario(Guid usuarioId)
        {
            var ativos = _mapper.Map<IEnumerable<AtivoViewModel>>(await _repository.GetManyBy(where: d => d.UsuarioId == usuarioId, includes: d => d.Produto));
            return ativos;
        }
    }
}
