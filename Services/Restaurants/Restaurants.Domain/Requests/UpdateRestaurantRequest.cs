using MediatR;
using Restaurants.Core.Common.Persistence;
using Restaurants.Core.Domain;

namespace Restaurants.Core.Requests
{
    public class UpdateRestaurantRequest : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Website { get; set; } = default!;

        public class UpdateRestaurantRequestHandler : IRequestHandler<UpdateRestaurantRequest, Guid>
        {
            private readonly IRepository<Restaurant> _repository;
            public UpdateRestaurantRequestHandler(IRepository<Restaurant> repository) =>
                _repository = repository;

            public async Task<Guid> Handle(UpdateRestaurantRequest request, CancellationToken cancellationToken)
            {
                var restaurant = await _repository.GetByIdAsync(request.Id, cancellationToken);
                _ = restaurant ?? throw new Exception("Restaurante não encontrado(a).");

                var updatedRestaurant = restaurant.Update(request.Name, request.Address, request.Website);

                await _repository.UpdateAsync(updatedRestaurant, cancellationToken);
                return restaurant.Id;
            }
        }
    }

}
