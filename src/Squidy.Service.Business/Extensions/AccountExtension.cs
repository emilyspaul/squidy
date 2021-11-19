using Squidy.Common.Data.Entities;
using Squidy.Common.Models.Dtos;

namespace Squidy.Service.Business.Extensions
{
    /// <summary>
    /// Account dto extensions
    /// </summary>
    public static class AccountExtension 
    {
        public static void HydrateFromEntity(this AccountDto dto, Account entity)
        {
            dto.HydrateTrackingDataFromEntity(entity);

            dto.Id = entity?.Id ?? Guid.Empty;
            dto.Title = entity?.Title;   
            dto.IsExpired = entity?.IsExpired ?? true;

            if (entity?.AccountType != null)
            {
                var accountTypeDto = new AccountTypeDto();
                accountTypeDto.HydrateFromEntity(entity.AccountType);
                dto.AccountType = accountTypeDto;
            }

            if (entity?.User != null)
            {
                var userDto = new UserDto();
                userDto.HydrateFromEntity(entity.User);
                dto.User = userDto;
            }
        }
    }
}
