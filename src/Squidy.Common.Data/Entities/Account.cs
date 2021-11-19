using Squidy.Common.Data.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Squidy.Common.Data.Entities
{
    public class Account : IEntityWithId, ITrackedEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public bool? IsExpired { get; set; }

        public virtual AccountType AccountType { get; set; }
        public virtual User User { get; set; }
    }
}
