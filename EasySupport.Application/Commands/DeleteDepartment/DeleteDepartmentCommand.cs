using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommand : IRequest<ResultViewModel>
    {
        public DeleteDepartmentCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
