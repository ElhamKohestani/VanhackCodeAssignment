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
    public class CourseRecordingProfile : Profile
    {
        public CourseRecordingProfile()
        {
            CreateMap<CourseRecordingCreateDTO, CourseRecording>()
        .ForMember(c => c.Id, options => options.Ignore())
        .ForMember(c => c.Title, options => options.MapFrom(d => d.RecordingTitle))
        .ForMember(c => c.Description, options => options.MapFrom(d => d.RecordingDescription))
        .ForMember(c => c.Order, options => options.MapFrom(d => d.RecordingOrder))
        .ForMember(c => c.Link, options => options.MapFrom(d => d.RecordingLink))
        .ForMember(c => c.CourseId, options => options.MapFrom(d => d.CourseId))
        .ForMember(c => c.CreatedBy, options => options.Ignore())
        .ForMember(c => c.CreatedOn, options => options.Ignore())
        .ReverseMap();

            CreateMap<CourseRecordingDTO, CourseRecording>()
                    .ForMember(c => c.Id, options => options.MapFrom(d => d.RecordingId))
                    .ForMember(c => c.Title, options => options.MapFrom(d => d.RecordingTitle))
                    .ForMember(c => c.Description, options => options.MapFrom(d => d.RecordingDescription))
                    .ForMember(c => c.Order, options => options.MapFrom(d => d.RecordingOrder))
                    .ForMember(c => c.Link, options => options.MapFrom(d => d.RecordingLink))
                    .ForMember(c => c.CourseId, options => options.MapFrom(d => d.CourseId))
                    .ForMember(c => c.CreatedBy, options => options.Ignore())
                    .ForMember(c => c.CreatedOn, options => options.Ignore())
                    .ReverseMap();
        }

    }
}
