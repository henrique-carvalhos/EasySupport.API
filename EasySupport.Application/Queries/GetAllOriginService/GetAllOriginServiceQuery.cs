using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Queries.GetAllOriginService
{
    public class GetAllOriginServiceQuery : IRequest<ResultViewModel<List<OriginServiceViewModel>>>
    {
        public GetAllOriginServiceQuery(string search)
        {
            Search = search;
        }

        public string Search { get; set; }
    }
}
