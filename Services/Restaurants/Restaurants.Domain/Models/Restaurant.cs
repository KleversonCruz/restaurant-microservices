using Restaurants.Core.Domain.Common;

namespace Restaurants.Core.Domain
{
    public class Restaurant : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; } = default!;
        public string Address { get; private set; } = default!;
        public string Website { get; private set; } = default!;

        public Restaurant(string name, string address, string website)
        {
            Name = name;
            Address = address;
            Website = website;
        }

        public Restaurant Update(string name, string address, string website)
        {
            if (name is not null && Name?.Equals(name) is not true) Name = name;
            if (address is not null && Address?.Equals(address) is not true) Address = address;
            if (website is not null && Website?.Equals(website) is not true) Website = website;
            return this;
        }
    }
}