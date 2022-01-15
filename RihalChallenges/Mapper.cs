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
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>();
        }

    }
}
