using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<ResultViewModel>
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime AlteredAt { get; set; }
        public int EnterpriseId { get; set; }
        public int DepartmentId { get; set; }
    }
}
