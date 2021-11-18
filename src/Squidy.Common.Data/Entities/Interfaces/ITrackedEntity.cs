using System;

namespace Squidy.Common.Data.Entities.Interfaces
{
    public interface ITrackedEntity
    {
        DateTime CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}
