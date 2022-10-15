using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Restaurants.Core.Common.Persistence;
using Restaurants.Infra.Persistence.Context;
using Mapster;
using Restaurants.Core.Domain.Common;

namespace Restaurants.Infra.Persistence.Repository
{
    public class ApplicationDbRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T>
        where T : class, IAggregateRoot
    {
        public ApplicationDbRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        protected override IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> specification) =>
            ApplySpecification(specification, false)
                .ProjectToType<TResult>();
    }
}
