using Squidy.Common.Data.Entities;
using Squidy.Common.Models.Dtos;

namespace Squidy.Service.Business.Extensions
{
    /// <summary>
    /// Account type dto extensions
    /// </summary>
    public static class AccountTypeExtension 
    {
        public static void HydrateFromEntity(this AccountTypeDto dto, AccountType entity)
        {
            dto.HydrateBaseFromEntity(entity);
            dto.HydrateTrackingDataFromEntity(entity);

            dto.IsActive = entity?.IsActive ?? true;

            if (entity?.SubscriptionPlan != null)
            {
                var planDto = new SubscriptionPlanDto();
                planDto.HydrateFromEntity(entity.SubscriptionPlan);
                dto.SubscriptionPlan = planDto;
            }
        }
    }
}
