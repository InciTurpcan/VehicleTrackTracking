using AutoMapper;
using Domain.DataTransferObjects;
using Domain.Entities;
using Dtos.CarDtos;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CarService : ICarService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CarService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public Car CreateOneCar(CarDtoForInsertion carDto)
        {
            // Plaka numarası mevcut mu diye kontrol et
            var existingCar = _manager.Car.FindByCondition(c => c.PlateNumber == carDto.PlateNumber,false).FirstOrDefault();
            if (existingCar != null)
            {
                // Plaka numarası mevcut ise ekleme yapma, null döndür
                throw new Exception("Plate already exists.");
            }

            // Plaka numarası mevcut değilse aracı ekle
            var entity = _mapper.Map<Car>(carDto);
            _manager.Car.CreateOneCar(entity);
            _manager.Save();
            return entity;
        }


        public void DeleteOneCar(int id, bool trackChanges)
        {
            var entitiy = _manager.Car.GetOneCarById(id, trackChanges);

            _manager.Car.DeleteOneCar(entitiy);
            _manager.Save();
        }

        public IEnumerable<Car> GetAllCars(bool trackChanges)
        {
            return _manager.Car.GetAllCars(trackChanges);
        }
      

        public Car GetOneCarById(int id, bool trackChanges)
        {
            return _manager.Car.GetOneCarById(id, trackChanges);
        }
       

        public void UpdateOneCar(int id, CarDtoForUpdate carDto, bool trackChanges)
        {
            
           
            var entity = _manager.Car.GetOneCarById(id, trackChanges);
        
                
            entity = _mapper.Map<Car>(carDto);

            _manager.Car.UpdateOneCar(entity);
            _manager.Save();
        }

        public ResultCarWithPartsDto GetOneCarWithPartsById(int carId)
        {
            var entity = _manager.Car.GetOneCarWithPartsById(carId);
            ResultCarWithPartsDto car = _mapper.Map<ResultCarWithPartsDto>(entity);               
            return car;
        }
    }
}
