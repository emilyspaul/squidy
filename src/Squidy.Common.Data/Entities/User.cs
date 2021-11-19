using Squidy.Common.Data.Entities.Interfaces;

namespace Squidy.Common.Data.Entities
{
    public class User : IEntityWithId
    {
        public Guid Id { get; set; }
    }
}
