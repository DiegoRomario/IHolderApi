using IHolder.Domain.Entities;
using IHolder.Domain.Entities.Validations;
using IHolder.Application.Interfaces.Notifications;
using IHolder.Application.Interfaces.Services;

using IHolder.Application.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IHolder.Domain.DomainObjects;

namespace IHolder.Application.Services
{
    public class UsuarioService : ServiceBase, IUsuarioService
    {
        private readonly IRepositoryBase<Usuario> _repositoryBase;
        private readonly UsuarioValidation validation;
        public UsuarioService(INotifier notifier, IRepositoryBase<Usuario> repositoryBase) : base(notifier)
        {
            _repositoryBase = repositoryBase;
            validation = new UsuarioValidation(_repositoryBase);
        }

        public async Task<Usuario> GetBy(Expression<Func<Usuario, bool>> predicate)
        {
            return await _repositoryBase.GetBy(predicate);
        }

        public async Task<bool> Insert(Usuario entity)
        {
            if (!RunValidation(validation, entity))
                return false;
            return await _repositoryBase.Insert(entity);
        }

        public async Task<bool> Update(Usuario entity)
        {
            if (!RunValidation(validation, entity))
                return false;
            return await _repositoryBase.Update(entity);
        }
    }
}
