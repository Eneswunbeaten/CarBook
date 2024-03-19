using CarBook.Application.Features.Mediator.Queries;
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
    public class GetBlogWithAuthorAndCategoryQueryHandler : IRequestHandler<GetBlogWithAuthorAndCategoryQuery, List<GetBlogWithAuthorAndCategoryQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogWithAuthorAndCategoryQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetBlogWithAuthorAndCategoryQueryResult>> Handle(GetBlogWithAuthorAndCategoryQuery request, CancellationToken cancellationToken)
        {
            var values=_blogRepository.GetBlogsWithAuthorsAndCategories();
            return values.Select(x => new GetBlogWithAuthorAndCategoryQueryResult
            {
                BlogId = x.BlogId,
                AuthorId = x.Author.AuthorId,
                AuthorName = x.Author.Name,
                CategoryId = x.Category.CategoryId,
                CategoryName = x.Category.Name,
                Title = x.Title,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate
            }).ToList();
        }
    }
}
