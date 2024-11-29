using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Queries.GetAllDepartment
{
    public class GetAllDepartmentQueryHandler : IRequestHandler<GetAllDepartmentQuery, ResultViewModel<List<DepartmentViewModel>>>
    {
        private readonly IDepartmentRepository _repository;
        public GetAllDepartmentQueryHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<DepartmentViewModel>>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            var departments = await _repository.GetAllAsync(request.Search);

            var model = departments.Select(DepartmentViewModel.FromEntity).ToList();

            return ResultViewModel<List<DepartmentViewModel>>.Success(model);
        }
    }
}
