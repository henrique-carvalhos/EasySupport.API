using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _repository;
        public UpdateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.UserId);

            if(user is null)
            {
                return ResultViewModel.Error("Usuário não encontrado");
            }

            user.Update(request.Name, request.Email, request.Role, request.AlteredAt, request.EnterpriseId, request.DepartmentId);
            await _repository.UpdateAsync(user);

            return ResultViewModel.Success();
        }
    }
}
