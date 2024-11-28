using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, ResultViewModel<DepartmentViewModel>>
    {
        private readonly IDepartmentRepository _repository;
        public GetDepartmentByIdQueryHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<DepartmentViewModel>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _repository.GetByIdAsync(request.Id);

            if (department is null)
            {
                return ResultViewModel<DepartmentViewModel>.Error("Departamento não encontrado");
            }

            var model = DepartmentViewModel.FromEntity(department);

            return ResultViewModel<DepartmentViewModel>.Success(model);
        }
    }
}
