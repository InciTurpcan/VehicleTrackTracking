using Domain.DataTransferObjects;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IPartService
    {
        IEnumerable<Part> GetAllParts(bool trackChanges);
        Part GetOnePartById(int id, bool trackChanges);
        Part CreateOnePart(PartDtoForInsertion partDto);
        void UpdateOnePart(int id, PartDtoForUpdate partDto, bool trackChanges);
        void DeleteOnePart(int id, bool trackChanges);
    }
}
