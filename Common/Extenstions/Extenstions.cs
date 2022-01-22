using AutoMapper;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Extenstions
{
    public static class Extensions
    {
        //Student
        public static Student ToPOCO(this StudentDTO dto, IMapper mapper)
        {
            return mapper.Map<Student>(dto);
        }

        public static StudentDTO ToDTO(this Student model, IMapper mapper)
        {
            return mapper.Map<StudentDTO>(model);
        }

        public static IEnumerable<StudentDTO> ToListDTO(this IEnumerable<Student> model, IMapper mapper)
        {
            return mapper.Map<IEnumerable<StudentDTO>>(model);
        }

        public static IEnumerable<Student> ToListPOCO(this IEnumerable<StudentDTO> model, IMapper mapper)
        {
            return mapper.Map<IEnumerable<Student>>(model);
        }


        //Class
        public static Class ToPOCO(this ClassDTO dto, IMapper mapper)
        {
            return mapper.Map<Class>(dto);
        }

        public static ClassDTO ToDTO(this Class model, IMapper mapper)
        {
            return mapper.Map<ClassDTO>(model);
        }
        public static IEnumerable<ClassDTO> ToListDTO(this IEnumerable<Class> model, IMapper mapper)
        {
            return mapper.Map<IEnumerable<ClassDTO>>(model);
        }

        public static IEnumerable<Class> ToListPOCO(this IEnumerable<ClassDTO> model, IMapper mapper)
        {
            return mapper.Map<IEnumerable<Class>>(model);
        }

        //Country
        public static Country ToPOCO(this CountryDTO dto, IMapper mapper)
        {
            return mapper.Map<Country>(dto);
        }

        public static CountryDTO ToDTO(this Country model, IMapper mapper)
        {
            return mapper.Map<CountryDTO>(model);
        }
        public static IEnumerable<CountryDTO> ToListDTO(this IEnumerable<Country> model, IMapper mapper)
        {
            return mapper.Map<IEnumerable<CountryDTO>>(model);
        }

        public static IEnumerable<Country> ToListPOCO(this IEnumerable<CountryDTO> model, IMapper mapper)
        {
            return mapper.Map<IEnumerable<Country>>(model);
        }
    }
}
