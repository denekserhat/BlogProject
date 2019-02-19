using AutoMapper;
using Entities;
using Entities.Dtos;

namespace Common
{
    public class AutoMapperHelper: Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<User, UserDetailModel>();
        }
    }
}