using System.ComponentModel.DataAnnotations;

namespace Squidy.Common.Data.Entities.Interfaces
{
    public interface IEntityWithId
    {
        [Key]
        Guid Id { get; set; }
    }
}
