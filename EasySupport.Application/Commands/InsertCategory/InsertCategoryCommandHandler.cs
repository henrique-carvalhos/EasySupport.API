using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.InsertCategory
{
    public class InsertCategoryCommandHandler : IRequestHandler<InsertCategoryCommand, ResultViewModel<int>>
    {
        private readonly ICategoryRepository _repository;
        public InsertCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = request.ToEntity();

            await _repository.AddAsync(category);

            return ResultViewModel<int>.Success(category.Id);
        }
    }
}
