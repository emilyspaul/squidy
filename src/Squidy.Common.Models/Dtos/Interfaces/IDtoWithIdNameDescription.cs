using System.ComponentModel.DataAnnotations;

namespace Squidy.Common.Models.Dtos.Interfaces
{
    /// <summary>
    /// Data transfer for entity with name and description fields
    /// </summary>
    public interface IDtoWithIdNameDescription : IDtoWithId
    {
        /// <summary>
        /// Short description of the entity
        /// </summary>
        [Required]
        [MaxLength(250)]
        string? Name { get; set; }

        /// <summary>
        /// Long description of the entity
        /// </summary>
        [MaxLength(1000)]
        string? Description { get; set; }
    }
}
