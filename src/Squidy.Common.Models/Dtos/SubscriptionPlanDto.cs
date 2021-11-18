using Squidy.Common.Models.Dtos.Interfaces;
using Squidy.Common.Models.Enums;

namespace Squidy.Common.Models.Dtos
{
    /// <summary>
    /// Subscripiton plan details
    /// </summary>
    public class SubscriptionPlanDto : IDtoWithIdNameDescription, ITrackedDto
    {
        /// <summary>
        /// Unique identifier for the subscription plan
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Short description for the subscription plan
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Long description for the subscription plan
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Cost of the subscription plan
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Frequency of charges for the subscription plan
        /// </summary>
        public PlanFrequency Frequency { get; set; }

        /// <summary>
        /// Date the subscription plan added to the data store
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Date the subscription plan changed in the data store
        /// </summary>
        public DateTime? UpdatedDate { get; set; }
    }
}
