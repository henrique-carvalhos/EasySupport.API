using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, ResultViewModel<CategoryViewModel>>
    {
        private readonly ICategoryRepository _repository;
        public GetCategoryByIdQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<CategoryViewModel>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);

            if(category is null)
            {
                return ResultViewModel<CategoryViewModel>.Error("Categoria não encontrada");
            }

            var model = CategoryViewModel.FromEntity(category);

            return ResultViewModel<CategoryViewModel>.Success(model);
        }
    }
}
