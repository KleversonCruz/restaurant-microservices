using MediatR;
using Restaurants.Core.Common.Persistence;
using Restaurants.Core.Domain;
using Restaurants.Core.Requests.Specs;

namespace Restaurants.Core.Requests
{
    public class GetRestaurantRequest : IRequest<RestaurantDto>
    {
        public Guid Id { get; set; }
        public GetRestaurantRequest(Guid id) => Id = id;

        public class GetRestaurantRequestHandler : IRequestHandler<GetRestaurantRequest, RestaurantDto>
        {
            private readonly IRepository<Restaurant> _repository;
            public GetRestaurantRequestHandler(IRepository<Restaurant> repository)
                => _repository = repository;

            public async Task<RestaurantDto> Handle(GetRestaurantRequest request, CancellationToken cancellationToken)
            {
                var restaurant = await _repository.FirstOrDefaultAsync(new GetRestaurantByIdSpec<RestaurantDto>(request.Id), cancellationToken);
                _ = restaurant ?? throw new Exception("Restaurante não encontrado(a).");
                return restaurant;
            }
        }
    }
}
