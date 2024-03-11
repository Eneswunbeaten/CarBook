using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogWithAuthorQueryHandler : IRequestHandler<GetBlogsWithAuthorsQuery, List<GetBlogWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetBlogWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        async Task<List<GetBlogWithAuthorQueryResult>> IRequestHandler<GetBlogsWithAuthorsQuery, List<GetBlogWithAuthorQueryResult>>.Handle(GetBlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values=_repository.GetBlogsWithAuthors();
            return values.Select(x => new GetBlogWithAuthorQueryResult
            {
                BlogId = x.BlogId,
                Title = x.Title,
                CreatedDate = x.CreatedDate,
                CoverImageUrl = x.CoverImageUrl,
                CategoryId=x.CategoryId,
                AuthorId=x.Author.AuthorId,
                AuthorName = x.Author.Name,
                Description=x.Description,
                AuthorDescription=x.Author.Description,
                AuthorImage=x.Author.ImageUrl
            }).ToList();
        }
    }
}
