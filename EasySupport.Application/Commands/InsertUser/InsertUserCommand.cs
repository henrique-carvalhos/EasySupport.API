using EasySupport.Application.Models;
using EasySupport.Core.Entities;
using MediatR;

namespace EasySupport.Application.Commands.InsertUser
{
    public class InsertUserCommand : IRequest<ResultViewModel<int>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public DateTime AlteredAt { get; set; }
        public int EnterpriseId { get; set; }
        public int DepartmentId { get; set; }

        //public User ToEntity()
        //   => new(Name, Email, Role, Password, AlteredAt, EnterpriseId, DepartmentId);
    }
}
