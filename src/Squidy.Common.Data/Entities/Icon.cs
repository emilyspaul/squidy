using Squidy.Common.Data.Entities.Interfaces;

namespace Squidy.Common.Data.Entities
{
    public class Icon : IEntityWithId
    {
        public Guid Id { get; set; }
        public string? Path { get; set; }
    }
}