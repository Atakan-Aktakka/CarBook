using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
         private readonly IRepository<Blog> _repository;
        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BlogID);
            value.Title = request.Title;
            value.AuthorID = request.AuthorID;
            value.CoverImageUrl = request.CoverImageUrl;
            value.CreatedDate = request.CreatedDate;
            value.CategoryID = request.CategoryID;
            await _repository.UpdateAsync(value);
        }
    }
}