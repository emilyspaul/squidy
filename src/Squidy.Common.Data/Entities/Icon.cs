using Squidy.Common.Data.Entities.Interfaces;

namespace Squidy.Common.Data.Entities
{
    public class Icon : ILookupEntity, ITrackedEntity
    {
        public int Id { get; set; }
        public string? Path { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

    }
}