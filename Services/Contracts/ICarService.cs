using Domain.DataTransferObjects;
using Domain.Entities;
using Dtos.CarDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICarService
    {
        IEnumerable<Car> GetAllCars(bool trackChanges);
        Car GetOneCarById(int id, bool trackChanges);
        ResultCarWithPartsDto GetOneCarWithPartsById(int carId);

        Car CreateOneCar(CarDtoForInsertion carDto);
        void UpdateOneCar(int id, CarDtoForUpdate carDto, bool trackChanges);
        void DeleteOneCar(int id, bool trackChanges);
    }
}
