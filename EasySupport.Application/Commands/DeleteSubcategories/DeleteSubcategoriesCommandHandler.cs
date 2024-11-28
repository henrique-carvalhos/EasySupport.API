using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.DeleteSubcategories
{
    public class DeleteSubcategoriesCommandHandler : IRequestHandler<DeleteSubcategoriesCommand, ResultViewModel>
    {
        private readonly ISubcategoriesRepository _repository;
        public DeleteSubcategoriesCommandHandler(ISubcategoriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(DeleteSubcategoriesCommand request, CancellationToken cancellationToken)
        {
            var subcategory = await _repository.GetByIdAsync(request.Id);

            if(subcategory is null)
            {
                return ResultViewModel.Error("Subcategoria não encontrada");
            }

            subcategory.SetAsDeleted();
            await _repository.UpdateAsync(subcategory);

            return ResultViewModel.Success();
        }
    }
}
