﻿using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public CreateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        async Task IRequestHandler<CreateBlogCommand>.Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Blog
            {
                Title = request.Title,
                CoverImageUrl = request.CoverImageUrl,
                AuthorId = request.AuthorId,
                CategoryId = request.CategoryId,
                CreatedDate = request.CreatedDate
            });
        }
    }
}
