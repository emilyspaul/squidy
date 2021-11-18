using System.ComponentModel.DataAnnotations;

namespace Squidy.Common.Models.Dtos.Interfaces
{
    /// <summary>
    /// Data transfer for entity with GUID id
    /// </summary>
    public interface IDtoWithId
    {
        /// <summary>
        /// Unique identifier for entity
        /// </summary>
        [Required]
        Guid Id { get; set; }
    }
}
