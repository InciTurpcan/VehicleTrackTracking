using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        public CarRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneCar(Car car) => _context.Database.ExecuteSqlInterpolated($@"
        EXEC AddCar 
            @PlateNumber={car.PlateNumber}, 
            @Brand={car.Brand}, 
            @Model={car.Model},
            @Color={car.Color}");
        public void DeleteOneCar(Car car) => Delete(car);
        public IQueryable<Car> GetAllCars(bool trackChanges) => FindAll(trackChanges);
        public IQueryable<Car> GetAllCarsWithParts(bool trackChanges) => _context.Set<Car>()
                                                                         .Include(c => c.Parts)
                                                                           ;
        public Car GetOneCarById(int id, bool trackChanges) => FindByCondition(x => x.CarId.Equals(id), trackChanges).SingleOrDefault();

        public Car GetOneCarWithPartsById(int carId)
       => base._context.Set<Car>()
                .Include(x => x.Parts)
                    .ThenInclude(p => p.PartCategory) 
                .Where(x => x.CarId == carId)
                .Select(x => new Car
                {
                    CarId = x.CarId,
                    Brand = x.Brand,
                    Color = x.Color,
                    Model = x.Model,
                    PlateNumber=x.PlateNumber,
                    
                    Parts = x.Parts.Select(p => new Part
                    {
                        PartId = p.PartId,
                        Name = p.Name,
                        
                        PartCategory = new PartCategory
                        {
                            PartCategoryName = p.PartCategory.PartCategoryName 
                        }
                    }).ToList()
                })
                .SingleOrDefault();


        public void UpdateOneCar(Car car) => Update(car);



    }
}
