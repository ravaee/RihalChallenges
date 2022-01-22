using AutoMapper;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RihalChallenges
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //student
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>();
            //CreateMap<IEnumerable<StudentDTO>, IEnumerable<Student>>();
            //CreateMap<IEnumerable<Student>, IEnumerable<StudentDTO>>();

            //class
            CreateMap<Class, ClassDTO>();
            CreateMap<ClassDTO, Class>();
            //CreateMap<IEnumerable<ClassDTO>, IEnumerable<Class>>();
            //CreateMap<IEnumerable<Class>, IEnumerable<ClassDTO>>();

            //country
            CreateMap<Country, CountryDTO>();
            CreateMap<CountryDTO, Country>();
            //CreateMap<IEnumerable<CountryDTO>, IEnumerable<Country>>();
            //CreateMap<IEnumerable<Country>, IEnumerable<CountryDTO>>();
        }

    }



}
