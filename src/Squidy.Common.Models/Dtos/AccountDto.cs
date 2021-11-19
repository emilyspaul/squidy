using Squidy.Common.Models.Dtos.Interfaces;

namespace Squidy.Common.Models.Dtos
{
    /// <summary>
    /// Account details
    /// </summary>
    public class AccountDto : IDtoWithId, ITrackedDto
    {
        /// <summary>
        /// Default constructor adding an empty AccountType & User
        /// </summary>
        public AccountDto()
        {
            AccountType = new AccountTypeDto();
            User = new UserDto();
        }

        /// <summary>
        /// Unique identifier for the account
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Short description for the account
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Associated account type with account
        /// </summary>
        public AccountTypeDto AccountType { get; set; }

        /// <summary>
        /// Associated user with account
        /// </summary>
        public UserDto User { get; set; }

        /// <summary>
        /// Status of the account type
        /// </summary>
        public bool IsExpired { get; set; }

        /// <summary>
        /// Date the account type added to the data store
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Date the account type changed in the data store
        /// </summary>
        public DateTime? UpdatedDate { get; set; }
    }
}
