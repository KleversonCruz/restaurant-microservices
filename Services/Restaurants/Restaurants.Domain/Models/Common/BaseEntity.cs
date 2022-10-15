﻿namespace Restaurants.Core.Domain.Common
{
    public abstract class BaseEntity : BaseEntity<Guid>
    {
        protected BaseEntity() => Id = Guid.NewGuid();
    }

    public abstract class BaseEntity<TId> : IEntity<TId>
    {
        public TId Id { get; protected set; } = default!;
    }
}
