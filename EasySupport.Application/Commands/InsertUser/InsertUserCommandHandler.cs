using EasySupport.Application.Models;
using EasySupport.Core.Entities;
using EasySupport.Core.Repositories;
using EasySupport.Core.Services;
using MediatR;

namespace EasySupport.Application.Commands.InsertUser
{
    public class InsertUserCommandHandler : IRequestHandler<InsertUserCommand, ResultViewModel<int>>
    {
        private readonly IUserRepository _repository;
        private readonly IAuthService _authService;
        public InsertUserCommandHandler(IUserRepository repository, IAuthService authService)
        {
            _repository = repository;
            _authService = authService;
        }

        public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new User(
                    request.Name,
                    request.Email,
                    request.Role,
                    passwordHash,
                    request.AlteredAt,
                    request.EnterpriseId,
                    request.DepartmentId);

            await _repository.AddAsync(user);

            return ResultViewModel<int>.Success(user.Id);
        }
    }
}
