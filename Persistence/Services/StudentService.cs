using AutoMapper;
using Common.Models;
using Persistence.Context;
using Persistence.UnitOfWork;

namespace Persistence.Services
{
    public class StudentService: BaseService
    {
        
        public StudentService(IMapper mapper, IRepositoryUnitOfWork unitOfWork): base(mapper, unitOfWork)
        {
        }

        public async Task<bool> Create(StudentDTO student)
        {
            try
            {
                var model = _mapper.Map<Student>(student);


                await _unitOfWork.StudentRepository.Add(model);
                await _unitOfWork.Complete();

            }
            catch (Exception ex)
            {
                return false;
            }
            
            return true;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {

            Thread.Sleep(1000);

            //var students = await _unitOfWork.StudentRepository.GetAll();

            //return students;

            Class @class = new Class() { Name = "A" };
            Country country = new Country() { Name = "Iran" };

            return new List<Student>()
            {
                new Student() { Name = "Mohamad", BirthDate = new DateTime(1994, 09,21), Country = country, Class = @class},
                new Student() { Name = "Ali", BirthDate = new DateTime(1994, 09,21), Country = country, Class = @class},
                new Student(){ Name = "Hasan", BirthDate = new DateTime(1994, 09,21), Country = country, Class = @class},
            };


        }
    }
}
