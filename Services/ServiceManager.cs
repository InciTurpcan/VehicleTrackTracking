using AutoMapper;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICarService> _carService;
        private readonly Lazy<IPartService> _partService;
        private readonly Lazy<IPartCategoryService> _partCategoryService;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _carService = new Lazy<ICarService>(() => new CarService (repositoryManager,mapper));
            _partService = new Lazy<IPartService>(() => new PartService (repositoryManager,mapper));
            _partCategoryService= new Lazy<IPartCategoryService>(() => new PartCategoryService (repositoryManager,mapper));
        }
        public ICarService Car => _carService.Value;

        public IPartCategoryService PartCategory => _partCategoryService.Value;

        public IPartService Part => _partService.Value;
    }
}
