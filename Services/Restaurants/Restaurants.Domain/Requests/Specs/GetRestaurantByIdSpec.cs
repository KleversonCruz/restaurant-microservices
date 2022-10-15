using Ardalis.Specification;
using Restaurants.Core.Domain;

namespace Restaurants.Core.Requests.Specs
{
    public class GetRestaurantByIdSpec<TDto> : Specification<Restaurant, TDto>, ISingleResultSpecification
    {
        public GetRestaurantByIdSpec(Guid id) =>
        Query
            .Where(c => c.Id == id);
    }

    public class GetRestaurantByIdSpec : Specification<Restaurant>, ISingleResultSpecification
    {
        public GetRestaurantByIdSpec(Guid id) =>
        Query
            .Where(c => c.Id == id);
    }
}
