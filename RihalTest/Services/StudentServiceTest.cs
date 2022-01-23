using Persistence.Context;
using Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RihalTest.Services
{
    public class StudentServiceTest: SqliteDatabaseService
    {
        private readonly StudentService _studentService;
        private readonly CountryService _countryService;
        private readonly ClassService _classService;

        public StudentServiceTest()
        {
            _studentService = new StudentService(_mapper, _work);
            _classService = new ClassService(_mapper, _work);
            _countryService = new CountryService(_mapper, _work);
        }

        [Fact]
        public void Can_Create_Student()
        {
            var Classes = _classService.GetAll().Result;
            var Countries = _countryService.GetAll().Result;

            var Result = _studentService.Create(new Common.Models.StudentDTO()
            {
                BirthDate = new DateTime(1994,09,21),
                ClassId = Classes.ToList().First().Id,
                CountryId = Countries.ToList().First().Id,
                Name = "MohamadRavaei",

            }).Result;



            var CreatedStudent = _studentService.GetAll()
                .Result.Where(a => a.Name == "MohamadRavaei").FirstOrDefault();

            Assert.NotNull(CreatedStudent);


        }

        [Fact]
        public void Can_Update_Student()
        {
            var Students = _studentService.GetAll().Result;

            var DestinationStudent = Students
                .FirstOrDefault(x => x.Name == "Mohamad");

            DestinationStudent.Name = "Michael";

            var Update = _studentService.Update(DestinationStudent).Result;


            var Updated = _studentService.GetAll().Result.Where(a => a.Name == "Michael").FirstOrDefault();

            Assert.NotNull(Updated);

        }
    }
}
