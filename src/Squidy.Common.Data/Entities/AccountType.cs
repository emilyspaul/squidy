using Squidy.Common.Data.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Squidy.Common.Data.Entities
{
    public class AccountType : IEntityWithIdNameDescription, ITrackedEntity
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public bool? IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get ; set; }

        [Required]
        public virtual SubscriptionPlan SubscriptionPlan { get; set; }
    }
}
