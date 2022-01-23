using AutoMapper;
using Common.Extenstions;
using Common.Models;
using Persistence.Context;
using Persistence.Specifications;
using Persistence.Specifications.EntitySpecs;
using Persistence.UnitOfWork;

namespace Persistence.Services
{
    public class StudentService : BaseService
    {
        public StudentService(IMapper mapper, IRepositoryUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<bool> Create(StudentDTO student)
        {

            var model = _mapper.Map<Student>(student);

            await _unitOfWork.StudentRepository.Add(model);
            await _unitOfWork.Complete();

            return true;
        }

        public async Task<IEnumerable<StudentDTO>> GetAll()
        {

            var students = await _unitOfWork.StudentRepository.
                ListAsync(new StudentWithCountriesAndClassSpecification());


            return students.ToListDTO(_mapper);
        }

        public async Task<StudentDTO> Get(int id)
        {
            var student = await _unitOfWork.StudentRepository.Get(id);

            return student.ToDTO(_mapper);
        }

        public async Task<double> AverageAge()
        {
             var studentsBirthDate = ((await _unitOfWork.StudentRepository.GetAll()).Select(a => a.BirthDate).Select(a => (DateTime.Now.Year - a.Year)));

            if(studentsBirthDate.Count() > 0)
            {
                return studentsBirthDate.Average();
            }

            return 0;        
        }

        public async Task<bool> Remove(int? studentId)
        {
            if (studentId == null)
            {
                return false;
            }

            var _student = await _unitOfWork.StudentRepository.Get(studentId.Value);

            if (_student == null)
            {
                return false;
            }

            _unitOfWork.StudentRepository.Remove(_student);
            await _unitOfWork.Complete();

            return true;
        }

        public async Task<bool> Update(StudentDTO dto)
        {
            _unitOfWork.StudentRepository.Update(dto.ToPOCO(_mapper));

            await _unitOfWork.Complete();

            return true;
        }

    }
}
