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
            CreateMap<DistribuicaoPorTipoInvestimento, DistribuicaoViewModel>()
                .ForMember(d => d.TipoDistribuicaoId, s => s.MapFrom(s => s.TipoInvestimento.Id))
                .ForMember(d => d.Descricao, s => s.MapFrom(s => s.TipoInvestimento.Informacoes.Descricao))
                .ForMember(d => d.Caracteristicas, s => s.MapFrom(s => s.TipoInvestimento.Informacoes.Caracteristicas))
                .ForMember(d => d.PercentualObjetivo, s => s.MapFrom(s => s.Valores.PercentualObjetivo))
                .ForMember(d => d.PercentualAtual, s => s.MapFrom(s => s.Valores.PercentualAtual))
                .ForMember(d => d.PercentualDiferenca, s => s.MapFrom(s => s.Valores.PercentualDiferenca))
                .ForMember(d => d.ValorAtual, s => s.MapFrom(s => s.Valores.ValorAtual))
                .ForMember(d => d.ValorDiferenca, s => s.MapFrom(s => s.Valores.ValorDiferenca))
                .ForMember(d => d.Orientacao, s => s.MapFrom(s => s.Orientacao));

            CreateMap<DistribuicaoPorAtivo, DistribuicaoViewModel>()
                .ForMember(d => d.TipoDistribuicaoId, s => s.MapFrom(s => s.Ativo.Id))
                .ForMember(d => d.Descricao, s => s.MapFrom(s => s.Ativo.Ticker))
                .ForMember(d => d.Caracteristicas, s => s.MapFrom(s => s.Ativo.Informacoes.Caracteristicas))
                .ForMember(d => d.PercentualObjetivo, s => s.MapFrom(s => s.Valores.PercentualObjetivo))
                .ForMember(d => d.PercentualAtual, s => s.MapFrom(s => s.Valores.PercentualAtual))
                .ForMember(d => d.PercentualDiferenca, s => s.MapFrom(s => s.Valores.PercentualDiferenca))
                .ForMember(d => d.ValorAtual, s => s.MapFrom(s => s.Valores.ValorAtual))
                .ForMember(d => d.ValorDiferenca, s => s.MapFrom(s => s.Valores.ValorDiferenca))
                .ForMember(d => d.Orientacao, s => s.MapFrom(s => s.Orientacao));

            CreateMap<DistribuicaoPorProduto, DistribuicaoViewModel>()
                .ForMember(d => d.TipoDistribuicaoId, s => s.MapFrom(s => s.Produto.Id))
                .ForMember(d => d.Descricao, s => s.MapFrom(s => s.Produto.Informacoes.Descricao))
                .ForMember(d => d.Caracteristicas, s => s.MapFrom(s => s.Produto.Informacoes.Caracteristicas))
                .ForMember(d => d.PercentualObjetivo, s => s.MapFrom(s => s.Valores.PercentualObjetivo))
                .ForMember(d => d.PercentualAtual, s => s.MapFrom(s => s.Valores.PercentualAtual))
                .ForMember(d => d.PercentualDiferenca, s => s.MapFrom(s => s.Valores.PercentualDiferenca))
                .ForMember(d => d.ValorAtual, s => s.MapFrom(s => s.Valores.ValorAtual))
                .ForMember(d => d.ValorDiferenca, s => s.MapFrom(s => s.Valores.ValorDiferenca))
                .ForMember(d => d.Orientacao, s => s.MapFrom(s => s.Orientacao));

            CreateMap<Ativo, AtivoViewModel>()
                .ForMember(d => d.Descricao, s => s.MapFrom(s => s.Informacoes.Descricao))
                .ForMember(d => d.Caracteristicas, s => s.MapFrom(s => s.Informacoes.Caracteristicas))
                .ForMember(d => d.ProdutoDescricao, s => s.MapFrom(s => s.Produto.Informacoes.Descricao))
                .ForMember(d => d.Situacao, s => s.MapFrom(s => s.Situacao));

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(d => d.Descricao, s => s.MapFrom(s => s.Informacoes.Descricao));

            CreateMap<Aporte, AporteViewModel>()
                    .ForMember(d => d.AtivoTicker, s => s.MapFrom(s => s.Ativo.Ticker))
                    .ForMember(d => d.AtivoDescricao, s => s.MapFrom(s => s.Ativo.Informacoes.Descricao))
                    .ForMember(d => d.ProdutoDescricao, s => s.MapFrom(s => s.Ativo.Produto.Informacoes.Descricao));

        }
    }
}
