using Domain.DataTransferObjects;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IPartCategoryService
    {
        IEnumerable<PartCategory> GetAllPartCategories(bool trackChanges);
        PartCategory GetOnePartCategoryById(int id, bool trackChanges);
        PartCategory CreateOnePartCategory(PartCategoryDtoForInsertion partDto);
        void UpdateOnePartCategory(int id, PartCategoryDtoForUpdate partDto, bool trackChanges);
        void DeleteOnePartCategory(int id, bool trackChanges);
    }
}
