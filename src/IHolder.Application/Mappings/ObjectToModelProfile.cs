using AutoMapper;
using IHolder.Application.Services.Models;

namespace IHolder.Application.Mappings
{
    public class ObjectToModelProfile : Profile
    {
        public ObjectToModelProfile()
        {
            CreateMap<CotacaoContract, Cotacao>().ReverseMap();
        }
    }
}
