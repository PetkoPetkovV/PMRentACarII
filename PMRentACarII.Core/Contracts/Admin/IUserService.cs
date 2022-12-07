using PMRentACarII.Core.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMRentACarII.Core.Contracts.Admin
{
    public interface IUserService
    {
        Task<IEnumerable<UserServiceModel>> AllUsers();
        
    }
}
