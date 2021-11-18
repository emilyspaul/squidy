using System.ComponentModel.DataAnnotations;

namespace Squidy.Common.Models.Dtos.Interfaces
{
    /// <summary>
    /// Data transfer for tracked entities
    /// </summary>
    public interface ITrackedDto
    {
        /// <summary>
        /// Date entity was added to the data store
        /// </summary>
        [Required]
        DateTime CreatedDate { get; set; }

        /// <summary>
        /// Date entity was last updated in the data store
        /// </summary>
        DateTime? UpdatedDate {  get; set; }
    }
}
