using MediatR;
using Restaurants.Core.Common.Persistence;
using Restaurants.Core.Domain;

namespace Restaurants.Core.Requests
{
    public class DeleteRestaurantRequest : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public DeleteRestaurantRequest(Guid id) => Id = id;

        public class DeleteRestaurantRequestHandler : IRequestHandler<DeleteRestaurantRequest, Guid>
        {
            private readonly IRepository<Restaurant> _repository;
            public DeleteRestaurantRequestHandler(IRepository<Restaurant> repository)
                => _repository = repository;

            public async Task<Guid> Handle(DeleteRestaurantRequest request, CancellationToken cancellationToken)
            {
                var restaurant = await _repository.GetByIdAsync(request.Id, cancellationToken);
                _ = restaurant ?? throw new Exception("Restaurante não encontrado(a).");

                await _repository.DeleteAsync(restaurant, cancellationToken);
                return request.Id;
            }
        }
    }
}
