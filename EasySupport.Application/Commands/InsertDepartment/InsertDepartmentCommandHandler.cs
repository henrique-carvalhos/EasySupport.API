using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.InsertDepartment
{
    public class InsertDepartmentCommandHandler : IRequestHandler<InsertDepartmentCommand, ResultViewModel<int>>
    {
        private readonly IDepartmentRepository _repository;
        public InsertDepartmentCommandHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = request.ToEntity();

            await _repository.AddAsync(department);

            return ResultViewModel<int>.Success(department.Id);
        }
    }
}
