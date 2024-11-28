using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQuery : IRequest<ResultViewModel<DepartmentViewModel>>
    {
        public GetDepartmentByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
