using Ardalis.Specification;
using Restaurants.Core.Domain.Common;

namespace Restaurants.Core.Common.Persistence
{
    public interface IRepository<T> : IRepositoryBase<T>
        where T : class, IAggregateRoot
    {
    }
    public interface IReadRepository<T> : IReadRepositoryBase<T>
        where T : class, IAggregateRoot
    {
    }
}
