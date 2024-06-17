using AutoMapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public AuthService(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> CreateUser(UserDtoForCreation userDtoForCreation)
        {
            var user = new IdentityUser()
            {
                UserName = userDtoForCreation.Username,
                Email = userDtoForCreation.Email
            };
            var result = await _userManager.CreateAsync(user,userDtoForCreation.Password);
            if (!result.Succeeded)
            {
                throw new Exception("User could not created");
            }
            if (userDtoForCreation.Roles.Count>0)
            {
                var roleResult = await _userManager.AddToRolesAsync(user, userDtoForCreation.Roles);
                if (!roleResult.Succeeded)
                {
                    throw new Exception("System have an error");
                }
            }
            return result;
        }

        public async Task<IdentityResult> DeleteOneUser(string userName)
        {
            var user = await GetOneUser(userName);
            if (user is not null)
            {
                return await _userManager.DeleteAsync(user);
            }
            throw new Exception("System have an error");
        }

        public IEnumerable<IdentityRole> GetAllRoles()
        {
            var roles = _roleManager.Roles;
            return roles;
        }

        public IEnumerable<IdentityUser> GetAllUsers()
        {
            var users = _userManager.Users.ToList();
            return users;
        }

        public async Task<IdentityUser> GetOneUser(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user;
        }

        public async Task<UserDtoForUpdate> GetOneUserForUpdate(string userName)
        {
            var user = await GetOneUser(userName);
            if (user is not null)
            {
                var userDto = _mapper.Map<UserDtoForUpdate>(user);
                //Tüm rolleri getiriyoruz
                userDto.Roles = new HashSet<string>(GetAllRoles().Select(p=>p.Name).ToList());
                //Kullanıcının sahip olduğu roller
                userDto.UserRoles = new HashSet<string>(await _userManager.GetRolesAsync(user));
                return userDto;
            }
            throw new Exception("System have an error");
        }

        public async Task<IdentityResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var user = await GetOneUser(resetPasswordDto.UserName);
            if (user is not null)
            {
                await _userManager.RemovePasswordAsync(user);
                var result = await _userManager.AddPasswordAsync(user, resetPasswordDto.Password);
                return result;
            }
            throw new Exception("System have an error");
        }

        public async Task UpdateUser(UserDtoForUpdate userDtoForUpdate)
        {
            var user = await GetOneUser(userDtoForUpdate.Username);
            user.Email = userDtoForUpdate.Email;

            if (user is not null)
            {
                var result = await _userManager.UpdateAsync(user);
                if (userDtoForUpdate.Roles.Count > 0)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);  //user'ın rolunu getir
                    var r1 = await _userManager.RemoveFromRolesAsync(user, userRoles); //user'ın rollerini sil
                    var r2 = await _userManager.AddToRolesAsync(user, userDtoForUpdate.Roles);
                }
                return;
            }
            throw new Exception("System have an error");
        }
    }
}
