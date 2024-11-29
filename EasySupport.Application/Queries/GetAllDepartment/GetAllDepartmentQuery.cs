using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Queries.GetAllDepartment
{
    public class GetAllDepartmentQuery : IRequest<ResultViewModel<List<DepartmentViewModel>>>
    {
        public GetAllDepartmentQuery(string search)
        {
            Search = search;
        }

        public string Search { get; set; }
    }
}
