using AutoMapper;
using Domain.DataTransferObjects;
using Domain.Entities;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PartCategoryService : IPartCategoryService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public PartCategoryService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public PartCategory CreateOnePartCategory(PartCategoryDtoForInsertion partDto)
        {
            var entity = _mapper.Map<PartCategory>(partDto);
            _manager.PartCategory.CreateOnePartCategory(entity);
            _manager.Save();
            return entity;
        }

        public void DeleteOnePartCategory(int id, bool trackChanges)
        {
            var entitiy = _manager.PartCategory.GetOnePartCategoryById(id, trackChanges);

            _manager.PartCategory.DeleteOnePartCategory(entitiy);
            _manager.Save();
        }

        public IEnumerable<PartCategory> GetAllPartCategories(bool trackChanges)
        {
            return _manager.PartCategory.GetAllPartCategories(trackChanges);
        }

        public PartCategory GetOnePartCategoryById(int id, bool trackChanges)
        {
            return _manager.PartCategory.GetOnePartCategoryById(id, trackChanges);
        }

        public void UpdateOnePartCategory(int id, PartCategoryDtoForUpdate partDto, bool trackChanges)
        {
            var entity = _manager.PartCategory.GetOnePartCategoryById(id, trackChanges);

            entity = _mapper.Map<PartCategory>(partDto);

            _manager.PartCategory.UpdateOnePartCategory(entity);
            _manager.Save();
        }
    }
}
