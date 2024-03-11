using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandler
{
    public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        private readonly ICarPricingRepository _repository;

        public GetCarPricingWithCarQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        async Task<List<GetCarPricingWithCarQueryResult>> IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>.Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var values=_repository.GetAllCarsWithPricings();
            return values.Select(x => new GetCarPricingWithCarQueryResult
            {
                CarPricingId = x.CarPricingId,
                Brand = x.Car.Brand.Name,
                Amount = x.Amount,
                Model = x.Car.Model,
                CoverImageUrl = x.Car.CoverImageUrl
            }).ToList();
        }
    }
}
