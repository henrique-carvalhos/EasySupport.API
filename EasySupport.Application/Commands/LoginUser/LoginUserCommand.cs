using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<ResultViewModel<LoginUserViewModel>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
