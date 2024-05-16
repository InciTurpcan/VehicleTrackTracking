using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ICarRepository : IRepositoryBase<Car>
    {
        IQueryable<Car> GetAllCars(bool trackChanges);
        Car GetOneCarById(int id, bool trackChanges);
        Car GetOneCarWithPartsById(int carId);
       
        void CreateOneCar(Car car);
        void UpdateOneCar(Car car);
        void DeleteOneCar(Car car);
    }
}
