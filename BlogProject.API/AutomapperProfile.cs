using AutoMapper;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.API
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User, UserDetailModel>();
            CreateMap<CategoryInsertModel, Category>()
            .ForMember(x=> x.OnModified, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(x => x.OnModifiedUsername, opt => opt.MapFrom(src => "admin"));

            //CreateMap<Category, CategoryInsertModel>();
        }
     
    }
}
