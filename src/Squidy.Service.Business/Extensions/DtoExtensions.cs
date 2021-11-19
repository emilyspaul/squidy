using Squidy.Common.Data.Entities.Interfaces;
using Squidy.Common.Models.Dtos.Interfaces;

namespace Squidy.Service.Business.Extensions
{
    internal static class DtoExtensions
    {
        internal static void HydrateBaseFromEntity(this IDtoWithIdNameDescription dto, 
                                                   IEntityWithIdNameDescription entity)
        {
            dto.Id = entity?.Id ?? Guid.Empty;
            dto.Name = entity?.Name; 
            dto.Description = entity?.Description;
        }

        internal static void HydrateTrackingDataFromEntity(this ITrackedDto dto, ITrackedEntity entity)
        {
            dto.CreatedDate = entity?.CreatedDate ?? DateTime.MinValue;
            dto.UpdatedDate = entity?.UpdatedDate;
        }
    }
}
