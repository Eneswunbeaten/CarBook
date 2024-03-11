using CarBook.Application.Features.CQRS.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        async Task<List<GetFeatureQueryResult>> IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>.Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetAllAsync();
            return value.Select(x => new GetFeatureQueryResult
            {
                FeatureId = x.FeatureId,
                Name = x.Name
            }).ToList();
        }
    }
}
