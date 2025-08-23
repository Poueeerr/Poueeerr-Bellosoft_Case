using AutoMapper;
using Studying.DTOs;
using Studying.DTOs.Views;
using Studying.Models;

namespace Studying.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            #region UserMap
            CreateMap<UserDTO, UserModel>().ReverseMap();
            CreateMap<UserModelViewDTO, UserModel>().ReverseMap();
            #endregion
        }
    }
}
