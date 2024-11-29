using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, ResultViewModel>
    {
        private readonly IDepartmentRepository _repository;
        public UpdateDepartmentCommandHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _repository.GetByIdAsync(request.DepartmentId);

            if(department is null)
            {
                return ResultViewModel.Error("Departamento não encontrado");
            }

            department.Update(request.Name);
            await _repository.UpdateAsync(department);

            return ResultViewModel.Success();   
        }
    }
}
