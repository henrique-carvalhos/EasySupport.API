using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.UpdateSubcategories
{
    public class UpdateSubcategoriesCommandHandler : IRequestHandler<UpdateSubcategoriesCommand, ResultViewModel>
    {
        private readonly ISubcategoriesRepository _repository;
        public UpdateSubcategoriesCommandHandler(ISubcategoriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateSubcategoriesCommand request, CancellationToken cancellationToken)
        {
            var subcategory = await _repository.GetByIdAsync(request.SubcategoryId);

            if(subcategory is null)
            {
                return ResultViewModel.Error("Subcategoria não encontrada");
            }

            subcategory.Update(request.Name, request.CategoryId);
            await _repository.UpdateAsync(subcategory);

            return ResultViewModel.Success();
        }
    }
}
