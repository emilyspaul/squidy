using Squidy.Common.Data.Entities;
using Squidy.Common.Models.Dtos;

namespace Squidy.Service.Business.Extensions
{
    /// <summary>
    /// User dto extensions
    /// </summary>
    public static class UserExtension 
    {
        public static void HydrateFromEntity(this UserDto dto, User entity)
        {
            dto.Id = entity?.Id ?? Guid.Empty;
        }
    }
}
