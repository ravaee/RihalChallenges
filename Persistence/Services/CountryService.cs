using AutoMapper;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Specifications.EntitySpecs;
using Persistence.UnitOfWork;
using Common.Extenstions;

namespace Persistence.Services
{
    public class CountryService: BaseService
    {
        public CountryService(IMapper mapper, IRepositoryUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<IEnumerable<CountryDTO>> GetAll()
        {
            var countries = await _unitOfWork.CountryRepository.GetAll();
            return countries.ToListDTO(_mapper);
        }

        public async Task<IEnumerable<CountryDTO>> GetAllWithAtListOneStudent()
        {
            var countries = await _unitOfWork.CountryRepository.ListAsync(new CountryWithAtListOneStudentSpecification());
            return countries.ToListDTO(_mapper);
        }

    }
}
