using Microsoft.EntityFrameworkCore;
using Squidy.Common.Data.Entities;
using Squidy.Common.Data.Entities.Interfaces;

namespace Squidy.Common.Data
{
    public class DataContext : DbContext, IDataContext, IDisposable
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AccountType>()
                .Property(b => b.IsActive)
                .HasDefaultValue(true);
        }

        public Task<T> GetEntityFor<T>(Guid id) where T : IEntityWithId 
            => throw new NotImplementedException();

        public Task<T> GetLookupEntityFor<T>(int id) where T : ILookupEntity
            => throw new NotImplementedException();

        public DbSet<AccountType>? AccountTypes { get; set; }
        public DbSet<Icon>? Icons { get; set; }
        public DbSet<SubscriptionPlan>? SubscriptionPlans { get; set; }
    }
}
