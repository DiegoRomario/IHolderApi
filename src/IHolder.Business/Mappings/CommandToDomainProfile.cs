using AutoMapper;
using IHolder.Business.Commands;
using IHolder.Domain.Entities;
using IHolder.Domain.ValueObjects;

namespace IHolder.Business.Mappings
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
