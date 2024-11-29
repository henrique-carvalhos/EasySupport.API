using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, ResultViewModel>
    {
        private readonly IDepartmentRepository _repository;
        public DeleteDepartmentCommandHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _repository.GetByIdAsync(request.Id);

            if(department is null)
            {
                return ResultViewModel.Error("Departamento não encontrado");
            }

            department.SetAsDeleted();
            await _repository.UpdateAsync(department);

            return ResultViewModel.Success();
        }
    }
}
