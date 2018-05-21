using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SCCTesting.Dtos;
using SCCTesting.Models;

namespace SCCTesting.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Professor, ProfessorDto>();
            CreateMap<ProfessorDto, Professor>();

            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();

            CreateMap<Test, TestDto>();
            CreateMap<TestDto, Test>();

            CreateMap<Term, TermDto>();
            CreateMap<TermDto, Term>();

            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
        }
    }
}
