using Squidy.Common.Models.Dtos.Interfaces;

namespace Squidy.Common.Models.Dtos
{
    /// <summary>
    /// Account type details
    /// </summary>
    public class AccountTypeDto : IDtoWithIdNameDescription, ITrackedDto
    {
        /// <summary>
        /// Default constructor adding an empty SubscriptionPlan
        /// </summary>
        public AccountTypeDto()
        {
            SubscriptionPlan = new SubscriptionPlanDto();
        }

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
        /// Associated subscription plan with account type
        /// </summary>
        public SubscriptionPlanDto SubscriptionPlan { get; set; }

        /// <summary>
        /// Status of the account type
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Date the account type added to the data store
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Date the account type changed in the data store
        /// </summary>
        public DateTime? UpdatedDate { get; set; }
    }
}
