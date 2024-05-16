using Domain.Entities;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<ICarRepository> _carRepository;
        private readonly Lazy<IPartRepository> _partRepository;
        private readonly Lazy<IPartCategoryRepository> _partCategoryRepository;


        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _carRepository = new Lazy<ICarRepository>(() => new CarRepository(_context));
            _partRepository = new Lazy<IPartRepository>(() => new PartRepository(_context));
            _partCategoryRepository= new Lazy<IPartCategoryRepository>(()=> new PartCategoryRepository(_context));
        }

        public ICarRepository Car => _carRepository.Value;
        public IPartCategoryRepository PartCategory => _partCategoryRepository.Value;

        public IPartRepository Part => _partRepository.Value;

     

        public void Save() => _context.SaveChanges();
       
    }
}
