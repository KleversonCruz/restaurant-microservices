namespace Restaurants.Core.Requests
{
    public class RestaurantDto
    {
        public Guid Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Website { get; set; } = default!;
    }
}