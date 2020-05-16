using System.Threading.Tasks;

namespace IHolder.Domain.DomainObjects
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
