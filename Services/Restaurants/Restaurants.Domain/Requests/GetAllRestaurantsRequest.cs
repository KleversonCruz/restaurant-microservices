using MediatR;
using Restaurants.Core.Common.Persistence;
using Restaurants.Core.Domain;
using Restaurants.Core.Requests.Specs;

namespace Restaurants.Core.Requests
{
    public class GetAllRestaurantsRequest : IRequest<List<RestaurantDto>>
    {
        public class GetAllRestaurantsRequestHandler : IRequestHandler<GetAllRestaurantsRequest, List<RestaurantDto>>
        {
            private readonly IRepository<Restaurant> _repository;

            public GetAllRestaurantsRequestHandler(IRepository<Restaurant> repository) => _repository = repository;

            public async Task<List<RestaurantDto>> Handle(GetAllRestaurantsRequest request, CancellationToken cancellationToken) =>
                await _repository.ListAsync(new GetAllRestaurantsSpec<RestaurantDto>(), cancellationToken);
        }
    }
}
