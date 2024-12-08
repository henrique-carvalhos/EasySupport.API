using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _repository;
        public DeleteUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);

            if(user is null)
            {
                return ResultViewModel.Error("Usuário não encontrado");
            }

            user.SetAsDeleted();
            await _repository.UpdateAsync(user);

            return ResultViewModel.Success();
        }
    }
}
