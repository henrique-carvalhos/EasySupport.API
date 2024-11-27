using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ResultViewModel>
    {
        private readonly ICategoryRepository _repository;
        public UpdateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.CategoryId);

            if(category is null)
            {
                return ResultViewModel.Error("Categoria não encontrada");
            }

            category.Update(request.Name);

            await _repository.UpdateAsync(category);

            return ResultViewModel.Success();
        }
    }
}
