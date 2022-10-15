namespace Restaurants.Core.Domain.Common
{
    public interface IEntity<TId>
    {
        TId Id { get; }
    }
}