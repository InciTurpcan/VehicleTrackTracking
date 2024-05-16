using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IPartCategoryRepository : IRepositoryBase<PartCategory>
    {
        IQueryable<PartCategory> GetAllPartCategories(bool trackChanges);
        PartCategory GetOnePartCategoryById(int id, bool trackChanges);
        void CreateOnePartCategory(PartCategory partCategory);
        void UpdateOnePartCategory(PartCategory partCategory);
        void DeleteOnePartCategory(PartCategory partCategory);
    }
}
