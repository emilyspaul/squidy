using Squidy.Common.Models.Dtos.Interfaces;

namespace Squidy.Common.Models.Dtos
{
    public class UserDto : IDtoWithId
    {
        public Guid Id { get; set; }
    }
}
