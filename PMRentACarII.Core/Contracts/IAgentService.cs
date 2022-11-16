namespace PMRentACarII.Core.Contracts
{
    public interface IAgentService
    {
        Task<bool> ExistsById(string userId);
        Task<bool> UserWithPhoneNumberExists(string phoneNumber);
        Task<bool> UserWithThatEmailExists(string email);

        Task Create(string userId, string phoneNumber, string email);

    }
}
