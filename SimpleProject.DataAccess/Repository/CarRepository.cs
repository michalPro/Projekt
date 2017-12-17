using SimpleProject.Contract.DataContracts;
using SimpleProject.Contract.Repository;
using SimpleProject.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleProject.DataAccess.Repository
{
    public class CarRepository : ICarRepository
    {
        public void Add(CarDto model)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Car.Add(new Car
                {
                    Color = model.Color,
                    Name = model.Name,
                    Year = model.Year
                });

                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                Car car = context.Car.First(f => f.Id == id);

                context.Car.Remove(car);

                context.SaveChanges();
            }
        }

        public void Edit(CarDto model)
        {
            using (var context = new ApplicationDbContext())
            {
                Car car = context.Car.First(f => f.Id == model.Id);

                car.Name = model.Name;
                car.Year = model.Year;
                car.Color = model.Color;

                context.SaveChanges();
            }
        }

        public List<CarDto> GetAll()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Car
                    .AsNoTracking()
                    .Select(s => new CarDto
                    {
                        Id = s.Id,
                        Color = s.Color,
                        Name = s.Name,
                        Year = s.Year
                    })
                    .ToList();
            }
        }

        public CarDto GetById(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Car
                    .AsNoTracking()
                    .Where(w => w.Id == id)
                    .Select(s => new CarDto
                    {
                        Id = s.Id,
                        Color = s.Color,
                        Name = s.Name,
                        Year = s.Year
                    })
                    .First();
            }
        }
    }
}