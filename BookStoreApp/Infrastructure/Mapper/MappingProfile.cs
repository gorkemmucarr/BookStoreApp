using AutoMapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace BookStoreApp.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDtoForUpdate, IdentityUser>().ReverseMap();
        }
    }
}
