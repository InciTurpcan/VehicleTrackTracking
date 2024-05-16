using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class PartCategoryRepository : RepositoryBase<PartCategory> , IPartCategoryRepository
    {
        public PartCategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOnePartCategory(PartCategory partCategory) => _context.Database.ExecuteSqlInterpolated($@"
            EXEC AddPartCategory 
            @PartCategoryName={partCategory.PartCategoryName}");
        public void DeleteOnePartCategory(PartCategory partCategory) => Delete(partCategory);
   
        public IQueryable<PartCategory> GetAllPartCategories(bool trackChanges) => FindAll(trackChanges);
        public PartCategory GetOnePartCategoryById(int id, bool trackChanges) => FindByCondition(x => x.PartCategoryId.Equals(id), trackChanges).SingleOrDefault();
        public void UpdateOnePartCategory(PartCategory partCategory) => Update(partCategory);
    }
}
