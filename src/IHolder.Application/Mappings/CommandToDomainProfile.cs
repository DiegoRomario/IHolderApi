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

            CreateMap<CadastrarDistribuicaoPorAtivoCommand, DistribuicaoPorAtivo>()
            .ConstructUsing(p => new DistribuicaoPorAtivo(p.AtivoId, p.UsuarioId, new Valores(p.PercentualObjetivo)));

            CreateMap<AlterarDistribuicaoPorAtivoCommand, DistribuicaoPorAtivo>()
            .ConstructUsing(p => new DistribuicaoPorAtivo(p.AtivoId, p.UsuarioId, new Valores(p.PercentualObjetivo)));

            CreateMap<CadastrarDistribuicaoPorProdutoCommand, DistribuicaoPorProduto>()
             .ConstructUsing(p => new DistribuicaoPorProduto(p.ProdutoId, p.UsuarioId, new Valores(p.PercentualObjetivo)));

            CreateMap<AlterarDistribuicaoPorProdutoCommand, DistribuicaoPorProduto>()
            .ConstructUsing(p => new DistribuicaoPorProduto(p.ProdutoId, p.UsuarioId, new Valores(p.PercentualObjetivo)));

            CreateMap<CadastrarAtivoCommand, Ativo>()
                .ConstructUsing(a => new Ativo(a.ProdutoId,
                new Informacoes(a.Descricao, a.Caracteristicas),
                a.Ticker, a.Cotacao, a.UsuarioId));

            CreateMap<AlterarAtivoCommand, Ativo>()
                .ForPath(d => d.Informacoes.Descricao, o => o.MapFrom(s => s.Descricao))
             .ForPath(d => d.Informacoes.Caracteristicas, o => o.MapFrom(s => s.Caracteristicas));
            //CreateMap<AlterarAtivoCommand, Ativo>()
            //    .ConstructUsing(a => new Ativo(a.ProdutoId,
            //    new Informacoes(a.Descricao, a.Caracteristicas),
            //    a.Ticker, a.Cotacao, a.UsuarioId));

        }
    }
}
