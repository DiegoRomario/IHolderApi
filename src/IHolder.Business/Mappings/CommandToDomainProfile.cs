using AutoMapper;
using IHolder.Business.Commands;
using IHolder.Domain.Entities;

namespace IHolder.Business.Mappings
{
    public class CommandToDomainProfile : Profile
    {
        public CommandToDomainProfile()
        {
            CreateMap<CadastrarUsuarioCommand, Usuario>();
            CreateMap<CadastrarDistribuicaoPorTipoInvestimentoCommand, DistribuicaoPorTipoInvestimento>();
        }
    }
}
