using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommand : IRequest<ResultViewModel>
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
    }
}
