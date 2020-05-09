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
        }
    }
}
