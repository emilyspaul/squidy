using Squidy.Common.Data.Entities;
using Squidy.Common.Data.Entities.Interfaces;
using System;
using System.Threading.Tasks;

namespace Squidy.Common.Data
{
    public interface IDataContext
    {
        Task<T> GetEntityFor<T>(Guid id) where T : IEntityWithId;
        Task<T> GetLookupEntityFor<T>(int id) where T : ILookupEntity;   
    }
}
