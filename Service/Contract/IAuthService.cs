using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> GetAllRoles();
        IEnumerable<IdentityUser> GetAllUsers();
        Task<IdentityResult> CreateUser(UserDtoForCreation userDtoForCreation);
        Task<IdentityUser> GetOneUser(string userName);
        Task UpdateUser(UserDtoForUpdate userDtoForUpdate);
        Task<UserDtoForUpdate> GetOneUserForUpdate(string userName);
        Task<IdentityResult> ResetPassword(ResetPasswordDto resetPasswordDto);
        Task<IdentityResult> DeleteOneUser(string userName);
    }
}
