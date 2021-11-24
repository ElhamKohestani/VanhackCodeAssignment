using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanhackTest.Core.Entities;
using VanhackTest.CourseServices.V1.DTOs;

namespace VanhackTest.CourseServices.V1.Maps
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<CourseDto, Course>()
                .ForMember(c => c.Id, options => options.MapFrom(d => d.CourseId))
                .ForMember(c => c.Title, options => options.MapFrom(d => d.CourseTitle))
                .ForMember(c => c.Description, options => options.MapFrom(d => d.CourseDescription))
                .ForMember(c => c.CategoryId, options => options.MapFrom(d => d.CourseCategoryId))
                .ForMember(c => c.CreatedBy, options => options.Ignore())
                .ForMember(c => c.CreatedOn, options => options.Ignore())
                .ReverseMap();

              CreateMap<CourseCreateDto, Course>()
             .ForMember(c => c.Title, options => options.MapFrom(d => d.CourseTitle))
             .ForMember(c => c.Description, options => options.MapFrom(d => d.CourseDescription))
             .ForMember(c => c.CategoryId, options => options.MapFrom(d => d.CourseCategoryId))
             .ForMember(c => c.CourseAccessLevels, options => options.Ignore())
             .ForMember(c => c.CreatedBy, options => options.Ignore())
             .ForMember(c => c.CreatedOn, options => options.Ignore())
             .ReverseMap();

        }
    }
}
