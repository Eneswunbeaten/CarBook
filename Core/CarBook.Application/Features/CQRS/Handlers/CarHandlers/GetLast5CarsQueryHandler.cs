using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarsQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetLast5CarsQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public List<GetLast5CarsQueryResult> Handle()
        {
               var values = _repository.GetLast5CarsWithBrands();
            return values.Select(x => new GetLast5CarsQueryResult
            {
                CarId = x.CarId,
                BrandId = x.BrandId,
                BrandName = x.Brand.Name,
                Model = x.Model,
                CoverImageUrl = x.CoverImageUrl,
                Km = x.Km,
                Transmission = x.Transmission,
                Seat = x.Seat,
                Luggage = x.Luggage,
                Fuel = x.Fuel,
                BigImageUrl = x.BigImageUrl
            }).ToList();
        }
    }
}
