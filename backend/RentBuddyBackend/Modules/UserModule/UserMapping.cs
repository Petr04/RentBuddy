using AutoMapper;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.UserModule
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<UserEntity, UserEntity>();
                //.ForMember(dest=>dest.BirthDate,
                //opt => opt.MapFrom(src=>src.BirthDate.Date.ToString("dd-MM-yyyy")));
        }
    }
}
