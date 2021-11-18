using Microsoft.EntityFrameworkCore;
using Squidy.Common.Data.Entities;
using Squidy.Common.Data.Entities.Interfaces;
using System;
using System.Threading.Tasks;

namespace Squidy.Common.Data
{
    public class DataContext : DbContext, IDataContext, IDisposable
    {
        public Task<T> GetEntityFor<T>(Guid id) where T : IEntityWithId
            => throw new NotImplementedException();

        public Task<T> GetTrackedEntityFor<T>(int id) where T : IEntityWithId
            => throw new NotImplementedException();

        public DbSet<Icon>? Icons { get; set; }
        public DbSet<SubscriptionPlan>? SubscriptionPlans { get; set; }
    }
}
