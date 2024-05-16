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
    public class PartService : IPartService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public PartService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public Part CreateOnePart(PartDtoForInsertion partDto)
        {
           var entity= _mapper.Map<Part>(partDto);
            _manager.Part.CreateOnePart(entity);
            _manager.Save();
            return entity;
        }

        public void DeleteOnePart(int id, bool trackChanges)
        {
            var entitiy = _manager.Part.GetOnePartById(id, trackChanges);

            _manager.Part.DeleteOnePart(entitiy);
            _manager.Save();
        }

        public IEnumerable<Part> GetAllParts(bool trackChanges)
        {
            return _manager.Part.GetAllParts(trackChanges);
        }
        public IEnumerable<Part> GetPartsByCarID(int carId)
        {
            return _manager.Part.GetPartsByCarID(carId);
        }

        public Part GetOnePartById(int id, bool trackChanges)
        {
            return _manager.Part.GetOnePartById(id, trackChanges);
        }

        public void UpdateOnePart(int id, PartDtoForUpdate partDto, bool trackChanges)
        {
            var entity = _manager.Part.GetOnePartById(id, trackChanges);

            entity = _mapper.Map<Part>(partDto);

            _manager.Part.UpdateOnePart(entity);
            _manager.Save();
        }
    }
}
