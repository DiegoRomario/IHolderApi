using AutoMapper;
using IHolder.Business.ViewModels;
using IHolder.Domain.Entities;

namespace IHolder.Business.Mappings
{
    public class DomainToViewModelProfile : Profile 
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Usuario, UsuarioAutenticadoViewModel>();
            CreateMap<DistribuicaoPorTipoInvestimento, DistribuicaoPorTipoInvestimentoViewModel>()
                .ForMember(d => d.DescricaoTipoInvestimento, s => s.MapFrom(s => s.TipoInvestimento.Informacoes.Descricao))
                .ForMember(d => d.PercentualObjetivo, s => s.MapFrom(s => s.Valores.PercentualObjetivo))
                .ForMember(d => d.PercentualAtual, s => s.MapFrom(s => s.Valores.PercentualAtual))
                .ForMember(d => d.PercentualDiferenca, s => s.MapFrom(s => s.Valores.PercentualDiferenca))
                .ForMember(d => d.ValorAtual, s => s.MapFrom(s => s.Valores.ValorAtual))
                .ForMember(d => d.ValorDiferenca, s => s.MapFrom(s => s.Valores.ValorDiferenca));

        }
    }
}
