using AutoMapper;
using Zhuk.University.Tachka.Models.Database;
using Zhuk.University.Tachka.Models.Frontend;

namespace Zhuk.University.Tachka.Web
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<UserModel, User>()
               .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.Password))
               .ForMember(dst => dst.Id, opt => opt.Ignore())
               ;

            CreateMap<User, AuthenticateResponse>()
               .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Email))
               .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dst => dst.Token, opt => opt.Ignore())
               ;
        }
    }
}
