using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
    {
        private readonly IRepository<Location> _repository;

        public UpdateLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        async Task IRequestHandler<UpdateLocationCommand>.Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.LocationId);
            value.Name = request.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
