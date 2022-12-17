using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PMRentACar.Infrastructure.Data;
using PMRentACarII.Core.Contracts.Admin;
using PMRentACarII.Core.Models.Admin;
using PMRentACarII.Infrastructure.Data.Common;

namespace PMRentACarII.Core.Services.Admin
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository _repo)
        {
            repo = _repo;
        }
        /// <summary>
        /// AllUsers as admin
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserServiceModel>> AllUsers()
        {
            List<UserServiceModel> result;

            result = await repo.AllReadonly<Agent>()
                .Select(a => new UserServiceModel()
                {
                    UserId = a.UserId,
                    Name = a.User.UserName,
                    Email = a.User.Email,
                    PhoneNumber = a.PhoneNumber,
                })
                .ToListAsync();

            string[] agentIds = result.Select(a => a.UserId).ToArray();

            result.AddRange(await repo.AllReadonly<IdentityUser>()
                .Where(u => agentIds.Contains(u.Id) == false)
                .Select(u => new UserServiceModel()
                {
                    UserId = u.Id,
                    Name = u.UserName,
                    Email = u.Email,
                }).ToListAsync());

            return result;
        }

        
    }
}
