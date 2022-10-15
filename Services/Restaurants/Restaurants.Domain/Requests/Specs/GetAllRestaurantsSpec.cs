using Ardalis.Specification;
using Restaurants.Core.Domain;

namespace Restaurants.Core.Requests.Specs
{
    public class GetAllRestaurantsSpec<TDto> : Specification<Restaurant, TDto>
    {
        public GetAllRestaurantsSpec() { }
    }

    public class GetAllRestaurantsSpec : Specification<Restaurant>
    {
        public GetAllRestaurantsSpec() { }
    }
}
