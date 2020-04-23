using IHolder.Business.Entities;
using IHolder.Business.Entities.Validations;
using IHolder.Business.Interfaces.Notifications;
using IHolder.Business.Interfaces.Services;
using IHolder.Business.Repositories.Base;
using IHolder.Business.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IHolder.Business.Services
{
    public class UsuarioService : ServiceBase, IUsuarioService
    {
        private readonly IRepositoryBase<Usuario> _repositoryBase;
        public UsuarioService(INotifier notifier, IRepositoryBase<Usuario> repositoryBase) : base(notifier)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task<Usuario> GetBy(Expression<Func<Usuario, bool>> predicate)
        {
            return await _repositoryBase.GetBy(predicate);
        }

        public async Task<bool> Insert(Usuario entity)
        {
            if (!RunValidation(new UsuarioValidation(_repositoryBase), entity))
                return false;
            return await _repositoryBase.Insert(entity);
        }
    }
}
