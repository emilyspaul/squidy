using Squidy.Common.Data.Entities;
using Squidy.Common.Models.Dtos;
using Squidy.Common.Models.Enums;

namespace Squidy.Service.Business.Extensions
{
    /// <summary>
    /// Subscription plan dto extensions
    /// </summary>
    public static class SubscriptionPlanExtension 
    {
        public static void HydrateFromEntity(this SubscriptionPlanDto dto, SubscriptionPlan entity)
        {
            dto.HydrateBaseFromEntity(entity);
            dto.HydrateTrackingDataFromEntity(entity);

            dto.Amount = entity.Amount;
            dto.Frequency = Enum.Parse<PlanFrequency>(entity.Frequency ?? PlanFrequency.Monthly.ToString());
        }
    }
}
