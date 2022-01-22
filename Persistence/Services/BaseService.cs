using AutoMapper;
using Persistence.UnitOfWork;

namespace Persistence.Services
{
    public class BaseService
    {
        protected readonly IMapper _mapper;
        protected readonly IRepositoryUnitOfWork _unitOfWork;

        public BaseService(IMapper mapper, IRepositoryUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

    
    }

   
}
