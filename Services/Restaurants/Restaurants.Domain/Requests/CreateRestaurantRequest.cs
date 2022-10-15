using MediatR;
using Restaurants.Core.Common.Persistence;
using Restaurants.Core.Domain;

namespace Restaurants.Core.Requests
{
    public class CreateRestaurantRequest : IRequest<Guid>
    {
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Website { get; set; } = default!;

        public class CreateRestaurantRequestHandler : IRequestHandler<CreateRestaurantRequest, Guid>
        {
            private readonly IRepository<Restaurant> _repository;
            public CreateRestaurantRequestHandler(IRepository<Restaurant> repository) =>
                _repository = repository;

            public async Task<Guid> Handle(CreateRestaurantRequest request, CancellationToken cancellationToken)
            {
                var restaurant = new Restaurant(request.Name, request.Address, request.Website);
                await _repository.AddAsync(restaurant, cancellationToken);
                return restaurant.Id;
            }
        }
    }
}
