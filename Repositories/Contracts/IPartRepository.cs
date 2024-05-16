using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IPartRepository : IRepositoryBase<Part>
    {
        IQueryable<Part> GetAllParts(bool trackChanges);
        Part GetOnePartById(int id, bool trackChanges);

        public IEnumerable<Part> GetPartsByCarID(int carId);
        void CreateOnePart(Part part);
        void UpdateOnePart(Part part);
        void DeleteOnePart(Part part);
    }
}
