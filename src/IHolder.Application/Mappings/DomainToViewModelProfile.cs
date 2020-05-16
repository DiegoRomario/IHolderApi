using AutoMapper;
using IHolder.Application.ViewModels;
using IHolder.Domain.Entities;

namespace IHolder.Application.Mappings
{
    public class DomainToViewModelProfile : Profile 
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Usuario, UsuarioAutenticadoViewModel>();
            CreateMap<DistribuicaoPorTipoInvestimento, DistribuicaoPorTipoInvestimentoViewModel>()
                .ForMember(d => d.DescricaoTipoInvestimento, s => s.MapFrom(s => s.TipoInvestimento.Informacoes.Descricao))
                .ForMember(d => d.CaracteristicasTipoInvestimento, s => s.MapFrom(s => s.TipoInvestimento.Informacoes.Caracteristicas))
                .ForMember(d => d.PercentualObjetivo, s => s.MapFrom(s => s.Valores.PercentualObjetivo))
                .ForMember(d => d.PercentualAtual, s => s.MapFrom(s => s.Valores.PercentualAtual))
                .ForMember(d => d.PercentualDiferenca, s => s.MapFrom(s => s.Valores.PercentualDiferenca))
                .ForMember(d => d.ValorAtual, s => s.MapFrom(s => s.Valores.ValorAtual))
                .ForMember(d => d.ValorDiferenca, s => s.MapFrom(s => s.Valores.ValorDiferenca))
                .ForMember(d => d.Orientacao, s => s.MapFrom(s => s.Orientacao));

            CreateMap<DistribuicaoPorAtivo, DistribuicaoPorAtivoViewModel>()
                .ForMember(d => d.DescricaoAtivo, s => s.MapFrom(s => s.Ativo.Informacoes.Descricao))
                .ForMember(d => d.CaracteristicasAtivo, s => s.MapFrom(s => s.Ativo.Informacoes.Caracteristicas))
                .ForMember(d => d.PercentualObjetivo, s => s.MapFrom(s => s.Valores.PercentualObjetivo))
                .ForMember(d => d.PercentualAtual, s => s.MapFrom(s => s.Valores.PercentualAtual))
                .ForMember(d => d.PercentualDiferenca, s => s.MapFrom(s => s.Valores.PercentualDiferenca))
                .ForMember(d => d.ValorAtual, s => s.MapFrom(s => s.Valores.ValorAtual))
                .ForMember(d => d.ValorDiferenca, s => s.MapFrom(s => s.Valores.ValorDiferenca))
                .ForMember(d => d.Orientacao, s => s.MapFrom(s => s.Orientacao));

        }
    }
}
