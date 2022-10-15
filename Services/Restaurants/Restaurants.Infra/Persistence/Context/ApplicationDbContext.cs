using Microsoft.EntityFrameworkCore;
using Restaurants.Core.Domain;

namespace Restaurants.Infra.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Restaurant> Restaurants => Set<Restaurant>();
    }

}
