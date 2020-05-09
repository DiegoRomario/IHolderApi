using IHolder.Business.ViewModels;
using IHolder.Domain.DomainObjects;
using System.Threading.Tasks;
using IHolder.Domain.Entities;
using AutoMapper;

namespace IHolder.Business.Queries
{
    public class UsuarioQueries : IUsuarioQueries
    {
        private readonly IRepositoryBase<Usuario> _repositoryBase;
        private readonly IMapper _mapper;

        public UsuarioQueries(IRepositoryBase<Usuario> repositoryBase, IMapper mapper)
        {
            this._repositoryBase = repositoryBase;
            _mapper = mapper;
        }

        public async Task<UsuarioAutenticadoViewModel> AutenticarUsuario(UsuarioLoginArgs login)
        {
            Usuario usuario = await _repositoryBase.GetBy(u => u.Email == login.Email && u.Senha == login.Senha);
            var UsuarioAutenticadoViewModel = _mapper.Map<UsuarioAutenticadoViewModel>(usuario);
            return UsuarioAutenticadoViewModel;
        }
    }
}
