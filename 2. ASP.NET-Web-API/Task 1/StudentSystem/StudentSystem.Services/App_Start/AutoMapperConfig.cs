namespace StudentSystem.Services.App_Start
{
    using StudentSystem.Models;
    using StudentSystem.Services.Models;
    using System;

    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<Course, CourseModel>().ReverseMap();

            AutoMapper.Mapper.CreateMap<Homework, HomeworkModel>()
                .ForMember(dest => dest.StudentId,
                           opts => opts.MapFrom(src => src.StudentIdentification))
                .ForMember(dest => dest.TimeSent, 
                           opts => opts.MapFrom(src => DateTime.Now))
                .ReverseMap();

            AutoMapper.Mapper.CreateMap<Student, StudentModel>()
                .ForMember(dest => dest.Id,
                           opts => opts.MapFrom(src => src.StudentIdentification))
                .ReverseMap();

            AutoMapper.Mapper.CreateMap<Test, TestModel>().ReverseMap();
        }
    }
}