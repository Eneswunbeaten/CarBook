using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository:ICarRepository
    {
        private readonly CarbookContext _context;

        public CarRepository(CarbookContext context)
        {
            _context = context;
        }

        List<Car> ICarRepository.GetAllCarsWithBrands()
        {
            var values = _context.Cars
                .Include(x => x.Brand)
                .ToList();
            return values;
        }

        List<Car> ICarRepository.GetLast5CarsWithBrands()
        {
            var values = _context.Cars
                .Include(x => x.Brand)
                .OrderByDescending(x => x.CarId)
                .Take(5)
                .ToList();
            return values;
        }
    }
}
