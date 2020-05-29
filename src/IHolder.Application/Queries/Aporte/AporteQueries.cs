using AutoMapper;
using IHolder.Application.ViewModels;
using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IHolder.Application.Queries
{
    public class AporteQueries : IAporteQueries
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<Aporte> _repository;

        public AporteQueries(IMapper mapper, IRepositoryBase<Aporte> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<AporteViewModel>> ObterAportesPorUsuario(Guid UsuarioId)
        {
            IEnumerable<Aporte> aportes = await _repository.GetManyBy(where: a => a.UsuarioId == UsuarioId, a => a.Ativo, a => a.Ativo.Produto);
            return _mapper.Map<IEnumerable<AporteViewModel>>(aportes);
        }
    }
}
