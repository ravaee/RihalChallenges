using AutoMapper;
using Common.Extenstions;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Specifications.EntitySpecs;
using Persistence.UnitOfWork;

namespace Persistence.Services
{
    public class ClassService: BaseService
    {
        public ClassService(IMapper mapper, IRepositoryUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<bool> Create(ClassDTO @class)
        {
            await _unitOfWork.ClassRepository.Add(@class.ToPOCO(_mapper));
            await _unitOfWork.Complete();
            return true;
        }

        public async Task<ClassDTO> Get(int id)
        {
            var _class = await _unitOfWork.ClassRepository.Get(id);

            return _class.ToDTO(_mapper);
        }


        public async Task<IEnumerable<ClassDTO>> GetAll()
        {
            var classes = await _unitOfWork.ClassRepository.GetAll();  
            return classes.ToListDTO(_mapper);
        }

        public async Task<IEnumerable<ClassDTO>> GetAllWithStudents()
        {
            var classes = await _unitOfWork.ClassRepository.ListAsync(new ClassWithStudentsSpecification());
            return classes.ToListDTO(_mapper);
        }

        public async Task<bool> Remove(int? classId)
        {
            if(classId == null)
            {
                return false;
            }

            var _class = await _unitOfWork.ClassRepository.Get(classId.Value);
            
            if(_class == null)
            {
                return false;
            }

            _unitOfWork.ClassRepository.Remove(_class);
            await _unitOfWork.Complete();

            return true;

        }

        public async Task<bool> Update(ClassDTO dto)
        {
            _unitOfWork.ClassRepository.Update(dto.ToPOCO(_mapper));
            await _unitOfWork.Complete();

            return true;
        }

        public async Task<IEnumerable<ClassDTO>> GetAllWithAtListOneStudent()
        {
            var classes = await _unitOfWork.ClassRepository.ListAsync(new ClassWithAtListOneStudentSpecification());
            return classes.ToListDTO(_mapper);
        }
    }
}
