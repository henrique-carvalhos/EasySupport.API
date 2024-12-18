using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using EasySupport.Core.Services;
using MediatR;

namespace EasySupport.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ResultViewModel<LoginUserViewModel>>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _repository;
        public LoginUserCommandHandler(IAuthService authService, IUserRepository repository)
        {
            _authService = authService;
            _repository = repository;
        }

        public async Task<ResultViewModel<LoginUserViewModel>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = await _repository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            if (user is null)
            {
                return ResultViewModel<LoginUserViewModel>.Error("");
            }

            var token = _authService.GenereteJwtToken(user.Email, user.Role);

            var loginUserViewModel = new LoginUserViewModel(user.Email, token);

            return ResultViewModel<LoginUserViewModel>.Success(loginUserViewModel);
        }
    }
}
