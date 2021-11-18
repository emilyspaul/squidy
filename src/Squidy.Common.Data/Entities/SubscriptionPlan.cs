using Squidy.Common.Data.Entities.Interfaces;

namespace Squidy.Common.Data.Entities
{
    public class SubscriptionPlan : IEntityWithIdNameDescription, ITrackedEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; } //9,2
        public string? Frequency { get; set;  }  //likely enum of monthly, semi-annual, annual
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
