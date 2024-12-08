using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Queries.GetAllUser
{
    public class GetAllUserQuery : IRequest<ResultViewModel<List<UserViewModel>>>
    {
        public GetAllUserQuery(string search)
        {
            Search = search;
        }

        public string Search { get; set; }
    }
}
