using EasySupport.Application.Models;
using EasySupport.Core.Entities;
using MediatR;

namespace EasySupport.Application.Commands.InsertDepartment
{
    public class InsertDepartmentCommand : IRequest<ResultViewModel<int>>
    {
        public string Name { get; set; }

        public Department ToEntity()
            => new(Name);
    }
}
