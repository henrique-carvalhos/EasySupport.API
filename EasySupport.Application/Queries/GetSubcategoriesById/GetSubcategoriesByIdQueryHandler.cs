using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Queries.GetSubcategoriesById
{
    public class GetSubcategoriesByIdQueryHandler : IRequestHandler<GetSubcategoriesByIdQuery, ResultViewModel<SubcategoriesViewModel>>
    {
        private readonly ISubcategoriesRepository _repository;
        public GetSubcategoriesByIdQueryHandler(ISubcategoriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<SubcategoriesViewModel>> Handle(GetSubcategoriesByIdQuery request, CancellationToken cancellationToken)
        {
            var subcategory = await _repository.GetByIdAsync(request.Id);

            if(subcategory is null)
            {
                return ResultViewModel<SubcategoriesViewModel>.Error("Subcategoria não encontrado");
            }

            var model = SubcategoriesViewModel.FromEntity(subcategory);

            return ResultViewModel<SubcategoriesViewModel>.Success(model);
        }
    }
}
