using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBook.Application.Features.Mediator.Results.TagCloudResults;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudsByBlogIdQueryHandler : IRequestHandler<GetTagCloudsByBlogIdQuery, List<GetTagCloudsByBlogIdQueryResult>>
    {
        private readonly ITagCloudRepository _repository;

        public GetTagCloudsByBlogIdQueryHandler(ITagCloudRepository repository)
        {
            _repository = repository;
        }

        async Task<List<GetTagCloudsByBlogIdQueryResult>> IRequestHandler<GetTagCloudsByBlogIdQuery, List<GetTagCloudsByBlogIdQueryResult>>.Handle(GetTagCloudsByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values =  _repository.GetTagCloudsByBlogId(request.Id);
            return values.Select(x => new GetTagCloudsByBlogIdQueryResult
            {
                BlogId = x.BlogId,
                TagCloudId = x.TagCloudId,
                Title = x.Title
            }).ToList();
        }
    }
}
