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
    public class PartRepository : RepositoryBase<Part>, IPartRepository
    {
        public PartRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOnePart(Part part) => 
        
            _context.Database.ExecuteSqlInterpolated($@"
            EXEC AddPart 
            @Name={part.Name},            
            @PartCategoryId={part.PartCategoryId}");
        
        public void DeleteOnePart(Part part) => Delete(part);
        public IQueryable<Part> GetAllParts(bool trackChanges) => FindAll(trackChanges);
        public Part GetOnePartById(int id, bool trackChanges) => FindByCondition(x => x.PartId.Equals(id), trackChanges).SingleOrDefault();

        public IEnumerable<Part> GetPartsByCarID(int carId) => FindByCondition(x => x.CarId.Equals(carId),false);


        public void UpdateOnePart(Part part) => Update(part);
    }
}
