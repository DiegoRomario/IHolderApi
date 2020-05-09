using AutoMapper;
using IHolder.Api.ViewModels;
using IHolder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IHolder.Api.Configurations.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration ()
        {
            CreateMap<TipoInvestimento, Tipo_investimentoViewModel>().ReverseMap();
            CreateMap<DistribuicaoPorTipoInvestimento, Distribuicao_por_tipo_investimentoViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<DistribuicaoPorProduto, Distribuicao_por_produtoViewModel>().ReverseMap();
            CreateMap<Ativo, AtivoViewModel>().ReverseMap();
            CreateMap<DistribuicaoPorAtivo, Distribuicao_por_ativoViewModel>().ReverseMap();
            CreateMap<Aporte, AporteViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioViewModel>()
                .ForMember(dest => dest.Nome, act => act.MapFrom(scr => scr.Nome))
                .ForMember(dest => dest.Id, act => act.MapFrom(scr => scr.Id))
                .ForMember(dest => dest.Email, act => act.MapFrom(scr => scr.Email))
                .ReverseMap();

        }
    }
}
