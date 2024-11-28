using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Queries.GetAllSubcategories
{
    public class GetAllSubcategoriesQueryHandler : IRequestHandler<GetAllSubcategoriesQuery, ResultViewModel<List<SubcategoriesViewModel>>>
    {
        private readonly ISubcategoriesRepository _repository;
        public GetAllSubcategoriesQueryHandler(ISubcategoriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<SubcategoriesViewModel>>> Handle(GetAllSubcategoriesQuery request, CancellationToken cancellationToken)
        {
            var subcategories = await _repository.GetAllAsync(request.Search);

            var model = subcategories.Select(SubcategoriesViewModel.FromEntity).ToList();

            return ResultViewModel<List<SubcategoriesViewModel>>.Success(model);
        }
    }
}
