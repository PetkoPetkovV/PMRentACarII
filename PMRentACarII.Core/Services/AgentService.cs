using Microsoft.EntityFrameworkCore;
using PMRentACar.Infrastructure.Data;
using PMRentACarII.Core.Contracts;
using PMRentACarII.Infrastructure.Data.Common;

namespace PMRentACarII.Core.Services
{
    public class AgentService : IAgentService
    {
        private readonly IRepository repo;

        public AgentService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task Create(string userId, string phoneNumber, string email)
        {
            var agent = new Agent()
            {
                UserId = userId,
                PhoneNumber = phoneNumber,
                Email = email
            };

            await repo.AddAsync(agent);
            await repo.SaveChangesAsync();
        }

        /// <summary>
        /// checking if the user is already an agent
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> ExistsById(string userId)
        {
            return await repo.All<Agent>()
                .AnyAsync(a => a.UserId == userId);
        }
        /// <summary>
        /// if succeed in finding the agent will return his Id, if not - 0(never returns 0 due to checkings made)
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<int> GetAgentId(string userId)
        {
           return (await repo.AllReadonly<Agent>()
                .FirstOrDefaultAsync(a => a.UserId == userId))?.Id ?? 0;
        }

        public async Task<bool> UserWithPhoneNumberExists(string phoneNumber)
        {
            return await repo.All<Agent>()
                 .AnyAsync(a => a.PhoneNumber == phoneNumber);
        }

        public async Task<bool> UserWithThatEmailExists(string email)
        {
            return await repo.All<Agent>()
                 .AnyAsync(a => a.Email == email);
        }
    }
}
