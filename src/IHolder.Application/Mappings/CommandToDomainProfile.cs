using AutoMapper;
using IHolder.Application.Commands;
using IHolder.Domain.Entities;
using IHolder.Domain.ValueObjects;

namespace IHolder.Application.Mappings
{
    public class CommandToDomainProfile : Profile
    {
        public CommandToDomainProfile()
        {
            CreateMap<CadastrarUsuarioCommand, Usuario>();

            CreateMap<CadastrarDistribuicaoPorTipoInvestimentoCommand, DistribuicaoPorTipoInvestimento>()
            .ConstructUsing(p => new DistribuicaoPorTipoInvestimento(p.TipoInvestimentoId, p.UsuarioId, new Valores(p.PercentualObjetivo)));

            CreateMap<AlterarDistribuicaoPorTipoInvestimentoCommand, DistribuicaoPorTipoInvestimento>()
            .ConstructUsing(p => new DistribuicaoPorTipoInvestimento(p.TipoInvestimentoId, p.UsuarioId, new Valores(p.PercentualObjetivo)));


        }
    }
}
